using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleRotas.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(p => p.EnderecoId);

            builder.Property(i => i.Logradouro)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Bairro)
                .HasColumnType("varchar(50)")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.Cep)
                .HasColumnType("varchar(8)")
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(i => i.Complemento)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(i => i.Numero)
                .HasColumnType("varchar(7)")
                .HasMaxLength(7);

            //builder.Property(m => m.FkMunicipioId)
            //    .HasColumnType("smallint")
            //    .IsRequired();

            builder.HasData(new Endereco
            {
                EnderecoId = 1,
                Logradouro = "Rua Antônio Jovita Duarte",
                Numero = "3147",
                Complemento = "Bloco 6 Apto 304",
                Bairro = "Forquilhas",
                Cep = "88107100"
            });
        }
    }
}
