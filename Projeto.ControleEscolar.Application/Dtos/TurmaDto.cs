using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record TurmaInputDto(string Nome, string Status, DateTime DataInicio);
    public record TurmaOutputDto(Guid Id, string Nome, string Status, DateTime DataInicio, ICollection<DisciplinaOutputDto> Disciplinas, ICollection<Aluno> Alunos);
}