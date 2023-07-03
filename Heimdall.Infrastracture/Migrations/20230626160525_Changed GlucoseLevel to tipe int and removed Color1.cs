using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heimdall.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class ChangedGlucoseLeveltotipeintandremovedColor1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "GlucoseRecords");

            migrationBuilder.AlterColumn<int>(
                name: "GlucoseLevel",
                table: "GlucoseRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GlucoseLevel",
                table: "GlucoseRecords",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "GlucoseRecords",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
