namespace Poc.Core.Interface;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
