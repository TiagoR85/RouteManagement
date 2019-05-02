using ControleRotas.Mapping;
using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleRotas.Context
{
    public class RouteContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<OrdemServico> OrdemServicos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

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
            modelBuilder.ApplyConfiguration(new PessoaMap());

            modelBuilder.ApplyConfiguration(new TelefoneMap());

            modelBuilder.ApplyConfiguration(new EnderecoMap());

            modelBuilder.ApplyConfiguration(new EmailMap());

            modelBuilder.ApplyConfiguration(new VeiculoMap());

            modelBuilder.ApplyConfiguration(new OrdemServicoMap());

            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            modelBuilder.ApplyConfiguration(new AgendaMap());

            modelBuilder.ApplyConfiguration(new MunicipioMap());

        }
    }
}


//https://docs.microsoft.com/pt-br/ef/core/modeling/value-conversions