using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITStudy.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Instructors_TeacherId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_TeacherId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "CartItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TeacherId",
                table: "CartItems",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Instructors_TeacherId",
                table: "CartItems",
                column: "TeacherId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
