using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Types;
using System.Data;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaApplicationService _service;

        public DisciplinaController(IDisciplinaApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Insert(DisciplinaInputDto disciplina)
        {
            await _service.Inserir(disciplina);
            return StatusCode(201, new
            {
                Mensagem = "Disciplina cadastrada com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Update(DisciplinaOutputDto disciplina)
        {
            await _service.Atualizar(disciplina);
            return StatusCode(201, new
            {
                Mensagem = "Disciplina atualizada com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.ControleTotal)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var disciplina = await _service.Remover(id);
            return StatusCode(201, new
            {
                Mensagem = $"Disciplina {disciplina.Nome} removida com sucesso."
            });
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> GetAll()
        {
            var disciplinas = await _service.ListarTodos();
            return StatusCode(201, disciplinas);
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Get(Guid id)
        {
            var disciplinas = await _service.ListarPorId(id);
            return StatusCode(201, disciplinas);
        }
    }
}
