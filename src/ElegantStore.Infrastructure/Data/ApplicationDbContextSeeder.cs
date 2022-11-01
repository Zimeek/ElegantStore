using ElegantStore.Domain.Entities;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace ElegantStore.Infrastructure.Data;

public static class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        if (dbContext.Database.IsSqlServer())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (!await dbContext.Colors.AnyAsync())
        {
            var colors = new[]
            {
                new Color(1, "blue"),
                new Color(2, "red")
            };

            await dbContext.Colors.AddRangeAsync(colors);
        }

        if (!await dbContext.Products.AnyAsync())
        {
            var products = new[]
            {
                new Product(1, "Nike", "Air Max", "test", 999M),
                new Product(2, "Adidas", "Superstar", "test", 499M)
            };

            await dbContext.Products.AddRangeAsync(products);
        }

        if (!await dbContext.ProductColors.AnyAsync())
        {
            var productColors = new[]
            {
                new ProductColor(1, 1),
                new ProductColor(2, 2)
            };

            await dbContext.ProductColors.AddRangeAsync(productColors);
        }

        await dbContext.SaveChangesAsync();
    }
}