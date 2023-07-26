using FluentValidation.Results;
using Projeto.ControleEscolar.Domain.Types;
using Projeto.ControleEscolar.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class Mensalidade
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public FormaPagamentoTypes FormaPagamento { get; set; }
        public Aluno? Aluno { get; set; }
        public ValidationResult Validate => new MensalidadeValidation().Validate(this); 
    }
}
