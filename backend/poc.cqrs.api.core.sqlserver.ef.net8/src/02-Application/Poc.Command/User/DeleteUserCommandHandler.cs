using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.User.Interfaces;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Command.User.Validators;

namespace Poc.Command.User;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly DeleteUserCommandValidator _validator;
    private readonly IUserWriteOnlyRepository _repo;
    private readonly ILogger<DeleteUserCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger,
                                    IUserWriteOnlyRepository repo,
                                    IUnitOfWork unitOfWork,
                                    DeleteUserCommandValidator validator,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        entity.Delete();

        await _repo.Remove(entity);

        await _unitOfWork.SaveChangesAsync();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.SuccessWithMessage("Removido com sucesso!");
    }
}

