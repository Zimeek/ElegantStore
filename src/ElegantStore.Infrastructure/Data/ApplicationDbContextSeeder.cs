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
                new (4, "adidas originals", "stripes tee", "brown", "men", "adidas_originals_stripes_tee_", 30M),
                new (5, "nike sportswear", "retro tee", "grey", "men", "nike_sportswear_retro_tee_", 35M),
                new (6, "hugo", "donos", "green", "men", "hugo_donos_", 38M),
                new (7, "calvin klein jeans", "tipping slim", "white", "men", "calvin_klein_jeans_tipping_slim_", 50M),
                new (8, "polo ralph lauren", "slim fit", "pink", "men", "polo_ralph_lauren_slim_fit_", 45M),
                new (9, "tommy jeans plus", "red flag neck", "navy", "men", "tommy_jeans_plus_red_flag_neck_", 40M),
                new (10, "gant", "original rugger", "green", "men", "gant_original_rugger_", 35M),
                new (11, "puma", "iconic t7 ft", "black", "men", "puma_iconic_t7_ft_", 20M),
                new (12, "levi's", "cozy up hoodie", "yellow", "men", "levis_cozy_up_hoodie_", 45M),
                new (13, "gap", "arch", "white", "men", "gap_arch_", 20M),
                new (14, "nike sportswear","club hoodie", "orange", "men", "nike_sportswear_club_hoodie_", 40M),
                new (15, "adidas performance", "entrada hoody", "white", "men", "adidas_performance_entrada_hoody_", 30M),
                new (16, "ellesse", "ducenta hoody", "grey", "men", "ellesse_ducenta_hoody_", 40M),
                new (17, "the north face", "drew peak hoodie", "red", "men", "the_north_face_drew_peak_hoodie_", 50M),
                new (18, "tommy hilfiger", "logo hoody", "white", "men", "tommy_hilfiger_logo_hoody_", 65M),
                new (19, "alpha industries", "nasa voyager hoody", "black", "men", "alpha_industries_nasa_voyager_hoody_", 45M),
                new (20, "vans", "core basic po", "blue", "men", "vans_core_basic_po_", 30M)
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
                new (10, 10),
                new (11, 2),
                new (12, 1),
                new (12, 2),
                new (13, 1),
                new (13, 6),
                new (14, 1),
                new (14, 8),
                new (15, 4),
                new (15, 7),
                new (16, 1),
                new (16, 5),
                new (17, 4),
                new (17, 5),
                new (18, 7),
                new (18, 10),
                new (19, 3),
                new (20, 1)
            };
        
            dbContext.ProductVariants.AddRange(productVariants);
        }

        await dbContext.SaveChangesAsync();
    }
}