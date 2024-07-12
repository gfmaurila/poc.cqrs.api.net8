using Poc.Contract.Command.Events.ViewModels;

namespace Poc.Contract.Command.Events.Interfaces;

public interface IEventMKTCommandStore
{
    Task Create(IEnumerable<EventMKTModel> entity);
}
