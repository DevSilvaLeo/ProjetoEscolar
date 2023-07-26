using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IMensalidadeApplicationService
    {
        Task Inserir(MensalidadeInputDto entity);
        Task Atualizar(MensalidadeOutputDto entity);
        Task<MensalidadeOutputDto> Remover(Guid id);
        Task<IList<MensalidadeOutputDto>> ListarTodos();
        Task<MensalidadeOutputDto> ListarPorId(Guid id);
    }
}
