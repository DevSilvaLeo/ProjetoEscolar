using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Core
{
    public interface IPersonEntity
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string CPF { get; set; }
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
        ValidationResult Validate { get; }
    }
}
