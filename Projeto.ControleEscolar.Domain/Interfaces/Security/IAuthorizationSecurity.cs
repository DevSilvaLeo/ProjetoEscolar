using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Security
{
    public interface IAuthorizationSecurity
    {
        string CreateToken(Usuario usuario);
    }
}
