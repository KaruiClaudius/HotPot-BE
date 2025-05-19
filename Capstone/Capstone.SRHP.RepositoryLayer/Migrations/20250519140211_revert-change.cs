using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class revertchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9170), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9176), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9178), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9047), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 9, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9050), new DateTime(2025, 5, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9058), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9059), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9061), new DateTime(2025, 5, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9062), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9064), new DateTime(2025, 5, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9065), new DateTime(2025, 5, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9067), new DateTime(2025, 5, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9068), new DateTime(2025, 5, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9070), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9072), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9073), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9075), new DateTime(2025, 5, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9076), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9078), new DateTime(2025, 5, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9079), new DateTime(2025, 5, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9081), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9082), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9084), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9085), new DateTime(2025, 5, 14, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9087), new DateTime(2025, 5, 9, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 15, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9088), new DateTime(2025, 5, 9, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 15, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9090), new DateTime(2025, 5, 9, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 15, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9091), new DateTime(2025, 5, 9, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8942), new DateTime(2025, 4, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8958), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8960), new DateTime(2025, 4, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8961), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8963), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8964), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8966), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8966) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8967), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8968) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8969), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8969) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8970), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8972), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8973) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8973), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8975) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8976), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8977) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8977), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8979), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8987), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8988), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8990), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8991), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8993), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8994), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8996), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8997), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8999), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8999) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9000), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9001) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9002), new DateTime(2025, 5, 16, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 6, 850, DateTimeKind.Utc).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 6, 850, DateTimeKind.Utc).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 6, 850, DateTimeKind.Utc).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 6, 850, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9270), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9275), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9278), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9281), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9284), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9286), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9287) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9289), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 6, 850, DateTimeKind.Utc).AddTicks(8783), "$2a$12$FhornS30JIyGuRD0rtGUiedjkCYcxWWQjzj.x0fmZfGDpszFZbF4G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 7, 93, DateTimeKind.Utc).AddTicks(9156), "$2a$12$CmE.GwbnZkThZcPPDbKyCOrzYu0ov2X7pKsUn6Ccrefosc3Wy7/Qa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 7, 342, DateTimeKind.Utc).AddTicks(1485), "$2a$12$gYZq65REFG4YBQxMDVAj..2njoOMZ9A1j9C2QxdJK0Q7NwbSfv.Qu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 7, 582, DateTimeKind.Utc).AddTicks(1227), "$2a$12$dYWxIxQz8zKVGAO7/LwlXeISoJ9VNDKEO4jBpbgU9ixLfWMUfKLaa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 7, 820, DateTimeKind.Utc).AddTicks(4082), "$2a$12$iqPed.FobNaqDG/Y9AtBEerZF0..aFQcWWpnA7QGP9B8zkhwbV5Gq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 8, 59, DateTimeKind.Utc).AddTicks(7250), "$2a$12$D53n8rYi/ab4fohk3iByd.O6.Y2ObEJvJDUsPD3Lf.D6rEMUUA44i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 8, 294, DateTimeKind.Utc).AddTicks(8228), "$2a$12$SKDuUS7gym3yo/GAK1nAKOuKFrrRwgKs1en6oookka7ZxOMw0Ntri" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 9, 486, DateTimeKind.Utc).AddTicks(685), "$2a$12$fAT1g6F3.sykgD0tQBzW5uupW/RTqBxnyrn00VUt/66TYp.7tiwu6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 9, 733, DateTimeKind.Utc).AddTicks(6409), "$2a$12$fU9vkCxJlZp6hnmXzsLeWetfSaskjDRAmsMbJXVVyuKnd6OwSQuP." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 9, 997, DateTimeKind.Utc).AddTicks(5005), "$2a$12$7T6lgROcCJ3Kud4REaWWZu2ypkVX39dVk.6pbRkmT2UY/vJkMzKry" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 8, 528, DateTimeKind.Utc).AddTicks(502), "$2a$12$kjbteJ7fHGJLLjbbe/2wquPc7DUVrP80vqNLX6Qz2/ZEfUE.lWUIe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 8, 761, DateTimeKind.Utc).AddTicks(8593), "$2a$12$Umf1bxNU9pctAzmkNACuseq8rhujahKsKQFuXd2Mg3U4sEbYliJQy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 8, 998, DateTimeKind.Utc).AddTicks(9518), "$2a$12$QD15dQwFhSrH2Q9Dy3cjUOxjEA9SUZ3YtQe.7Ni0o/pQPhtiwGuim" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 9, 240, DateTimeKind.Utc).AddTicks(6403), "$2a$12$f85TIH.w9FQWvHPFSOYn3eBSHGKhGWgFpv3c67tZbz7UyNO.a3fo." });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8662), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8684), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8687), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8687) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8689), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8691), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9345), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9349), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9351), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9352) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9354), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9356), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9358), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9359) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9361), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9361) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9363), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9365), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9365) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9367), new DateTime(2025, 5, 19, 21, 2, 10, 245, DateTimeKind.Utc).AddTicks(9368) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4559), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4566), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4568), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4325), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4366), new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4374), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4376), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4377), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4378), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4380), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4381), new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 18, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4382), new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4384), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4386), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4387), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4388), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4390), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4391), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4392), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4394), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4395), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4396), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4398), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4399), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4400), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4402), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4403), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4404), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4205), new DateTime(2025, 4, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4223), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4225), new DateTime(2025, 4, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4226), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4228), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4229), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4230), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4231), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4233), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4234), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4235), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4237), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4239), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4241), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4249), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4250), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4251), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4253), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4254), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4255), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4257), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4258), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4259), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4260), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4262), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4646), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4651), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4654), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4657), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4659), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4662), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4664), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2337), "$2a$12$o1vFTTTf7bZPlIkaUL8DpeEOGZFQWt1l5nF1PeoXwxk1dOQs.QwKm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 47, 727, DateTimeKind.Utc).AddTicks(1077), "$2a$12$tWtB0nBntY29WnWNzCK.GOwK22lcZbwkhUg3JWzxVKQG4/goNmf5a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 47, 965, DateTimeKind.Utc).AddTicks(1677), "$2a$12$tUHI7qOGhi9LbKATAsC1s.z4cgxm39LqV.LMYK9Mh3ZyLyJ0a64Uu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 202, DateTimeKind.Utc).AddTicks(9850), "$2a$12$qfXdfyUyOZ3REfAJCrhSeus0ZFGuJQb3bLKc8cVrjjn4OulBsuY72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 437, DateTimeKind.Utc).AddTicks(9708), "$2a$12$mjhTpsGeia7qKMvP6uRZ3.8f6EUDNJvy5xlChlwISw3RBMGeYoRBu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 669, DateTimeKind.Utc).AddTicks(3021), "$2a$12$X3KH7DIsXBQtXK3zBh.owufmKxnGkibv9LxHCcYBYlM.PyBp9hld2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 900, DateTimeKind.Utc).AddTicks(485), "$2a$12$irEV1fMe74ixXqd8wj/b0.VG5bXAvQqJwz2FgRT51.KpQRNiF6lAG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 70, DateTimeKind.Utc).AddTicks(193), "$2a$12$OCOzquFakXWaALCS7FGCEe90iqPkYld.PTiwTApCJ2WGqBwids8Fe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 301, DateTimeKind.Utc).AddTicks(1939), "$2a$12$sxSikHu2iSKi.iMPa4Ayk.Yd2l.tBGLOMf/5wn9B53tsgCiQsABwy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 533, DateTimeKind.Utc).AddTicks(4279), "$2a$12$hcouVy/uf61glGWS7kRkSeJaJkCLyKBagFrgCfPyq4MWOuUUTeeRS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 131, DateTimeKind.Utc).AddTicks(1552), "$2a$12$6Evsy6kQBtiDUvG6NU.GQ.wKquItlF1Oh1T9QoZYG5e3PKDecfcoC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 365, DateTimeKind.Utc).AddTicks(1731), "$2a$12$/lAgNtvrmwuHrbkt0ifgAuJzCa9hebPiBg1EOTGtsq0rjOWb.DNc6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 598, DateTimeKind.Utc).AddTicks(3253), "$2a$12$27MXt2PzlzK1j/YBWXAKf.9JJoi7YAeSjTYdNs.3SK./QlrD0gQ7K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 835, DateTimeKind.Utc).AddTicks(4165), "$2a$12$cNzTOdDep6KzFBBNi3CCUuE2Z9e0EdTfmrHHh0y.DYhJp2DxtlR/W" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3826), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3833), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3835), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3836) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3839), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4756), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4760), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4762), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4764), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4765) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4767), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4769), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4771), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4773), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4775), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4777), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4778) });
        }
    }
}
