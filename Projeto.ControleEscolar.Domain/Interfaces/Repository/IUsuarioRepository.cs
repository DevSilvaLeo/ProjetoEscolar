using Projeto.ControleEscolar.Domain.Core;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        Usuario GetUserByCredentials(string email, string senha);
        bool EmailExists(string email);
    }
}
