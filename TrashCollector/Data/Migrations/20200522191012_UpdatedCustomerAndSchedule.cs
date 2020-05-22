using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class UpdatedCustomerAndSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abe13c4-09b6-4c4b-baa7-aa77f8402286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dc1a7c9-6d81-476b-858c-a37d8d3aaee2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be50a83b-bfd4-49e5-9368-064b5a583d9c");

            migrationBuilder.DropColumn(
                name: "holdEnd",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "holdStart",
                table: "Schedules");

            migrationBuilder.AddColumn<string>(
                name: "DayofWeek",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "holdEnd",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "holdStart",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DayofWeek",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "holdEnd",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "holdStart",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "holdEnd",
                table: "Schedules",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "holdStart",
                table: "Schedules",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3dc1a7c9-6d81-476b-858c-a37d8d3aaee2", "7ec6bd5f-ec31-4dd1-8b14-9ddc30afc473", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be50a83b-bfd4-49e5-9368-064b5a583d9c", "a9d88213-0fe0-466c-a67e-755af939f340", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3abe13c4-09b6-4c4b-baa7-aa77f8402286", "43147c15-34f4-40dd-9fd2-ad71323cea70", "Customer", "Customer" });
        }
    }
}
