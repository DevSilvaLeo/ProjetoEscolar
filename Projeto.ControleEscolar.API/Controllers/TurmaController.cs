using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Types;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaApplicationService _service;

        public TurmaController(ITurmaApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Insert(TurmaInputDto turma)
        {
            await _service.Inserir(turma);
            return StatusCode(201, new
            {
                Mensagem = "Turma cadastrada com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Update(TurmaOutputDto turma)
        {
            await _service.Atualizar(turma);
            return StatusCode(201, new
            {
                Mensagem = "Turma atualizado com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.ControleTotal)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var turma = await _service.Remover(id);
            return StatusCode(201, new
            {
                Mensagem = $"Turma {turma.Nome} removida com sucesso."
            });
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Secretaria)]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var turmas = await _service.ListarTodos();
            return StatusCode(201, turmas);
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Educacional)]
        public async Task<IActionResult> Get(Guid id)
        {
            var turma = await _service.ListarPorId(id);
            return StatusCode(201, turma);
        }
    }
}
