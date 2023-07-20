using FluentValidation.Results;
using Projeto.ControleEscolar.Domain.Core;
using Projeto.ControleEscolar.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class Aluno : IPersonEntity
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string CPF { get; set; }
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public Turma? Turma { get; set; }
        public ValidationResult Validate => new AlunoValidation().Validate(this);
    }
}
