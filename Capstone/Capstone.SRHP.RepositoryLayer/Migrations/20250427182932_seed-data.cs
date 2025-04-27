using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6031), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6037) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6039), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6041), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1318));

            migrationBuilder.InsertData(
                table: "IngredientBatchs",
                columns: new[] { "IngredientBatchId", "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "IsDelete", "ReceivedDate", "RemainingQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "BEEF-2025-04-01", new DateTime(2025, 5, 12, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5878), 1, 50, false, new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 50, null },
                    { 2, "BEEF-2025-04-15", new DateTime(2025, 5, 19, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5881), 1, 30, false, new DateTime(2025, 4, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 3, "LAMB-2025-04-01", new DateTime(2025, 5, 12, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5891), 2, 40, false, new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 40, null },
                    { 4, "PORK-2025-04-01", new DateTime(2025, 5, 8, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5893), 3, 45, false, new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 45, null },
                    { 5, "SHRIMP-2025-04-01", new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5894), 4, 35, false, new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 35, null },
                    { 6, "FISHBALL-2025-04-01", new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5896), 5, 60, false, new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 60, null },
                    { 7, "SQUID-2025-04-01", new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5898), 6, 30, false, new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 8, "CABBAGE-2025-04-01", new DateTime(2025, 5, 3, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5899), 7, 40, false, new DateTime(2025, 4, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 40, null },
                    { 9, "SPINACH-2025-04-01", new DateTime(2025, 5, 2, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5901), 8, 35, false, new DateTime(2025, 4, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 35, null },
                    { 10, "CORN-2025-04-01", new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5902), 9, 30, false, new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 11, "UDON-2025-04-01", new DateTime(2025, 6, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5904), 10, 50, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 50, null },
                    { 12, "GLASS-2025-04-01", new DateTime(2025, 7, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5905), 11, 45, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 45, null },
                    { 13, "RAMEN-2025-04-01", new DateTime(2025, 6, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5907), 12, 55, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 55, null },
                    { 14, "TOFU-2025-04-01", new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5908), 13, 40, false, new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 40, null },
                    { 15, "FRIEDTOFU-2025-04-01", new DateTime(2025, 5, 12, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5910), 14, 35, false, new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 35, null },
                    { 16, "SHIITAKE-2025-04-01", new DateTime(2025, 5, 8, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5911), 15, 30, false, new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 17, "ENOKI-2025-04-01", new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5913), 16, 35, false, new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 35, null },
                    { 18, "SICHUAN-2025-04-01", new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5914), 17, 25, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 25, null },
                    { 19, "TOMATO-2025-04-01", new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5916), 18, 25, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 25, null },
                    { 20, "MUSHBROTH-2025-04-01", new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5917), 19, 25, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 25, null },
                    { 21, "BONE-2025-04-01", new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5919), 20, 25, false, new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 25, null },
                    { 22, "SESAME-2025-04-01", new DateTime(2025, 7, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5920), 21, 30, false, new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 23, "GARLICSOY-2025-04-01", new DateTime(2025, 10, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5922), 22, 30, false, new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 24, "CHILI-2025-04-01", new DateTime(2025, 10, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5923), 23, 30, false, new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null },
                    { 25, "SHACHA-2025-04-01", new DateTime(2025, 10, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5925), 24, 30, false, new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), 30, null }
                });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5688), new DateTime(2025, 3, 29, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5691) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5700), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5702), new DateTime(2025, 3, 29, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5703) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5704), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5705), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5706) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5707), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5707) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5708), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5783), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5786), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5787), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5789), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5790), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5792), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5793), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5794) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5795), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5802), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5803), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5804) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5805), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5806), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5808), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5809), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5811), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5812), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5813) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5814), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5815) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5815), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5817), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5587));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6101), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6102) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6107), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6108) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6110), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6111) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6113), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6116), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6119), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6122), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2559), "$2a$12$RcC.Kx7vqwyxWQr8Xm2N5.Sn59h3yyDGzHRfXeqV4nCa9huExKIVq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 219, DateTimeKind.Utc).AddTicks(2317), "$2a$12$e/N17lFSkSgKNfCDdoFMP.JctdMED6wZQfWkyxQTROEteuXAttjje" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 446, DateTimeKind.Utc).AddTicks(3220), "$2a$12$hbsrFZvmyKxsnTL.DfTCdOhR.mMWFG9fbMRUxSpXEXKVP0SGrqSbG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 673, DateTimeKind.Utc).AddTicks(799), "$2a$12$e38fdNjOKy8SvOGxf5JNTOZn3UjZsgjsSUStBjtfB0kjfMqYgU3Pe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 898, DateTimeKind.Utc).AddTicks(5672), "$2a$12$k5xfSftiCgnZKR28ZbAfPOS1OJAxeOk8bWWyQBQKupW/CIhpTmPyu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 124, DateTimeKind.Utc).AddTicks(3222), "$2a$12$Eztg0Slzbj02sMiHVXNWHe0Ub2f/jVlanU7AAFiKGgJDW3GpieHj2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 349, DateTimeKind.Utc).AddTicks(9465), "$2a$12$6AD8oPwZYfCmU6oT5gvdEOtbyKOqvACTdTbO2f/uCYJzrk.Cksswm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 483, DateTimeKind.Utc).AddTicks(2222), "$2a$12$AFVdQLAlIzf1GEoZlKHszOc1UCOiKdrTH0TwviWEH7iby1WKvfnZC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 709, DateTimeKind.Utc).AddTicks(1185), "$2a$12$NGukswJrUDHbK6NYL5RzYOrLdqQsaJPUI7rYh7/1cJghJpFtcHw0u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 935, DateTimeKind.Utc).AddTicks(7083), "$2a$12$RU5JIc7PNw82k7bODwEL6.8yjeBPfhJeU/JLYKmxjvdLIZthBLEAe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 575, DateTimeKind.Utc).AddTicks(2210), "$2a$12$UTmlTXW0khDq0kQtknyKKu0WureqUmP9/Hdwcr957c3h.jrurFdbG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 800, DateTimeKind.Utc).AddTicks(7506), "$2a$12$UUJ2B2W5Z4F10byCuiwPyOc93z.6bEuDZmNrtYBNbBxvQtH2sLQwa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 28, DateTimeKind.Utc).AddTicks(340), "$2a$12$2OyfOTewmDHo6U31S7sDUOccZlU7IJ8CforYvE9ufUy3cyDpe7SjC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 257, DateTimeKind.Utc).AddTicks(5329), "$2a$12$xjhaarixfVTFypF7dsejbuBnKUkatbiUjz8p1/tcZeLSFC9/.66DO" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1645), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1654), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1654) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1657), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1657) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1659), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1661), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1661) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6206), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6207) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6209), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6212), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6214), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6215) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6217), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6217) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6219), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6222), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6224), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6225) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6227), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6227) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6229), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6230) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8996), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9001), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9003), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9003) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8889), new DateTime(2025, 3, 26, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8892) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8899), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8901), new DateTime(2025, 3, 26, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8902), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8903) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8904), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8905), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8907), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8907) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8908), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8910), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8911), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8912), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8914), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8916), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8917), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8919), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8924), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8926), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8927), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8928) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8929), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8930), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8931), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8933), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8934), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8936), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8937), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8938), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9116), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9118) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9122), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9125), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9128), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9130), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9131) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9133), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9135), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9136) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6633), "$2a$12$qPHMPdAWNY2wJijYbh6ysua5pYdvFN92UDfrZGz2kOtqlD/oR1Cxu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 484, DateTimeKind.Utc).AddTicks(9007), "$2a$12$FvNGv.w6bcFfTe1XtxYif.iGkcZyOstAMlchtWGyzNIrOGCt/zMxC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 722, DateTimeKind.Utc).AddTicks(4803), "$2a$12$DHoPUMmWIQ.0Sgk.5i9Zw.eVI9a63ILwg/pwdYx1wkONzjadk7eaG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 954, DateTimeKind.Utc).AddTicks(6952), "$2a$12$rzYeZqGs3lXB1R.hnuyzluAcpZBMO7lwu/eOXVgYdbpV3v5qIK.ba" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 186, DateTimeKind.Utc).AddTicks(7929), "$2a$12$DsssiIBhZR6qG77qPgAu6.SWnDjHUt4jr1gGQRrQSrjdmX8Hfbfse" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 417, DateTimeKind.Utc).AddTicks(9675), "$2a$12$F63eHBxbVuuAvvcMbSi.uecYflYGWJ7tZWl3mOLQAoI2taLsOmkjG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 649, DateTimeKind.Utc).AddTicks(3816), "$2a$12$VmsNlgn0CfR1pYujxBCFGOLVu9BHh8d8mIqfH.sj/Mu8LuIwW6o4O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 803, DateTimeKind.Utc).AddTicks(6732), "$2a$12$1bhu3q5cSAv7nt7NE3hj.uIF26CvcQEvyO1tsdgKSWlDKAPX6O9JG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 34, DateTimeKind.Utc).AddTicks(5183), "$2a$12$x2G2xGfY4QK99Bw39KgdhOX/CiNh6Rer8UtikBWzFCI4.uxzI56mW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 266, DateTimeKind.Utc).AddTicks(3764), "$2a$12$FprL1Iaj8BRMgkWY1qiO8.pEbuxfeNDWE4svkKrixpQqnnzcuHYYa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 879, DateTimeKind.Utc).AddTicks(2160), "$2a$12$DNVoxs8yE6.iPcdcg9AxTepTPLZmQLgfdNj2PZcUTshpTG3Cfv672" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 109, DateTimeKind.Utc).AddTicks(5184), "$2a$12$Jw4d7AFD/qybiQ.Peo.FZeVsl8Bfpr5uxaqLo7NUsO0fTajaWujXW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 340, DateTimeKind.Utc).AddTicks(6901), "$2a$12$5iNG3oPwGWZzZ.hPA8gkZutDiNA9p/qbBoRp/Pvk.Rx0akYNEIB1y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 572, DateTimeKind.Utc).AddTicks(3285), "$2a$12$dB4uOa0ZG2zTfZUOlTlefel/CERhLmPo9.XNqymd4mF.d.vYqnDwW" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8593), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8607), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8609), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8611), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8613), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9188), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9189) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9191), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9193), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9195), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9198), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9200), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9201) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9202), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9205), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9207), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9209), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9210) });
        }
    }
}
