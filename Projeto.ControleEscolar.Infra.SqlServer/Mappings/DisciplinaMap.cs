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
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
