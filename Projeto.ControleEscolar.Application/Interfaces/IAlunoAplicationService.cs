using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IAlunoAplicationService
    {
        Task Inserir(AlunoInputDto entity);
        Task Atualizar(AlunoOutputDto entity);
        Task<AlunoOutputDto> Remover(Guid id);
        Task<IList<AlunoOutputDto>> ListarTodos();
        Task<AlunoOutputDto> ListarPorId(Guid id);
    }
}
