using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class JoinTableforeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTwitterUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TwitterUserId = table.Column<int>(nullable: true),
                    TwitterUser_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    User_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTwitterUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTwitterUsers_TwitterUsers_TwitterUserId",
                        column: x => x.TwitterUserId,
                        principalTable: "TwitterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTwitterUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTwitterUsers_TwitterUserId",
                table: "UserTwitterUsers",
                column: "TwitterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTwitterUsers_UserId",
                table: "UserTwitterUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTwitterUsers");
        }
    }
}
