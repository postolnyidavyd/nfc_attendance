using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTapDedupIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Taps_RoomId",
                table: "Taps");

            migrationBuilder.CreateIndex(
                name: "IX_Taps_RoomId_UserId_CreatedAt",
                table: "Taps",
                columns: new[] { "RoomId", "UserId", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Taps_RoomId_UserId_CreatedAt",
                table: "Taps");

            migrationBuilder.CreateIndex(
                name: "IX_Taps_RoomId",
                table: "Taps",
                column: "RoomId");
        }
    }
}
