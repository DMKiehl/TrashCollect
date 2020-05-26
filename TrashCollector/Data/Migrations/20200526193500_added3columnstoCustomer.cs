using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class added3columnstoCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac56b92-94c2-427b-b7b0-0dbd1191cc20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b92aa6e-23b4-4a00-b018-6b5f7b6b56bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0845ef0-07b7-4b81-ab8a-2dbe42a3c0dd");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "latitude",
                table: "Customers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "longitude",
                table: "Customers",
                nullable: false,
                defaultValue: 0f);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b92aa6e-23b4-4a00-b018-6b5f7b6b56bd", "32d6e3bb-14f5-451f-bdbf-95020ca44f82", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ac56b92-94c2-427b-b7b0-0dbd1191cc20", "c32cf1ca-8512-43f3-9601-ed49b3573042", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0845ef0-07b7-4b81-ab8a-2dbe42a3c0dd", "ef43b26e-2339-41bb-a281-7663a3c072ae", "Customer", "Customer" });
        }
    }
}
