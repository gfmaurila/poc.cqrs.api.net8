namespace Poc.Contract.Command.HR.Region.Response;

public class CreateRegionResponse
{
    public CreateRegionResponse(decimal id) => RegionId = id;

    public decimal RegionId { get; }
}
