using AutoMapper;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Services
{
    public class AutenticacaoApplicationService : IAutenticacaoApplicationService
    {
        private readonly IAutenticacaoDomainService _service;
        private readonly IMapper _mapper;

        public AutenticacaoApplicationService(IAutenticacaoDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public AutenticacaoResponseDto Login(AutenticacaoRequestDto request)
        {
            var usuario = _service.AutenticarUsuario(request.Email, request.Senha);
            return _mapper.Map<AutenticacaoResponseDto>(usuario);
        }
        public void ForgotPassword(string email)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
