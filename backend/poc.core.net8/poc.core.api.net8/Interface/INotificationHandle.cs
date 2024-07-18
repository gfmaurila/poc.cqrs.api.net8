using poc.core.api.net8.Model;

namespace poc.core.api.net8.Interface;

public interface INotificationHandle
{
    bool IsNotification();
    List<Notification> GetNotification();
    void Handle(Notification notification);
}
