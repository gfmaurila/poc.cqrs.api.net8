using poc.core.api.net8.Interface;

namespace poc.core.api.net8.Handle;

public class NotificationHandle : INotificationHandle
{
    private List<poc.core.api.net8.Model.Notification> _notification;

    public NotificationHandle()
    {
        _notification = new List<poc.core.api.net8.Model.Notification>();
    }

    public void Handle(poc.core.api.net8.Model.Notification notification)
    {
        _notification.Add(notification);
    }

    public List<poc.core.api.net8.Model.Notification> GetNotification()
    {
        return _notification;
    }

    public bool IsNotification()
    {
        return _notification.Any();
    }
}
