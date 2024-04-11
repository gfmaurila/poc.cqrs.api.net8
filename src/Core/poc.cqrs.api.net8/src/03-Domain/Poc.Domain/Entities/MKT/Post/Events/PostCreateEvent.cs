namespace Poc.Domain.Entities.MKT.Post.Events;

public class PostCreateEvent : PostBaseEven
{
    public PostCreateEvent(Guid id, string title, string content) : base(id, title, content)
    {

    }
}
