using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using MediatR;
using poc.core.api.net8.Extensions;
using poc.core.api.net8.Interface;
using Poc.Contract.Command.Auth.Request;
using Poc.Contract.Command.Auth.Response;
using Poc.Contract.Command.Auth.Validators;
using Poc.Contract.Query.User.EF.Interface;
using Poc.Domain.Entities.User;

namespace Poc.Command.Auth;

public class AuthCommandHandler : IRequestHandler<AuthCommand, Result<AuthTokenResponse>>
{
    private readonly IAuthService _authService;
    private readonly IUserReadOnlyRepository _repo;
    private readonly IMediator _mediator;
    private readonly AuthCommandValidator _validator;
    private readonly IMapper _mapper;

    public AuthCommandHandler(IAuthService authService,
                              IUserReadOnlyRepository repo,
                              IMediator mediator,
                              AuthCommandValidator validator,
                              IMapper mapper)
    {
        _authService = authService;
        _repo = repo;
        _mediator = mediator;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<Result<AuthTokenResponse>> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var auth = await _repo.GetAuthByEmailPassword(request.Email, Password.ComputeSha256Hash(request.Password));

        //Se não existir, erro no login
        if (auth is null)
            return Result.Error("Usuário ou senha inválidos.");

        var token = _authService.GenerateJwtToken(auth.Id.ToString(), auth.Email, auth.RoleUserAuth);

        var entity = _mapper.Map<UserEntity>(auth);

        entity.AuthEvent(auth.Id.ToString(), auth.LastName, auth.Email, token);

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.Success(new AuthTokenResponse(token), "Sucesso!");
    }
}
