using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnect.Core.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "sc",
                table: "Connections");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "FriendWithId",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "UserRoleId",
                schema: "sc",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                schema: "sc",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "sc",
                table: "AspNetRoles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Editor",
                schema: "sc",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Reader",
                schema: "sc",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserRoleId",
                schema: "sc",
                table: "AspNetUsers",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_UserRoleId",
                schema: "sc",
                table: "AspNetUsers",
                column: "UserRoleId",
                principalSchema: "sc",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_UserRoleId",
                schema: "sc",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserRoleId",
                schema: "sc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                schema: "sc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Admin",
                schema: "sc",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "sc",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Editor",
                schema: "sc",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Reader",
                schema: "sc",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendWithId",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "sc",
                table: "Connections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
