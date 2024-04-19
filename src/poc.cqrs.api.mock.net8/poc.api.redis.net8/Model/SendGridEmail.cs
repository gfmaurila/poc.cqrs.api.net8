namespace poc.api.redis.Model;
public class SendGridEmail
{
    public int Id { get; set; }
    public string From { get; set; }

    public string Subject { get; set; }
    public string HtmlContent { get; set; }
    public string To { get; set; }
    public string Name { get; set; }
    public DateTime Dt { get; set; }
}
