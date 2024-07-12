namespace poc.api.redis.Model;

public class TwilioWhatsApp
{
    public int Id { get; set; }
    public string From { get; set; }
    public string Body { get; set; }
    public string To { get; set; }
    public DateTime Dt { get; set; }
}
