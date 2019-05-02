using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(p => p.PessoaId);

            builder.Property(i => i.NomeComp)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.RazaoSocial)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(ie => ie.Cpf_Cnpj)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14);

            builder.Property(ie => ie.Grupo)
                .HasColumnType("varchar(25)")
                .HasMaxLength(25);

            builder.Property(ie => ie.Ie_Rg)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
            
            builder.Property(im => im.InscrMunicipal)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(e => e.Status)
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.TipoPessoa)
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.TipoCadastro)
                .HasColumnType("varchar(20)")
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

            builder.Property(p => p.Nascimento)
                .HasColumnType("date");

            builder.HasMany(p => p.Telefones)
                .WithOne()
                .HasForeignKey(fk => fk.TelefoneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Enderecos)
                .WithOne()
                .HasForeignKey(fk => fk.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Emails)
                .WithOne()
                .HasForeignKey(fk => fk.EmailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(q => q.DataExclusao == null);

            builder.HasData(
                new Pessoa
                {
                    PessoaId = 1,
                    NomeComp = "Tiago Rodrigues",
                    Cpf_Cnpj = "00937879959",
                    Ie_Rg = "3808964",
                    Grupo = "SuperUser",
                    Nascimento = new System.DateTime(1985, 11, 23),
                    TipoCadastro = Enums.TipoContrante.Usuario,
                    TipoPessoa = Enums.TipoPessoa.Pessoa_Fisica
                });
        }
    }
}
