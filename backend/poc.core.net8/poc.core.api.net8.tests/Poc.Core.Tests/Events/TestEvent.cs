using poc.core.api.net8.Events;

namespace poc.core.api.net8.tests.Events;

public class TestEvent : Event
{
    public TestEvent(string messageType, Guid aggregateId)
    {
        MessageType = messageType;
        AggregateId = aggregateId;
    }
}
