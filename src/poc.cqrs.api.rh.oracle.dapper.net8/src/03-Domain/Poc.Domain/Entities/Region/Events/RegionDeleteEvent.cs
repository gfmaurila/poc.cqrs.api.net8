namespace Poc.Domain.Entities.Region.Events;

public class RegionDeleteEvent : RegionBaseEvent
{
    public RegionDeleteEvent(decimal regionId, string regionName) : base(regionId, regionName)
    {
    }
}
