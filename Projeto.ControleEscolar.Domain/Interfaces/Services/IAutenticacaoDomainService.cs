using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Services
{
    public interface IAutenticacaoDomainService
    {
        AuthorizationModel AutenticarUsuario(string email, string senha);
        void RecuperarSenha(string email);
    }
}
