using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoColeta.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontosColeta",
                columns: table => new
                {
                    IdPontoColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePonto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CapacidadeMaxima = table.Column<double>(type: "float", nullable: false),
                    StatusPonto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosColeta", x => x.IdPontoColeta);
                });

            migrationBuilder.CreateTable(
                name: "TiposResiduos",
                columns: table => new
                {
                    IdTipoResiduo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Reciclavel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposResiduos", x => x.IdTipoResiduo);
                });

            migrationBuilder.CreateTable(
                name: "ColetasResiduos",
                columns: table => new
                {
                    IdColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataColeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    IdPontoColeta = table.Column<int>(type: "int", nullable: false),
                    IdTipoResiduo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColetasResiduos", x => x.IdColeta);
                    table.ForeignKey(
                        name: "FK_ColetasResiduos_PontosColeta_IdPontoColeta",
                        column: x => x.IdPontoColeta,
                        principalTable: "PontosColeta",
                        principalColumn: "IdPontoColeta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColetasResiduos_TiposResiduos_IdTipoResiduo",
                        column: x => x.IdTipoResiduo,
                        principalTable: "TiposResiduos",
                        principalColumn: "IdTipoResiduo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColetasResiduos_IdPontoColeta",
                table: "ColetasResiduos",
                column: "IdPontoColeta");

            migrationBuilder.CreateIndex(
                name: "IX_ColetasResiduos_IdTipoResiduo",
                table: "ColetasResiduos",
                column: "IdTipoResiduo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColetasResiduos");

            migrationBuilder.DropTable(
                name: "PontosColeta");

            migrationBuilder.DropTable(
                name: "TiposResiduos");
        }
    }
}
