using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class FixRalations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserViewCategoryCounts_Categories_UserId",
                table: "UserViewCategoryCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewCategoryCounts_Users_CategoryId",
                table: "UserViewCategoryCounts");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewCategoryCounts_Categories_CategoryId",
                table: "UserViewCategoryCounts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewCategoryCounts_Users_UserId",
                table: "UserViewCategoryCounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserViewCategoryCounts_Categories_CategoryId",
                table: "UserViewCategoryCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewCategoryCounts_Users_UserId",
                table: "UserViewCategoryCounts");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewCategoryCounts_Categories_UserId",
                table: "UserViewCategoryCounts",
                column: "UserId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewCategoryCounts_Users_CategoryId",
                table: "UserViewCategoryCounts",
                column: "CategoryId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
