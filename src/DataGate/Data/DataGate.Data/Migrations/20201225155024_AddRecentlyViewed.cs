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
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    LinkUrl = table.Column<string>(nullable: false),
                    DisplayLink = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentlyViewed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecentlyViewed_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecentlyViewed_UserId",
                table: "RecentlyViewed",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecentlyViewed");
        }
    }
}
