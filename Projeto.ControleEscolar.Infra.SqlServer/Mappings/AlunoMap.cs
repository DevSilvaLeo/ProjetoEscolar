using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.SqlServer.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Turma).WithMany();
        }
    }
}
