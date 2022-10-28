using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacoes();
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.publicarNotificacao(new Notificacao(mensagem));
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            } 

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n=> n.Message)
            });
        }
    }
}
