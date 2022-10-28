using System.ComponentModel.DataAnnotations;

namespace FantasyGame.API.Contracts.Equipes.Request
{
    public class CriarAtualizarEquipe
    {
        [Required(ErrorMessage = "O nome da equipe deve ser informado")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
