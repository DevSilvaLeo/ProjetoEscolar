using FluentValidation;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Validations
{
    public class AvaliacaoValidation : AbstractValidator<Avaliacao>
    {
        public AvaliacaoValidation()
        {
            RuleFor(x => x.N1)
                .NotEmpty()
                .WithMessage("A nota precisa ser informada");

            RuleFor(x => x.Disciplina)
                .NotEmpty()
                .WithMessage("Uma disciplina precisa ser informada.");

            RuleFor(x => x.Aluno)
                .NotEmpty()
                .WithMessage("Um aluno precisa ser informado.");
        }
    }
}
