using FantasyGame.Application.Common;
using FantasyGame.Application.Equipes.Validation;

namespace FantasyGame.Application.Equipes.Commands
{
    public class AtualizarEquipeCommand : Command<bool>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Guid Id { get; private set; }

        public AtualizarEquipeCommand(Guid id, string nome, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Nome = nome;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarEquipaValidation().Validate(instance: this);
            return ValidationResult.IsValid;
        }
    }
}
