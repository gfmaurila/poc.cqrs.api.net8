using Microsoft.IdentityModel.Tokens;
using poc.api.redis.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace poc.api.redis.Service.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IAuthQueryStore _repo;
    public AuthService(IConfiguration configuration, IAuthQueryStore repo)
    {
        _configuration = configuration;
        _repo = repo;
    }

    public async Task<AuthToken> Auth(AuthRequest request)
    {
        var auth = await _repo.GetAuthByEmailPassword(request.Email, request.Password);

        if (auth is null)
            return null;

        var token = GenerateJwtToken(auth.Email, auth.Role);

        return new AuthToken { Token = token };
    }

    private string GenerateJwtToken(string email, string role)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
            {
                new Claim("userName",email),
                new Claim(ClaimTypes.Role, role),
            };

        var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials,
            claims: claims);

        var tokenHandler = new JwtSecurityTokenHandler();

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }

}
