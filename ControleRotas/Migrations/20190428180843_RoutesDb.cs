using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleRotas.Migrations
{
    public partial class RoutesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NivelAcesso = table.Column<string>(maxLength: 10, nullable: false, defaultValue: "0"),
                    Cargo = table.Column<string>(nullable: true),
                    TrocarSenha = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(maxLength: 25, nullable: false),
                    Modelo = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Ano = table.Column<string>(nullable: true),
                    Renavan = table.Column<string>(nullable: true),
                    Disponivel = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false),
                    NomeComp = table.Column<string>(maxLength: 50, nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    TipoContrante = table.Column<string>(maxLength: 20, nullable: false),
                    Status = table.Column<string>(maxLength: 20, nullable: false),
                    TipoPessoa = table.Column<string>(maxLength: 20, nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: true),
                    Cpf_Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    InscrEstadual = table.Column<string>(name: "Inscr. Estadual", maxLength: 20, nullable: true),
                    InscrMunicipal = table.Column<string>(name: "Inscr. Municipal", nullable: true),
                    Grupo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoa_Funcionario_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    AgendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCompromisso = table.Column<string>(maxLength: 20, nullable: false),
                    Compromisso = table.Column<string>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataInativacao = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.AgendaId);
                    table.ForeignKey(
                        name: "FK_Agenda_Pessoa_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agenda_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<int>(nullable: false),
                    EndEmail = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Email_Pessoa_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    CodIbge = table.Column<int>(maxLength: 20, nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: false),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(nullable: false),
                    NumTelefone = table.Column<string>(nullable: true),
                    TipoTelefone = table.Column<string>(maxLength: 11, nullable: false),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.TelefoneId);
                    table.ForeignKey(
                        name: "FK_Telefone_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefone_Pessoa_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    OrdemServicoId = table.Column<int>(nullable: false),
                    Ativo = table.Column<string>(nullable: false),
                    Urgencia = table.Column<string>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    DataPagamento = table.Column<DateTime>(nullable: true),
                    SolicitantePessoaId = table.Column<int>(nullable: true),
                    Passageiro = table.Column<string>(nullable: true),
                    EndBaseEnderecoId = table.Column<int>(nullable: true),
                    EndOrigemEnderecoId = table.Column<int>(nullable: true),
                    EndDestinoEnderecoId = table.Column<int>(nullable: true),
                    KmPercorrida = table.Column<string>(nullable: true),
                    ValorPedagio = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    ValorCobrado = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    Acrescimo = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    NumOs = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    NfSeMotorista = table.Column<string>(nullable: true),
                    SituacaoServico = table.Column<string>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.OrdemServicoId);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Endereco_EndBaseEnderecoId",
                        column: x => x.EndBaseEnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Endereco_EndDestinoEnderecoId",
                        column: x => x.EndDestinoEnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Endereco_EndOrigemEnderecoId",
                        column: x => x.EndOrigemEnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Agenda_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "Agenda",
                        principalColumn: "AgendaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Pessoa_SolicitantePessoaId",
                        column: x => x.SolicitantePessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PessoaId",
                table: "Agenda",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_PessoaId",
                table: "Email",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_EndBaseEnderecoId",
                table: "OrdemServico",
                column: "EndBaseEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_EndDestinoEnderecoId",
                table: "OrdemServico",
                column: "EndDestinoEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_EndOrigemEnderecoId",
                table: "OrdemServico",
                column: "EndOrigemEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_SolicitantePessoaId",
                table: "OrdemServico",
                column: "SolicitantePessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_VeiculoId",
                table: "OrdemServico",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaId",
                table: "Telefone",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
