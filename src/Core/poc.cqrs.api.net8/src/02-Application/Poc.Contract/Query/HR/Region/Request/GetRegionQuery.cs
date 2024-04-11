using Ardalis.Result;
using MediatR;
using Poc.Contract.Query.HR.Region.ViewModels;

namespace Poc.Contract.Query.HR.Region.Request;

public class GetRegionQuery : IRequest<Result<List<RegionQueryModel>>>
{
    public GetRegionQuery()
    {
    }
}