using FluentValidation.Results;
using Projeto.ControleEscolar.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class Professor
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string CPF { get; set; }
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<Turma>? Turmas { get; set; }
        public ValidationResult Validate => new ProfessorValidation().Validate(this);
    }
}
