using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITStudy.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_BuyCourses_BuyCoursesId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_BuyCourses_BuyCourseId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BuyCourseId",
                table: "Reviews",
                newName: "CartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BuyCourseId",
                table: "Reviews",
                newName: "IX_Reviews_CartItemId");

            migrationBuilder.RenameColumn(
                name: "BuyCoursesId",
                table: "CartItems",
                newName: "BuyCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_BuyCoursesId",
                table: "CartItems",
                newName: "IX_CartItems_BuyCourseId");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Share",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_BuyCourses_BuyCourseId",
                table: "CartItems",
                column: "BuyCourseId",
                principalTable: "BuyCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_CartItems_CartItemId",
                table: "Reviews",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_BuyCourses_BuyCourseId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_CartItems_CartItemId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Share",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "Reviews",
                newName: "BuyCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CartItemId",
                table: "Reviews",
                newName: "IX_Reviews_BuyCourseId");

            migrationBuilder.RenameColumn(
                name: "BuyCourseId",
                table: "CartItems",
                newName: "BuyCoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_BuyCourseId",
                table: "CartItems",
                newName: "IX_CartItems_BuyCoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_BuyCourses_BuyCoursesId",
                table: "CartItems",
                column: "BuyCoursesId",
                principalTable: "BuyCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_BuyCourses_BuyCourseId",
                table: "Reviews",
                column: "BuyCourseId",
                principalTable: "BuyCourses",
                principalColumn: "Id");
        }
    }
}
