using ED.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddDataAccess(builder.Configuration)
    .AddCookieAuth();

var app = builder.Build();

app.UseConfiguredMiddleware();
await app.SeedDatabaseAsync();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
