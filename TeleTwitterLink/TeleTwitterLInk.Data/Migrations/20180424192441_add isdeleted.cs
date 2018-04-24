using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class addisdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserTwitterUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTwitterUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserTwitterUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTwitterUsers");
        }
    }
}
