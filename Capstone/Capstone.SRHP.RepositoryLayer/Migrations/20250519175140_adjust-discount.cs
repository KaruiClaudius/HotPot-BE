using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class adjustdiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PointCost",
                table: "Discounts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7388), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7392), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7394), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7395) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7209), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 10, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7213), new DateTime(2025, 5, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7228), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7229), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7232), new DateTime(2025, 5, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7233), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7235), new DateTime(2025, 5, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 25, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7236), new DateTime(2025, 5, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7239), new DateTime(2025, 5, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7241), new DateTime(2025, 5, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7243), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7244), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7246), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7247), new DateTime(2025, 5, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7249), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7251), new DateTime(2025, 5, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7252), new DateTime(2025, 5, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7254), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7255), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7257), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7258), new DateTime(2025, 5, 15, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7260), new DateTime(2025, 5, 10, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7261), new DateTime(2025, 5, 10, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7263), new DateTime(2025, 5, 10, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7265), new DateTime(2025, 5, 10, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7059), new DateTime(2025, 4, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7061) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7074), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7076), new DateTime(2025, 4, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7077), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7079), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7081), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7081) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7082), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7083) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7084), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7087), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7088), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7089) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7090), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7092), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7094), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7094) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7095), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7096) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7125), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7133), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7135), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7137), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7137) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7138), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7140), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7142), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7144), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7145), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7147), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7149), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7149) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7150), new DateTime(2025, 5, 17, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6945));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 36, 341, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 36, 341, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 36, 341, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 36, 341, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7460), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7466), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7467) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7471), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7471) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7474), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7477), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7480), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7482), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 36, 341, DateTimeKind.Utc).AddTicks(3948), "$2a$12$T5RHpYYO3S/1s3X3/T8XZuzL5JkIb/htZ6.L.yPOeXg7xBHTs/Jva" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 36, 571, DateTimeKind.Utc).AddTicks(5431), "$2a$12$iUQWxYxq/m8tjTArtjuOsufxbFbysEPt5SyYXbIENFaUgZaGWIs9y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 36, 806, DateTimeKind.Utc).AddTicks(1340), "$2a$12$yOv2y53hPqNsar.kTj345uNU.ZxTz9Ov6PQ.98LOKB4zjXTZVJ13C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 37, 36, DateTimeKind.Utc).AddTicks(1709), "$2a$12$L6s6fu3Q5HXvHElX1XD2yeWqhcVT.KX8K/g5R/f9bd7JLG1dLzQSu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 37, 276, DateTimeKind.Utc).AddTicks(6082), "$2a$12$5rpNeOpXZr4MK6nU5soEGulrM7W4am4cfpZaN9OF14Nd63Feo.EXe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 37, 510, DateTimeKind.Utc).AddTicks(7984), "$2a$12$LNZWTdaHCo./Mp828QCA6Ov5sZEMdmKlveHVI4lTJpURT/oUkBpEu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 37, 742, DateTimeKind.Utc).AddTicks(9895), "$2a$12$dNgdpY1GexFhcYeTBoIdxeRvumG6Os9IzQyMOrWcpeWgnCKK/RS2O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 38, 895, DateTimeKind.Utc).AddTicks(3247), "$2a$12$VPap4JQPoG.C4OySwH7z5uUbII5AH1PpVsrPkVjV7.dIXRXjfmOCC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 125, DateTimeKind.Utc).AddTicks(7786), "$2a$12$BZZ4E7kai4kbyHxHHTSzYeZLu4Ij/a/hDBu2L94zK7P9tOKU3c59i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 361, DateTimeKind.Utc).AddTicks(3894), "$2a$12$yUlXzDVbUxFBPDef7MGjh.eNy1Q6tnSsfXcobSkUHO6xLvy9OPmIu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 37, 978, DateTimeKind.Utc).AddTicks(9059), "$2a$12$807VeCuzknTMB0RKferJyOi/fXsU8Jt2p3XnalNtyDuiu3VhhxLDe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 38, 209, DateTimeKind.Utc).AddTicks(6111), "$2a$12$cTvsNI5VJw5BqwJ9Ptqw5eyJrdfQD3Zw8LlJTA1ERcME6YtMBJokK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 38, 438, DateTimeKind.Utc).AddTicks(4814), "$2a$12$SolMzo8sU8NMupuzAr6eZeNC90Pi0XzDoCDHlYqbvdE.g.Mg9lkLm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 38, 666, DateTimeKind.Utc).AddTicks(7255), "$2a$12$j9OF1X8mTGfph8XEx.qqaewa3iXfIqhw8rMuO80wMphw6O.DG1ure" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6749), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6805), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6806) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6809), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6811), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6813), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7554), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7555) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7558), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7558) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7560), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7590), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7591) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7593), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7596), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7596) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7598), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7599) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7601), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7603), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7604) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7606), new DateTime(2025, 5, 20, 0, 51, 39, 609, DateTimeKind.Utc).AddTicks(7607) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PointCost",
                table: "Discounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7049), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7053), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7053) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7054), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6913), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6917), new DateTime(2025, 5, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6926), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6928), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6929), new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6931), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6932), new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6934), new DateTime(2025, 5, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6935), new DateTime(2025, 5, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6937), new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6938), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6940), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6941), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6943), new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6944), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6945), new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6947), new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6948), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6950), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6951), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6952), new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6954), new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 15, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6955), new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 15, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6957), new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 15, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6958), new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6817), new DateTime(2025, 4, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6827), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6831), new DateTime(2025, 4, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6833), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6834), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6836), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6837), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6839), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6840), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6841) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6842), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6843), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6844) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6845), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6846), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6848), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6849), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6856), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6859), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6862), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6865), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6866), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6868), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6869), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6871), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6871) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7113), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7117), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7120), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7121) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7150), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7153), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7156), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7156) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7158), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4770), "$2a$12$ULKCz/gUooEZOZgHMgN8z.omhaLJbN7/hSx2zOmYosEyepCADwiCG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 33, 185, DateTimeKind.Utc).AddTicks(2193), "$2a$12$h0Gt/rkXvb9d9VEKkBSwBe5fFEd4e0TQxaePLFOinNirF7Uy0ZJ9." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 33, 442, DateTimeKind.Utc).AddTicks(9121), "$2a$12$wNenfg.Oy3aJHsLxU1sraO4Zy0eAjq42wDVZckZWLECLW8hlbEb7u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 33, 691, DateTimeKind.Utc).AddTicks(2197), "$2a$12$.xlblFxGOvZvi/yt/HsRuuSY.s2aAITK0TPKueaVXlCoi6ZPCwp.W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 33, 937, DateTimeKind.Utc).AddTicks(2858), "$2a$12$ha5WFYAahaMSnF1nXrdlsuGv3zxsxusD5KqVBWleTrhpd3rcI0qUe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 34, 180, DateTimeKind.Utc).AddTicks(2641), "$2a$12$xLr3XOgexepVJSiONAUZmumd9VaSZkHQ06IxzH9/bC0Qd6AESDjLS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 34, 427, DateTimeKind.Utc).AddTicks(3098), "$2a$12$YazWmc8/cBia4X0ewL805eg9DfEVzJmz2Y0EK5JWMS0WQ4Kvg6Msi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 35, 776, DateTimeKind.Utc).AddTicks(8407), "$2a$12$bG9rWIU/u.PrCKmcPOOjau0otpIXuvnkUQYuqCkwBgojwzb2OLkba" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 73, DateTimeKind.Utc).AddTicks(8990), "$2a$12$dEpY8sP.l8DiU2dEg3IKAOcK6yydFxYrDoClLjqAirrWf9K4yrh1m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 345, DateTimeKind.Utc).AddTicks(2939), "$2a$12$M4iAAOT3o0PwHrOgeUmHjOUUo6AY1v8w6.yfVlMBQkmKjTxrsoLTq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 34, 714, DateTimeKind.Utc).AddTicks(6233), "$2a$12$ZrQvU5h2yuqN.vrrUYM9pO/JW.ix2uRM6Cb1Gf.gVqKsWSqh9aPqy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 34, 971, DateTimeKind.Utc).AddTicks(1267), "$2a$12$X/jrL8k3Jg3dIlF1/WTuweIlKawz1Er.pjdpJQRBeY0zYkDZ4A45G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 35, 253, DateTimeKind.Utc).AddTicks(4474), "$2a$12$d7467t0P10skc/seoE1NfO81TIM05c.fZfHZdNHRzO9zteKxAWYH6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 35, 507, DateTimeKind.Utc).AddTicks(5122), "$2a$12$FaeBWItWSfDTwE0G/zpZ1.f7bOU0mAUF30/pTsqtgbZytZSwScaHy" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3361));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6528), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6529) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6539), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6539) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6541), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6541) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6543), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6543) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6545), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7214), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7215) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7217), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7218) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7220), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7222), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7225), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7227), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7229), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7231), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7234), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7234) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7236), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7236) });
        }
    }
}
