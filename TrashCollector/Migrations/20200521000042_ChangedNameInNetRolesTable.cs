using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class ChangedNameInNetRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "290aa935-5fd9-466a-8cc7-e384183f097f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef1815d-169e-47ac-b5e2-e7bb00f9424f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c45fd83b-7c50-4211-8759-5339494d8ff3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f244a62-e7d8-48e0-b0c9-fc1e425951b8", "8e448e6c-6a4d-4a2f-aeeb-ac46131b583e", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8133796-3131-4e1c-8031-618000384d45", "6eb63101-eeb5-4549-9e1d-7af703fbbc60", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69ff0c34-16ea-4e05-ab44-022f6891d824", "2d38fbc4-0764-429f-95ac-6f048a8c34ed", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69ff0c34-16ea-4e05-ab44-022f6891d824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f244a62-e7d8-48e0-b0c9-fc1e425951b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8133796-3131-4e1c-8031-618000384d45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "290aa935-5fd9-466a-8cc7-e384183f097f", "b1e4ecb2-b7c0-4595-9597-87cdfab2468f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ef1815d-169e-47ac-b5e2-e7bb00f9424f", "ec153898-e869-499d-b944-a2dde684371b", "Employee", "EMP" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c45fd83b-7c50-4211-8759-5339494d8ff3", "e3c6926c-b2aa-4ea4-804c-ff1851caf243", "Customer", "CUST" });
        }
    }
}
