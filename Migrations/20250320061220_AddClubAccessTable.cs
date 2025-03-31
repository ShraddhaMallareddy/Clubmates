using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clubmates.web.Migrations
{
    /// <inheritdoc />
    public partial class AddClubAccessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubAccess",
                columns: table => new
                {
                    ClubAccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    ClubmatesUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClubAccessRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubAccess", x => x.ClubAccessId);
                    table.ForeignKey(
                        name: "FK_ClubAccess_AspNetUsers_ClubmatesUserId",
                        column: x => x.ClubmatesUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClubAccess_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubAccess_ClubId",
                table: "ClubAccess",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubAccess_ClubmatesUserId",
                table: "ClubAccess",
                column: "ClubmatesUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubAccess");
        }
    }
}
