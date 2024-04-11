using Poc.Contract.Command.Core.EventCore.ViewModels;

namespace Poc.Contract.Command.Core.EventCore.Interfaces;

public interface IEventMKTCommandStore
{
    Task Create(IEnumerable<EventMKTModel> entity);
}
