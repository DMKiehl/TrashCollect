using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class MoreRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0581bf69-6302-4ea7-ae26-f584e859fd76");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85aae2fe-9274-483b-a896-4812e189210b", "d3b7c57f-0492-4759-b924-62968fa95911", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5278d142-5c8f-4afd-8e1d-082c7095e16a", "6000dde4-d752-447a-9fbc-a38267cd9bfc", "Employee", "EMP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0b7d11d-6b70-4840-a1ce-649447874989", "11859ba7-0cee-46d3-b129-e260b8634e37", "Customer", "CUST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5278d142-5c8f-4afd-8e1d-082c7095e16a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85aae2fe-9274-483b-a896-4812e189210b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b7d11d-6b70-4840-a1ce-649447874989");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0581bf69-6302-4ea7-ae26-f584e859fd76", "3beacb18-19eb-4c6a-b978-566304dc3640", "Admin", "ADMIN" });
        }
    }
}
