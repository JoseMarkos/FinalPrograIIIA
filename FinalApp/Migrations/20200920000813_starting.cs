using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalApp.Migrations
{
    public partial class starting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelefonoCiudadEnsanblajes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoCiudadEnsanblajes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoColores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoColores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoGamas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoGamas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonoCiudadEnsanblajeId = table.Column<int>(nullable: true),
                    TelefonoGamaId = table.Column<int>(nullable: true),
                    TelefonoColorId = table.Column<int>(nullable: true),
                    ProductionPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefonos_TelefonoCiudadEnsanblajes_TelefonoCiudadEnsanblajeId",
                        column: x => x.TelefonoCiudadEnsanblajeId,
                        principalTable: "TelefonoCiudadEnsanblajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefonos_TelefonoColores_TelefonoColorId",
                        column: x => x.TelefonoColorId,
                        principalTable: "TelefonoColores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefonos_TelefonoGamas_TelefonoGamaId",
                        column: x => x.TelefonoGamaId,
                        principalTable: "TelefonoGamas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    TelefonoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Telefonos_TelefonoId",
                        column: x => x.TelefonoId,
                        principalTable: "Telefonos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_TelefonoId",
                table: "Registros",
                column: "TelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_TelefonoCiudadEnsanblajeId",
                table: "Telefonos",
                column: "TelefonoCiudadEnsanblajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_TelefonoColorId",
                table: "Telefonos",
                column: "TelefonoColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_TelefonoGamaId",
                table: "Telefonos",
                column: "TelefonoGamaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "TelefonoCiudadEnsanblajes");

            migrationBuilder.DropTable(
                name: "TelefonoColores");

            migrationBuilder.DropTable(
                name: "TelefonoGamas");
        }
    }
}
