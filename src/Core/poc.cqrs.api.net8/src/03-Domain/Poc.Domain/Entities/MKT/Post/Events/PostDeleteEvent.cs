namespace Poc.Domain.Entities.MKT.Post.Events;

public class PostDeleteEvent : PostBaseEven
{
    public PostDeleteEvent(Guid id, string title, string content) : base(id, title, content)
    {

    }
}
