using Microsoft.EntityFrameworkCore.Storage;
using Projeto.ControleEscolar.Domain.Interfaces.Repository;
using Projeto.ControleEscolar.Infra.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAlunoRepository AlunoRepository => new AlunoRepository(_context);

        public IProfessorRepository ProfessorRepository => new ProfessorRepository(_context);

        public ITurmaRepository TurmaRepository => new TurmaRepository(_context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);

        public IDisciplinaRepository DisciplinaRepository => new DisciplinaRepository(_context);
    }
}
