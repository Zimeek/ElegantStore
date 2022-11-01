using ElegantStore.Api.Services;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Infrastructure.Data;
using ElegantStore.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElegantStore.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProductService, ProductService>();
        
        return services;
    }
    
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}