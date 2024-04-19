using Poc.Contract.Command.EventCore.ViewModels;

namespace Poc.Contract.Command.EventCore.Interfaces;

public interface IEventMKTCommandStore
{
    Task Create(IEnumerable<EventMKTModel> entity);
}
