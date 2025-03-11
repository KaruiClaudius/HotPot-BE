using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixAndAddPropsForWorkshiftStaffManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Managers_ManagerID",
                table: "WorkShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Staffs_StaffID",
                table: "WorkShifts");

            migrationBuilder.DropIndex(
                name: "IX_WorkShifts_ManagerID",
                table: "WorkShifts");

            migrationBuilder.DropIndex(
                name: "IX_WorkShifts_StaffID",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "ManagerID",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "ShiftTime",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "WorkShifts");

            migrationBuilder.AddColumn<int>(
                name: "DaysOfWeek",
                table: "WorkShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ShiftStartTime",
                table: "WorkShifts",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkDays",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkDays",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ManagerWorkShift",
                columns: table => new
                {
                    ManagersManagerId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerWorkShift", x => new { x.ManagersManagerId, x.WorkShiftsId });
                    table.ForeignKey(
                        name: "FK_ManagerWorkShift_Managers_ManagersManagerId",
                        column: x => x.ManagersManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerWorkShift_WorkShifts_WorkShiftsId",
                        column: x => x.WorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "ComboAllowedIngredientTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffWorkShift",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffWorkShift", x => new { x.StaffId, x.WorkShiftsId });
                    table.ForeignKey(
                        name: "FK_StaffWorkShift_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffWorkShift_WorkShifts_WorkShiftsId",
                        column: x => x.WorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "ComboAllowedIngredientTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7234), new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7237), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7239), new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7241), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7243), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7244), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7246), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7248), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7250), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7252), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7254), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7256), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7258), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7259), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7266), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7268), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7270), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7272), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7273), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7275), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7277), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7279), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7281), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7283), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7285), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7284) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7286), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7286) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4555), 0 });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4562), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4502), 0 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4507), 0 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4508), 0 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4509), 0 });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 688, DateTimeKind.Utc).AddTicks(6524), "$2a$12$oXGqWfAs5/QoGd5ocvXhWuEKjvx9SkpbEhMpiwGC0YNgqZoSOO0na" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 457, DateTimeKind.Utc).AddTicks(904), "$2a$12$yZP07UM4ZgGT.0ebAK2NE.M.S9V0ZrbP82npm/aWyDLjzjtdtMLfS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 225, DateTimeKind.Utc).AddTicks(1207), "$2a$12$1W5r4YWT2zympc/1whNDFeMp4K1HQF3BUZHGsq18FtM0Df.GSCmjC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 994, DateTimeKind.Utc).AddTicks(5811), "$2a$12$KRctPrMRryu4EApV3PH.l.1yVX61NhGMzfAKMProh4.TmfibCgM4C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 763, DateTimeKind.Utc).AddTicks(9994), "$2a$12$1gXs6p0m3V0eUggD7xgd/.2IXS8hSM7cFVXaTZ/Iv0YT4AY9c0tDO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 536, DateTimeKind.Utc).AddTicks(4750), "$2a$12$TpIc2LwXjCZifVihcowoMOH0JOp287p.Reiar7gVUn79pqFZw7Vlq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 306, DateTimeKind.Utc).AddTicks(1791), "$2a$12$jCdCrqa1KfLOQ.sgtzqIaOy3ij49FYhA6PnGKl0RQBKTku956XNTm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 73, DateTimeKind.Utc).AddTicks(8882), "$2a$12$WUClYB.kTS9gg98woJVZLuKdgZw42/EmEqgYdezS.z20Va54O4II." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 32, 839, DateTimeKind.Utc).AddTicks(4035), "$2a$12$c/n2q8iUAiRhUKEI0G/5nes6TsrlPQp6Bcm8iwuBJqBFCTosZ0uJK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 32, 597, DateTimeKind.Utc).AddTicks(119), "$2a$12$tnSlCx0T6tknUI3gsmqMOOdVYdUz0qYjaSoKU5Ixi5hJnctgH8oDq" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6709), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6703) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6712), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6714), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6717), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6716) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6719), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.CreateIndex(
                name: "IX_ManagerWorkShift_WorkShiftsId",
                table: "ManagerWorkShift",
                column: "WorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffWorkShift_WorkShiftsId",
                table: "StaffWorkShift",
                column: "WorkShiftsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerWorkShift");

            migrationBuilder.DropTable(
                name: "StaffWorkShift");

            migrationBuilder.DropColumn(
                name: "DaysOfWeek",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "ShiftStartTime",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "ManagerID",
                table: "WorkShifts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShiftTime",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "WorkShifts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8018), new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8011) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8021), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8021) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8024), new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8026), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8025) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8028), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8030), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8032), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8034), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8036), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8038), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8040), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8039) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8042), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8044), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8046), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8052), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8054), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8056), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8058), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8060), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8062), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8064), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8066), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8065) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8068), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8070), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8110), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8109) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8112), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8111) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 289, DateTimeKind.Utc).AddTicks(1154), "$2a$12$4pljidGfnlQ8tjIWmtcJA.tjSWW6B3eIGQ5Zre4dKexrEPeGGcTaW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 41, DateTimeKind.Utc).AddTicks(8830), "$2a$12$mBe7cen4iaSiq5ryZIXIIeho8otKrGd2wYPcxsvHWXA4ViVK.Sn06" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 795, DateTimeKind.Utc).AddTicks(1092), "$2a$12$tCyDeHEwP9GZ5EsD4WCX1uj9elCqZNTQ8/z4AhEc7QKQJB1Xd.MFe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 543, DateTimeKind.Utc).AddTicks(7801), "$2a$12$m7iNE6VNTQOU5.VsYCaK/.V4doemI9qf5sLUoJ6/oLHLWTIIVbyje" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 293, DateTimeKind.Utc).AddTicks(1078), "$2a$12$g5ik/V5u4qLa3Lq3knKl2e2iuDXrn5Wr1MTRknrahTkxUlZV3TqSm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 47, DateTimeKind.Utc).AddTicks(4697), "$2a$12$lVvgHSsVq99MJixkds7.YO6aJ5qACZa6GG2Lkj.lN1CTZMW2n2u2y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 800, DateTimeKind.Utc).AddTicks(4822), "$2a$12$0ISDLUITz09N2xBt2OvUYOuMSH6sqY03wzdzbdRbgWw9FGprioyZG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 553, DateTimeKind.Utc).AddTicks(2898), "$2a$12$DkNCtdgxtOv80NdRotDpsOhCkW3lxRXAgFAqdaAkn09GyUnThxGdO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 300, DateTimeKind.Utc).AddTicks(5124), "$2a$12$nIcCdPSknyEOOHe7N84fre6NH8Cv7o0au4FGunC2YRVw0vSpJEcF2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8554), "$2a$12$OdtilG30AypcBV0f7U7TVepjytEsdk7/kfuc5IX/2T/r0DcgGjKhG" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7602), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7605), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7603) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7609), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7607) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7616), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7618), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_ManagerID",
                table: "WorkShifts",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_StaffID",
                table: "WorkShifts",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Managers_ManagerID",
                table: "WorkShifts",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Staffs_StaffID",
                table: "WorkShifts",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffId");
        }
    }
}
