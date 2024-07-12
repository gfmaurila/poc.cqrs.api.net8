using poc.api.redis.Model;

namespace poc.api.redis.Service.Auth;

public class AuthQueryStore : IAuthQueryStore
{
    public AuthQueryStore()
    {
    }

    public async Task<AuthEntity> GetAuthByEmailPassword(string email, string passwordHash)
    {
        var listAuth = new List<AuthEntity>();

        var twilioWhatsApp = new AuthEntity
        {
            Id = new Guid("98a22d8f-b5eb-4424-8038-a05f771b7ee4"),
            Email = "twilioWhatsApp@twilioWhatsApp.com.br",
            Password = "master",
            Role = "TwilioWhatsApp"
        };
        listAuth.Add(twilioWhatsApp);

        var sendGridEmail = new AuthEntity
        {
            Id = new Guid("98a22d8f-b5eb-4424-8038-a05f771b7ee5"),
            Email = "SendGridEmail@SendGridEmail.com.br",
            Password = "master",
            Role = "SendGridEmail"
        };
        listAuth.Add(sendGridEmail);

        var auth = listAuth.Where(f => f.Email == email && f.Password == passwordHash).FirstOrDefault();

        if (auth is not null)
            return await Task.FromResult(auth);

        // Se e-mail ou senha não corresponderem, retornamos null
        return null;
    }
}
