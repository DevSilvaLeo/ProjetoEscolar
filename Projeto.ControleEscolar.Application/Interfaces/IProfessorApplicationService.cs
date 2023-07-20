using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IProfessorApplicationService
    {
        Task Inserir(ProfessorInputDto entity);
        Task Atualizar(ProfessorOutputDto entity);
        Task<ProfessorOutputDto> Remover(Guid id);
        Task<IList<ProfessorOutputDto>> ListarTodos();
        Task<ProfessorOutputDto> ListarPorId(Guid id);
    }
}
