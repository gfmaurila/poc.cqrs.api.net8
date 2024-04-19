using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Poc.Contract.Command.Auth.Interfaces;
using Poc.Contract.Command.Auth.Request;
using Poc.Contract.Command.Auth.Validators;
using Poc.Contract.Command.User.Request;

namespace Poc.Command.Auth;

public class AuthNewPasswordCommandHandler : IRequestHandler<AuthNewPasswordCommand, Result>
{
    private readonly IAuthResetCommandStore _repo;
    private readonly IMediator _mediator;
    private readonly AuthNewPasswordCommandValidator _validator;

    public AuthNewPasswordCommandHandler(IAuthResetCommandStore repo,
                                         IMediator mediator,
                                         AuthNewPasswordCommandValidator validator)
    {
        _repo = repo;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<Result> Handle(AuthNewPasswordCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var getToken = await _repo.GetAuthByToken(request.Token);
        if (getToken == null)
            return Result.NotFound($"Nenhum registro encontrado");

        await _mediator.Send(new UpdatePasswordUserCommand()
        {
            Id = Guid.Parse(getToken.AuthId),
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
        });

        await _repo.Delete(getToken.Id);

        return Result.SuccessWithMessage($"Senha alterada com sucesso!");
    }
}
