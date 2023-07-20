using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record DisciplinaInputDto(string Nome);
    public record DisciplinaOutputDto(Guid Id, string Nome);
}
