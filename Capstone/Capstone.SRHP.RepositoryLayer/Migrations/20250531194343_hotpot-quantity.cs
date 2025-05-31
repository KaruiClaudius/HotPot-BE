using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class hotpotquantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Hotpots");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(301), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(306) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(308), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(309) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(310), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(311) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5485));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4489), 73000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5126), 146000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5151), 49000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5197), 171000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5231), 98000m });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 15, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(43), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 22, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(51), new DateTime(2025, 5, 31, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 15, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(70), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 11, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(72), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 8, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(74), new DateTime(2025, 5, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(76), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 8, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(79), new DateTime(2025, 5, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 6, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(81), new DateTime(2025, 5, 31, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 5, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(84), new DateTime(2025, 5, 31, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 8, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(85), new DateTime(2025, 5, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 31, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(88), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 8, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(90), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 31, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(92), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 8, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(94), new DateTime(2025, 5, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 15, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(96), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 11, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(98), new DateTime(2025, 5, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 6, 8, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(100), new DateTime(2025, 5, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(102), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(104), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(106), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 7, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(108), new DateTime(2025, 5, 27, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 8, 30, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(110), new DateTime(2025, 5, 22, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 11, 28, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(112), new DateTime(2025, 5, 22, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 11, 28, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(114), new DateTime(2025, 5, 22, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250601024342", new DateTime(2025, 11, 28, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(116), new DateTime(2025, 5, 22, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9624), new DateTime(2025, 5, 2, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9631) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9641), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9642) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9644), new DateTime(2025, 5, 2, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9645) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9646), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9648), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9649) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9650), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9652), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9653), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9655), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9657), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9658) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9659), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9660) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9661), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9662) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9664), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9666), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9668), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9675), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9677), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9679), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9681), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9682), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9683) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9684), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9686), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9688), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9690), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9692), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9693) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9694), new DateTime(2025, 5, 29, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 38, 871, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 38, 871, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 38, 871, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 38, 871, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(386), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(388) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(393), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(393) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(396), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(400), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(403), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(404) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(407), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(407) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(410), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 38, 871, DateTimeKind.Utc).AddTicks(2090), "$2a$12$uSHooYvDjFzVIEXiRGUyb.1Ukquyq9HjCBBBbzBIIsdqQp45DEA0O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 39, 112, DateTimeKind.Utc).AddTicks(5390), "$2a$12$mvhir7CwpItd5JSs/8XypuhE9Y6QmE.9IPDtB1Gv6IjgyVnwkDQfK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 39, 370, DateTimeKind.Utc).AddTicks(4007), "$2a$12$coyHRlVJzIm9.JWBVcOfMu6Bb0B/NNDWzEr0YVdwJx9agAfTsWZ.W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 39, 624, DateTimeKind.Utc).AddTicks(9412), "$2a$12$EZVuLyIgBLt8dKUkKgZqq.xdoNsfYs8g33D5F7V6HlCRRHonF.Roq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 39, 859, DateTimeKind.Utc).AddTicks(1790), "$2a$12$jSadXDNDtNbxeKEAgcv34OkF6A/.NphHCIwQcQvopn7vAicqTy2.q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 40, 93, DateTimeKind.Utc).AddTicks(1220), "$2a$12$4Qk3l4q/8yvp0TuH.ibsZuEt5uYOIHo/z1tJdZA9ZEDQnB4nCkNx." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 40, 329, DateTimeKind.Utc).AddTicks(4378), "$2a$12$pZxeZhVBTukTrub7sGVNbORC3XKULHAkyey9gjlwe0IIyeAT/KXsS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 41, 517, DateTimeKind.Utc).AddTicks(4079), "$2a$12$vFbLwZxjmeGS1xomZfBS3OXcTHSSmtshyQnkVU4h4dOSc/ACQe32y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 41, 763, DateTimeKind.Utc).AddTicks(9467), "$2a$12$pmoPga5QClm/hL3WYADP5emecRr62emSF93JQH5oZG27WC0FJJoky" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 23, DateTimeKind.Utc).AddTicks(667), "$2a$12$TgTw9QUBsu3azC93mMnSv.r3jfBwM2/Gn3xYYYyKph0ogzSiq39pK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 40, 572, DateTimeKind.Utc).AddTicks(3991), "$2a$12$zROqqgC9X0iGN07f4D635.5HS3wfc2BAeTufs73iym0uCd9KrjtDC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 40, 810, DateTimeKind.Utc).AddTicks(1539), "$2a$12$cST4Ack3vNeMdvik6GY2Gucq7HEZTEQHGsXYvqwJnJRxvm10WbSYC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 41, 45, DateTimeKind.Utc).AddTicks(2400), "$2a$12$adF9iLWH8PzI5079g5s8LOK4oZ8.cKtUf6qyclbeT0dy/qRckhsKa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 41, 278, DateTimeKind.Utc).AddTicks(510), "$2a$12$NOC6fSwaHcVcBdA/kvOVcO8wLvMdueSlShUdWBGpmL5qUWhbnAm4a" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5576), new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5576) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5586), new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5588), new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5589) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5591), new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5591) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5593), new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5594) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(482), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(482) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(485), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(488), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(491), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(494), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(494) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(497), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(500), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(503), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(505), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(508), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(511), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(514), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(515) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(564), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(565) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(567), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(567) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(570), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(572), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(581), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(581) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(583), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(586), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(589), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(592), new DateTime(2025, 6, 1, 2, 43, 42, 303, DateTimeKind.Utc).AddTicks(592) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Hotpots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4056), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4062), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4063), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2463), 730000m, 5 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2999), 1460000m, 2 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3019), 490000m, 2 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3051), 1710000m, 2 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Price", "Quantity" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3081), 980000m, 4 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 13, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3901), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3904), new DateTime(2025, 5, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 13, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3912), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 9, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3914), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3916), new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3917), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3919), new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 4, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3920), new DateTime(2025, 5, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 3, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3922), new DateTime(2025, 5, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3923), new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 7, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3925), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 8, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3926), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 7, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3928), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3929), new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 13, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3931), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 9, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3932), new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3934), new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3935), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3937), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3939), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3940), new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 8, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3941), new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 11, 26, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3943), new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 11, 26, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3944), new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 11, 26, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3946), new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3593), new DateTime(2025, 4, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3605), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3606), new DateTime(2025, 4, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3608), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3609), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3611), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3611) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3612), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3613) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3614), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3615), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3616), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3617) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3618), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3619), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3621), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3621) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3622), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3623), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3636), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3637) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3637), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3638) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3639), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3640), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3642) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3643), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3645), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3646), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3647), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3649), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3649) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3650), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4127), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4133), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4136), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4138), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4141), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4144), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4146), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9569), "$2a$12$Pk2OwM90vZgCqI06UoPJheJZdQDXPAKRqfPNSWV4dDaP7LKxRPizW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 301, DateTimeKind.Utc).AddTicks(8624), "$2a$12$giEVyKbmqBPqUl9uU1BF3OK9M3EnzWCDK5P/IQ4Lt3QfVXobVM.D." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 540, DateTimeKind.Utc).AddTicks(1077), "$2a$12$TWNL0OR18.Gkd8D/HNqKcOj.bEKfX.iV41t.IvoBGbeKCghbbqUwe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 774, DateTimeKind.Utc).AddTicks(7904), "$2a$12$ZxPppLKyitnw/8W3gIOmYO2WddJOAO25D/m4B1aXxfTmQXfQsXCQe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 9, DateTimeKind.Utc).AddTicks(5222), "$2a$12$SgwYACuWVi08h.DDAiYuv.PcfT1a2VRdjwUR.PJMHf2ILaHJWgxSC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 245, DateTimeKind.Utc).AddTicks(7308), "$2a$12$b9rXNF6NYajM5BiDkohkm.Q3Uv.ft8pDwRUfSULq2oFWCUcjx8F3S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 485, DateTimeKind.Utc).AddTicks(4842), "$2a$12$8BVuKit0eZufsnMZfkzDxOa57sfZ1Gij5hZP8qbBHCfQyzxaJujYy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 656, DateTimeKind.Utc).AddTicks(8297), "$2a$12$7/kAdqVjAI4c03fy14vvbOUldXAHcMfMBGfA47kbOrlQhZaA151Om" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 895, DateTimeKind.Utc).AddTicks(8235), "$2a$12$uJbhIYhyviDuWtSoJJfPW.e7yBCBu7wroev15aDn8i/RN6bCzsXFK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 135, DateTimeKind.Utc).AddTicks(7256), "$2a$12$ucmP.wJuhXKg0M/XQGvLQOIEIz3GbJc7psNvbd4FPpLVMpfg7EZ2." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 718, DateTimeKind.Utc).AddTicks(5627), "$2a$12$p8aJmEh7kAhBdmzOqDxyeeigs6xsY4C9nqvP6tTxau2wZYgNw9zPq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 951, DateTimeKind.Utc).AddTicks(3262), "$2a$12$sN54HLWBh8MUY7m7XUuW3uSNubeHQrYhi4gvhUHs.ndOD/IohRsy6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 185, DateTimeKind.Utc).AddTicks(936), "$2a$12$s8Iqqe6oq.JhHimdTviSleuUkFcRezsrt0W7SdS9aiRgj.k5zoRa6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 418, DateTimeKind.Utc).AddTicks(9308), "$2a$12$7j7KVs0..cF.k7YvnfUVSObDxwqfTCQLqhdMqjXMLGIlNFVOIgiHK" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3302), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3303) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3308), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3308) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3310), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3311) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3312), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3314), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4211), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4213), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4216), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4218), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4220), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4223), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4225), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4227), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4229), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4232), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4234), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4236), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4241), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4275), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4277), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4277) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4286), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4289), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4293), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4294) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4296), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4296) });
        }
    }
}
