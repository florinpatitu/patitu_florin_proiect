using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patitu_florin_proiect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mecanici",
                columns: table => new
                {
                    MecanicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanici", x => x.MecanicID);
                });

            migrationBuilder.CreateTable(
                name: "Piese",
                columns: table => new
                {
                    PiesaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piese", x => x.PiesaID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    VehiculID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarInmatriculare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.VehiculID);
                });

            migrationBuilder.CreateTable(
                name: "SarciniService",
                columns: table => new
                {
                    SarcinaServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehiculID = table.Column<int>(type: "int", nullable: false),
                    MecanicID = table.Column<int>(type: "int", nullable: false),
                    PiesaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SarciniService", x => x.SarcinaServiceID);
                    table.ForeignKey(
                        name: "FK_SarciniService_Mecanici_MecanicID",
                        column: x => x.MecanicID,
                        principalTable: "Mecanici",
                        principalColumn: "MecanicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SarciniService_Piese_PiesaID",
                        column: x => x.PiesaID,
                        principalTable: "Piese",
                        principalColumn: "PiesaID");
                    table.ForeignKey(
                        name: "FK_SarciniService_Vehicule_VehiculID",
                        column: x => x.VehiculID,
                        principalTable: "Vehicule",
                        principalColumn: "VehiculID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SarciniService_MecanicID",
                table: "SarciniService",
                column: "MecanicID");

            migrationBuilder.CreateIndex(
                name: "IX_SarciniService_PiesaID",
                table: "SarciniService",
                column: "PiesaID");

            migrationBuilder.CreateIndex(
                name: "IX_SarciniService_VehiculID",
                table: "SarciniService",
                column: "VehiculID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SarciniService");

            migrationBuilder.DropTable(
                name: "Mecanici");

            migrationBuilder.DropTable(
                name: "Piese");

            migrationBuilder.DropTable(
                name: "Vehicule");
        }
    }
}
