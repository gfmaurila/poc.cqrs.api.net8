namespace Poc.Domain.Entities.HR.Region.Events;

public class RegionUpdateEvent : RegionBaseEvent
{
    public RegionUpdateEvent(decimal regionId, string regionName) : base(regionId, regionName)
    {
    }
}
