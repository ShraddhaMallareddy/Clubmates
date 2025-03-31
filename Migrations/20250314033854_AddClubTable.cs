using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clubmates.web.Migrations
{
    /// <inheritdoc />
    public partial class AddClubTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubCategory = table.Column<int>(type: "int", nullable: false),
                    ClubType = table.Column<int>(type: "int", nullable: false),
                    ClubManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
