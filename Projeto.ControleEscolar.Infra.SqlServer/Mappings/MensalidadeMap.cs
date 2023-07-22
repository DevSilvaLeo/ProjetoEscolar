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
    public class MensalidadeMap : IEntityTypeConfiguration<Mensalidade>
    {
        public void Configure(EntityTypeBuilder<Mensalidade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Valor).HasPrecision(5, 2);
            builder.HasOne(x => x.Aluno).WithMany();
        }
    }
}
