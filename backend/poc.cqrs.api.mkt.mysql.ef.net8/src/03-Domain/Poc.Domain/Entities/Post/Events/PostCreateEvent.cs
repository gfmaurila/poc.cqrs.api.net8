namespace Poc.Domain.Entities.Post.Events;

public class PostCreateEvent : PostBaseEven
{
    public PostCreateEvent(Guid id, string title, string content) : base(id, title, content)
    {

    }
}
