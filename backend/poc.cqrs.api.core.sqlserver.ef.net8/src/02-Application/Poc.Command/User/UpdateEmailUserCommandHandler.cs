using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Abstractions;
using poc.core.api.net8.ValueObjects;
using Poc.Contract.Command.User.Interfaces;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Command.User.Validators;

namespace Poc.Command.User;

public class UpdateEmailUserCommandHandler : IRequestHandler<UpdateEmailUserCommand, Result>
{
    private readonly UpdateEmailUserCommandValidator _validator;
    private readonly IUserWriteOnlyRepository _repo;
    private readonly ILogger<UpdateEmailUserCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public UpdateEmailUserCommandHandler(ILogger<UpdateEmailUserCommandHandler> logger,
                                    IUserWriteOnlyRepository repo,
                                    IUnitOfWork unitOfWork,
                                    UpdateEmailUserCommandValidator validator,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mediator = mediator;
    }

    public IUnitOfWork UnitOfWork => _unitOfWork;

    public async Task<Result> Handle(UpdateEmailUserCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        // Instanciando o VO Email.
        var newEmail = new Email(request.Email);

        // Verificiando se já existe um cliente com o endereço de e-mail.
        if (await _repo.ExistsByEmailAsync(newEmail, entity.Id))
            return Result.Error("O endereço de e-mail informado já está sendo utilizado.");

        entity.ChangeEmail(newEmail);

        await _repo.Update(entity);

        await _unitOfWork.SaveChangesAsync();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.SuccessWithMessage("Atualizado com sucesso!");
    }
}
