using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.MKT.Post.Interfaces;
using Poc.Contract.Command.MKT.Post.Request;
using Poc.Contract.Command.MKT.Post.Validators;

namespace Poc.Command.MKT.Post;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result>
{
    private readonly UpdatePostCommandValidator _validator;
    private readonly IPostWriteOnlyRepository _repo;
    private readonly ILogger<UpdatePostCommandHandler> _logger;
    private readonly IMySQLUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public UpdatePostCommandHandler(ILogger<UpdatePostCommandHandler> logger,
                                    IPostWriteOnlyRepository repo,
                                    IMySQLUnitOfWork unitOfWork,
                                    UpdatePostCommandValidator validator,
                                    IMapper mapper,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mapper = mapper;
        _mediator = mediator;
    }
    public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        entity.Update(request.Title, request.Content);

        await _repo.Update(entity);

        await _unitOfWork.SaveChangesAsync();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.SuccessWithMessage("Atualizado com sucesso!");
    }
}
