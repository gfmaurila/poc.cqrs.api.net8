namespace Poc.Domain.Entities.Post.Events;

public class PostUpdateEvent : PostBaseEven
{
    public PostUpdateEvent(Guid id, string title, string content) : base(id, title, content)
    {

    }
}
