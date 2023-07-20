using FluentValidation;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Validations
{
    public class DisciplinaValidation : AbstractValidator<Disciplina>
    {
        public DisciplinaValidation()
        {
            RuleFor(x => x.Nome)
               .Length(5, 50)
               .WithMessage("O nome da disciplina de ter entre 5 e 50 caractéres")
               .NotEmpty()
               .WithMessage("O nome da disciplina é obrigatório.");
        }
    }
}
