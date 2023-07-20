using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record ProfessorInputDto(string Nome, string Email, string CPF, string RG, DateTime DataNascimento);
    public record ProfessorOutputDto(Guid Id, string Nome, string Email, string CPF, string RG, DateTime DataNascimento, ICollection<TurmaOutputDto> Turmas);
}
