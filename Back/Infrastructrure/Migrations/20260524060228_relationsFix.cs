using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro");

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro",
                column: "IdReserva",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro");

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro",
                column: "IdReserva");
        }
    }
}
