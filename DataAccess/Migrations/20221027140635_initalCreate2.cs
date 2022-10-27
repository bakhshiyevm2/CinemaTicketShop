using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initalCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 6, 34, 924, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Name", "UpdateDate", "UpdateUserId" },
                values: new object[] { 2, new DateTime(2022, 10, 27, 18, 6, 34, 924, DateTimeKind.Local).AddTicks(9105), 1, "User", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2022, 10, 27, 18, 6, 34, 925, DateTimeKind.Local).AddTicks(800), "�'��Ξ���T�����fKg��[��Ѫ������", "qfOGQGQyHzGFhA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2022, 10, 27, 18, 4, 44, 528, DateTimeKind.Local).AddTicks(4878), "J\"A�f)�A.8���{�-�ϧ �0������q+0", "VIxWqgyYhfdM5A==" });
        }
    }
}
