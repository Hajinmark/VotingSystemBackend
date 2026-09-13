using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionOfJunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectionUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectionUsers",
                columns: table => new
                {
                    ElectionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionUsers", x => new { x.ElectionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ElectionUsers_Elections_ElectionsId",
                        column: x => x.ElectionsId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectionUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectionUsers_UsersId",
                table: "ElectionUsers",
                column: "UsersId");
        }
    }
}
