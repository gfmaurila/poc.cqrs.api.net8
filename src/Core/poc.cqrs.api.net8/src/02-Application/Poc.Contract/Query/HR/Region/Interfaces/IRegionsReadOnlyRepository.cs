using Poc.Contract.Query.HR.Region.ViewModels;

namespace Poc.Contract.Query.HR.Region.Interfaces;

public interface IRegionsReadOnlyRepository
{
    Task<RegionQueryModel> Get(decimal id);
    Task<List<RegionQueryModel>> Get();
}
