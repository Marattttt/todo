using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedUserLevelsNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_items_User_ClientId",
                table: "todo_items");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Profiles_ProfileId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_AdminId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_login_info_LoginInfoId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "profiles");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_User_ProfileId",
                table: "users",
                newName: "IX_users_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoginInfoId",
                table: "users",
                newName: "IX_users_LoginInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AdminId",
                table: "users",
                newName: "IX_users_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profiles",
                table: "profiles",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_todo_items_users_ClientId",
                table: "todo_items",
                column: "ClientId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_login_info_LoginInfoId",
                table: "users",
                column: "LoginInfoId",
                principalTable: "login_info",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_ProfileId",
                table: "users",
                column: "ProfileId",
                principalTable: "profiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_AdminId",
                table: "users",
                column: "AdminId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_items_users_ClientId",
                table: "todo_items");

            migrationBuilder.DropForeignKey(
                name: "FK_users_login_info_LoginInfoId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_ProfileId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_users_AdminId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profiles",
                table: "profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "profiles",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_users_ProfileId",
                table: "User",
                newName: "IX_User_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_users_LoginInfoId",
                table: "User",
                newName: "IX_User_LoginInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_users_AdminId",
                table: "User",
                newName: "IX_User_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_todo_items_User_ClientId",
                table: "todo_items",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profiles_ProfileId",
                table: "User",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_AdminId",
                table: "User",
                column: "AdminId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_login_info_LoginInfoId",
                table: "User",
                column: "LoginInfoId",
                principalTable: "login_info",
                principalColumn: "Id");
        }
    }
}
