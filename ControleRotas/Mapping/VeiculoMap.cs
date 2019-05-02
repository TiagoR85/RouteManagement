using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");
            builder.HasKey(p => p.VeiculoId);

            builder.Property(i => i.Modelo)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(i => i.Ano)
                .HasColumnType("varchar(4)")
                .HasMaxLength(4);

            builder.Property(i => i.Placa)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);

            builder.Property(ie => ie.Renavan)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
            
            builder.Property(e => e.Status)
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Marca)
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Disponivel)
                .HasColumnType("varchar(4)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.DataInclusao)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataExclusao)
                .HasColumnType("date");

            builder.HasQueryFilter(q => q.DataExclusao == null);

            builder.HasData(
                new Veiculo
                {
                    Ano = "2010",
                    Marca = Enums.EnumMarcaVeiculo.PEUGEOT,
                    Modelo = "206",
                    Placa = "MFG-1993",
                    VeiculoId = 1,
                    Renavan = "1234567890"
                });
        }
    }
}
