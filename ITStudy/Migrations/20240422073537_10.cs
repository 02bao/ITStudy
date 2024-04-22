﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITStudy.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}