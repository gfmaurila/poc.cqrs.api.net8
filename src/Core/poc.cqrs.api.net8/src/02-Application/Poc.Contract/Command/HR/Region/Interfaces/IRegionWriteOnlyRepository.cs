using Poc.Contract.Query.HR.Region.ViewModels;
using Poc.Domain.Entities.HR.Region;

namespace Poc.Contract.Command.HR.Region.Interfaces;

public interface IRegionWriteOnlyRepository
{
    Task<RegionQueryModel> Create(RegionEntity region);
    Task<bool> Update(RegionEntity region);
    Task<bool> Delete(decimal regionId);
    Task<RegionEntity> Get(decimal id);
}
