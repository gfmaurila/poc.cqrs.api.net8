using poc.core.api.net8;

namespace Poc.Contract.Command.User.Response;

public class CreateUserResponse : BaseResponse
{
    public CreateUserResponse(Guid id) => Id = id;

    public Guid Id { get; }
}
