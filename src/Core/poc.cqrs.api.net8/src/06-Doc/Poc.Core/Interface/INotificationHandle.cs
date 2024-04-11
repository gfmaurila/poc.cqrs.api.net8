namespace Poc.Core.Interface;

public interface INotificationHandle
{
    bool IsNotification();
    List<Poc.Core.Model.Notification> GetNotification();
    void Handle(Poc.Core.Model.Notification notification);
}
