using Microsoft.EntityFrameworkCore.Migrations;
using Todo.Models;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedUserLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoginInfo_LoginInfoId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginInfo",
                table: "LoginInfo");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "todo_items");

            migrationBuilder.RenameTable(
                name: "LoginInfo",
                newName: "login_info");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ProfileId",
                table: "User",
                newName: "IX_User_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LoginInfoId",
                table: "User",
                newName: "IX_User_LoginInfoId");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "login_info",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "login_info",
                newName: "lassword");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:role", "admin,client");

            migrationBuilder.AlterColumn<int>(
                name: "LoginInfoId",
                table: "User",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_type",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "todo_items",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "login_info",
                type: "character varying(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lassword",
                table: "login_info",
                type: "character varying(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todo_items",
                table: "todo_items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_login_info",
                table: "login_info",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_AdminId",
                table: "User",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_todo_items_ClientId",
                table: "todo_items",
                column: "ClientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AdminId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todo_items",
                table: "todo_items");

            migrationBuilder.DropIndex(
                name: "IX_todo_items_ClientId",
                table: "todo_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_login_info",
                table: "login_info");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "user_type",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "todo_items");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "todo_items",
                newName: "TodoItems");

            migrationBuilder.RenameTable(
                name: "login_info",
                newName: "LoginInfo");

            migrationBuilder.RenameIndex(
                name: "IX_User_ProfileId",
                table: "Users",
                newName: "IX_Users_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoginInfoId",
                table: "Users",
                newName: "IX_Users_LoginInfoId");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "LoginInfo",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "lassword",
                table: "LoginInfo",
                newName: "Password");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:role", "admin,client");

            migrationBuilder.AlterColumn<int>(
                name: "LoginInfoId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Role>(
                name: "Role",
                table: "Users",
                type: "role",
                nullable: false,
                defaultValue: Role.admin);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "LoginInfo",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LoginInfo",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginInfo",
                table: "LoginInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoginInfo_LoginInfoId",
                table: "Users",
                column: "LoginInfoId",
                principalTable: "LoginInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }
    }
}
