namespace poc.core.api.net8.Interface;

public interface INotificationHandle
{
    bool IsNotification();
    List<poc.core.api.net8.Model.Notification> GetNotification();
    void Handle(poc.core.api.net8.Model.Notification notification);
}
