﻿// <auto-generated />
using System;
using ControleRotas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleRotas.Migrations
{
    [DbContext(typeof(RouteContext))]
    [Migration("20190502052208_RouteDb")]
    partial class RouteDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleRotas.Models.Agenda", b =>
                {
                    b.Property<int>("AgendaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Compromisso")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("date");

                    b.Property<short?>("FKOrdemServicoId")
                        .HasColumnType("smallint");

                    b.Property<string>("NomeCompromisso")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PessoaId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("AgendaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ControleRotas.Models.Email", b =>
                {
                    b.Property<int>("EmailId");

                    b.Property<string>("EndEmail")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PessoaId");

                    b.HasKey("EmailId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Email");

                    b.HasData(
                        new
                        {
                            EmailId = 1,
                            EndEmail = "tiago.rds85@hotmail.com"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("MunicipioId");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(7)")
                        .HasMaxLength(7);

                    b.Property<int?>("PessoaId");

                    b.HasKey("EnderecoId");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Endereco");

                    b.HasData(
                        new
                        {
                            EnderecoId = 1,
                            Bairro = "Forquilhas",
                            Cep = "88107100",
                            Complemento = "Bloco 6 Apto 304",
                            Logradouro = "Rua Antônio Jovita Duarte",
                            Numero = "3147"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<string>("NivelAcesso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .HasDefaultValue("0");

                    b.Property<int?>("PessoaId");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("TrocarSenha");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("FuncionarioId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Funcionario");

                    b.HasData(
                        new
                        {
                            FuncionarioId = 1,
                            Cargo = "SuperAdmin",
                            NivelAcesso = "1234567890",
                            Senha = "Abc123@",
                            TrocarSenha = false,
                            UserName = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.Municipio", b =>
                {
                    b.Property<int>("MunicipioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodIbge")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Pais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .HasDefaultValue("Brasil");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("MunicipioId");

                    b.ToTable("Municipio");

                    b.HasData(
                        new
                        {
                            MunicipioId = 1,
                            CodIbge = "4216602",
                            Nome = "São José",
                            Pais = "Brasil",
                            Uf = "SantaCatarina"
                        },
                        new
                        {
                            MunicipioId = 2,
                            CodIbge = "4205407",
                            Nome = "Florianópolis",
                            Uf = "SantaCatarina"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.OrdemServico", b =>
                {
                    b.Property<int>("OrdemServicoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Acrescimo")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("Ativo");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Desconto")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("EndBase")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("EndDestino")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("EndOrigem")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<short?>("FkAgenda")
                        .HasColumnType("smallint");

                    b.Property<short?>("FkPessoaIdSolicitante")
                        .HasColumnType("smallint");

                    b.Property<short?>("FkVeiculo")
                        .HasColumnType("smallint");

                    b.Property<string>("KmPercorrida")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("NfSeMotorista")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("NumOs")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Passageiro")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("SituacaoServico")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Urgencia")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<decimal?>("ValorCobrado")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("ValorPedagio")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("ValorTotal")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("OrdemServicoId");

                    b.ToTable("OrdemServico");
                });

            modelBuilder.Entity("ControleRotas.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf_Cnpj")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("date");

                    b.Property<string>("Grupo")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Ie_Rg")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("InscrMunicipal")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Nascimento")
                        .HasColumnType("date");

                    b.Property<string>("NomeComp")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoCadastro")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            PessoaId = 1,
                            Cpf_Cnpj = "00937879959",
                            DataAlteracao = new DateTime(2019, 5, 2, 2, 22, 7, 638, DateTimeKind.Local).AddTicks(967),
                            DataInclusao = new DateTime(2019, 5, 2, 2, 22, 7, 638, DateTimeKind.Local).AddTicks(967),
                            Grupo = "SuperUser",
                            Ie_Rg = "3808964",
                            Nascimento = new DateTime(1985, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeComp = "Tiago Rodrigues",
                            Status = "Ativo",
                            TipoCadastro = "Usuario",
                            TipoPessoa = "Pessoa_Fisica"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.Telefone", b =>
                {
                    b.Property<int>("TelefoneId");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("NumTelefone")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("PessoaId");

                    b.Property<string>("TipoTelefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("TelefoneId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Telefone");

                    b.HasData(
                        new
                        {
                            TelefoneId = 1,
                            DDD = "48",
                            NumTelefone = "984710744",
                            TipoTelefone = "Celular"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .HasColumnType("varchar(4)")
                        .HasMaxLength(4);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("date");

                    b.Property<string>("Disponivel")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Placa")
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Renavan")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("VeiculoId");

                    b.ToTable("Veiculo");

                    b.HasData(
                        new
                        {
                            VeiculoId = 1,
                            Ano = "2010",
                            DataAlteracao = new DateTime(2019, 5, 2, 2, 22, 7, 663, DateTimeKind.Local).AddTicks(4259),
                            DataInclusao = new DateTime(2019, 5, 2, 2, 22, 7, 663, DateTimeKind.Local).AddTicks(4259),
                            Disponivel = "Sim",
                            Marca = "PEUGEOT",
                            Modelo = "206",
                            Placa = "MFG-1993",
                            Renavan = "1234567890",
                            Status = "Ativo"
                        });
                });

            modelBuilder.Entity("ControleRotas.Models.Agenda", b =>
                {
                    b.HasOne("ControleRotas.Models.Pessoa")
                        .WithMany("Agendas")
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("ControleRotas.Models.Email", b =>
                {
                    b.HasOne("ControleRotas.Models.Pessoa")
                        .WithMany("Emails")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ControleRotas.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("ControleRotas.Models.Endereco", b =>
                {
                    b.HasOne("ControleRotas.Models.Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ControleRotas.Models.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.HasOne("ControleRotas.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("ControleRotas.Models.Funcionario", b =>
                {
                    b.HasOne("ControleRotas.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("ControleRotas.Models.Telefone", b =>
                {
                    b.HasOne("ControleRotas.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.HasOne("ControleRotas.Models.Pessoa")
                        .WithMany("Telefones")
                        .HasForeignKey("TelefoneId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
