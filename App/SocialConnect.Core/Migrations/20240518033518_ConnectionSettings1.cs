using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnect.Core.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionSettings1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "IsMutual",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "IsRequestPending",
                schema: "sc",
                table: "Connections");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RejectedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AcceptedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "FriendWithId",
                schema: "sc",
                table: "Connections",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "sc",
                table: "Connections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Connections_FriendWithId",
                schema: "sc",
                table: "Connections",
                column: "FriendWithId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_FriendWithId",
                schema: "sc",
                table: "Connections",
                column: "FriendWithId",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                schema: "sc",
                table: "Connections",
                column: "UserId",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_FriendWithId",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_FriendWithId",
                schema: "sc",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "FriendWithId",
                schema: "sc",
                table: "Connections");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RejectedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AcceptedOn",
                schema: "sc",
                table: "Connections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMutual",
                schema: "sc",
                table: "Connections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestPending",
                schema: "sc",
                table: "Connections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                schema: "sc",
                table: "Connections",
                column: "UserId",
                principalSchema: "sc",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
