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

        if (!dbContext.Colors.Any())
        {
            var colors = new List<Color>
            {
                new (1, "blue"),
                new (2, "red")
            };

            dbContext.Colors.AddRange(colors);
        }

        if (!dbContext.Products.Any())
        {
            var products = new List<Product>()
            {
                new (1, "Nike", "Air Max", "blue", "men", "test", 999M),
                new (2, "Adidas", "Superstar", "red", "men", "test", 499M)
            };
        
            dbContext.Products.AddRange(products);
        }

        if (!dbContext.ProductVariants.Any())
        {
            var productColors = new List<ProductVariant>()
            {
                new (1, 1),
                new (2, 2)
            };
        
            dbContext.ProductVariants.AddRange(productColors);
        }

        await dbContext.SaveChangesAsync();
    }
}