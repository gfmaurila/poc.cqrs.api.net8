namespace poc.core.api.net8.Interface;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
