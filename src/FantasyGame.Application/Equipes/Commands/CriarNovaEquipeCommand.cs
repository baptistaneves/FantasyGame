using FantasyGame.Application.Equipes.Validation;
using FantasyGame.Application.Common;
using MediatR;
using FantasyGame.Domain.Entities;

namespace FantasyGame.Application.Equipes.Commands
{
    public class CriarNovaEquipeCommand : Command<Equipe>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public CriarNovaEquipeCommand(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public override bool EhValido()
        {
            ValidationResult = new CriarNovaEquipaValidation().Validate(instance: this);
            return ValidationResult.IsValid;
        }

    }
}
