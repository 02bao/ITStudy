using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITStudy.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Instructors",
                newName: "Avatars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatars",
                table: "Instructors",
                newName: "Images");
        }
    }
}
