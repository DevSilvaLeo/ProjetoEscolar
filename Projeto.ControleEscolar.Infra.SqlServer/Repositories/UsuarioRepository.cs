using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Interfaces.Repository;
using Projeto.ControleEscolar.Infra.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.SqlServer.Repositories
{
    public class UsuarioRepository : Repository<Usuario, int>, IUsuarioRepository
    {
        private readonly SqlServerContext _context;
        public UsuarioRepository(SqlServerContext context) 
            : base(context)
        {
            _context = context;
        }

        public Usuario GetUserByCredentials(string email, string senha)
        {
            var query = @"SELECT * FROM USUARIO WHERE EMAIL = @EMAIL AND PASSWORD = @SENHA";

            var user = _context.Database
                .GetDbConnection()
                .Query<Usuario>(query, new { email, senha })
                .FirstOrDefault();

            if(user != null)
                return user;

            return null;
        }

        public bool EmailExists(string email)
        {
            var query = @"SELECT * FROM USUARIO WHERE EMAIL = @EMAIL";

            var emailCadastrado = _context.Database
                .GetDbConnection()
                .Query<Usuario>(query, new { email })
                .FirstOrDefault();

            if(emailCadastrado != null)
                return true;
            
            return false;
        }
    }
}
