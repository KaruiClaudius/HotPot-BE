using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class orderCodePaymentPurpose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "HotpotDeposit",
                table: "RentOrders");

            migrationBuilder.AddColumn<int>(
                name: "Purpose",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2541), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2544) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2546), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2548), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2549) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2550), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2432), new DateTime(2025, 3, 8, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2451), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2452), new DateTime(2025, 3, 8, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2454), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2456), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2457) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2458), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2459) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2460), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2461), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2462) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2463), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2465), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2466), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2467) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2468), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2470), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2471), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2473), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2482) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2483), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2484) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2485), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2486), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2488), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2489) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2489), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2491), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2492), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2493) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2494), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2494) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2495), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2497), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2498), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2625), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2630), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2633), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2635), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2636) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2638), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2641), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2643), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5877), "$2a$12$K5ZHLcVYhDBrEfK3Nm9b6O.Sr/fBm5sHdc/PVbXkouMBt7z19mX2a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 384, DateTimeKind.Utc).AddTicks(6709), "$2a$12$pOe3FmoOWFquEbs6FBeGQOsUTwMhrBjx772DdJ2IMx2uC8jtHBS.m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 615, DateTimeKind.Utc).AddTicks(8189), "$2a$12$3dMsijUpUXmg46yS/3zLueXuhJ.8DrVrXCdwzL2dizugTw0FNfJma" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 842, DateTimeKind.Utc).AddTicks(4638), "$2a$12$UPZleLY5eUkURZjgNQTIeuQ06lIyVLuoFdVyAY1BDpjtp..weljwq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 69, DateTimeKind.Utc).AddTicks(7134), "$2a$12$quNmzghqgVxbXBRCIvO94.gvaFNHHKvHmlFkGIQspbpjrwpOuZBGy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 297, DateTimeKind.Utc).AddTicks(806), "$2a$12$Kme5FUV5Pw4xEhegigeZ9OvJAqmHhsR9qbiS4wWdgzpVs/wibrHC6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 524, DateTimeKind.Utc).AddTicks(6178), "$2a$12$yMu3c9Vh3G/gc40cEt8wduTXeKUH/3ZJdXiiunhskh5fcWAvRytc6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 751, DateTimeKind.Utc).AddTicks(1997), "$2a$12$gOknzdzLqfFMrz4mjKEYCea/22NRTFR11OWgSHMrayiG1QScWhGq." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 977, DateTimeKind.Utc).AddTicks(8014), "$2a$12$XElTjIfS2.g37e.GCI2fqeg/h5GPCuH/GQpastcvmRq8M3Dwc6.H6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 204, DateTimeKind.Utc).AddTicks(4922), "$2a$12$dmmdR5hmENyuV3mR/bOnQea18SoUJY.wtFgl9ty4yX/7n9gnvVnAi" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2235), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2244), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2244) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2246), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2246) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2248), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2249), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "HotpotDeposit",
                table: "RentOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3075), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3079), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3081), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3083), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2965), new DateTime(2025, 3, 6, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2977), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2979), new DateTime(2025, 3, 6, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2981), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2982) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2983), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2984) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2984), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2986), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2987), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2988) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2989), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2991), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2991) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2992), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2993) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2994), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2995) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2996), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2998), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2998) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2999), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3008), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3009) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3010), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3012), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3012) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3013), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3015), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3016), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3018), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3019), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3021), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3022) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3023), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3023) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3024), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3025) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5026), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5032), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5033) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5035), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5038), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5042), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5042) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5045), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5048), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4646), "$2a$12$oevRlwFgHzOW.PLRdMTWh.q6Z6NueGtQcU1dPqZGmgxz83Q37SfIa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 407, DateTimeKind.Utc).AddTicks(635), "$2a$12$ooQK45fg7wP/DEcmaIvAX.RcHIDlvnQHq5wI3DoFcv72a1vgtMkoG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 634, DateTimeKind.Utc).AddTicks(166), "$2a$12$8nN0BUlw29zdsrPsaIFfg.KibAiiDWZCm4cmU5kvWPqG9/kEP1/4y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 878, DateTimeKind.Utc).AddTicks(1603), "$2a$12$i/693.tSIWMZjWjNZuM30eoRamL44lL9ZOXMnBFEj.ORQRWPWyd6y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 122, DateTimeKind.Utc).AddTicks(3619), "$2a$12$xSC8BkWuCk2D8gQ1ot8Pg.tQmglNEfhxj1/L.4EAmKEhbtnOM8bwK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 350, DateTimeKind.Utc).AddTicks(6721), "$2a$12$nClArMXWXQcrzwAAASatNOp4IEg6qyMp63u0gr8v3y4ADQZBUFkYK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 586, DateTimeKind.Utc).AddTicks(1155), "$2a$12$XVOJwLJk1viy8D4anyWB8.rKsPEweUDyTJdlKOo0RmM0D512rMRf2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 829, DateTimeKind.Utc).AddTicks(4677), "$2a$12$RZ0uH.ySFYbojZjYJvVVUufmkqAvp6kn/3WuS9mL73sBOank0mjd." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 74, DateTimeKind.Utc).AddTicks(7261), "$2a$12$LCIwhSlA83npijuRhpScZOFOk72xqxJq3cy.hWJk03gHlsoNQx906" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 305, DateTimeKind.Utc).AddTicks(9301), "$2a$12$lv8Djage90SV8unmIRx2Bu/l91w6/ZCZpWkTCWymLw7iowCcOqcYG" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2708), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2708) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2715), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2718), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2718) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2721), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2723), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2723) });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");
        }
    }
}
