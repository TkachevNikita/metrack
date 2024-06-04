using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metrack.Domain.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Stages_StageId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_OwnerId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_OwnerId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StageId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Issues",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Period",
                table: "Issues",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Issues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Issues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Issues",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Issues",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Issues",
                newName: "Period");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Issues",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "Issues",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_OwnerId",
                table: "Issues",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StageId",
                table: "Issues",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Stages_StageId",
                table: "Issues",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_OwnerId",
                table: "Issues",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
