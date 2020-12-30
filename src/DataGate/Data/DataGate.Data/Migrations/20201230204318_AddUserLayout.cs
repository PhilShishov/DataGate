using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataGate.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class AddUserLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFundColumn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFundColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFundColumn_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFundSubFundsColumn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFundSubFundsColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFundSubFundsColumn_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserShareClassColumn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShareClassColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShareClassColumn_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubFundColumn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubFundColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubFundColumn_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubFundShareClassesColumn",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubFundShareClassesColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubFundShareClassesColumn_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFundColumn_UserId",
                table: "UserFundColumn",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFundSubFundsColumn_UserId",
                table: "UserFundSubFundsColumn",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShareClassColumn_UserId",
                table: "UserShareClassColumn",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubFundColumn_UserId",
                table: "UserSubFundColumn",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubFundShareClassesColumn_UserId",
                table: "UserSubFundShareClassesColumn",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFundColumn");

            migrationBuilder.DropTable(
                name: "UserFundSubFundsColumn");

            migrationBuilder.DropTable(
                name: "UserShareClassColumn");

            migrationBuilder.DropTable(
                name: "UserSubFundColumn");

            migrationBuilder.DropTable(
                name: "UserSubFundShareClassesColumn");
        }
    }
}
