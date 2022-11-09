using System.Reflection;
using ElegantStore.Api.DTOs;
using ElegantStore.Api.Middlewares;
using ElegantStore.Api.Services;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Infrastructure.Data;
using ElegantStore.Infrastructure.Data.Repositories;
using Mapster;
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
        services.AddScoped<ICartService, CartService>();
        services.AddTransient<GlobalExceptionHandler>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        return services;
    }

    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());
        
        return services;
    }

    public static IServiceCollection AddCustomerCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("_localorigin", builder =>
            {
                builder.WithOrigins("http://localhost:4200");
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
            });
        });

        return services;
    }
}