using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class seedpackagedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6598), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6603) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6604), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6605) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6606), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6607) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 2, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2953), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 2, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2959), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 29, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5405), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 26, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5411), new DateTime(2025, 5, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5413), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 26, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5414), new DateTime(2025, 5, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 24, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 23, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5417), new DateTime(2025, 5, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 26, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5419), new DateTime(2025, 5, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 7, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5420), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 8, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5422), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 7, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5424), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 26, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5425), new DateTime(2025, 5, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 2, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5426), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 29, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5428), new DateTime(2025, 5, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 5, 26, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5429), new DateTime(2025, 5, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5431), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5432), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5434), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 6, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5435), new DateTime(2025, 5, 14, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 8, 17, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5436), new DateTime(2025, 5, 9, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 11, 15, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5438), new DateTime(2025, 5, 9, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 11, 15, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5439), new DateTime(2025, 5, 9, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519063039", new DateTime(2025, 11, 15, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5441), new DateTime(2025, 5, 9, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 9, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5442), new DateTime(2025, 5, 18, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.InsertData(
                table: "IngredientPackagings",
                columns: new[] { "PackagingId", "CreatedAt", "IngredientId", "IsDefault", "IsDelete", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6179), 1, false, false, "Nhỏ", 250, null },
                    { 2, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6180), 1, true, false, "Vừa", 500, null },
                    { 3, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6181), 1, false, false, "Lớn", 1000, null },
                    { 4, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6215), 2, false, false, "Nhỏ", 250, null },
                    { 5, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6215), 2, true, false, "Vừa", 500, null },
                    { 6, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6216), 2, false, false, "Lớn", 1000, null },
                    { 7, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6236), 3, false, false, "Nhỏ", 250, null },
                    { 8, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6237), 3, true, false, "Vừa", 500, null },
                    { 9, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6237), 3, false, false, "Lớn", 1000, null },
                    { 10, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5741), 4, false, false, "Nhỏ", 250, null },
                    { 11, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5742), 4, true, false, "Vừa", 500, null },
                    { 12, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5743), 4, false, false, "Lớn", 1000, null },
                    { 13, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5863), 5, false, false, "Nhỏ", 250, null },
                    { 14, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5863), 5, true, false, "Vừa", 500, null },
                    { 15, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5864), 5, false, false, "Lớn", 1000, null },
                    { 16, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5886), 6, false, false, "Nhỏ", 250, null },
                    { 17, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5886), 6, true, false, "Vừa", 500, null },
                    { 18, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5887), 6, false, false, "Lớn", 1000, null },
                    { 19, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5908), 7, false, false, "Nhỏ", 250, null },
                    { 20, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5909), 7, true, false, "Vừa", 500, null },
                    { 21, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5910), 7, false, false, "Lớn", 1000, null },
                    { 22, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5987), 8, false, false, "Nhỏ", 250, null },
                    { 23, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5988), 8, true, false, "Vừa", 500, null },
                    { 24, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5988), 8, false, false, "Lớn", 1000, null },
                    { 25, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6009), 9, false, false, "Nhỏ", 250, null },
                    { 26, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6010), 9, true, false, "Vừa", 500, null },
                    { 27, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6010), 9, false, false, "Lớn", 1000, null },
                    { 28, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6030), 10, false, false, "Nhỏ", 250, null },
                    { 29, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6031), 10, true, false, "Vừa", 500, null },
                    { 30, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6032), 10, false, false, "Lớn", 1000, null },
                    { 31, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6052), 11, false, false, "Nhỏ", 250, null },
                    { 32, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6053), 11, true, false, "Vừa", 500, null },
                    { 33, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6053), 11, false, false, "Lớn", 1000, null },
                    { 34, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6073), 12, false, false, "Nhỏ", 250, null },
                    { 35, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6074), 12, true, false, "Vừa", 500, null },
                    { 36, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6074), 12, false, false, "Lớn", 1000, null },
                    { 37, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6093), 13, false, false, "Nhỏ", 250, null },
                    { 38, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6094), 13, true, false, "Vừa", 500, null },
                    { 39, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6095), 13, false, false, "Lớn", 1000, null },
                    { 40, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6115), 14, false, false, "Nhỏ", 250, null },
                    { 41, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6116), 14, true, false, "Vừa", 500, null },
                    { 42, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6116), 14, false, false, "Lớn", 1000, null },
                    { 43, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6137), 15, false, false, "Nhỏ", 250, null },
                    { 44, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6138), 15, true, false, "Vừa", 500, null },
                    { 45, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6139), 15, false, false, "Lớn", 1000, null },
                    { 46, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6160), 16, false, false, "Nhỏ", 250, null },
                    { 47, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6161), 16, true, false, "Vừa", 500, null },
                    { 48, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6161), 16, false, false, "Lớn", 1000, null },
                    { 49, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5639), 17, false, false, "Nhỏ", 250, null },
                    { 50, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5642), 17, true, false, "Vừa", 500, null },
                    { 51, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5643), 17, false, false, "Lớn", 1000, null },
                    { 52, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5673), 18, false, false, "Nhỏ", 250, null },
                    { 53, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5673), 18, true, false, "Vừa", 500, null },
                    { 54, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5673), 18, false, false, "Lớn", 1000, null },
                    { 55, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5700), 19, false, false, "Nhỏ", 250, null },
                    { 56, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5700), 19, true, false, "Vừa", 500, null },
                    { 57, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5701), 19, false, false, "Lớn", 1000, null },
                    { 58, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5720), 20, false, false, "Nhỏ", 250, null },
                    { 59, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5721), 20, true, false, "Vừa", 500, null },
                    { 60, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(5721), 20, false, false, "Lớn", 1000, null },
                    { 61, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6454), 21, false, false, "Nhỏ", 50, null },
                    { 62, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6456), 21, true, false, "Vừa", 100, null },
                    { 63, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6457), 21, false, false, "Lớn", 200, null },
                    { 64, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6481), 22, false, false, "Nhỏ", 50, null },
                    { 65, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6481), 22, true, false, "Vừa", 100, null },
                    { 66, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6482), 22, false, false, "Lớn", 200, null },
                    { 67, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6534), 23, false, false, "Nhỏ", 50, null },
                    { 68, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6535), 23, true, false, "Vừa", 100, null },
                    { 69, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6536), 23, false, false, "Lớn", 200, null },
                    { 70, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6558), 24, false, false, "Nhỏ", 50, null },
                    { 71, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6559), 24, true, false, "Vừa", 100, null },
                    { 72, new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6559), 24, false, false, "Lớn", 200, null }
                });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2600), new DateTime(2025, 4, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2602) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2613), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2614) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2615), new DateTime(2025, 4, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2615) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2616), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2617), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2618) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2619), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2620), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2622), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2622) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2623), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2624) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2625), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2626), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2628), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2629) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2629), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2631), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2631) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2632), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2639), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2640), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2642), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2643), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2646), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2647) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2647), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2648) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2649), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2649) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2650), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2651) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2652), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2652) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2653), new DateTime(2025, 5, 16, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2654) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 35, 718, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 35, 718, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 35, 718, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 35, 718, DateTimeKind.Utc).AddTicks(5469));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6660), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6662) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6664), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6665) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6667), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6668) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6670), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6670) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6672), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6675), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6678), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6678) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 35, 718, DateTimeKind.Utc).AddTicks(5646), "$2a$12$OMZIHzQ20KGzJKBLlPI3Oew2u6aCOonTDazrGgaLdoez3dSsd3ESK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 35, 967, DateTimeKind.Utc).AddTicks(7601), "$2a$12$ZeniGtmO4giZAt7.T67oZOPaGegFAImI3m4CHq5BzkYcdSJ1s/IaK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 36, 226, DateTimeKind.Utc).AddTicks(5943), "$2a$12$EVkoyEr4Mh8F2ldk.rR/d.3C6NmFzvFtC0J7AbAX87GhD3TIyHgr." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 36, 475, DateTimeKind.Utc).AddTicks(9147), "$2a$12$6YQdnebvxlQ.d6Gnnpl1Se1K9vx1z3MrNL0XsbLaPXypWTD3wJp.y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 36, 726, DateTimeKind.Utc).AddTicks(3708), "$2a$12$g23O7WY9BN9GsOETBzuIW.1bKT7CyNbPe86mAY4fZGoDXNbUiq9/." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 36, 967, DateTimeKind.Utc).AddTicks(893), "$2a$12$xwFGRr4hWKKolrdYxJBu6ODt4Y8xMD1vbocFmER84M6Fu4CbbYIAq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 37, 194, DateTimeKind.Utc).AddTicks(8932), "$2a$12$saHdPgEXyAq7BT6hWNlItOQwJl2yIfeN9ZYLbhEQPrBniSsCkOzr2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 38, 403, DateTimeKind.Utc).AddTicks(8755), "$2a$12$/mwC3V6Wzby0nOyWJlQVAufMMVXCG8KuTjhuD71tWSVmCXbFxq7he" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 38, 642, DateTimeKind.Utc).AddTicks(8561), "$2a$12$f4e8rGscILBMQ5NvWkEQT.SUWd9/ZM/WgE8ax3Xz2ZdC8auL8/wEu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 38, 875, DateTimeKind.Utc).AddTicks(5815), "$2a$12$2LSulMBzdYQnFWaY.Lk0LOqpUR.1HLKGt.Gjwmv1LmByibH14ECC6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 37, 425, DateTimeKind.Utc).AddTicks(1413), "$2a$12$Xl9/NCFrbcieazLpLiWO0eUZ.MvtU8hM4lXlBqD126ZUGPNju9HyW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 37, 670, DateTimeKind.Utc).AddTicks(7797), "$2a$12$gOHk96YiZa32oE3zm7ih.u9wHSl988H5K7eRxSX9vdM7wzwLywK3O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 37, 904, DateTimeKind.Utc).AddTicks(5031), "$2a$12$D3vH16svB0EuaDRMLiQMF.zxEQtzCJra27jf8CEd7Oic0QU6KVOZK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 38, 152, DateTimeKind.Utc).AddTicks(309), "$2a$12$C9KllE6UD3O82z3alqcsaOSj2Hlp/l.r8l6mrb6d4PPRKjPzeR4W6" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2284), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2284) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2293), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2295), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2297), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2297) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2299), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6726), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6728) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6730), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6733), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6733) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6735), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6737), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6743), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6745), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6747), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6748) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6750), new DateTime(2025, 5, 19, 13, 30, 39, 117, DateTimeKind.Utc).AddTicks(6750) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "IngredientPackagings",
                keyColumn: "PackagingId",
                keyValue: 72);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6857), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6866), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 2, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6727), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 2, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6730), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 29, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6738), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6739), new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6741), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6742), new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 24, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6744), new DateTime(2025, 5, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 23, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6745), new DateTime(2025, 5, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6747), new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 7, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6748), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 8, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6750), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 7, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6751), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6753), new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 2, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6755), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 29, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6757), new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6758), new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6759), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6761), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6762), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6764), new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 8, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6765), new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 11, 15, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6767), new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 11, 15, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6768), new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 11, 15, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6770), new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6771), new DateTime(2025, 5, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6409), new DateTime(2025, 4, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6411) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6420), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6421) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6422), new DateTime(2025, 4, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6422) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6423), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6424) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6425), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6425) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6426), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6427), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6428) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6429), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6430), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6432), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6432) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6433), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6434) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6435), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6436), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6437), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6438) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6439), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6446) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6447), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6448), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6449) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6449), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6451), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6452), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6453) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6454), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6454) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6455), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6456) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6456), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6457) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6458), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6459), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6461), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6461) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6928), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6932), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6933) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6935), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6936) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6938), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6940), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6943), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6946), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7537), "$2a$12$j2mE2Xf1AxjuzsH/LdWpl.AmP.zg1R60VlrtDVz6GNs0OxscqncDm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 54, 905, DateTimeKind.Utc).AddTicks(347), "$2a$12$ysWQPWok7K83MB2YUSEHvuHshDuw4pC50JcKtMT8Vz.HpYasP3pfy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 157, DateTimeKind.Utc).AddTicks(7875), "$2a$12$Y2IK.Ay.RU3M5G/WsEw8DuXPOuTd7SrQ/CCVL/lM9zzg/o9YVbOkG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 390, DateTimeKind.Utc).AddTicks(8527), "$2a$12$oGIbFrEJx8eBsaDFK0i9vOPhcH7bg9rWI2U4kT4mLM1hVWLjqe5Sy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 616, DateTimeKind.Utc).AddTicks(5793), "$2a$12$Dus2q05fNuSfZAIwK62elO7nnglKD8FBFOhamtSAFItO56wxv/zEW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 842, DateTimeKind.Utc).AddTicks(2998), "$2a$12$7cdGT1HmeIdkcXtgvmwFK.PN1o.PSg45Rsd4VcZ8.DipfqJKo1fFO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 68, DateTimeKind.Utc).AddTicks(5409), "$2a$12$BN.nSNZyp4ydUjpP4hhZmusaVpi3P0OI8c.AwD7.0GPrtFl4eyeJ6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 251, DateTimeKind.Utc).AddTicks(2003), "$2a$12$k0dYQrJ9cV0Qf0oSy498p.UTIL60cyuXHufwWEXzTAyv2SnOdYwNG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 502, DateTimeKind.Utc).AddTicks(7587), "$2a$12$8IvIuQHsT4gupdJxUGtK2ugs70n7Fqj0Ox1wBm2a5AlNixkRSrXvq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 753, DateTimeKind.Utc).AddTicks(769), "$2a$12$tPi44WSLeUpnfpNlyIFvzuFDLmF174iFcHy5ksP8Gy/TkFvSsZDKK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 294, DateTimeKind.Utc).AddTicks(2143), "$2a$12$R5x.HyJvV2zvnUoNYwE2c.73cxVIM3y2azelpGH3MEt9GOsMPfa/K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 520, DateTimeKind.Utc).AddTicks(6458), "$2a$12$jL/D3/LbGhPYH2PzuRaQK.FEQmyTnWSxnjYf.jhFLpNFilJ2bEaRS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 763, DateTimeKind.Utc).AddTicks(4599), "$2a$12$O3havNcnLuR8PWpOE/beHOq5fg7XxioKrYERNK5K72hmiNB8IIu9i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 4, DateTimeKind.Utc).AddTicks(2495), "$2a$12$TGWDiSt8yPsVUfBB6WOAa.XWPdHdNiy74UiIAOb1hfJjP/0O5v.tO" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6130), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6135), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6137), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6139), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6141), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7000), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7003), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7004) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7006), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7008), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7008) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7010), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7012), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7014), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7015) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7017), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7017) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7019), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7021), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7021) });
        }
    }
}
