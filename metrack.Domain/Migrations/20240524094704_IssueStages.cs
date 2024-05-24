using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metrack.Domain.Migrations
{
    /// <inheritdoc />
    public partial class IssueStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IssueStageId",
                table: "Issues",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Issues",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Period",
                table: "Issues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueStageId",
                table: "Issues",
                column: "IssueStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_OwnerId",
                table: "Issues",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Stages_IssueStageId",
                table: "Issues",
                column: "IssueStageId",
                principalTable: "Stages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_OwnerId",
                table: "Issues",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Stages_IssueStageId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_OwnerId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueStageId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_OwnerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueStageId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Issues");
        }
    }
}
