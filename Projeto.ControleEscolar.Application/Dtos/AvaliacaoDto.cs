using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record AvaliacaoInputDto(decimal N1, decimal N2, decimal N3, decimal Media, AlunoOutputDto Aluno, DisciplinaOutputDto Disciplina);
    public record AvaliacaoOutputDto(int Id, decimal N1, decimal N2, decimal N3, decimal Media, AlunoOutputDto Aluno, DisciplinaOutputDto Disciplina);
}