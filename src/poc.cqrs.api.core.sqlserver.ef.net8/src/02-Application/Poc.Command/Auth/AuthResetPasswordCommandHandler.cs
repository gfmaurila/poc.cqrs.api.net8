using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using MediatR;
using poc.core.api.net8.Interface;
using Poc.Contract.Command.Auth.Request;
using Poc.Contract.Command.Auth.Validators;
using Poc.Contract.Query.User.EF.Interface;
using Poc.Domain.Entities.User;

namespace Poc.Command.Auth;

public class AuthResetPasswordCommandHandler : IRequestHandler<AuthResetPasswordCommand, Result>
{
    private readonly IAuthService _authService;
    private readonly IUserReadOnlyRepository _repo;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly AuthResetPasswordCommandValidator _validator;

    public AuthResetPasswordCommandHandler(IAuthService authService,
                                           IUserReadOnlyRepository repo,
                                           IMediator mediator,
                                           IMapper mapper,
                                           AuthResetPasswordCommandValidator validator)
    {
        _authService = authService;
        _repo = repo;
        _mediator = mediator;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(AuthResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        // Busca os dados do usuarios 
        var auth = await _repo.GetByEmailAsync(request.Email);

        //Se não existir, erro no login
        if (auth is null)
            return Result.Error("E-mail inválidos.");

        var entity = _mapper.Map<UserEntity>(auth);

        entity.AuthResetEvent();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.SuccessWithMessage($"Uma mensagem foi enviada para o seu e-mail ou celular!");
    }


}
