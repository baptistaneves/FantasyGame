using FantasyGame.Application.Equipes.Commands;
using FluentValidation;

namespace FantasyGame.Application.Equipes.Validation
{
    public class CriarNovaEquipaValidation : AbstractValidator<CriarNovaEquipeCommand>
    {
        public CriarNovaEquipaValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O nome da equipe deve ser informado")
                .MinimumLength(3).WithMessage("O nome da equipe deve ter no minímo 3 caracteres");

            RuleFor(e => e.Descricao)
               .NotEmpty().WithMessage("Digite alguma descrição da equipe");
        }
    }
}
