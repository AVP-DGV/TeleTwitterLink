using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class removeRealationshipsBetweenUsersAndTwitterUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TwitterUsers_TwitterUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TwitterUsers_AspNetUsers_UserId",
                table: "TwitterUsers");

            migrationBuilder.DropIndex(
                name: "IX_TwitterUsers_UserId",
                table: "TwitterUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TwitterUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TwitterUsers");

            migrationBuilder.DropColumn(
                name: "TwitterUserId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TwitterUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TwitterUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TwitterUsers_UserId",
                table: "TwitterUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TwitterUserId",
                table: "AspNetUsers",
                column: "TwitterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TwitterUsers_TwitterUserId",
                table: "AspNetUsers",
                column: "TwitterUserId",
                principalTable: "TwitterUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TwitterUsers_AspNetUsers_UserId",
                table: "TwitterUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
