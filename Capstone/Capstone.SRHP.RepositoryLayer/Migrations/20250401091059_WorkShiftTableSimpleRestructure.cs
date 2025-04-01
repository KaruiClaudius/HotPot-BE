using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class WorkShiftTableSimpleRestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Create a permanent backup table to store the current data
            migrationBuilder.Sql("SELECT * INTO WorkShifts_Backup FROM WorkShifts");

            // Step 2: Drop foreign keys that reference WorkShifts
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkShift_WorkShifts_MangerWorkShiftsId",
                table: "UserWorkShift");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkShift1_WorkShifts_StaffWorkShiftsId",
                table: "UserWorkShift1");

            // Step 3: Create a mapping table for old and new IDs
            migrationBuilder.Sql("CREATE TABLE IdMapping (OldId INT, NewId INT)");

            // Step 4: Drop the primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShifts",
                table: "WorkShifts");

            // Step 5: Drop the original table
            migrationBuilder.DropTable(
                name: "WorkShifts");

            // Step 6: Create the new table with the desired structure
            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    WorkShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftEndTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.WorkShiftId);
                });

            // Step 7: Insert data from the backup table and populate the mapping table
            migrationBuilder.Sql(@"
                -- Insert data from backup table
                INSERT INTO WorkShifts (ShiftName)
                SELECT 'Shift ' + CAST(Id AS NVARCHAR(10))
                FROM WorkShifts_Backup;

                -- Populate the mapping table
                INSERT INTO IdMapping (OldId, NewId)
                SELECT wb.Id, ws.WorkShiftId
                FROM WorkShifts_Backup wb
                JOIN WorkShifts ws ON ws.ShiftName = 'Shift ' + CAST(wb.Id AS NVARCHAR(10));
            ");

            // Step 8: Rename the foreign key columns
            migrationBuilder.RenameColumn(
                name: "StaffWorkShiftsId",
                table: "UserWorkShift1",
                newName: "StaffWorkShiftsWorkShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkShift1_StaffWorkShiftsId",
                table: "UserWorkShift1",
                newName: "IX_UserWorkShift1_StaffWorkShiftsWorkShiftId");

            migrationBuilder.RenameColumn(
                name: "MangerWorkShiftsId",
                table: "UserWorkShift",
                newName: "MangerWorkShiftsWorkShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkShift_MangerWorkShiftsId",
                table: "UserWorkShift",
                newName: "IX_UserWorkShift_MangerWorkShiftsWorkShiftId");

            // Step 9: Update foreign keys in related tables
            migrationBuilder.Sql(@"
                -- Update foreign keys in UserWorkShift
                UPDATE uw
                SET uw.MangerWorkShiftsWorkShiftId = m.NewId
                FROM UserWorkShift uw
                JOIN IdMapping m ON uw.MangerWorkShiftsWorkShiftId = m.OldId;

                -- Update foreign keys in UserWorkShift1
                UPDATE uw
                SET uw.StaffWorkShiftsWorkShiftId = m.NewId
                FROM UserWorkShift1 uw
                JOIN IdMapping m ON uw.StaffWorkShiftsWorkShiftId = m.OldId;
            ");

            // Step 10: Add foreign key constraints back
            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkShift_WorkShifts_MangerWorkShiftsWorkShiftId",
                table: "UserWorkShift",
                column: "MangerWorkShiftsWorkShiftId",
                principalTable: "WorkShifts",
                principalColumn: "WorkShiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkShift1_WorkShifts_StaffWorkShiftsWorkShiftId",
                table: "UserWorkShift1",
                column: "StaffWorkShiftsWorkShiftId",
                principalTable: "WorkShifts",
                principalColumn: "WorkShiftId",
                onDelete: ReferentialAction.Cascade);

            // Step 11: Clean up (optional - you might want to keep the backup table)
            // migrationBuilder.Sql("DROP TABLE WorkShifts_Backup");
            // migrationBuilder.Sql("DROP TABLE IdMapping");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This is a complex migration that's difficult to revert
            // If you need to roll back, it's better to restore from a backup
        }
    }
}
