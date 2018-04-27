using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class changedColumnNameOFTwitterUSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TweeterUserId",
                table: "TwitterUsers",
                newName: "TwitterUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwitterUserId",
                table: "TwitterUsers",
                newName: "TweeterUserId");
        }
    }
}
