var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.Request.Path.Value == "/" || context.Request.Path.Value == "/index.html")
    {
        context.Response.Redirect("/Index");
        return;
    }
    
    await next();
});


app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
