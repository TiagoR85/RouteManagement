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
                .HasKey(i => i.PessoaId);
				
			// modelBuilder.Entity<Pessoa>()
				// .HasMany(end => end.Enderecos)
				// .WithOne();

            modelBuilder.Entity<Pessoa>()
                .Property(i => i.NomeComp).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Pessoa>()
                .Property(ie => ie.Ie_Rg).HasColumnName("Inscr. Estadual");

			modelBuilder.Entity<Pessoa>()
                .Property(im => im.InscrMunicipal).HasColumnName("Inscr. Municipal");
				
            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Ativo).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoPessoa).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoContrante).HasConversion<string>().HasMaxLength(20);

            #endregion
			
			#region Telefone
			
			modelBuilder.Entity<Telefone>()
                .HasOne(p => p.Pessoa)
                .WithMany(t => t.Telefones)
                .HasForeignKey(p => p.PessoaId);
			
			modelBuilder.Entity<Telefone>()
                .HasKey(i => i.TelefoneId);
				
			modelBuilder.Entity<Telefone>()
                .Property(e => e.TipoTelefone).HasConversion<string>().HasMaxLength(11);
			
			#endregion
			
			#region Endereco
			
			modelBuilder.Entity<Endereco>()
                .HasKey(i => i.EnderecoId);
			
			modelBuilder.Entity<Municipio>()
				.ToTable("Endereco");

			modelBuilder.Entity<Endereco>()
				.ToTable("Endereco")
				.HasOne(m => m.Municipio).WithOne()
				.HasForeignKey<Endereco>(m => m.MunicipioId);
				
			modelBuilder.Entity<Endereco>()
                .Property(e => e.Uf).HasConversion<string>().HasMaxLength(30);
			
			modelBuilder.Entity<Endereco>()
                .HasOne<Pessoa>(p => p.Pessoa)
                .WithMany(end => end.Enderecos)
                .HasForeignKey(p => p.PessoaId);
				
			modelBuilder.Entity<Endereco>()
                .Property(i => i.Logradouro).IsRequired()
                .HasMaxLength(200);
			
			modelBuilder.Entity<Endereco>()
                .Property(i => i.Bairro).IsRequired()
                .HasMaxLength(200);
				
				modelBuilder.Entity<Endereco>()
                .Property(i => i.Cep).IsRequired()
                .HasMaxLength(8);
				
				modelBuilder.Entity<Endereco>()
                .Property<Municipio>(m => m.Municipio).IsRequired()
                .HasMaxLength(200);
				
			#endregion
			
			#region Email
			
			modelBuilder.Entity<Email>()
                .HasOne<Pessoa>(p => p.Pessoa)
                .WithOne();
			
			modelBuilder.Entity<Email>()
                .HasKey(i => i.EmailId);
			
			#endregion
			
			#region Veiculo
			
			modelBuilder.Entity<Veiculo>()
                .HasKey(i => i.VeiculoId);

            // modelBuilder.Entity<Veiculo>()
                // .Property(i => i.Marca).IsRequired()
                // .HasMaxLength(50);

            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Marca).HasConversion<string>()
				.HasMaxLength(25)
				.IsRequired();

			modelBuilder.Entity<Veiculo>()
                .Property(e => e.Ativo).HasConversion<string>();

			#endregion
			
			#region OrdemServico
			
			modelBuilder.Entity<OrdemServico>()
                .Property(e => e.Ativo).HasConversion<string>();

			modelBuilder.Entity<OrdemServico>()
                .Property(e => e.SituacaoServico).HasConversion<string>();

			modelBuilder.Entity<OrdemServico>()
                .Property(p => p.ValorPedagio).HasColumnType("decimal(6, 2)");
				
			modelBuilder.Entity<OrdemServico>()
                .Property(p => p.ValorCobrado).HasColumnType("decimal(6, 2)");
			
			modelBuilder.Entity<OrdemServico>()
                .Property(p => p.Acrescimo).HasColumnType("decimal(6, 2)");
			
			modelBuilder.Entity<OrdemServico>()
                .Property(p => p.Desconto).HasColumnType("decimal(6, 2)");

			modelBuilder.Entity<OrdemServico>()
                .Property(p => p.ValorTotal).HasColumnType("decimal(6, 2)");
				
			#endregion
	
			#region Funcionario
			
			modelBuilder.Entity<Funcionario>()
                .HasOne(p => p.Pessoa)
				.WithOne();

			modelBuilder.Entity<Funcionario>()
                .Property(e => e.Senha).IsRequired();

			modelBuilder.Entity<Funcionario>()
                .Property(e => e.NivelAcesso)
				.HasDefaultValue(0)
				.HasMaxLength(10).IsRequired();
				
			#endregion
		
		}
		
		// public DbSet<Pessoa> Pessoas { get; set; }
		// public DbSet<Funcionario> Funcionarios { get; set; }
        // public DbSet<Telefone> Telefones { get; set; }
        // public DbSet<Email> Emails { get; set; }
        // public DbSet<Endereco> Enderecos { get; set; }
        // public DbSet<Veiculo> Veiculos { get; set; }
		public DbSet<Motorista> Motoristas { get; set; }
		
    }
}


//https://docs.microsoft.com/pt-br/ef/core/modeling/value-conversions