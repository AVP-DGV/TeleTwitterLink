using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class JoinTableforealforeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterUsers_TwitterUsers_TwitterUserId",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "TwitterUser_Id",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "UserTwitterUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TwitterUserId",
                table: "UserTwitterUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterUsers_TwitterUsers_TwitterUserId",
                table: "UserTwitterUsers",
                column: "TwitterUserId",
                principalTable: "TwitterUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterUsers_TwitterUsers_TwitterUserId",
                table: "UserTwitterUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TwitterUserId",
                table: "UserTwitterUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TwitterUser_Id",
                table: "UserTwitterUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "UserTwitterUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterUsers_TwitterUsers_TwitterUserId",
                table: "UserTwitterUsers",
                column: "TwitterUserId",
                principalTable: "TwitterUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
