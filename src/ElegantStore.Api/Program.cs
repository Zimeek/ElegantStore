using System.Text.Json.Serialization;
using ElegantStore.Api.Extensions;
using ElegantStore.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMapster();
builder.Services.AddCustomerCors();

var app = builder.Build();

await app.UseSeeder();

app.UseHttpsRedirection();

app.UseCustomCors();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
