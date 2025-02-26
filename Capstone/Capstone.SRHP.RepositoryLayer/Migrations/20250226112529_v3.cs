using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Feedback",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "Feedback",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ManagerId",
                table: "Feedback",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Managers_ManagerId",
                table: "Feedback",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Managers_ManagerId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ManagerId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "Feedback");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 16, 9, 49, 639, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 16, 9, 49, 639, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 16, 9, 49, 639, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 16, 9, 49, 639, DateTimeKind.Utc).AddTicks(4259));
        }
    }
}
