using Microsoft.OpenApi.Models;
using poc.api.redis.Model;
using poc.api.redis.Service.Persistence;

namespace poc.api.redis.EndPoints;
public static class TwilioWhatsAppEndPoints
{
    public static void RegisterTwilioWhatsAppEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/twiliowhatsapp", async (ITwilioWhatsAppService _service, ILogger<Program> logger) =>
        {
            var service = await _service.Get();
            if (service is null)
                return Results.NotFound();
            return TypedResults.Ok(service);
        })
        .WithName("TwilioWhatsApp - Buscar")
        .RequireAuthorization("TwilioWhatsappPolicy")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "TwilioWhatsApp - Buscar",
            Description = "TwilioWhatsApp - Buscar",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "TwilioWhatsApp" } }
        });

        app.MapPost("/api/twiliowhatsapp", async (TwilioWhatsApp entity, ITwilioWhatsAppService _service, ILogger<Program> logger) =>
        {
            logger.LogInformation("TwilioWhatsApp - Cadastro");
            if (entity is null)
                return Results.NotFound();
            return Results.Created($"{entity.Id}", await _service.Post(entity));
        })
        .WithName("TwilioWhatsApp - Cadastrar")
        .RequireAuthorization("TwilioWhatsappPolicy")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "TwilioWhatsApp - Cadastrar",
            Description = "TwilioWhatsApp - Cadastrar",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "TwilioWhatsApp" } }
        });

        app.MapDelete("/api/twiliowhatsapp/{id}", async (int id, ITwilioWhatsAppService _service, ILogger<Program> logger) =>
        {
            var service = await _service.Delete(id);
            return Results.Ok($"ID={id} deletado");
        })
        .WithName("TwilioWhatsApp - Deletar")
        .RequireAuthorization("TwilioWhatsappPolicy")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "TwilioWhatsApp - Deletar",
            Description = "TwilioWhatsApp - Deletar",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "TwilioWhatsApp" } }
        });
    }
}
