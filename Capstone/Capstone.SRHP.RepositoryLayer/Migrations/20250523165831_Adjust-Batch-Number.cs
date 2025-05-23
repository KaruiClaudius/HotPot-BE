using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class AdjustBatchNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 6, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7721), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7724), new DateTime(2025, 5, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 6, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9893), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 2, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9904), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9906), new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9908), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9912), new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 28, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9913), new DateTime(2025, 5, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 27, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9915), new DateTime(2025, 5, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9917), new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 7, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9919), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 8, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9921), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 7, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9923), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9924), new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 6, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9926), new DateTime(2025, 5, 20, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 2, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9928), new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 5, 30, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9930), new DateTime(2025, 5, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9932), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9933), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9935), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 6, 22, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9937), new DateTime(2025, 5, 18, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 8, 21, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9939), new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 11, 19, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9940), new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 11, 19, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9942), new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250523235829", new DateTime(2025, 11, 19, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 23, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(9944), new DateTime(2025, 5, 13, 23, 58, 29, 171, DateTimeKind.Utc).AddTicks(7413) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4413), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4419), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4420), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4421) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BEEF-2025-04-01", new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4226), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BEEF-2025-04-15", new DateTime(2025, 6, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4228), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "LAMB-2025-04-01", new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4235), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "PORK-2025-04-01", new DateTime(2025, 6, 2, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4236), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SHRIMP-2025-04-01", new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "FISHBALL-2025-04-01", new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4239), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SQUID-2025-04-01", new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4240), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "CABBAGE-2025-04-01", new DateTime(2025, 5, 28, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4242), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SPINACH-2025-04-01", new DateTime(2025, 5, 27, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4243), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "CORN-2025-04-01", new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4244), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "UDON-2025-04-01", new DateTime(2025, 7, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4246), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "GLASS-2025-04-01", new DateTime(2025, 8, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4247), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "RAMEN-2025-04-01", new DateTime(2025, 7, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4248), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "TOFU-2025-04-01", new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4282), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "FRIEDTOFU-2025-04-01", new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4284), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SHIITAKE-2025-04-01", new DateTime(2025, 6, 2, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4285), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "ENOKI-2025-04-01", new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4286), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SICHUAN-2025-04-01", new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4288), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "TOMATO-2025-04-01", new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4289), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "MUSHBROTH-2025-04-01", new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4290), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BONE-2025-04-01", new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SESAME-2025-04-01", new DateTime(2025, 8, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4293), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "GARLICSOY-2025-04-01", new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4294), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "CHILI-2025-04-01", new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4295), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "SHACHA-2025-04-01", new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4297), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4129), new DateTime(2025, 4, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4137), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4138), new DateTime(2025, 4, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4140), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4141), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4142), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4144), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4145), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4146), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4147), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4149), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4150), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4151), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4153), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4154), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4159), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4160), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4161), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4162), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4164), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4165), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4166), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4167) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4168), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4169), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4170), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4171), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4172) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3993));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4477), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4481), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4484), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4484) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4486), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4489), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4491), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4492) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4494), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4494) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3682), "$2a$12$XHluTNYatBuVc7g8dyEq7O7KCPknOm3LChQHK887m2yhveUO536g." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 274, DateTimeKind.Utc).AddTicks(2095), "$2a$12$2/pxmCKL8hWyBDj2jDx9auCD/PVRZjQV2MgVmYoh6y4GxYaA1c8AO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 504, DateTimeKind.Utc).AddTicks(985), "$2a$12$59fPysGPv7f6RpCwPUde9OaHVqUxiucKPYNIWGSph4ENTzEcxPQjK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 734, DateTimeKind.Utc).AddTicks(75), "$2a$12$.wL5px9IYgxeg.qw7yyR..31zZyB3IeP3w8HN0P96y2KNbStzN2R." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 957, DateTimeKind.Utc).AddTicks(1163), "$2a$12$hox.Vctbkuro/fmu1v8pT.PHeCvz5ysSq4JEd.iJd1N29lfI.vO7e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 180, DateTimeKind.Utc).AddTicks(7453), "$2a$12$xEa2wBSLYKiMOb3u7/5mBuVRy9xZxA0kU449JCIWZS/wTvMxqcdDy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 404, DateTimeKind.Utc).AddTicks(3243), "$2a$12$of4ZRZ./zCmIlY9AAq.tBeSjJbNZWfcV8RZbQhNUcQUqzQk72i1uq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 515, DateTimeKind.Utc).AddTicks(1303), "$2a$12$8.LtYaY8jb2vgtI6yE3A.Ogj7eU/nqaVEcgZRxJJSn679ny4L/bRG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 736, DateTimeKind.Utc).AddTicks(6097), "$2a$12$27l2rfAb3nklxq1MAwseju7AlARBArYocANGjkqE9Oxt0fnUY5ZSm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 956, DateTimeKind.Utc).AddTicks(9213), "$2a$12$qMsnfZ/qPHPFLgnCq.lHP.zplwrEahaJnIjztCqSs9.rovZd7KWYe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 626, DateTimeKind.Utc).AddTicks(8354), "$2a$12$jyjf.4E63jKtthjwxb0z4ek1kYQN5Z9e3Advn3AiQexDqMT5xAjmu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 846, DateTimeKind.Utc).AddTicks(4873), "$2a$12$xJqiaQckIVHDw6VkbyYcIOh0pu7Ul1JQpXaazP1v/J5X80Nq9cR/q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 68, DateTimeKind.Utc).AddTicks(3606), "$2a$12$NgK/o0SnPp8So5csTuqAR.gGxeb13AajoXzdxhCrzewIhtjM5d282" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 292, DateTimeKind.Utc).AddTicks(9405), "$2a$12$/cGG4dpPR1IXA2Fsl8nsROdIHGpxM4KGFhWKz8iEcRfsb74s21tPK" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3857), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3862), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3864), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3865) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3866), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3868), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3869) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4558), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4561), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4563), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4566), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4566) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4567), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4570), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4572), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4574), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4576), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4578), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4580), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4582), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4584), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4586), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4588), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4591), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4601), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4603), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4605), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4607), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4609), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4610) });
        }
    }
}
