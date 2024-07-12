using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using poc.core.api.net8.Interface;
using Poc.Contract.Query.Post.Interface;
using Poc.Contract.Query.Post.QueriesModel;
using Poc.Contract.Query.Post.Request;
using Poc.Contract.Query.Post.Validators;

namespace Poc.Query.Post;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<PostQueryModel>>
{
    private readonly IPostReadOnlyRepository _repo;
    private readonly IRedisCacheService<PostQueryModel> _cacheService;
    private readonly GetPostByIdQueryValidator _validator;
    public GetPostByIdQueryHandler(IPostReadOnlyRepository repo,
                                   IRedisCacheService<PostQueryModel> cacheService,
                                   GetPostByIdQueryValidator validator)
    {
        _repo = repo;
        _cacheService = cacheService;
        _validator = validator;
    }

    public async Task<Result<PostQueryModel>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var cacheKey = $"{nameof(GetPostByIdQuery)}_{request.Id}";

        var model = await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.Get(request.Id), TimeSpan.FromHours(2));
        if (model == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        return Result.Success(model);
    }

}
