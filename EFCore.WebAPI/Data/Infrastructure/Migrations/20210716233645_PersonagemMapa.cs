using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Data.Infrastructure.Migrations
{
    public partial class PersonagemMapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Equipes_EquipeId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_EquipeId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Personagens");

            migrationBuilder.CreateTable(
                name: "Mapas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempoDeGame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemMapas",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    MapaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemMapas", x => new { x.MapaId, x.PersonagemId });
                    table.ForeignKey(
                        name: "FK_PersonagemMapas_Mapas_MapaId",
                        column: x => x.MapaId,
                        principalTable: "Mapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemMapas_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemMapas_PersonagemId",
                table: "PersonagemMapas",
                column: "PersonagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemMapas");

            migrationBuilder.DropTable(
                name: "Mapas");

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_EquipeId",
                table: "Personagens",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Equipes_EquipeId",
                table: "Personagens",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
