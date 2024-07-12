namespace poc.api.redis.Model;

public class ResponseDefault
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public dynamic Data { get; set; }
}
