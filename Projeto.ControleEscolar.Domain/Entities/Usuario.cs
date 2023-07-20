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
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
        public PermisionType Permision { get; set; }
        public ValidationResult Validate => new UsuarioValidation().Validate(this); 
    }
}
