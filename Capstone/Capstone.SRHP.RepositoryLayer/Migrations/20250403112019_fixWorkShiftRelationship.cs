using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixWorkShiftRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserManagerWorkShifts",
                columns: table => new
                {
                    ManagersUserId = table.Column<int>(type: "int", nullable: false),
                    MangerWorkShiftsWorkShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManagerWorkShifts", x => new { x.ManagersUserId, x.MangerWorkShiftsWorkShiftId });
                    table.ForeignKey(
                        name: "FK_UserManagerWorkShifts_Users_ManagersUserId",
                        column: x => x.ManagersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserManagerWorkShifts_WorkShifts_MangerWorkShiftsWorkShiftId",
                        column: x => x.MangerWorkShiftsWorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "WorkShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStaffWorkShifts",
                columns: table => new
                {
                    StaffUserId = table.Column<int>(type: "int", nullable: false),
                    StaffWorkShiftsWorkShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStaffWorkShifts", x => new { x.StaffUserId, x.StaffWorkShiftsWorkShiftId });
                    table.ForeignKey(
                        name: "FK_UserStaffWorkShifts_Users_StaffUserId",
                        column: x => x.StaffUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStaffWorkShifts_WorkShifts_StaffWorkShiftsWorkShiftId",
                        column: x => x.StaffWorkShiftsWorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "WorkShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(202), new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(213), new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(214) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(215), new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(215) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(216), new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(217) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(97), new DateTime(2025, 3, 4, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(98) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(108), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(110), new DateTime(2025, 3, 4, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(111) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(112), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(113), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(114), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(115) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(116), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(116) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(117), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(118) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(118), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(120), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(121), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(122) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(122), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(123) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(124), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(125), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(126), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(137) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(138), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(139) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(139), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(141), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(141) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(142), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(143), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(144) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(145), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(146), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(147) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(147), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(148) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(149), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(150), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(151) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(151), new DateTime(2025, 3, 31, 18, 20, 18, 358, DateTimeKind.Utc).AddTicks(152) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 16, 35, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 16, 35, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 16, 35, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 16, 35, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 16, 35, DateTimeKind.Utc).AddTicks(7167), "$2a$12$8onfqvwJlymEsUQWQtNoh.Uy0zWwuH1554krZnhr4xkPlUF8Eqs7C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 16, 282, DateTimeKind.Utc).AddTicks(984), "$2a$12$4FLuqJH1XNTbj7SvIWbnRucDCah4ytKd0fkl5sCnxLmkqJl0ovXre" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 16, 515, DateTimeKind.Utc).AddTicks(8540), "$2a$12$TTkgB7NIPOzX0ZGWj0OLDul5VjdNM7CVwuw/twxWNulBGG7z4zTkC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 16, 745, DateTimeKind.Utc).AddTicks(5781), "$2a$12$0pnK52Ggt/LAysPfbB3bE.VrO.ml4jHij3qXRCMDuljTs6xQsqAby" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 16, 974, DateTimeKind.Utc).AddTicks(9356), "$2a$12$GHVUeW9ZvNJJfEBt71bCkOnk5oFJ2jNzrbEPBCLb9mtAb.W4c4Eem" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 17, 205, DateTimeKind.Utc).AddTicks(3478), "$2a$12$56KSQWEOgBnwuGybfPoyqey9fgXSvs9BxitiGZ8oE7VCXOAXk6Iwa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 17, 437, DateTimeKind.Utc).AddTicks(5598), "$2a$12$iE/.7LEOvuK2fmePirLEUuErxQNkkx0nvj668Ca1Fs9VLh2QLL51u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 17, 665, DateTimeKind.Utc).AddTicks(6513), "$2a$12$PhCntnCJN7rLQjtnrsu04ucWOI4wfVceBeIBZoOkA4oe6BGsLZ/zS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 17, 893, DateTimeKind.Utc).AddTicks(2146), "$2a$12$VPJ.NU7UqJC79KlCQEqh9uDEdD/nDKI9zVHHu8pEd/fGPvAcsi17W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 124, DateTimeKind.Utc).AddTicks(4362), "$2a$12$SWiZ2z9bHW1AXao4q/7jiulC3heVNBSqtHONTc.QIKWT.FsqjASNi" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9796), new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9797) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9802), new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9804), new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9804) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9806), new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9806) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9808), new DateTime(2025, 4, 3, 18, 20, 18, 357, DateTimeKind.Utc).AddTicks(9808) });

          

            migrationBuilder.CreateIndex(
                name: "IX_UserManagerWorkShifts_MangerWorkShiftsWorkShiftId",
                table: "UserManagerWorkShifts",
                column: "MangerWorkShiftsWorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStaffWorkShifts_StaffWorkShiftsWorkShiftId",
                table: "UserStaffWorkShifts",
                column: "StaffWorkShiftsWorkShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "UserManagerWorkShifts");

            migrationBuilder.DropTable(
                name: "UserStaffWorkShifts");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8736), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8738) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8741), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8743), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8745), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8745) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8626), new DateTime(2025, 3, 4, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8646), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8647), new DateTime(2025, 3, 4, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8649), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8650), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8652), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8652) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8653), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8655), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8656), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8658), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8659) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8659), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8661), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8662), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8664), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8664) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8666), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8674) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8675), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8677), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8677) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8678), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8680), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8681), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8683), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8684), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8685) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8685), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8687), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8688), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8690), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5919), "$2a$12$fTDsphTIhjiX.XtiujnUVub.Q/EIsCcSbdnV9T.6Em7xIfKu1X5OO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 34, 749, DateTimeKind.Utc).AddTicks(200), "$2a$12$C3zThKELwffvGay05WWs7OvAN9SKHPflvHX59Q/o.hQWogLTpLEVK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 34, 989, DateTimeKind.Utc).AddTicks(255), "$2a$12$9m9OlgsvWv9ZmvccH7.fW.sDvGLoFdlzsuz4sRRo4IYazg.9hxVNa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 234, DateTimeKind.Utc).AddTicks(27), "$2a$12$6ZQDCGKJ9rnMKfHAz76esuMDmXEH30MHR5RNhQI8FLRTxyt2Xlz7i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 470, DateTimeKind.Utc).AddTicks(6629), "$2a$12$UEDRcCZQiAdAmDTcjcrr7.1o591wueODV1/zveHBaPR7B7.X8jwoC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 710, DateTimeKind.Utc).AddTicks(9623), "$2a$12$wEC5ILIcwOcjxBPN9SqiOOOYqDe8TI8B2EkR13eeFMdV0o7ZHMxg2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 942, DateTimeKind.Utc).AddTicks(2405), "$2a$12$D6Qzl0LcKfcNbP.UAKyflOAaIlH10ZcNMVkR0UQ9oZHOjkGVGJFXS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 181, DateTimeKind.Utc).AddTicks(3568), "$2a$12$nrA.88R4wvnoidGEubbIcutS5sJJqrOGO5Bv05mwJMpfQIjCK62O2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 410, DateTimeKind.Utc).AddTicks(6455), "$2a$12$C6D42fHuqVW/3/Tk0wrZ7u.qHY6bl9.tcGO/D822k9oTbOLPd2MkS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 646, DateTimeKind.Utc).AddTicks(2937), "$2a$12$0ocQ1zgpzpFs1QSlZ./K4eA9l.6KF6IWtbKZT8j09rgyaN3FovS9." });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8345), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8352), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8355), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8356), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8358), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8358) });
        }
    }
}
