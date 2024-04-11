namespace Poc.Domain.Entities.HR.Region.Events;

public class RegionCreatedEvent : RegionBaseEvent
{
    public RegionCreatedEvent(decimal regionId, string regionName) : base(regionId, regionName)
    {
    }
}
