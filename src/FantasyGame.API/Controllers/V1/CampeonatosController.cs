using FantasyGame.Application.Campeonatos.Commands;
using FantasyGame.Application.Campeonatos.Models;
using FantasyGame.Domain.Interfaces.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    public class CampeonatosController : MainController
    {
        private readonly IMediator _mediator;
        public CampeonatosController(INotificador notificador, IMediator mediator) : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Campeonato>> ObterCampeonato()
        {
            var query = new GerarCampeonatoQuery();
            var result = await _mediator.Send(query);

            return CustomResponse(result);
        }


    }
}
