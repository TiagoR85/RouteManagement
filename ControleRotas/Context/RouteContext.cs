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
			modelBuilder.Entity<Pessoa>()
				.Property(e => e.Ativo).HasConversion<string>()
				.Property(e => e.TipoPessoa).HasConversion<string>()
				.Property(e => e.TipoContrante).HasConversion<string>()
				.Property(p => p.NomeComp).IsRequired()
				.HasKey(p => p.PessoaId);
        }
		
		public DbSet<Pessoa> Pessoas { get; set; }
    }
}


https://docs.microsoft.com/pt-br/ef/core/modeling/value-conversions