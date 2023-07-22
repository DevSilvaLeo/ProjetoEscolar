using FluentValidation;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Validations
{
    public class MensalidadeValidation : AbstractValidator<Mensalidade>
    {
        public MensalidadeValidation()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor da mensalidade precisa ser informado.")
                .LessThan(1)
                .WithMessage("O valor da mensalidade não pode ser zero");

            RuleFor(x => x.Vencimento)
                .NotEmpty()
                .WithMessage("Insira uma data de vencimento.");

            RuleFor(x => x.FormaPagamento)
                .NotEmpty()
                .WithMessage("A forma de pagamento precisa ser informada.")
                .IsInEnum();
        }
    }
}
