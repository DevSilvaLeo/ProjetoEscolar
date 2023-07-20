using FluentValidation.Results;
using Projeto.ControleEscolar.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class Disciplina
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public ValidationResult Validate => new DisciplinaValidation().Validate(this);
    }
}
