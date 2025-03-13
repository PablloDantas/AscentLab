using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Configuração da porta - use a variável de ambiente PORT que o container/host define
var port = int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "8080");

// Importante: Remova todas as outras configurações de URL/porta antes desta
builder.Services.Configure<KestrelServerOptions>(options =>
{
    // Limpar todas as configurações anteriores
    options.ConfigureEndpointDefaults(lo => { });

    // Configurar apenas uma única porta
    options.ListenAnyIP(port);
});

// Remova qualquer uso adicional de UseUrls ou ConfigureKestrel

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    var swaggerConfig = builder.Configuration.GetSection("Swagger");
    c.SwaggerDoc("v1", new()
    {
        Title = swaggerConfig["Title"] ?? "API",
        Version = swaggerConfig["Version"] ?? "v1",
        Description = swaggerConfig["Description"] ?? "API Description"
    });
});

var app = builder.Build();

// Exibir a porta que está sendo usada (para debug)
app.Logger.LogInformation($"Application starting on port {port}");

// Configure o middleware da aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
    app.MapOpenApi();
}
else
{
    // Para ambientes de produção também é útil ter Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

// Rota para verificar se a aplicação está funcionando
app.MapGet("/", () => "API is running!")
    .WithName("Root");

// Outras rotas
app.MapGet("/weatherforecast", () =>
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}