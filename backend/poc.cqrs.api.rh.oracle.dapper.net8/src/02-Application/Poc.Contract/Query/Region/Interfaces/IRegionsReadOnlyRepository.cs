using poc.core.api.net8.Filter.QueryStore.Response;
using Poc.Contract.Query.Region.ViewModels;

namespace Poc.Contract.Query.Region.Interfaces;

public interface IRegionsReadOnlyRepository
{
    Task<RegionQueryModel> Get(decimal id);
    Task<List<RegionQueryModel>> Get();
    Task<PaginationResponse<RegionQueryModel>> Get(uint page, uint itemsPerPage, string name);
}
