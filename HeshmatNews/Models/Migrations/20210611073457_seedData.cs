using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "permissionTitle" },
                values: new object[] { 1, null, "پنل مدیریت" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "permissionTitle" },
                values: new object[] { 2, 1, "مدیریت کاربران" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "permissionTitle" },
                values: new object[] { 6, 1, "مدیریت  نقش ها" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "permissionTitle" },
                values: new object[] { 7, 6, "افزودن نقش" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "permissionTitle" },
                values: new object[] { 8, 6, "ویرایش نقش" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 1);
        }
    }
}
