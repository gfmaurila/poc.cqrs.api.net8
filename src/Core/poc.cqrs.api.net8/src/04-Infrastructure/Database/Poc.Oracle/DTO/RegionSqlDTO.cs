using Poc.Domain.Entities.HR.Region;

namespace Poc.Oracle.DTO;

public class RegionSqlDTO
{
    public decimal RegionId { get; set; }
    public string RegionName { get; set; }

    public RegionEntity MapToResult()
    {
        return new RegionEntity(RegionId, RegionName);
    }
}
