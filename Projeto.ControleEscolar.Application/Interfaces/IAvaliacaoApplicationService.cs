using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IAvaliacaoApplicationService
    {
        Task Inserir(AvaliacaoInputDto entity);
        Task Atualizar(AvaliacaoOutputDto entity);
        Task<AvaliacaoOutputDto> Remover(int id);
        Task<IList<AvaliacaoOutputDto>> ListarTodos();
        Task<AvaliacaoOutputDto> ListarPorId(int id);
    }
}
