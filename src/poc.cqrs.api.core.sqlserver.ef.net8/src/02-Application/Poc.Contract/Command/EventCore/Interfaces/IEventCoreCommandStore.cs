using Poc.Contract.Command.EventCore.ViewModels;

namespace Poc.Contract.Command.EventCore.Interfaces;

public interface IEventCoreCommandStore
{
    Task Create(IEnumerable<EventCoreModel> entity);
}
