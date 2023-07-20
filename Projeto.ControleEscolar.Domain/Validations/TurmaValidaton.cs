using FluentValidation;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Validations
{
    public class TurmaValidaton : AbstractValidator<Turma>
    {
        public TurmaValidaton()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5)
                .WithMessage("O nome da turma deve ter no mínimo 5 caracteres.")
                .MaximumLength(30)
                .WithMessage("O nome da turma deve ter no máximo 30 caracteres.")
                .NotEmpty()
                .WithMessage("O nome da turma deve ser preenchido.");
            
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("O status da turma é obrigatório.");

            RuleFor(x => x.DataInicio)
                .NotEmpty()
                .WithMessage("A data de inicio é obrigatória.");
        }
    }
}
