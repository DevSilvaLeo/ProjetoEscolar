using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDomainService<Usuario, int>
    {
        Usuario GetUserByCredentials(string usuario, string senha);
        bool EmailExists(string email);
    }
}
