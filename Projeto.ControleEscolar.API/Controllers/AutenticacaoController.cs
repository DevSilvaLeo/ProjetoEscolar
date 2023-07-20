using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;

namespace Projeto.ControleEscolar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoApplicationService _service;

        public AutenticacaoController(IAutenticacaoApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(AutenticacaoRequestDto model)
        {
            var usuario = _service.Login(model);
            return StatusCode(201, usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword() 
        {
            return null;
        }
    }
}
