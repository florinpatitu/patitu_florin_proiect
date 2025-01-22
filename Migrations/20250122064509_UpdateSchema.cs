using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patitu_florin_proiect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SarciniService_Piese_PiesaID",
                table: "SarciniService");

            migrationBuilder.AddForeignKey(
                name: "FK_SarciniService_Piese_PiesaID",
                table: "SarciniService",
                column: "PiesaID",
                principalTable: "Piese",
                principalColumn: "PiesaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SarciniService_Piese_PiesaID",
                table: "SarciniService");

            migrationBuilder.AddForeignKey(
                name: "FK_SarciniService_Piese_PiesaID",
                table: "SarciniService",
                column: "PiesaID",
                principalTable: "Piese",
                principalColumn: "PiesaID");
        }
    }
}
