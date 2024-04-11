using poc.core.api.net8.Events;

namespace Poc.Domain.Entities.MKT.Post.Events;
public abstract class PostBaseEven : Event
{
    protected PostBaseEven(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
}

