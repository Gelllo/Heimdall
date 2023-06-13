using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heimdall.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddedforeginKeytousers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GlucoseRecords",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserID",
                table: "Users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GlucoseRecords_UserId",
                table: "GlucoseRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlucoseRecords_Users_UserId",
                table: "GlucoseRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlucoseRecords_Users_UserId",
                table: "GlucoseRecords");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_GlucoseRecords_UserId",
                table: "GlucoseRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GlucoseRecords");
        }
    }
}
