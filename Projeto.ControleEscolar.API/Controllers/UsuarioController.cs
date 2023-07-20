using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Types;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _service;

        public UsuarioController(IUsuarioApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.Secretaria)]
        public async Task<IActionResult> Insert(UsuarioInputDto usuario)
        {           
            await _service.CriarUsuario(usuario);
            return StatusCode(201, new
            {
                Mensagem = "Usuário cadastrado com sucesso."
            });
        }

        [HttpPost]
        //[Authorize(Roles = ControleEscolarPermisionRoles.Secretaria)]
        public async Task<IActionResult> Update(UsuarioOutputDto usuario)
        {
            await _service.AtualizarUsuario(usuario);
            return StatusCode(201, new
            {
                Mensagem = "Usuário atualizado com sucesso."
            });
        }

        [HttpPost]
        [Authorize(Roles = ControleEscolarPermisionRoles.ControleTotal)]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _service.RemoverUsuario(id);
            return StatusCode(201, new
            {
                Mensagem = $"Usuário {usuario.Email} removido com sucesso."
            });
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Secretaria)]
        public async Task<IActionResult> GetAll() 
        {
            var usuarios = await _service.ListarUsuarios();
            return StatusCode(201, usuarios);
        }

        [HttpGet]
        [Authorize(Roles = ControleEscolarPermisionRoles.Secretaria)]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _service.ListarPorId(id);
            return StatusCode(201, usuario);
        }
    }
}
