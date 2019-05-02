using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");
            builder.HasKey(p => p.MunicipioId);

            builder.Property(i => i.CodIbge)
                .HasColumnType("varchar(10)")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(i => i.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired()                
                .HasMaxLength(100);

            builder.Property(ie => ie.Pais)
                .HasColumnType("varchar(20)")
                .HasDefaultValue("Brasil")
                .HasMaxLength(20);

            builder.Property(e => e.Uf)
                .HasColumnType("varchar(25)")
                .HasConversion<string>()
                .IsRequired();

            builder.HasData(new Municipio
            {
                MunicipioId = 1,
                Nome = "São José",
                Uf = Enums.EnumEstadosBr.SantaCatarina,
                CodIbge = 4216602,
                Pais = "Brasil"
            },
            new Municipio
            {
                MunicipioId = 2,
                Nome = "Florianópolis",
                Uf = Enums.EnumEstadosBr.SantaCatarina,
                CodIbge = 4205407
            });
        }
    }
}
