namespace poc.core.api.net8.Model;

public class Notification
{
    public Notification(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
