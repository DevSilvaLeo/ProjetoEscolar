using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Entities;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoApplicationService _service;

        public AvaliacaoController(IAvaliacaoApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AvaliacaoInputDto avaliacao)
        {
            await _service.Inserir(avaliacao);
            return StatusCode(201, new
            {
                Mensagem = "Aluno cadastrado com sucesso."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AvaliacaoOutputDto avaliacao)
        {
            await _service.Atualizar(avaliacao);
            return StatusCode(201, new
            {
                Mensagem = "Aluno atualizado com sucesso."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var avaliacao = await _service.Remover(id);
            return StatusCode(201, new
            {
                Mensagem = $"Aluno {avaliacao.Disciplina} removido com sucesso."
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var avaliacoes = await _service.ListarTodos();
            return StatusCode(201, avaliacoes);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var avaliacao = await _service.ListarPorId(id);
            return StatusCode(201, avaliacao);
        }
    }
}
