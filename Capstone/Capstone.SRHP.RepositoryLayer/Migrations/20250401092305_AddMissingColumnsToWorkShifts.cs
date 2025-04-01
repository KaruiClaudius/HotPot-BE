using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingColumnsToWorkShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the missing ShiftStartTime column
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ShiftStartTime",
                table: "WorkShifts",
                type: "time",
                nullable: true);

            // Add the BaseEntity properties
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "DATEADD(HOUR, 7, GETUTCDATE())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "WorkShifts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "WorkShifts",
                type: "datetime2",
                nullable: true);

            // Set default values for existing rows
            migrationBuilder.Sql(@"
                UPDATE WorkShifts
                SET CreatedAt = DATEADD(HOUR, 7, GETUTCDATE()),
                    IsDelete = 0
                WHERE CreatedAt IS NULL
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the added columns
            migrationBuilder.DropColumn(
                name: "ShiftStartTime",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "WorkShifts");
        }
    }
}
