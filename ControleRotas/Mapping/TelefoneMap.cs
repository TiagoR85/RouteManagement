using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");
            builder.HasKey(p => p.TelefoneId);

            builder.Property(i => i.DDD)
                .HasColumnType("varchar(3)")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(i => i.NumTelefone)
                .HasColumnType("varchar(10)")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(t => t.TipoTelefone)
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.HasData(new Telefone
            {
                DDD = "48",
                NumTelefone = "984710744",
                TelefoneId = 1,
                TipoTelefone = Enums.TipoTelefone.Celular
            });
        }
    }
}
