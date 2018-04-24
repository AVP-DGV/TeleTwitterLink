using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class ManyUsersWithManyFavTwitterUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TwitterUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TwitterUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FollowersCount = table.Column<int>(nullable: false),
                    FriendsCount = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TweeterUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TwitterUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TwitterUserId",
                table: "AspNetUsers",
                column: "TwitterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TwitterUsers_UserId",
                table: "TwitterUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TwitterUsers_TwitterUserId",
                table: "AspNetUsers",
                column: "TwitterUserId",
                principalTable: "TwitterUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TwitterUsers_TwitterUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TwitterUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TwitterUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwitterUserId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "TweetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FollowersCount = table.Column<int>(nullable: false),
                    FriendsCount = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TweeterUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TweetUsers_UserId",
                table: "TweetUsers",
                column: "UserId");
        }
    }
}
