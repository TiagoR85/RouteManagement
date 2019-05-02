using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleRotas.Migrations
{
    public partial class RouteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    MunicipioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodIbge = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Uf = table.Column<string>(type: "varchar(25)", nullable: false),
                    Pais = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValue: "Brasil")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.MunicipioId);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    OrdemServicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<int>(nullable: false),
                    Urgencia = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "date", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "date", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    FkPessoaIdSolicitante = table.Column<short>(type: "smallint", nullable: true),
                    Passageiro = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    EndBase = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    EndOrigem = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    EndDestino = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    KmPercorrida = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    ValorPedagio = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    ValorCobrado = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Acrescimo = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    NumOs = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Observacao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    NfSeMotorista = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    SituacaoServico = table.Column<string>(type: "varchar(10)", nullable: false),
                    FkVeiculo = table.Column<short>(type: "smallint", nullable: true),
                    FkAgenda = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.OrdemServicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeComp = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "date", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "date", nullable: true),
                    TipoCadastro = table.Column<string>(type: "varchar(20)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoPessoa = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: true),
                    Cpf_Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Ie_Rg = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    InscrMunicipal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Grupo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "varchar(20)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Placa = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    Ano = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    Renavan = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Disponivel = table.Column<string>(type: "varchar(4)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "date", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    AgendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCompromisso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Compromisso = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "date", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataInativacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    FKOrdemServicoId = table.Column<short>(type: "smallint", nullable: true),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.AgendaId);
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
                    EndEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
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
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    MunicipioId = table.Column<int>(nullable: true),
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
                        name: "FK_Endereco_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NivelAcesso = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValue: "0"),
                    Cargo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TrocarSenha = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Senha = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Pessoa_PessoaId",
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
                    NumTelefone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DDD = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    TipoTelefone = table.Column<string>(type: "varchar(20)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Cargo", "DataExclusao", "NivelAcesso", "PessoaId", "Senha", "TrocarSenha", "UserName" },
                values: new object[] { 1, "SuperAdmin", null, "1234567890", null, "Abc123@", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "Municipio",
                columns: new[] { "MunicipioId", "CodIbge", "Nome", "Pais", "Uf" },
                values: new object[,]
                {
                    { 1, "4216602", "São José", "Brasil", "SantaCatarina" },
                    { 2, "4205407", "Florianópolis", "Brasil", "SantaCatarina" }
                });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "PessoaId", "Cpf_Cnpj", "DataAlteracao", "DataExclusao", "DataInclusao", "Grupo", "Ie_Rg", "InscrMunicipal", "Nascimento", "NomeComp", "RazaoSocial", "Status", "TipoCadastro", "TipoPessoa" },
                values: new object[] { 1, "00937879959", new DateTime(2019, 5, 2, 2, 22, 7, 638, DateTimeKind.Local).AddTicks(967), null, new DateTime(2019, 5, 2, 2, 22, 7, 638, DateTimeKind.Local).AddTicks(967), "SuperUser", "3808964", null, new DateTime(1985, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiago Rodrigues", null, "Ativo", "Usuario", "Pessoa_Fisica" });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "VeiculoId", "Ano", "DataAlteracao", "DataExclusao", "DataInclusao", "Disponivel", "Marca", "Modelo", "Placa", "Renavan", "Status" },
                values: new object[] { 1, "2010", new DateTime(2019, 5, 2, 2, 22, 7, 663, DateTimeKind.Local).AddTicks(4259), null, new DateTime(2019, 5, 2, 2, 22, 7, 663, DateTimeKind.Local).AddTicks(4259), "Sim", "PEUGEOT", "206", "MFG-1993", "1234567890", "Ativo" });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "EmailId", "EndEmail", "PessoaId" },
                values: new object[] { 1, "tiago.rds85@hotmail.com", null });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "EnderecoId", "Bairro", "Cep", "Complemento", "Logradouro", "MunicipioId", "Numero", "PessoaId" },
                values: new object[] { 1, "Forquilhas", "88107100", "Bloco 6 Apto 304", "Rua Antônio Jovita Duarte", null, "3147", null });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "TelefoneId", "DDD", "NumTelefone", "PessoaId", "TipoTelefone" },
                values: new object[] { 1, "48", "984710744", null, "Celular" });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PessoaId",
                table: "Agenda",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_PessoaId",
                table: "Email",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_MunicipioId",
                table: "Endereco",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaId",
                table: "Telefone",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
