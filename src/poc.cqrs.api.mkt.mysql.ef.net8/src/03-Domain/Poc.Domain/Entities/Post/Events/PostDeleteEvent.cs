namespace Poc.Domain.Entities.Post.Events;

public class PostDeleteEvent : PostBaseEven
{
    public PostDeleteEvent(Guid id, string title, string content) : base(id, title, content)
    {

    }
}
