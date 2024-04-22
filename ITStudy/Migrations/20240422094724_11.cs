using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITStudy.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Users_UsersId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_UsersId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Vouchers");

            migrationBuilder.AlterColumn<long>(
                name: "Discount",
                table: "Vouchers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "BuyCoursesId",
                table: "CartItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BuyCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    PurchasedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CourseName = table.Column<string>(type: "text", nullable: false),
                    PriceCourse = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyCourses_Instructors_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BuyCoursesId",
                table: "CartItems",
                column: "BuyCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyCourses_StudentId",
                table: "BuyCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyCourses_TeacherId",
                table: "BuyCourses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_BuyCourses_BuyCoursesId",
                table: "CartItems",
                column: "BuyCoursesId",
                principalTable: "BuyCourses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_BuyCourses_BuyCoursesId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "BuyCourses");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_BuyCoursesId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "BuyCoursesId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Vouchers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UsersId",
                table: "Vouchers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_UsersId",
                table: "Vouchers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Users_UsersId",
                table: "Vouchers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
