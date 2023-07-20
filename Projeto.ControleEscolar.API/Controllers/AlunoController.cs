using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Entities;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoAplicationService _service;

        public AlunoController(IAlunoAplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AlunoInputDto aluno)
        {
            await _service.Inserir(aluno);
            return StatusCode(201, new
            {
                Mensagem = "Aluno cadastrado com sucesso."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AlunoOutputDto aluno)
        {
            await _service.Atualizar(aluno);
            return StatusCode(201, new
            {
                Mensagem = "Aluno atualizado com sucesso."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var aluno = await _service.Remover(id);
            return StatusCode(201, new
            {
                Mensagem = $"Aluno {aluno.Nome} removido com sucesso."
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var alunos = await _service.ListarTodos();
            return StatusCode(201, alunos);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var aluno = await _service.ListarPorId(id);
            return StatusCode(201, aluno);
        }
    }
}
