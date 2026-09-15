using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_With_CoreMVC_RepoPattern.Migrations
{
    /// <inheritdoc />
    public partial class FixTaskMembersUserRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taskmember_User_UserId1",
                table: "Taskmember");

            migrationBuilder.DropIndex(
                name: "IX_Taskmember_UserId1",
                table: "Taskmember");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Taskmember");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Taskmember",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taskmember_UserId1",
                table: "Taskmember",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Taskmember_User_UserId1",
                table: "Taskmember",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
