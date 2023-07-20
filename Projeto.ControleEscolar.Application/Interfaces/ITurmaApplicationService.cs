using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface ITurmaApplicationService
    {
        Task Inserir(TurmaInputDto entity);
        Task Atualizar(TurmaOutputDto entity);
        Task<TurmaOutputDto> Remover(Guid id);
        Task<IList<TurmaOutputDto>> ListarTodos();
        Task<TurmaOutputDto> ListarPorId(Guid id);
    }
}
