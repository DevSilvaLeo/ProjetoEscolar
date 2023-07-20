using FluentValidation;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Insira um email válido.")
                .NotEmpty()
                .WithMessage("O nome de usuário é obrigatório");
        }
    }
}
