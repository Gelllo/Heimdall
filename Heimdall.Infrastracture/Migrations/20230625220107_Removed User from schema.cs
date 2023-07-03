using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heimdall.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserfromschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlucoseRecords_Users_UserId",
                table: "GlucoseRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_GlucoseRecords_UserId",
                table: "GlucoseRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserID", x => x.UserID);
                });

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
    }
}
