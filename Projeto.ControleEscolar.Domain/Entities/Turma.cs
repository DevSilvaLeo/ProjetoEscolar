using FluentValidation.Results;
using Projeto.ControleEscolar.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class Turma
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Status { get; set; }
        public DateTime DataInicio { get; set; }
        public ICollection<Disciplina>? Disciplinas { get; set; }
        public ICollection<Aluno>? Alunos { get; set; }
        public ValidationResult Validate => new TurmaValidaton().Validate(this);
    }
}
