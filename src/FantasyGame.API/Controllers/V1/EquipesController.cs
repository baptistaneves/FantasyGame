using FantasyGame.API.Contracts.Equipes.Request;
using FantasyGame.API.Filters;
using FantasyGame.Application.Equipes.Commands;
using FantasyGame.Application.Equipes.Queries;
using FantasyGame.Application.Pagination;
using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    public class EquipesController : MainController
    {
        private readonly IMediator _mediator;
        public EquipesController(INotificador notificador, IMediator mediator) : base(notificador)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipe>>> ObterTodasEquipes([FromQuery] PaginationParams @params)
        {
            var query = new ObterTodasEquipesQuery(@params);
            var result = await _mediator.Send(query);

            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);

            return CustomResponse(new { result, result.CurrentPage, result.TotalCount, result.TotalPages });
        }

        [HttpGet, Route(ApiRoutes.Equipe.ObterEquipePorId)]
        public async Task<ActionResult<Equipe>> ObterEquipePorId(Guid id, CancellationToken token)
        {
            var query = new ObterEquipePorIdQuery(id);
            var result = await _mediator.Send(query, token);

            return CustomResponse(result);
        }

        [HttpPost, Route(ApiRoutes.Equipe.NovaEquipe)]
        [ValidateModel]
        public async Task<ActionResult> NovaEquipe([FromBody] CriarAtualizarEquipe novaEquipe, CancellationToken token)
        {
            var command = new CriarNovaEquipeCommand(novaEquipe.Nome, novaEquipe.Descricao);

            var result = await _mediator.Send(command, token);

            return CustomResponse(result);
        }

        [HttpPut, Route(ApiRoutes.Equipe.AtualizarEquipe)]
        [ValidateModel]
        public async Task<ActionResult> AtualizarEquipe(Guid id, [FromBody] CriarAtualizarEquipe equipe, CancellationToken token)
        {
            var command = new AtualizarEquipeCommand(id, equipe.Nome, equipe.Descricao);

            var result = await _mediator.Send(command, token);

            return CustomResponse();
        }

        [HttpDelete, Route(ApiRoutes.Equipe.RemoverEquipe)]
        public async Task<ActionResult> RemoverEquipe(Guid id, CancellationToken token)
        {
            var command = new RemoverEquipeCommand(id);

            var result = await _mediator.Send(command, token);

            return CustomResponse(result);
        }
    }
}
