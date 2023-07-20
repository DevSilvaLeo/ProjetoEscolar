using Projeto.ControleEscolar.Domain.Core;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Interfaces.Repository;
using Projeto.ControleEscolar.Domain.Interfaces.Security;
using Projeto.ControleEscolar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Services
{
    public class AutenticacaoDomainService : IAutenticacaoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationSecurity _security;
        public AutenticacaoDomainService(IUnitOfWork unitOfWork, IAuthorizationSecurity security)
        {
            _unitOfWork = unitOfWork;
            _security = security;
        }

        public AuthorizationModel AutenticarUsuario(string email, string senha)
        {
            var usuario = _unitOfWork.UsuarioRepository.GetUserByCredentials(email, senha);
             
            DomainException.When(usuario == null, 
                "Acesso negado. Usuário não encontrado."
                );

            return new AuthorizationModel
            {
                AccessToken = _security.CreateToken(usuario),
                DataHoraAcesso = DateTime.Now
            };
        }

        public void RecuperarSenha(string email)
        {
            //TODO..
            throw new NotImplementedException();
        }
    }
}
