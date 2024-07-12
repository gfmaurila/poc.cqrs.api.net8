using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Abstractions;
using poc.core.api.net8.Extensions;
using poc.core.api.net8.ValueObjects;
using Poc.Contract.Command.User.Interfaces;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Command.User.Response;
using Poc.Contract.Command.User.Validators;
using Poc.Domain.Entities.User;

namespace Poc.Command.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    private readonly CreateUserCommandValidator _validator;
    private readonly IUserWriteOnlyRepository _repo;
    private readonly ILogger<CreateUserCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
                                    IUserWriteOnlyRepository repo,
                                    IUnitOfWork unitOfWork,
                                    IMediator mediator,
                                    CreateUserCommandValidator validator)
    {
        _repo = repo;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var email = new Email(request.Email);
        var phone = new PhoneNumber(request.Phone);

        if (await _repo.ExistsByEmailAsync(email))
            return Result.Error("O endereço de e-mail informado já está sendo utilizado.");

        var entity = new UserEntity(request.FirstName,
            request.LastName,
            request.Gender,
            request.Notification,
            email,
            phone,
            Password.ComputeSha256Hash(request.Password),
            request.RoleUserAuth,
            request.DateOfBirth);

        await _repo.Create(entity);

        await _unitOfWork.SaveChangesAsync();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.Success(new CreateUserResponse(entity.Id), "Cadastrado com sucesso!");
    }
}
