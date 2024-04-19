using Microsoft.OpenApi.Models;
using poc.api.redis.Model;
using poc.api.redis.Service.Persistence;

namespace poc.api.redis.EndPoints;
public static class SendGridEmailEndpoints
{
    public static void RegisterSendGridEmailEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/sendgridemail", async (ISendGridEmailService _service, ILogger<Program> logger) =>
        {
            var service = await _service.Get();
            if (service is null)
                return Results.NotFound();
            return TypedResults.Ok(service);
        })
        .WithName("SendGridEmail - Buscar")
        .RequireAuthorization("SendGridEmailPolicy")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "SendGridEmail - Buscar",
            Description = "SendGridEmail - Buscar",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "SendGridEmail" } }
        });

        app.MapPost("/api/sendgridemail", async (SendGridEmail entity, ISendGridEmailService _service, ILogger<Program> logger) =>
        {
            if (entity is null)
                return Results.NotFound();
            return Results.Created($"{entity.Id}", await _service.Post(entity));
        })
        .WithName("SendGridEmail - Cadastrar")
        .RequireAuthorization("SendGridEmailPolicy")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "SendGridEmail - Cadastrar",
            Description = "SendGridEmail - Cadastrar",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "SendGridEmail" } }
        });

        app.MapDelete("/api/sendgridemail/{id}", async (int id, ISendGridEmailService _service, ILogger<Program> logger) =>
        {
            var service = await _service.Delete(id);
            return Results.Ok($"Id={id} deletado");
        })
        .WithName("SendGridEmail - Deletar")
        .RequireAuthorization("SendGridEmailPolicy")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "SendGridEmail - Deletar",
            Description = "SendGridEmail - Deletar",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "SendGridEmail" } }
        });
    }
}
