using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Infra.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.SqlServer.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
            base.OnModelCreating(modelBuilder);
            */
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new MensalidadeMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Mensalidade> Mensalidade { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
    }
}
