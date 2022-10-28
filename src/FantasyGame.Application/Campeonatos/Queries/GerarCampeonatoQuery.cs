using FantasyGame.Application.Campeonatos.Models;
using MediatR;

namespace FantasyGame.Application.Campeonatos.Commands
{
    public class GerarCampeonatoQuery : IRequest<Campeonato> { }
}
