using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clubmates.web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeClubTableColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClubManager",
                table: "Clubs");

            migrationBuilder.AddColumn<string>(
                name: "ClubEmail",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClubManagerId",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubManagerId",
                table: "Clubs",
                column: "ClubManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AspNetUsers_ClubManagerId",
                table: "Clubs",
                column: "ClubManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AspNetUsers_ClubManagerId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_ClubManagerId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubEmail",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubManagerId",
                table: "Clubs");

            migrationBuilder.AddColumn<string>(
                name: "ClubManager",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
