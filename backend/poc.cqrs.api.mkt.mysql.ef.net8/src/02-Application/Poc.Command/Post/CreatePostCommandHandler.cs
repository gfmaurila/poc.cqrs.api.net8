using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.Post.Interfaces;
using Poc.Contract.Command.Post.Request;
using Poc.Contract.Command.Post.Response;
using Poc.Contract.Command.Post.Validators;
using Poc.Domain.Entities.Post;

namespace Poc.Command.Post;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<CreatePostResponse>>
{
    private readonly CreatePostCommandValidator _validator;
    private readonly IPostWriteOnlyRepository _repo;
    private readonly ILogger<CreatePostCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger,
                                    IPostWriteOnlyRepository repo,
                                    IUnitOfWork unitOfWork,
                                    IMediator mediator,
                                    CreatePostCommandValidator validator)
    {
        _repo = repo;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<Result<CreatePostResponse>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        if (await _repo.ExistsByTitleAsync(request.Title))
            return Result.Error("Registro duplicado.");

        var entity = new PostEntity(request.Title, request.Content);

        await _repo.Create(entity);

        await _unitOfWork.SaveChangesAsync();

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return Result.Success(new CreatePostResponse(entity.Id), "Cadastrado com sucesso!");
    }
}
