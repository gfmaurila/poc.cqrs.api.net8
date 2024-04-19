using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using poc.core.api.net8;
using poc.core.api.net8.Abstractions;
using poc.core.api.net8.Events;
using poc.core.api.net8.Extensions;
using Poc.Contract.Command.EventCore.Interfaces;
using Poc.Contract.Command.EventCore.ViewModels;
using Poc.SQLServer.Context;
using System.Data;

namespace Poc.SQLServer;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFSqlServerContext _writeDbContext;
    private readonly IEventCoreCommandStore _eventCoreRepository;
    private readonly IMediator _mediator;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(
        EFSqlServerContext writeDbContext,
        IEventCoreCommandStore eventCoreRepository,
        IMediator mediator,
        ILogger<UnitOfWork> logger)
    {
        _writeDbContext = writeDbContext;
        _eventCoreRepository = eventCoreRepository;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task SaveChangesAsync()
    {
        // Criando a estratégia de execução (Connection resiliency and database retries).
        var strategy = _writeDbContext.Database.CreateExecutionStrategy();

        // Executando a estratégia.
        await strategy.ExecuteAsync(async () =>
        {
            using var transaction
                = await _writeDbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            _logger.LogInformation("----- Begin transaction: '{TransactionId}'", transaction.TransactionId);

            try
            {
                // Obtendo os eventos e stores das entidades rastreadas no contexto do EF Core.
                var (domainEvents, eventCores) = BeforeSaveChanges();

                var rowsAffected = await _writeDbContext.SaveChangesAsync();

                _logger.LogInformation("----- Commit transaction: '{TransactionId}'", transaction.TransactionId);

                await transaction.CommitAsync();

                // Disparando os eventos e salvando os stores.
                await AfterSaveChangesAsync(domainEvents, eventCores);

                _logger.LogInformation(
                    "----- Transaction successfully confirmed: '{TransactionId}', Rows Affected: {RowsAffected}",
                    transaction.TransactionId, rowsAffected);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An unexpected exception occurred while committing the transaction: '{TransactionId}', message: {Message}",
                    transaction.TransactionId, ex.Message);

                await transaction.RollbackAsync();

                throw;
            }
        });
    }

    private (IEnumerable<Event> domainEvents, IEnumerable<EventCoreModel> eventCores) BeforeSaveChanges()
    {
        var domainEntities = _writeDbContext
            .ChangeTracker
            .Entries<BaseEntity>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = new List<Event>();
        var eventCores = new List<EventCoreModel>();

        if (domainEntities.Any())
        {
            domainEvents = domainEntities
                .SelectMany(entry => entry.Entity.DomainEvents)
                .ToList();

            foreach (var @event in domainEvents)
            {
                var aggregateId = @event.AggregateId;
                var messageType = @event.GetGenericTypeName();
                var data = @event.ToJson();
                eventCores.Add(new EventCoreModel(aggregateId, messageType, data));
            }

            // Limpando os eventos das entidades.
            domainEntities
                .ForEach(entry => entry.Entity.ClearDomainEvents());
        }

        return (domainEvents, eventCores);
    }

    private async Task AfterSaveChangesAsync(IEnumerable<Event> domainEvents, IEnumerable<EventCoreModel> eventCores)
    {
        if (domainEvents.Any() && eventCores.Any())
        {
            // Agrupando todos os eventos em uma lista de Task's.
            var tasks = domainEvents
                .Select((@event) => _mediator.Publish(@event));

            // Disparando as notificações.
            await Task.WhenAll(tasks);

            // Salvando os eventos.
            await _eventCoreRepository.Create(eventCores);
        }
    }

    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    // Public implementation of Dispose pattern callable by consumers.
    ~UnitOfWork()
        => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (disposing)
        {
            _writeDbContext.Dispose();
            //_eventCoreRepository.Dispose();
        }

        _disposed = true;
    }

    #endregion
}
