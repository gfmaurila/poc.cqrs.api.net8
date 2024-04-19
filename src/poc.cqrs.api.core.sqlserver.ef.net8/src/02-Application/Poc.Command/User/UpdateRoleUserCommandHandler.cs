using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.User.Interfaces;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Command.User.Validators;

namespace Poc.Command.User;

public class UpdateRoleUserCommandHandler : IRequestHandler<UpdateRoleUserCommand, Result>
{
    private readonly UpdateRoleUserCommandValidator _validator;
    private readonly IUserWriteOnlyRepository _repo;
    private readonly ILogger<UpdateRoleUserCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public UpdateRoleUserCommandHandler(ILogger<UpdateRoleUserCommandHandler> logger,
                                    IUserWriteOnlyRepository repo,
                                    IUnitOfWork unitOfWork,
                                    UpdateRoleUserCommandValidator validator,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<Result> Handle(UpdateRoleUserCommand request, CancellationToken cancellationToken)
    {
        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        entity.UpdateRole(request.RoleUserAuth);

        await _repo.Update(entity);

        await _unitOfWork.SaveChangesAsync();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.SuccessWithMessage("Atualizado com sucesso!");
    }
}
