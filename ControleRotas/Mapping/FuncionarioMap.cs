using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(p => p.FuncionarioId);

            builder.Property(i => i.Cargo)
                .HasColumnType("varchar(20)")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ie => ie.NivelAcesso)
                .HasColumnType("varchar(10)")
                .HasDefaultValue(0)
                .HasMaxLength(10);

            builder.Property(ie => ie.UserName)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(ie => ie.Senha)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(p => p.DataExclusao)
                .HasColumnType("datetime");

            builder.HasQueryFilter(q => q.DataExclusao == null);

            builder.HasData(new Funcionario
            {
                FuncionarioId = 1,
                Cargo = "SuperAdmin",
                IsSuperUser = true,
                NivelAcesso = "1234567890",
                Senha = "Abc123@",
                UserName = "SuperAdmin"
            });
        }
    }
}
