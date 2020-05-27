using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class changedDataTypeOfLatAndLongToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f1e118a-8907-434a-ada5-72aed595aac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b7ed276-60a9-427e-944c-8bbb6a88ed13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbddc582-89a9-47ff-acc2-dfbe263dd616");

            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f31aee5-ab15-4c67-96a7-8b9a9a7bca92", "f789cf48-abdf-4608-ae87-e323dddf9fc0", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f702549-aed5-43dc-8b46-93dfaed5dfe6", "427f8638-db35-466f-9d5c-e1b13444aec0", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c437fcff-afb5-4363-8a51-b58b7b544a22", "aeb57858-f453-4356-9344-6b1dd5d50b61", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f702549-aed5-43dc-8b46-93dfaed5dfe6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f31aee5-ab15-4c67-96a7-8b9a9a7bca92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c437fcff-afb5-4363-8a51-b58b7b544a22");

            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "Customers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "latitude",
                table: "Customers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f1e118a-8907-434a-ada5-72aed595aac5", "e4a55b1e-b97a-46d6-a813-1363cb09da33", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b7ed276-60a9-427e-944c-8bbb6a88ed13", "93a9b43d-9160-4247-85bf-53c094cefdc7", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbddc582-89a9-47ff-acc2-dfbe263dd616", "35f0194a-b3c6-4a77-b4cd-9f7c58b5ce89", "Customer", "Customer" });
        }
    }
}
