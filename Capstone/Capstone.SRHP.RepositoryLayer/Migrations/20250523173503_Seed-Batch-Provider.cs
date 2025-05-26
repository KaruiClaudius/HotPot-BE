using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedBatchProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7564), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7572) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7576), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7577) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7579), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 7, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7261), "FPT", new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 14, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7273), "FPT", new DateTime(2025, 5, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 7, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7287), "FPT", new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 3, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7289), "FPT", new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 31, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7291), "FPT", new DateTime(2025, 5, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7293), "FPT", new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 31, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7296), "FPT", new DateTime(2025, 5, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 29, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7298), "FPT", new DateTime(2025, 5, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 28, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7301), "FPT", new DateTime(2025, 5, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 31, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7303), "FPT", new DateTime(2025, 5, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 7, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7305), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 8, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7310), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 7, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7312), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 31, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7315), "FPT", new DateTime(2025, 5, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 7, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7370), "FPT", new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 3, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7374), "FPT", new DateTime(2025, 5, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 5, 31, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7376), "FPT", new DateTime(2025, 5, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7378), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7380), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7383), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 6, 23, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7385), "FPT", new DateTime(2025, 5, 19, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 8, 22, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7387), "FPT", new DateTime(2025, 5, 14, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 11, 20, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7389), "FPT", new DateTime(2025, 5, 14, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 11, 20, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7391), "FPT", new DateTime(2025, 5, 14, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250524003501", new DateTime(2025, 11, 20, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7393), "FPT", new DateTime(2025, 5, 14, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6826), new DateTime(2025, 4, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6844), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6847), new DateTime(2025, 4, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6849), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6851), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6853), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6856), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6856) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6860), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6862), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6862) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6866), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6868) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6869), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6871), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6872) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6874), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6882), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6914), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6915) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6916), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6918), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6920), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6922), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6923) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6924), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6924) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6926), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6927) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6928), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6929) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6930), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6932), new DateTime(2025, 5, 21, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6933) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6511));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 34, 57, 819, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 34, 57, 819, DateTimeKind.Utc).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 34, 57, 819, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 34, 57, 819, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7679), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7686), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7690), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7695), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7696) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7699), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7703), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7707), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 57, 819, DateTimeKind.Utc).AddTicks(7266), "$2a$12$IITnAfyFwlz51auEUjJyiuggbR5Y02ljnzggIHKidXorWFmLX4coC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 58, 72, DateTimeKind.Utc).AddTicks(3290), "$2a$12$.mxN1/d19.IGlTA.Ephek.PgwHrlp2J51sFF2tsuwexxdZOipASRu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 58, 345, DateTimeKind.Utc).AddTicks(5041), "$2a$12$NgqEm/gBGLzMMNqI4UVkAei1mgnOuwf8j567wh/wwH8S4OAp4Dlva" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 58, 603, DateTimeKind.Utc).AddTicks(2207), "$2a$12$zx1aPGQFf68qt0AwM5DvPO2hquYGC76cJSW3wXMX4OrjU3Uyl0e8q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 58, 853, DateTimeKind.Utc).AddTicks(5994), "$2a$12$aYFM06O3B5v8tFysLNxEh.zao5aldvrcosYEqxqza9nyKOy6paNia" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 59, 104, DateTimeKind.Utc).AddTicks(9035), "$2a$12$4/EKitOCQZxO.lsMnW8r4OCnRXS.6OWXykA4TweWEGXu64bCC4uO." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 59, 346, DateTimeKind.Utc).AddTicks(8456), "$2a$12$w51YA5Q2bhrCAO3MoMSf9ehmTNWKNVvTSJM3X6Iw3sa.UvIYNsuWG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 0, 696, DateTimeKind.Utc).AddTicks(3771), "$2a$12$uLbEg2BUts1o1PXEZ2QiZOTaTMuTcgfg5xQ7y0AQRNpry8l8Vj8/i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 0, 953, DateTimeKind.Utc).AddTicks(8111), "$2a$12$X1TYcXYK4Cn1TKIazhs33e1udWNFzsKlQp4wlMp8GyeC3/R6ERahy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 214, DateTimeKind.Utc).AddTicks(9783), "$2a$12$gu5slBNzXSS1ojNTTF06euFz9hGVG/mnotCFqLQ8B1/WoMauJZ.im" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 59, 594, DateTimeKind.Utc).AddTicks(5001), "$2a$12$5FSFgNwfvDFIH7f6lZ4MEuXrfQqgKVT9SR/mkLrJfUbz1/KchBP0i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 34, 59, 880, DateTimeKind.Utc).AddTicks(7503), "$2a$12$mtb.u2W0q5.Gu1AeVB5CSuycULhTnSG08ZEfhHy1qMTcyV0hsL/cm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 0, 154, DateTimeKind.Utc).AddTicks(5288), "$2a$12$YbnS9FHg.ohIZf0KcqXgTeRrPmCSpGvRtMjqfeP/V85dQ0iwYRe/e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 0, 429, DateTimeKind.Utc).AddTicks(2092), "$2a$12$91vzm989pV0M5E3bRu3aeegtBUQGdXhx0CemKr9Msq4rI5eL9ms2C" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6406), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6406) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6425), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6425) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6428), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6428) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6431), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6433), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(6434) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7804), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7806) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7809), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7813), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7816), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7819), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7823), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7826), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7829), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7834), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7835) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7838), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7842), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7843) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7846), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7849), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7852), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7852) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7855), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7855) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7858), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7858) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7869), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7872), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7875), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7876) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7878), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7881), new DateTime(2025, 5, 24, 0, 35, 1, 509, DateTimeKind.Utc).AddTicks(7882) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(231), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(241), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(242) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(243), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 6, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7721), null, new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7724), null, new DateTime(2025, 5, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 6, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9893), null, new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 2, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9904), null, new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9906), null, new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9908), null, new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9912), null, new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 28, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9913), null, new DateTime(2025, 5, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 27, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9915), null, new DateTime(2025, 5, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9917), null, new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 7, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9919), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 8, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9921), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 7, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9923), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9924), null, new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 6, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9926), null, new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 2, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9928), null, new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9930), null, new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9932), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9933), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9935), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9937), null, new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 8, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9939), null, new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 11, 19, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9940), null, new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 11, 19, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9942), null, new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 11, 19, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9944), null, new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7329), new DateTime(2025, 4, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7341), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7343), new DateTime(2025, 4, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7344), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7346), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7348), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7349), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7351), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7353), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7354), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7356), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7358), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7360), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7361), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7363), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7375), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7377), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7378), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7380), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7382), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7383), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7385), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7386) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7386), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7388), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7390), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7391), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 25, 508, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 25, 508, DateTimeKind.Utc).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 25, 508, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 25, 508, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(358), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(366), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(367) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(370), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(371) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(451), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(451) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(604), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(620), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(626), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(628) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 25, 508, DateTimeKind.Utc).AddTicks(3031), "$2a$12$0wkqzPa25lKCZNhS1iu.fOPUrDTrlB4MOxXQD57Y8GguUnWJLI/dq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 25, 755, DateTimeKind.Utc).AddTicks(2730), "$2a$12$8oUPw2ugGkd.ugh/XKqQ0.VW8ibNjNwAY5Bi.blirQmM0qQJ0NUUm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 26, 28, DateTimeKind.Utc).AddTicks(4120), "$2a$12$1Gi5YeG.PTbviuR/KbJHKewbkSjAhMpZ3y.4r3.PdY13NmZPt/y16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 26, 285, DateTimeKind.Utc).AddTicks(8855), "$2a$12$1rdNXFH4Yrq5EvP6bWOXmudxqCZpuvTbVObuzifq1EM4Fap/qiUda" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 26, 529, DateTimeKind.Utc).AddTicks(1846), "$2a$12$E75O1XrNmQBXM4GEj2uLoODXHZNmT5x4ko8H08BDH/wW7Oeca1J3m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 26, 784, DateTimeKind.Utc).AddTicks(4447), "$2a$12$c0Qz74h0kZZX1J6t8.QkT.e1aj4Q.L/VQDPh1aFPgqhOweqTNxnSy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 27, 24, DateTimeKind.Utc).AddTicks(460), "$2a$12$MA0V9LJw0QHyiPZ7TpgKzOXZ60jPTn8yTYZIkhF5f/oLC3znGTrQy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 28, 363, DateTimeKind.Utc).AddTicks(4118), "$2a$12$ShIuK9.LX2APO1NFXb8gm.pA7OhqWQnkVYbnUhHklR5RlfjQ8MNgO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 28, 634, DateTimeKind.Utc).AddTicks(4708), "$2a$12$cFsM2UOpUWF2ueM.ygBrDuldeEhBIuwhY/.N8Fn9GpCJCvRbfChXu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 28, 915, DateTimeKind.Utc).AddTicks(7798), "$2a$12$fcmevh0B72jsd.P9GkUYnuh/ShIgSdJKua2GvMYfhoTtB7Lbl9Veu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 27, 266, DateTimeKind.Utc).AddTicks(692), "$2a$12$kFqEK3UEOyV.xptlyNQEN.F87QfqufHQ3Yiup6zHbKasVQGYg2EvS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 27, 535, DateTimeKind.Utc).AddTicks(4194), "$2a$12$5mK/sHL3l1M3rl7T4eoyv.BNDTVbQuMdJypQfthIRO/SvsP6obPhe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 27, 806, DateTimeKind.Utc).AddTicks(8445), "$2a$12$R3xCqQIx.6fLn4f3Qk16cesINAIo1tqSEYyF5bBcgbUptB5P24TGq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 28, 76, DateTimeKind.Utc).AddTicks(7534), "$2a$12$of852D7keMxcoUszAELd7OGD3vCHQTT5Rh5ZHgjfzVGJKcf93l1Ma" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7058), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7065), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7065) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7067), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7070), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7072), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(927), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(932), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(936), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(940), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(943), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(946), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(949), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(952), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(954), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(957), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(960), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(963), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(967), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(970), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(972), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(975), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(976) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(992), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(995), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(999), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(1007), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 5, 23, 23, 58, 29, 172, DateTimeKind.Utc).AddTicks(1011) });
        }
    }
}
