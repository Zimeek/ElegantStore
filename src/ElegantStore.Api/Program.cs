using System.Text.Json.Serialization;
using ElegantStore.Infrastructure.Data.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

await app.UseSeeder();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
