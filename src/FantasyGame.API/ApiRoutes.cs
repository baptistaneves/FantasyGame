namespace FantasyGame.API
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

        public static class Equipe
        {
            public const string ObterEquipePorId = "obter-equipe-por-id/{id:guid}";
            public const string NovaEquipe = "nova-equipe";
            public const string AtualizarEquipe = "atualizar-equipe/{id:guid}";
            public const string RemoverEquipe = "remover-equipe/{id:guid}";
        }
    }
}
