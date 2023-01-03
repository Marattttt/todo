using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class LoginSeparation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginInfoId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginInfoId",
                table: "Users",
                column: "LoginInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoginInfo_LoginInfoId",
                table: "Users",
                column: "LoginInfoId",
                principalTable: "LoginInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoginInfo_LoginInfoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropIndex(
                name: "IX_Users_LoginInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoginInfoId",
                table: "Users");
        }
    }
}
