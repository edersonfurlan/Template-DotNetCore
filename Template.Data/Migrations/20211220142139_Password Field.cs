using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class PasswordField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 20, 11, 21, 39, 120, DateTimeKind.Local).AddTicks(5015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 1, 8, 53, 49, 662, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                defaultValue: "TesteTemplate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 1, 8, 53, 49, 662, DateTimeKind.Local).AddTicks(1058),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 12, 20, 11, 21, 39, 120, DateTimeKind.Local).AddTicks(5015));
        }
    }
}
