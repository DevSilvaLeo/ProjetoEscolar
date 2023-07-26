using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MensalidadeController : ControllerBase
    {
        private readonly IMensalidadeApplicationService _service;

        public MensalidadeController(IMensalidadeApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(MensalidadeInputDto mensalidade)
        {
            await _service.Inserir(mensalidade);
            return StatusCode(201, new
            {
                Mensagem = "Mensalidade cadastrado com sucesso."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(MensalidadeOutputDto mensalidade)
        {
            await _service.Atualizar(mensalidade);
            return StatusCode(201, new
            {
                Mensagem = "Mensalidade atualizado com sucesso."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mensalidade = await _service.Remover(id);
            return StatusCode(201, new
            {
                Mensagem = $"Mensalidade {mensalidade.Vencimento} removida com sucesso."
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mensalidades = await _service.ListarTodos();
            return StatusCode(201, mensalidades);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var mensalidade = await _service.ListarPorId(id);
            return StatusCode(201, mensalidade);
        }
    }
}
