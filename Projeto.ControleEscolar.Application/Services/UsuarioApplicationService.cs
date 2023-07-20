using AutoMapper;
using FluentValidation;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Core;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Interfaces.Security;
using Projeto.ControleEscolar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService _service;
        private readonly IMapper _mapper;
        private readonly IMD5Cryptograph _crypto;

        public UsuarioApplicationService(IUsuarioDomainService service, IMapper mapper, IMD5Cryptograph crypto)
        {
            _service = service;
            _mapper = mapper;
            _crypto = crypto;
        }

        public async Task CriarUsuario(UsuarioInputDto usuario)
        {
            var emailCadastrado = _service.EmailExists(usuario.Email);
            DomainException.When(
                emailCadastrado,
                "Email já existe em nossa base, favor cadastrar um novo email."
                );
                        
            var user = _mapper.Map<Usuario>(usuario);
            user.Password = _crypto.Encrypt(user.Password);
            var validate = user.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Insert(user);
        }

        public async Task AtualizarUsuario(UsuarioOutputDto usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            var validate = user.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(user);
        }

        public async Task<UsuarioOutputDto> RemoverUsuario(int id)
        {
            var user = await _service.GetById(id);
            DomainException.When(
                    user == null,
                    "Usuário informado não encontrado."
                );
            if(user != null) 
                _service.Delete(user);

            return _mapper.Map<UsuarioOutputDto>(user);
        }

        public async Task<IList<UsuarioOutputDto>> ListarUsuarios()
        {
            var users = await _service.GetAll();
            DomainException.When(
                    users == null,
                    "Usuários não encontrados."
                );

            return _mapper.Map<IList<UsuarioOutputDto>>(users).ToList();
        }

        public async Task<UsuarioOutputDto> ListarPorId(int id)
        {
            var user = await _service.GetById(id);
            DomainException.When(
                    user == null,
                    "Usuário informado não encontrado."
                );

            return _mapper.Map<UsuarioOutputDto>(user);
        }
    }
}
