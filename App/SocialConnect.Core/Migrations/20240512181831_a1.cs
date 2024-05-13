using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnect.Core.Migrations
{
    /// <inheritdoc />
    public partial class a1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_UserId1",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId1",
                schema: "sc",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId1",
                schema: "sc",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId1",
                schema: "sc",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId1",
                schema: "sc",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Connections_UserId1",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "sc",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "sc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "sc",
                table: "Connections");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sc",
                table: "UserDetails",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sc",
                table: "Posts",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                schema: "sc",
                table: "UserDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                schema: "sc",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserId",
                schema: "sc",
                table: "Connections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                schema: "sc",
                table: "Connections",
                column: "UserId",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                schema: "sc",
                table: "Posts",
                column: "UserId",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                schema: "sc",
                table: "UserDetails",
                column: "UserId",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                schema: "sc",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                schema: "sc",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId",
                schema: "sc",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                schema: "sc",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Connections_UserId",
                schema: "sc",
                table: "Connections");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "sc",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "sc",
                table: "UserDetails",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "sc",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "sc",
                table: "Posts",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "sc",
                table: "Connections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId1",
                schema: "sc",
                table: "UserDetails",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId1",
                schema: "sc",
                table: "Posts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserId1",
                schema: "sc",
                table: "Connections",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_UserId1",
                schema: "sc",
                table: "Connections",
                column: "UserId1",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId1",
                schema: "sc",
                table: "Posts",
                column: "UserId1",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId1",
                schema: "sc",
                table: "UserDetails",
                column: "UserId1",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
