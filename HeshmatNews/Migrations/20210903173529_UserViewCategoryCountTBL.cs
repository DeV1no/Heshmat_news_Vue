using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class UserViewCategoryCountTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserViewCategoryCounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserViewCategoryCounts", x => new { x.CategoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserViewCategoryCounts_Categories_UserId",
                        column: x => x.UserId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserViewCategoryCounts_Users_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserViewCategoryCounts_CategoryId",
                table: "UserViewCategoryCounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewCategoryCounts_UserId",
                table: "UserViewCategoryCounts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserViewCategoryCounts");
        }
    }
}
