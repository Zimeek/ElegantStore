using System.Text.Json.Serialization;
using ElegantStore.Api.Extensions;
using ElegantStore.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.

await app.UseSeeder();

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
