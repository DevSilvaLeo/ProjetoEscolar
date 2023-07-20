using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IDisciplinaApplicationService
    {
        Task Inserir(DisciplinaInputDto entity);
        Task Atualizar(DisciplinaOutputDto entity);
        Task<DisciplinaOutputDto> Remover(Guid id);
        Task<IList<DisciplinaOutputDto>> ListarTodos();
        Task<DisciplinaOutputDto> ListarPorId(Guid id);
    }
}
