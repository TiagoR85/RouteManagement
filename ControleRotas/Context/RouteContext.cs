using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ControleRotas.Context
{
    public class RouteContext : DbContext
    {
        public RouteContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //                        .SetBasePath(Directory.GetCurrentDirectory())
        //                        .AddJsonFile("appsettings.json");

        //    var configuration = builder.Build();
        //    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:RouteContext"]);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Pessoa

            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.PessoaId);

            modelBuilder.Entity<Pessoa>()
                .HasOne(f => f.Funcionario).WithOne(p => p.Pessoa)
                .HasForeignKey<Pessoa>(p => p.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pessoa>()
                .Property(i => i.NomeComp).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Pessoa>()
                .Property(ie => ie.Ie_Rg).HasColumnName("Inscr. Estadual");

            modelBuilder.Entity<Pessoa>()
                .Property(im => im.InscrMunicipal).HasColumnName("Inscr. Municipal");

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Status).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoPessoa).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoContrante).HasConversion<string>().HasMaxLength(20);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Telefones).WithOne()
                .HasForeignKey(t => t.TelefoneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Enderecos).WithOne()
                .HasForeignKey(t => t.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Emails).WithOne()
                .HasForeignKey(t => t.EmailId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Agendas).WithOne()
                .HasForeignKey(t => t.AgendaId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Telefone

            modelBuilder.Entity<Telefone>()
                .HasKey(i => i.TelefoneId);

            modelBuilder.Entity<Telefone>()
                .Property(e => e.TipoTelefone).HasConversion<string>().HasMaxLength(11);

            #endregion

            #region Endereco

            modelBuilder.Entity<Endereco>()
                .HasKey(i => i.EnderecoId);
            
            modelBuilder.Entity<Endereco>()
                .HasOne(m => m.Municipio).WithOne(e => e.Endereco)
                .HasForeignKey<Municipio>(m => m.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Municipio>()
                .ToTable("Endereco");

            modelBuilder.Entity<Endereco>()
                .ToTable("Endereco");

            modelBuilder.Entity<Endereco>()
                .Property(i => i.Logradouro).IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Endereco>()
                .Property(i => i.Bairro).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Endereco>()
                .Property(i => i.Cep).IsRequired()
                .HasMaxLength(8);
            
            #endregion

            #region Email

            modelBuilder.Entity<Email>()
                .HasKey(i => i.EmailId);

            #endregion

            #region Veiculo

            modelBuilder.Entity<Veiculo>()
                .HasKey(i => i.VeiculoId);

            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Marca).HasConversion<string>()
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Status).HasConversion<string>();

            #endregion

            #region OrdemServico

            modelBuilder.Entity<OrdemServico>().
                HasKey(os => os.OrdemServicoId);

            modelBuilder.Entity<OrdemServico>()
                .Property(e => e.Ativo).HasConversion<string>();

            modelBuilder.Entity<OrdemServico>()
                .Property(e => e.SituacaoServico).HasConversion<string>();

            modelBuilder.Entity<OrdemServico>()
                .Property(e => e.Urgencia).HasConversion<string>();

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
                .HasKey(f => f.FuncionarioId);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Senha).IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.NivelAcesso)
                .HasDefaultValue(0)
                .HasMaxLength(10).IsRequired();

            #endregion

            #region Agenda

            modelBuilder.Entity<Agenda>()
                .HasOne(p => p.OrdemServico).WithOne(os => os.Agenda)
                .HasForeignKey<OrdemServico>(os => os.OrdemServicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>()
                .Property(e => e.NomeCompromisso)
                .HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Agenda>()
                .HasKey(a => a.AgendaId);

            //modelBuilder.Entity<Agenda>()
            //    .Property(e => e.Status).HasConversion<string>();

            modelBuilder.Entity<Agenda>()
                .Property(p => p.Valor).HasColumnType("decimal(6, 2)");

            #endregion

            #region Munnicipio

            modelBuilder.Entity<Municipio>()
                .HasKey(m => m.EnderecoId);

            modelBuilder.Entity<Municipio>()
                .Property(e => e.CodIbge)
                .HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Municipio>()
                .Property(e => e.Uf).HasConversion<string>();

            #endregion

        }

        // public DbSet<Pessoa> Pessoas { get; set; }
        // public DbSet<Funcionario> Funcionarios { get; set; }
        // public DbSet<Telefone> Telefones { get; set; }
        // public DbSet<Email> Emails { get; set; }
        // public DbSet<Endereco> Enderecos { get; set; }
        // public DbSet<Veiculo> Veiculos { get; set; }
        // public DbSet<Motorista> Motoristas { get; set; }

    }
}


//https://docs.microsoft.com/pt-br/ef/core/modeling/value-conversions