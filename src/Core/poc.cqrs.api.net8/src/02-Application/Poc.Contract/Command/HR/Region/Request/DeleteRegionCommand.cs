using Ardalis.Result;
using MediatR;

namespace Poc.Contract.Command.HR.Region.Request;

public class DeleteRegionCommand : IRequest<Result>
{
    public DeleteRegionCommand(decimal regionId) => RegionId = regionId;

    public decimal RegionId { get; private set; }
}
