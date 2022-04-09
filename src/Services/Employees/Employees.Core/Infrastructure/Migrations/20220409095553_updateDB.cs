using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees.Core.Infrastructure.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Verifications",
                keyColumn: "Id",
                keyValue: new Guid("e673021a-bb5b-4031-a1ba-5c6ac6e73037"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfModification",
                table: "Verifications",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreation",
                table: "Verifications",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Verifications",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Verifications",
                columns: new[] { "Id", "Age", "DateOfBirth", "DateOfCreation", "DateOfModification", "Email", "LastName", "Name", "Phone" },
                values: new object[] { new Guid("68e4fff6-f4cb-496f-9cae-c69d4268b332"), 22, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bey1705@gmail.com", "Bei", "Vadym", "380971234567" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Verifications",
                keyColumn: "Id",
                keyValue: new Guid("68e4fff6-f4cb-496f-9cae-c69d4268b332"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfModification",
                table: "Verifications",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreation",
                table: "Verifications",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Verifications",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Verifications",
                columns: new[] { "Id", "Age", "DateOfBirth", "DateOfCreation", "DateOfModification", "Email", "LastName", "Name", "Phone" },
                values: new object[] { new Guid("e673021a-bb5b-4031-a1ba-5c6ac6e73037"), 22, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bey1705@gmail.com", "Bei", "Vadym", "380971234567" });
        }
    }
}
