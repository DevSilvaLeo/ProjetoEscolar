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
    public class AlunoRepository : Repository<Aluno, Guid>, IAlunoRepository
    {
        public AlunoRepository(SqlServerContext context) 
            : base(context)
        {
        }
    }
}
