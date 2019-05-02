using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");
            builder.HasKey(p => p.AgendaId);

            builder.Property(i => i.Compromisso)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(i => i.NomeCompromisso)
                .HasColumnType("varchar(50)")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ie => ie.FKOrdemServicoId)
                .HasColumnType("smallint");

            builder.Property(ie => ie.Valor)
                .HasColumnType("decimal(6,2)");
            
            builder.Property(p => p.DataInclusao)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataInativacao)
                .HasColumnType("datetime");

            builder.HasQueryFilter(q => q.DataInativacao == null);
        }
    }
}
