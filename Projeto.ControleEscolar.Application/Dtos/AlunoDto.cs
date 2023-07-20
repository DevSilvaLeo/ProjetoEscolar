using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record AlunoInputDto(string Nome, string Email, string CPF, string RG, DateTime DataNascimento);
    public record AlunoOutputDto(Guid Id, string Nome, string Email, string CPF, string RG, DateTime DataNascimento, TurmaOutputDto Turma);
}
