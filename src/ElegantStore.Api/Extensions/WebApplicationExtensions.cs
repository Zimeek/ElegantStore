using ElegantStore.Infrastructure.Data;

namespace ElegantStore.Api.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> UseSeeder(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await ApplicationDbContextSeeder.SeedAsync(applicationDbContext);
        }

        return app;
    }
}