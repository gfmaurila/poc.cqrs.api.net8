using Ardalis.Result;
using MediatR;
using Poc.Contract.Command.HR.Region.Response;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.HR.Region.Request;

public class CreateRegionCommand : IRequest<Result<CreateRegionResponse>>
{
    [Required]
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public string RegionName { get; set; }
}
