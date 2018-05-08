using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class removePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterUsers_AspNetUsers_UserId",
                table: "UserTwitterUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTwitterUsers",
                table: "UserTwitterUsers");

            migrationBuilder.DropIndex(
                name: "IX_UserTwitterUsers_TwitterUserId",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserTwitterUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTwitterUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTwitterUsers",
                table: "UserTwitterUsers",
                columns: new[] { "TwitterUserId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterUsers_AspNetUsers_UserId",
                table: "UserTwitterUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterUsers_AspNetUsers_UserId",
                table: "UserTwitterUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTwitterUsers",
                table: "UserTwitterUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTwitterUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTwitterUsers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserTwitterUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserTwitterUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTwitterUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserTwitterUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTwitterUsers",
                table: "UserTwitterUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTwitterUsers_TwitterUserId",
                table: "UserTwitterUsers",
                column: "TwitterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterUsers_AspNetUsers_UserId",
                table: "UserTwitterUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
