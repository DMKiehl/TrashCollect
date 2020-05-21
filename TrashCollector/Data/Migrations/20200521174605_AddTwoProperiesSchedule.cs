using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class AddTwoProperiesSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4def3fba-d097-4cd6-a743-581ecda5c9ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fb3b164-9280-4681-bc03-b01a0de4010e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab05b6-131e-4d3f-8fcd-ccd39e062555");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fb3b164-9280-4681-bc03-b01a0de4010e", "cb7767ae-d394-4c93-be8b-0ae9727c6605", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88ab05b6-131e-4d3f-8fcd-ccd39e062555", "d6823db5-9bce-4269-a894-4cb15dce7c32", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4def3fba-d097-4cd6-a743-581ecda5c9ef", "4526a15e-6715-4c37-8463-aa46c6624d82", "Customer", "Customer" });
        }
    }
}
