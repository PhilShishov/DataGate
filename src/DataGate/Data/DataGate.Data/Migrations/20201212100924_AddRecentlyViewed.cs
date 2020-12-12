using Microsoft.EntityFrameworkCore.Migrations;

namespace DataGate.Data.Migrations
{
    public partial class AddRecentlyViewed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecentlyViewed",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentlyViewed", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecentlyViewed");
        }
    }
}
