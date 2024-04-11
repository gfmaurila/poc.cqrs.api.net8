using Poc.Contract.Command.Core.EventCore.ViewModels;

namespace Poc.Contract.Command.Core.EventCore.Interfaces;

public interface IEventCoreCommandStore
{
    Task Create(IEnumerable<EventCoreModel> entity);
}
