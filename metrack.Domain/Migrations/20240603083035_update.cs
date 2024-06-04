using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metrack.Domain.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Stages_IssueStageId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueStageId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueStageId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Issues");

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "Issues",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Stages_StageId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StageId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Issues");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueStageId",
                table: "Issues",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueStageId",
                table: "Issues",
                column: "IssueStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Stages_IssueStageId",
                table: "Issues",
                column: "IssueStageId",
                principalTable: "Stages",
                principalColumn: "Id");
        }
    }
}
