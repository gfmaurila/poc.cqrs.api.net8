using Microsoft.OpenApi.Models;
using poc.api.redis.Model;
using poc.api.redis.Service.Auth;

namespace poc.api.redis.EndPoints;
public static class AuthEndPoints
{
    public static void RegisterAuthEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth", async (AuthRequest entity, IAuthService _service, ILogger<Program> logger) =>
        {
            if (entity is null)
                return Results.NotFound();
            return Results.Ok(await _service.Auth(entity));
        })
        .WithName("Auth")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Auth",
            Description = "Auth",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Auth" } }
        });
    }
}
