using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heimdall.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Changedpropertytype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegistered",
                table: "GlucoseRecords",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateRegistered",
                table: "GlucoseRecords",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
