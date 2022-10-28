using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace FantasyGame.API.Registrar
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar
    {
        
        public void RegisterServices(WebApplication app)
        {
            app.ConfigureExceptionHandler(app.Environment);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.ApiVersion.ToString());
                }
            });
        }
    }
}
