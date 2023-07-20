using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Types;
using System.Data;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorApplicationService _service;

        public ProfessorController(IProfessorApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Insert(ProfessorInputDto professor)
        {
            await _service.Inserir(professor);
            return StatusCode(201, new
            {
                Mensagem = "Professor cadastrado com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Coordenador)]
        public async Task<IActionResult> Update(ProfessorOutputDto professor)
        {
            await _service.Atualizar(professor);
            return StatusCode(201, new
            {
                Mensagem = "Professor atualizado com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.ControleTotal)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var professor = await _service.Remover(id);
            return StatusCode(201, new
            {
                Mensagem = $"Professor {professor.Nome} removido com sucesso."
            });
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Educacional)]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var professores = await _service.ListarTodos();
            return StatusCode(201, professores);
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Educacional)]
        public async Task<IActionResult> Get(Guid id)
        {
            var professor = await _service.ListarPorId(id);
            return StatusCode(201, professor);
        }
    }
}
