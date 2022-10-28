using FluentValidation.Results;
using MediatR;

namespace FantasyGame.Application.Common
{
    public class Command<T> : IRequest<T>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
