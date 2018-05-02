using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeleTwitterLInk.Data.Migrations
{
    public partial class fkFromTweetToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tweets_TwitterUserId",
                table: "Tweets",
                column: "TwitterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_TwitterUsers_TwitterUserId",
                table: "Tweets",
                column: "TwitterUserId",
                principalTable: "TwitterUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_TwitterUsers_TwitterUserId",
                table: "Tweets");

            migrationBuilder.DropIndex(
                name: "IX_Tweets_TwitterUserId",
                table: "Tweets");
        }
    }
}
