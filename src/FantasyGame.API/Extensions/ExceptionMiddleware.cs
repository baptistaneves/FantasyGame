using FantasyGame.API.Contracts.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace FantasyGame.API.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this WebApplication app, IHostEnvironment env)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {

                        var ex = contextFeature.Error;

                        var response = env.IsDevelopment()
                            ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                            : new ApiException(context.Response.StatusCode, "Erro Interno do Servidor");

                        var options = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        };

                        var json = JsonSerializer.Serialize(response, options);

                        await context.Response.WriteAsync(json);
                    }
                    
                });
            });
        }
    }
}
