using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPHoteisAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quartos_hoteis_HotelId",
                table: "quartos");

            migrationBuilder.DropIndex(
                name: "IX_quartos_HotelId",
                table: "quartos");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "quartos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "quartos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_quartos_HotelId",
                table: "quartos",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_quartos_hoteis_HotelId",
                table: "quartos",
                column: "HotelId",
                principalTable: "hoteis",
                principalColumn: "Id");
        }
    }
}
