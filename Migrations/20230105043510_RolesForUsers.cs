using Microsoft.EntityFrameworkCore.Migrations;
using Todo.Models;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class RolesForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:role", "admin,client");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Role>(
                name: "Role",
                table: "Users",
                type: "role",
                nullable: false,
                defaultValue: Role.admin);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:role", "admin,client");
        }
    }
}
