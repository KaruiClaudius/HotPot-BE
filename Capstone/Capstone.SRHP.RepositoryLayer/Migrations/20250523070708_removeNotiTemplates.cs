using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class removeNotiTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationTemplates");

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
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4226), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4228), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4235), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4236), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4239), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4240), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4242), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4243), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4244), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4246), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4247), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4248), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4282), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4284), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4285), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4286), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4288), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4289), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4290), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4293), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4294), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4295), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4297), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultTargetType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MessageTemplate = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.TemplateId);
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4838), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4843), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4845), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4846) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3337));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4642), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 12, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4646), new DateTime(2025, 5, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4652), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4684), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4685), new DateTime(2025, 5, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4687), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4688), new DateTime(2025, 5, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4690), new DateTime(2025, 5, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4691), new DateTime(2025, 5, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4693), new DateTime(2025, 5, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4694), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4696), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4697), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4699), new DateTime(2025, 5, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4700), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4701), new DateTime(2025, 5, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4703), new DateTime(2025, 5, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4704), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4706), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4707), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4708), new DateTime(2025, 5, 17, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4710), new DateTime(2025, 5, 12, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 18, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4711), new DateTime(2025, 5, 12, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 18, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4713), new DateTime(2025, 5, 12, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 18, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4714), new DateTime(2025, 5, 12, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4534), new DateTime(2025, 4, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4546), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4547) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4548), new DateTime(2025, 4, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4549) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4550), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4551), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4552) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4553), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4554), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4555), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4557), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4558), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4560), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4561), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4563), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4563) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4564), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4565) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4566), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4571), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4573), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4574), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4575), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4577), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4578) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4578), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4580), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4581), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4583), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4584), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4585), new DateTime(2025, 5, 19, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4586) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 39, 58, 233, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 39, 58, 233, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 39, 58, 233, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 39, 58, 233, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4911), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4916), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4916) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4919), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4919) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4922), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4922) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4924), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4925) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4927), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4930), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 58, 233, DateTimeKind.Utc).AddTicks(4659), "$2a$12$zNveVxqytpt16zgScIey2uniRDYHrOu.gkQflrRFFDEUj.Gb5eswq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 58, 469, DateTimeKind.Utc).AddTicks(9993), "$2a$12$58WAvoPsDPQu5JQOEj8z/.gEsQdrWmA2.LYa2UcTwJi8ImiH58.9W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 58, 709, DateTimeKind.Utc).AddTicks(20), "$2a$12$OD/iZgIof1YTm/gLVRVOreCPFhcuUaxD6pL/rqauIRKlBXnw02rq." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 58, 949, DateTimeKind.Utc).AddTicks(6208), "$2a$12$dT.lWjopABbEAL1ze1s.aeWosfJgq1wgNL1335QGE3abH6JgiwYqi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 59, 196, DateTimeKind.Utc).AddTicks(2647), "$2a$12$LqpMx5.wLCrZtMd.REXKfewLh2Ii7aG6S4BFqngDxSsqtcYiuBd0u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 59, 434, DateTimeKind.Utc).AddTicks(9619), "$2a$12$MI3IhJtSFZR1br1YPCbmsO8kL4Xg1wESwa8bjHyRpzT0XgR32loMe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 59, 669, DateTimeKind.Utc).AddTicks(5530), "$2a$12$J7/Ymq2EE1kFYXA/d2ZrK.8o97B0ugjQ00uPTM6g8ITW0XIQaS2t2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 0, 855, DateTimeKind.Utc).AddTicks(1113), "$2a$12$XjaCutymy9nUQHK0aJxdp.z/Ym0y4USmh0Dh1JLpuQ96BIfJWIYv6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 93, DateTimeKind.Utc).AddTicks(7029), "$2a$12$pmNAGseCb2RO9e27FoH9N.ldLq7ZAK4TRIeXK/z.VsgzsADwj/erO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 329, DateTimeKind.Utc).AddTicks(9514), "$2a$12$uY5i9GIHVZCgFFybXpanaO90Ez1Gybw9lSGQw0LiRy9p/QtrOTCXK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 39, 59, 907, DateTimeKind.Utc).AddTicks(7926), "$2a$12$I8ROjuDufdeRhkvOudvdZ.YnCzY5gaK6yEA.cujbZlzE1Zo3soKtq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 0, 145, DateTimeKind.Utc).AddTicks(140), "$2a$12$7dA3eFxyNDmZcv6RnaDYD.8Rgi8HvMWJGqwxwlg2KiKECwQUBqo8O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 0, 380, DateTimeKind.Utc).AddTicks(5871), "$2a$12$CWTtZhjFi3K21cx19c6Sq.ZBFLZWi3tZlGyxULIdfxzqez2GP5gLq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 0, 617, DateTimeKind.Utc).AddTicks(3779), "$2a$12$7/qrNg4WwK5BKtPFuQ.lv.G0RREUIFOaJJ7eJ2tFrr0oPBtKcqhby" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4247), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4252), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4254), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4257), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4259), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4996), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5001), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5001) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5003), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5005), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5008), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5008) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5010), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5012), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5014), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5017), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5017) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5019), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5019) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5021), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5023), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5026), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5026) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5028), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5028) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5030), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5031) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5032), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5033) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5044), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5044) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5046), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5048), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5078), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5081), new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5081) });
        }
    }
}
