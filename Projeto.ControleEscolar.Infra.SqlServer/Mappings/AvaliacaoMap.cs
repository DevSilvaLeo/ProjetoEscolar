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
    public class AvaliacaoMap : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.N1)
                .HasPrecision(2, 1)
                .HasMaxLength(10);
            builder.Property(x => x.N2)
                .HasPrecision(2, 1)
                .HasMaxLength(10);
            builder.Property(x => x.N3)
                .HasPrecision(2, 1)
                .HasMaxLength(10);
            builder.Property(x => x.Media)
                .HasPrecision(2, 1)
                .HasMaxLength(10);
            builder.HasOne(x => x.Disciplina).WithMany();
            builder.HasOne(x => x.Aluno).WithMany();
        }
    }
}
