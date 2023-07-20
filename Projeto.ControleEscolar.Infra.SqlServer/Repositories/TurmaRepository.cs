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
    public class TurmaRepository : Repository<Turma, Guid>, ITurmaRepository
    {
        public TurmaRepository(SqlServerContext context) 
            : base(context)
        {
        }
    }
}
