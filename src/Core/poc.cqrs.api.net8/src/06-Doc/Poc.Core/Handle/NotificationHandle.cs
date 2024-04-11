using Poc.Core.Interface;

namespace Poc.Core.Handle;

public class NotificationHandle : INotificationHandle
{
    private List<Poc.Core.Model.Notification> _notification;

    public NotificationHandle()
    {
        _notification = new List<Poc.Core.Model.Notification>();
    }

    public void Handle(Poc.Core.Model.Notification notification)
    {
        _notification.Add(notification);
    }

    public List<Poc.Core.Model.Notification> GetNotification()
    {
        return _notification;
    }

    public bool IsNotification()
    {
        return _notification.Any();
    }
}
