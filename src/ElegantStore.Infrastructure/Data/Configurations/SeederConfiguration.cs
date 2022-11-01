using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ElegantStore.Infrastructure.Data.Configurations;

public static class SeederConfiguration
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