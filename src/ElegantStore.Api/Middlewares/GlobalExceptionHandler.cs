using System.Net;
using System.Text.Json;
using ElegantStore.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ElegantStore.Api.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            context.Response.ContentType = "application/json";

            switch (error)
            {
                case ProductNotFoundException e:
                    context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    break;
                default:
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    break;
            }

            ProblemDetails problem = new()
            {
                Status = context.Response.StatusCode,
                Detail = error.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            
        }
    }
}