using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleRotas.Migrations
{
    public partial class QueryFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "MunicipioId",
                keyValue: 1,
                column: "CodIbge",
                value: "4216602");

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "MunicipioId",
                keyValue: 2,
                column: "CodIbge",
                value: "4205407");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataInclusao" },
                values: new object[] { new DateTime(2019, 5, 2, 2, 37, 35, 342, DateTimeKind.Local).AddTicks(6325), new DateTime(2019, 5, 2, 2, 37, 35, 342, DateTimeKind.Local).AddTicks(6325) });

            migrationBuilder.UpdateData(
                table: "Veiculo",
                keyColumn: "VeiculoId",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataInclusao" },
                values: new object[] { new DateTime(2019, 5, 2, 2, 37, 35, 361, DateTimeKind.Local).AddTicks(3318), new DateTime(2019, 5, 2, 2, 37, 35, 361, DateTimeKind.Local).AddTicks(3318) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "MunicipioId",
                keyValue: 1,
                column: "CodIbge",
                value: null);

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "MunicipioId",
                keyValue: 2,
                column: "CodIbge",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "PessoaId",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataInclusao" },
                values: new object[] { new DateTime(2019, 5, 2, 2, 22, 7, 638, DateTimeKind.Local).AddTicks(967), new DateTime(2019, 5, 2, 2, 22, 7, 638, DateTimeKind.Local).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Veiculo",
                keyColumn: "VeiculoId",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataInclusao" },
                values: new object[] { new DateTime(2019, 5, 2, 2, 22, 7, 663, DateTimeKind.Local).AddTicks(4259), new DateTime(2019, 5, 2, 2, 22, 7, 663, DateTimeKind.Local).AddTicks(4259) });
        }
    }
}
