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
                new (10, "orange"),
                new (11, "beige"),
                new (12, "violet"),
                new (13, "brown")
            };

            dbContext.Colors.AddRange(colors);
        }

        if (!dbContext.Products.Any())
        {
            var products = new List<Product>()
            {
                //MEN
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
                new (20, "vans", "core basic po", "blue", "men", "vans_core_basic_po_", 30M),
                //WOMEN
                new (21, "pieces", "pclina cropped v neck", "blue", "women", "pieces_pclina_cropped_v_neck_", 20M),
                new (22, "pepe jeans", "new virginia", "black", "women", "pepe_jeans_new_virginia_", 20M),
                new (23, "marks & spencer", "straight crew", "white", "women", "marks_&_spencer_straight_crew_", 10M),
                new (24, "adidas originals", "chic tee", "beige", "women", "adidas_originals_chic_tee_", 15M),
                new (25, "gap", "mod ballet", "black", "women", "gap_mod_ballet_", 25M),
                new (26, "gina tricot", "sorft turtleneck", "beige", "women", "gina_tricot_soft_turtleneck_", 15M),
                new (27, "soaked in luxury", "slclara singlet", "blue", "women", "soaked_in_luxury_slclara_singlet_", 30M),
                new (28, "jdy", "jdysisi singlet", "black", "women", "jdy_jdysisi_singlet_", 25M),
                new (29, "puma", "ess metallic", "black", "women", "puma_ess_metallic_", 15M),
                new (30, "eivy", "icegold gaiter", "pink", "women", "eivy_icegold_gaiter_", 50M),
                new (31, "pieces", "halterneck dress", "black", "women", "pieces_pclina_halterneck_dress_", 40M),
                new (32, "esprit", "fine", "navy", "women", "esprit_fine_", 45M),
                new (33, "only", "onlleva belt dres", "green", "women", "only_onlleva_belt_dress_", 30M),
                new (34, "noisy may", "nmtimmy dress", "black", "women", "noisy_may_nmtimmy_dress_", 55M),
                new (35, "repeat", "dress", "grey", "women", "repeat_dress_", 70M),
                new (36, "naf naf", "lazale", "black", "women", "naf_naf_lazale_", 60M),
                new (37, "jdy", "jdykate dress", "brown", "women", "jdy_jdykate_dress_", 35M),
                new (38, "next", "standard", "black", "women", "next_standard_", 40M),
                new (39, "next", "neck standard", "grey", "women", "next_neck_standard_", 55M),
                new (40, "parfois", "short", "white", "women", "parfois_short_", 30M)
            };
        
            dbContext.Products.AddRange(products);
        }

        if (!dbContext.ProductVariants.Any())
        {
            var productVariants = new List<ProductVariant>()
            {
                new (1, 2), new (1, 3),
                new (2, 3),
                new (3, 1), new (3, 5),
                new (4, 1), new (4, 4),
                new (5, 2), new (5, 5),
                new (6, 1), new (6, 5),
                new (7, 1), new (7, 4),
                new (8, 2), new (8, 3),
                new (9, 2),
                new (10, 10),
                new (11, 2),
                new (12, 1), new (12, 2),
                new (13, 1), new (13, 6),
                new (14, 1), new (14, 8),
                new (15, 4), new (15, 7),
                new (16, 1), new (16, 5),
                new (17, 4), new (17, 5),
                new (18, 7), new (18, 10),
                new (19, 3),
                new (20, 1),
                new (21, 1),
                new (22, 2), new (22, 6),
                new (23, 1),
                new (24, 1),
                new (25, 3),
                new (26, 1), new (26, 12),
                new (27, 1), new (27, 4),
                new (28, 2), new (28, 5),
                new (29, 3),
                new (30, 13),
                new (31, 5),
                new (32, 1),
                new (33, 2), new (33, 11),
                new (34, 2), new (34, 5),
                new (35, 1), new (35, 13),
                new (36, 2),
                new (37, 1),
                new (38, 13),
                new (39, 3),
                new (40, 1)
            };
        
            dbContext.ProductVariants.AddRange(productVariants);
        }

        await dbContext.SaveChangesAsync();
    }
}