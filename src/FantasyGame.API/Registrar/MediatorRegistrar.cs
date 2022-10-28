using FantasyGame.Application.Equipes.Commands;
using MediatR;

namespace FantasyGame.API.Registrar
{
    public class MediatorRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(CriarNovaEquipeCommand));
        }
    }
}
