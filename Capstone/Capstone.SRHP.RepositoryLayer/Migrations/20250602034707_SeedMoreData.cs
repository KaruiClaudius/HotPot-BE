using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9542), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9547) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9550), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9551) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9551), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9552) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8653), 1, "CP-2023-0003" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8654), 1, "CP-2023-0004" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8655), 1, "CP-2023-0005" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8656), 1, "CP-2023-0006" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8657), 1, "CP-2023-0007" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8657), "CP-2023-0008" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "SeriesNumber", "Status" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8658), "CP-2023-0009", 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "SeriesNumber", "Status" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8659), "CP-2023-0010", 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8660), 2, "EL-2023-0001" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8661), 2, "EL-2023-0002" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8661), 2, "EL-2023-0003" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8662), 2, "EL-2023-0004" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber", "Status" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8663), 2, "EL-2023-0005", 0 });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 16, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8664), 2, false, "EL-2023-0002", 0, null },
                    { 17, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8665), 3, false, "PT-2023-0001", 0, null },
                    { 18, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8665), 3, false, "PT-2023-0002", 0, null },
                    { 19, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8666), 3, false, "PT-2023-0003", 0, null },
                    { 20, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8667), 3, false, "PT-2023-0004", 0, null },
                    { 21, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8668), 3, false, "PT-2023-0005", 0, null },
                    { 22, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8669), 3, false, "PT-2023-0006", 0, null },
                    { 23, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8669), 3, false, "PT-2023-0007", 0, null },
                    { 24, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8670), 3, false, "PT-2023-0008", 0, null },
                    { 25, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8671), 3, false, "PT-2023-0009", 0, null },
                    { 26, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8672), 3, false, "PT-2023-0010", 0, null },
                    { 27, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8674), 4, false, "MC-2023-0001", 0, null },
                    { 28, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8675), 4, false, "MC-2023-0002", 0, null },
                    { 29, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8676), 4, false, "MC-2023-0003", 0, null },
                    { 30, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8677), 4, false, "MC-2023-0004", 0, null },
                    { 31, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8677), 4, false, "MC-2023-0005", 0, null },
                    { 32, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8678), 5, false, "CR-2023-0001", 0, null },
                    { 33, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8679), 5, false, "CR-2023-0002", 0, null },
                    { 34, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8681), 5, false, "CR-2023-0003", 0, null },
                    { 35, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8682), 5, false, "CR-2023-0004", 2, null },
                    { 36, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8683), 5, false, "CR-2023-0005", 0, null },
                    { 37, new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8684), 5, false, "CR-2023-0006", 0, null }
                });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 16, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9371), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 23, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9374), new DateTime(2025, 6, 1, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 16, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9388), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 12, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9389), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 9, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9391), new DateTime(2025, 5, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 7, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9393), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 9, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9394), new DateTime(2025, 5, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 7, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9397), new DateTime(2025, 6, 1, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 6, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9398), new DateTime(2025, 6, 1, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 9, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9400), new DateTime(2025, 5, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 8, 1, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9402), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 8, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9403), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 8, 1, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9405), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 9, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9406), new DateTime(2025, 5, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 16, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9408), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 12, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9409), new DateTime(2025, 5, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 6, 9, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9411), new DateTime(2025, 5, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 7, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9412), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 7, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9414), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 7, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9415), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 7, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9417), new DateTime(2025, 5, 28, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 8, 31, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9418), new DateTime(2025, 5, 23, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 11, 29, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9420), new DateTime(2025, 5, 23, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 11, 29, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9421), new DateTime(2025, 5, 23, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250602104706", new DateTime(2025, 11, 29, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9423), new DateTime(2025, 5, 23, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9039), new DateTime(2025, 5, 3, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9041) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9049), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9051), new DateTime(2025, 5, 3, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9052) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9052), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9053) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9054), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9054) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9055), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9057), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9058), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9061), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9062), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9064), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9064) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9065), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9067), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9067) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9068), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9070), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9077), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9079), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9080), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9082), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9083), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9085), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9086), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9087), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9089), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9090), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9092), new DateTime(2025, 5, 30, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 3, 226, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 3, 226, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 3, 226, DateTimeKind.Utc).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 3, 226, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9609), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9613), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9616), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9616) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9620), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9622), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9625), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9625) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9627), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 3, 226, DateTimeKind.Utc).AddTicks(8298), "$2a$12$Nt.S4XXpNm8urXCEbXe6b.L0zWHu5erf1WKbw5.h9fn0hssLl8HA." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 3, 465, DateTimeKind.Utc).AddTicks(763), "$2a$12$2l8o.pqCCCnSAJcTdpsSZuw7SHD1C4wHOI9yd.M8znVinGAAoiWYa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 3, 696, DateTimeKind.Utc).AddTicks(6967), "$2a$12$BszgLcSimcY5xqR0XRGUQ.UENfBcYlZPY5tSS1ZWavSSRl6VgaZuu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 3, 931, DateTimeKind.Utc).AddTicks(8006), "$2a$12$p78JIQyzNDvcZBeoQc4Ce..0BukfajBn2SNlnXoK1vt5t1r4LrMqi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 4, 170, DateTimeKind.Utc).AddTicks(2458), "$2a$12$dFC77UTwpRMOErbDbIcZ3.97SxIFya6hdMpBim.JIARLzsX6jNGt." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 4, 417, DateTimeKind.Utc).AddTicks(9349), "$2a$12$8Ry5Q1T521aGJlxi.kv1EOXpd96FFXPYZ4WE/gIEbzOhmLnI1IYjS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 4, 694, DateTimeKind.Utc).AddTicks(1557), "$2a$12$IqBCcRAqV4FzQPC9adjQGOL0dSsERpnD8Mk01wBCfBkWRXxQqsOMO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 5, 907, DateTimeKind.Utc).AddTicks(2551), "$2a$12$clXBrZBlQ6jgUU0WVxEk5u/TdctxcJ6OZqBAouvPWSCDrfDBniopC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 139, DateTimeKind.Utc).AddTicks(5902), "$2a$12$KkvlaFQIOxYkdB5kNSOUWOyt9T2FEAVGNjun0BXZoqzla8PG3YIsy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 373, DateTimeKind.Utc).AddTicks(5272), "$2a$12$Zsw54685bIr5WZ4.GwZvluAMOOwP.Sx3evvxkTc.jasqYtfEl5oKC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 4, 945, DateTimeKind.Utc).AddTicks(7745), "$2a$12$ulDFep7Pi4dyITK2mXrPY.F0RkeZDcrdYT42dCQSIMM5jCjPXh4NW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 5, 201, DateTimeKind.Utc).AddTicks(4847), "$2a$12$eny.96hZ8aXJynF//RP.SO1JnPqOjlCRQ4F1qFSMiBNrOEmkMSTkO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 5, 441, DateTimeKind.Utc).AddTicks(4124), "$2a$12$3389WwZf8vBv0QSeYi7RLuEZiAkYAUw1F0vrroaY0gO.7CDWhurBG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 5, 675, DateTimeKind.Utc).AddTicks(6432), "$2a$12$mUeD4KZpeYaa1xwf1gdQLeD1Pv3sxy1s4VcETuu061so2hcamPsxe" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8767), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8775), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8777), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8777) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8779), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8781), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9673), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9675) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9677), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9677) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9679), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9681), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9683), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9686), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9686) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9688), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9688) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9690), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9692), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9733), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9735), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9735) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9737), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9739), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9742), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9744), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9746), new DateTime(2025, 6, 2, 10, 47, 6, 601, DateTimeKind.Utc).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1776), new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1781), new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1783), new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1783) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1785), new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1788), new DateTime(2025, 6, 2, 10, 47, 6, 602, DateTimeKind.Utc).AddTicks(1788) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 37);

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
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5478), 2, "EL-2023-0001" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5479), 2, "EL-2023-0002" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5480), 3, "PT-2023-0001" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5481), 4, "MC-2023-0001" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5482), 5, "CR-2023-0001" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5483), "CP-2023-0003" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "SeriesNumber", "Status" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5484), "CP-2023-0004", 2 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "SeriesNumber", "Status" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5485), "CP-2023-0005", 2 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5486), 3, "PT-2023-0002" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5487), 4, "MC-2023-0002" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5488), 5, "CR-2023-0002" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5489), 5, "CR-2023-0003" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "HotpotId", "SeriesNumber", "Status" },
                values: new object[] { new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5490), 5, "CR-2023-0004", 2 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 43, 42, 302, DateTimeKind.Utc).AddTicks(5231));

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
    }
}
