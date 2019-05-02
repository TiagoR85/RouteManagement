using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ControleRotas.Mapping
{
    public class OrdemServicoMap : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("OrdemServico");
            builder.HasKey(p => p.OrdemServicoId);

            builder.Property(i => i.Acrescimo)
                .HasColumnType("decimal(6,2)");

            builder.Property(i => i.Desconto)
                .HasColumnType("decimal(6,2)");

            builder.Property(i => i.ValorCobrado)
                .HasColumnType("decimal(6,2)");

            builder.Property(i => i.ValorPedagio)
                .HasColumnType("decimal(6,2)");

            builder.Property(i => i.ValorTotal)
                .HasColumnType("decimal(6,2)");

            //builder.OwnsOne(i => i.EndBase);

            //builder.OwnsOne(i => i.EndDestino);

            //builder.OwnsOne(i => i.EndOrigem);

            builder.Property(ie => ie.FkAgenda)
                .HasColumnType("smallint");

            builder.Property(ie => ie.FkPessoaIdSolicitante)
                .HasColumnType("smallint");
            
            builder.Property(im => im.FkVeiculo)
                .HasColumnType("smallint");

            builder.Property(e => e.SituacaoServico)
                .HasColumnType("varchar(10)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Urgencia)
                .HasColumnType("varchar(10)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Passageiro)
                .HasColumnType("varchar(25)")
                .HasMaxLength(25);

            builder.Property(e => e.Observacao)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(e => e.EndBase)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(e => e.EndDestino)
                .HasColumnType("varchar(500)")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.EndOrigem)
                .HasColumnType("varchar(500)")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.NumOs)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(e => e.NfSeMotorista)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(e => e.KmPercorrida)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);

            builder.Property(p => p.DataInclusao)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataExclusao)
                .HasColumnType("date");

            builder.Property(p => p.DataPagamento)
                .HasColumnType("datetime");

            builder.HasQueryFilter(q => q.DataExclusao == null);
        }
    }
}
