using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Context
{
    public class RouteContext : DbContext
    {
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Pessoa

            modelBuilder.Entity<Pessoa>()
                .Property(i => i.NomeComp).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Telefones)
                .WithOne()
                .HasForeignKey(t => t.PessoaId);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Emails)
                .WithOne()
                .HasForeignKey(e => e.PessoaId); ;

            modelBuilder.Entity<Pessoa>()
                .HasMany(end => end.Enderecos)
                .WithOne()
                .HasForeignKey(end => end.PessoaId); ;

            modelBuilder.Entity<Pessoa>()
                .HasKey(i => i.PessoaId);

            modelBuilder.Entity<Pessoa>()
                .Property(im => im.InscrMunicipal).HasColumnName("Inscr. Municipal");

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Ativo).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoPessoa).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoContrante).HasConversion<string>().HasMaxLength(20);

            #endregion
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}


//https://docs.microsoft.com/pt-br/ef/core/modeling/value-conversions