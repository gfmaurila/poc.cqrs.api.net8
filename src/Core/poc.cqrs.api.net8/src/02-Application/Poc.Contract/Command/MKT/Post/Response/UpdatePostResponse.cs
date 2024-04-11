using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.MKT.Post.Response;

public class UpdatePostResponse : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Title { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Content { get; set; }
}
