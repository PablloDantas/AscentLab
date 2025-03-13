var builder = WebApplication.CreateBuilder(args);

// Configuração de URLs padrão
builder.WebHost.UseUrls("http://+:8080");

// Configuração condicional para ambientes que não sejam de desenvolvimento
if (!builder.Environment.IsDevelopment())
{
    // Configura apenas HTTP na porta 8080
    builder.WebHost.ConfigureKestrel(serverOptions => { serverOptions.ListenAnyIP(8080); });

    // Remover qualquer URL HTTPS das configurações, se existir
    var urls = builder.Configuration["URLS"] ?? builder.Configuration["ASPNETCORE_URLS"];
    if (!string.IsNullOrEmpty(urls))
    {
        var httpUrls = urls.Split(';')
            .Where(url => url.StartsWith("http://"))
            .ToArray();

        if (httpUrls.Length > 0)
        {
            builder.WebHost.UseUrls(httpUrls);
        }
        else
        {
            builder.WebHost.UseUrls("http://+:8080");
        }
    }
    else
    {
        builder.WebHost.UseUrls("http://+:8080");
    }
}

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    var swaggerConfig = builder.Configuration.GetSection("Swagger");
    c.SwaggerDoc("v1", new()
    {
        Title = swaggerConfig["Title"],
        Version = swaggerConfig["Version"],
        Description = swaggerConfig["Description"]
    });
});

// Depois de todas as configurações, gera a aplicação
var app = builder.Build();

// Configuração do pipeline HTTP para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ascent Lab API v1");
        c.RoutePrefix = string.Empty;
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.DefaultModelExpandDepth(0);
        c.DefaultModelsExpandDepth(-1);
        c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
        c.DisplayOperationId();
        c.DisplayRequestDuration();
        c.EnableDeepLinking();
        c.EnableFilter();
        c.ShowExtensions();
    });

    app.MapOpenApi();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
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