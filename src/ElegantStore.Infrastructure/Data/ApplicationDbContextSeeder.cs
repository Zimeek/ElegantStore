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
                new (1, "black"),
                new (2, "red"),
                new (3, "white"),
                new (4, "yellow"),
                new (5, "blue"),
                new (6, "grey"),
                new (7, "green"),
                new (8, "pink"),
                new (9, "navy"),
                new (10, "orange")
            };

            dbContext.Colors.AddRange(colors);
        }

        if (!dbContext.Products.Any())
        {
            var products = new List<Product>()
            {
                new (1, "jordan", "jumpman crew", "black", "men", "jordan_jumpman_crew_", 20M),
                new (2, "closure london", "life tee", "black", "men", "closure_london_life_tee_", 10M),
                new (3, "tommy jeans", "chest logo tee", "yellow", "men", "tommy_jeans_chest_logo_tee_", 25M),
                new (4, "adidas originals", "stripes tee", "brown", "men", "adidas_originals_stripes_tee_", 28M),
                new (5, "nike sportswear", "retro tee", "grey", "men", "nike_sportswear_retro_tee_", 35M),
                new (6, "hugo", "donos", "green", "men", "hugo_donos_", 38M),
                new (7, "calvin klein jeans", "tipping slim", "white", "men", "calvin_klein_jeans_tipping_slim_", 50M),
                new (8, "polo ralph lauren", "slim fit", "pink", "men", "polo_ralph_lauren_slim_fit_", 45M),
                new (9, "tommy jeans plus", "red flag neck", "navy", "men", "tommy_jeans_plus_red_flag_neck_", 40M),
                new (10, "gant", "original rugger", "green", "men", "gant_original_rugger_", 35M)
            };
        
            dbContext.Products.AddRange(products);
        }

        if (!dbContext.ProductVariants.Any())
        {
            var productVariants = new List<ProductVariant>()
            {
                new (1, 2),
                new (1, 3),
                new (2, 3),
                new (3, 1),
                new (3, 5),
                new (4, 1),
                new (4, 4),
                new (5, 2),
                new (5, 5),
                new (6, 1),
                new (6, 5),
                new (7, 1),
                new (7, 4),
                new (8, 2),
                new (8, 3),
                new (9, 2),
                new (10, 10)
            };
        
            dbContext.ProductVariants.AddRange(productVariants);
        }

        await dbContext.SaveChangesAsync();
    }
}