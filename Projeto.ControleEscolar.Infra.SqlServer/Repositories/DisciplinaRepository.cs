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
    public class DisciplinaRepository : Repository<Disciplina, Guid>, IDisciplinaRepository
    {
        public DisciplinaRepository(SqlServerContext context)
            : base(context)
        {
        }
    }
}
