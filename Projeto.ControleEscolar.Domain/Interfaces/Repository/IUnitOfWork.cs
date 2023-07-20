using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        IAlunoRepository AlunoRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        ITurmaRepository TurmaRepository { get; }
        IDisciplinaRepository DisciplinaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
    }
}
