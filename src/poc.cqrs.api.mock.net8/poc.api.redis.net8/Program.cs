using poc.api.redis.Configuration;
using poc.api.redis.EndPoints;
using poc.api.redis.Service.Auth;
using poc.api.redis.Service.Consumers;
using poc.api.redis.Service.Persistence;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddConnections();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig(builder.Configuration);


// Redis
string redisConfiguration = builder.Configuration.GetSection("Redis:Configuration").Value;
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfiguration));

// Bus
//builder.Services.AddHostedService<ProdutoConsumer>();
builder.Services.AddHostedService<CriarProdutoConsumer>();
builder.Services.AddHostedService<AlterarProdutoConsumer>();
builder.Services.AddHostedService<RemoverProdutoConsumer>();

// Repository
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ITwilioWhatsAppService, TwilioWhatsAppService>();
builder.Services.AddScoped<ISendGridEmailService, SendGridEmailService>();

builder.Services.AddScoped<IAuthQueryStore, AuthQueryStore>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddHttpClient();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SendGridEmailPolicy", policy => policy.RequireRole("SendGridEmail"));
    options.AddPolicy("TwilioWhatsappPolicy", policy => policy.RequireRole("TwilioWhatsApp"));
});

var app = builder.Build();

app.UseSerilogRequestLogging();

app.RegisterAuthEndPoints();
app.RegisterSendGridEmailEndpoints();
app.RegisterTwilioWhatsAppEndpoints();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();