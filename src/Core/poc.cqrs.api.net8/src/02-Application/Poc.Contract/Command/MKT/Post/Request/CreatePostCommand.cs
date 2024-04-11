using Ardalis.Result;
using MediatR;
using Poc.Contract.Command.MKT.Post.Response;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.MKT.Post.Request;

public class CreatePostCommand : IRequest<Result<CreatePostResponse>>
{
    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Title { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Content { get; set; }
}
