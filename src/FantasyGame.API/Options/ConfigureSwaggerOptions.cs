using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FantasyGame.API.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Fantasy Game API",
                Version = description.ApiVersion.ToString(),
                Description = "Esta API foi desenvolvida como parte do Desafio Técnico para Vaga de Backend",
                Contact = new OpenApiContact
                {
                    Name = "Baptista Neves",
                    Email = "baptistafirminoneves@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "CC BY"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description = "Esta versão da API está depreciada";
            }

            return info;
        }

    }
}
