using poc.core.api.net8;
using poc.core.api.net8.api.net8.api.net8.Abstractions;
using Poc.Domain.Entities.MKT.Post.Events;

namespace Poc.Domain.Entities.MKT.Post;

public class PostEntity : BaseEntity, IAggregateRoot
{
    public PostEntity() { }

    public PostEntity(string title, string content)
    {
        Title = title;
        Content = content;
        AddDomainEvent(new PostCreateEvent(Id, Title, Content));
    }

    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
        AddDomainEvent(new PostUpdateEvent(Id, Title, Content));
    }

    public void Delete()
        => AddDomainEvent(new PostDeleteEvent(Id, Title, Content));


    public string Title { get; private set; }
    public string Content { get; private set; }
}
