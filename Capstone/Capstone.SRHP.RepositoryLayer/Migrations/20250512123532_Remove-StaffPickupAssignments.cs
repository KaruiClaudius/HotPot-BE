using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStaffPickupAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffPickupAssignments");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7963), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7967) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7968), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7969) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7776), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7779), new DateTime(2025, 5, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7786), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7788), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7789), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7791), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7792), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 17, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7794), new DateTime(2025, 5, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 16, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7795), new DateTime(2025, 5, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7796), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7798), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7799), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7801), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7802), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7804), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7805), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7837), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7839), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7840), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7842), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7843), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7844), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7846), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7847), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7849), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7679), new DateTime(2025, 4, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7688), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7690), new DateTime(2025, 4, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7692), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7692) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7693), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7695), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7696), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7698), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7698) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7699), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7700), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7702), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7702) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7703), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7705), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7705) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7706), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7708), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7712) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7713), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7714) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7715), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7716), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7718), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7719), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7721), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7721) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7722), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7723) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7723), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7725), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7726), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7728), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7728) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7598));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8029), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8034), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8037), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8040), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8042), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8045), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8047), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8048) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9819), "$2a$12$rzsMsSnPdcCBHR1oey7PM.2SgC0lHeNhiG8DfY1e/GaH1sI94rfgy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 28, 538, DateTimeKind.Utc).AddTicks(2749), "$2a$12$Tkf.twe2M.wPh6EMRhHqSuNbOiUH.987tANio7YsCPBX1hBcy0Z1i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 28, 777, DateTimeKind.Utc).AddTicks(159), "$2a$12$ainBNk.WmmoFsXvZov/LCOsyKExeRsJWhalswcZJkjxeKv2AN3tt6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 13, DateTimeKind.Utc).AddTicks(8510), "$2a$12$NnahWZPaaz/lMoip78eVL.RkAe8wmHbIEqrMuDO2Wl3H9PAunE5/i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 250, DateTimeKind.Utc).AddTicks(7412), "$2a$12$AFqx9qhcJU9L.JghK/DmTuqzSBwziJxjvqYbVtz.3V6dzi7EKRi4S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 485, DateTimeKind.Utc).AddTicks(9749), "$2a$12$6vZE/QBR49Fk.0Na5.8kYeScT1YGol/fbjor7QUH.G8V7YwQOrGxK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 720, DateTimeKind.Utc).AddTicks(7354), "$2a$12$D/xJlrdIaAFRAC2fPqTMdejolw.TN/lBNEnCtqamdGM8ieIa7QNFq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 895, DateTimeKind.Utc).AddTicks(6094), "$2a$12$7NEWxoBmQ6ivkg1V5ivNUudlWCGAHdTd4dDN4TFEAI43t3lskJOyy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 134, DateTimeKind.Utc).AddTicks(881), "$2a$12$gWgP0SENFqaK3QaqGOpI/u28YcG3xI5/w1UdXAXXf81EHgorcL5t6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 373, DateTimeKind.Utc).AddTicks(6715), "$2a$12$GR9A7kCGztPd.6awzBGwJeaG1y81xRZX5093.4XhWzvxHclKT.65." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 956, DateTimeKind.Utc).AddTicks(2608), "$2a$12$gIOwoBMCXEich9SPwLnSxOv5JrLWgKGXSEVZxHYcRyyAgETzurlXa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 191, DateTimeKind.Utc).AddTicks(9205), "$2a$12$2SKIG.3Vf5KKaeu3XEamhOMgLwge8AbqhUSHH1jk4XjiWuEGm16Ya" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 426, DateTimeKind.Utc).AddTicks(794), "$2a$12$GbYP4f.gJmsRLFg7ra4OP.RtvAxuKVtvZSQgprw.HTJs7P5stJw3." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 660, DateTimeKind.Utc).AddTicks(7087), "$2a$12$odU0424ywM7k45zMk5FzgOoHi2cODIP.8rXfwS8RTwc2RvIFcbFTm" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7403), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7403) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7408), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7411), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7415), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8112), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8115), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8116) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8118), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8118) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8120), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8122), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8125), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8125) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8127), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8127) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8129), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8131), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8132) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8134), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8134) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffPickupAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPickupAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_StaffPickupAssignments_RentOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "RentOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffPickupAssignments_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffPickupAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5392), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5398), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5399), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5227), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5230), new DateTime(2025, 5, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5242), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5244), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5245), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5247), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5248), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 17, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5249), new DateTime(2025, 5, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 16, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5251), new DateTime(2025, 5, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5253), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5254), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5255), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5257), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5259), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5260), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5261), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5263), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5264), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5266), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5267), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5269), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5270), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5272), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5273), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5275), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5066), new DateTime(2025, 4, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5082), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5085), new DateTime(2025, 4, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5088), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5090), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5092), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5093) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5094), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5095), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5102) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5103), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5104) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5105), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5106), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5108), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5109), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5110), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5112), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5119), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5156), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5158), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5160), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5161), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5163), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5163) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5164), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5165) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5166), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5167), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5169), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5170), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5480), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5489), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5492), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5493) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5495), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5498), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5501), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5503), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6636), "$2a$12$Av9EK9cSPixbrOky6onSe.HdFuFK1MRaXfpyHKbdchkHE20cjtwGC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 402, DateTimeKind.Utc).AddTicks(3617), "$2a$12$AINQpfxpCnDFqGWTuMdW.eElrEHBY7XOlwxTSJmSc09nD6OitF/am" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 663, DateTimeKind.Utc).AddTicks(5306), "$2a$12$oWlZvhfQMQIHHzzsIs.NquY57lyc/dcvu1IkJ9D641tSTlE0vfaZK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 932, DateTimeKind.Utc).AddTicks(1133), "$2a$12$TmJ4RyTzDHeU.4lvj.JElu5ySjaAVlXWgbvlvMpUEE98ssKVps4fK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 191, DateTimeKind.Utc).AddTicks(2987), "$2a$12$/1rQYmXT5vc1o/L1gRtpHe00IZCj41zbBJU/3kMdFi5e.7rPhOc/u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 446, DateTimeKind.Utc).AddTicks(8664), "$2a$12$SPVh5362DwW1Ou1cNGw8A.noAVHTT/S1InbJAqCJyjoFU.ooako2a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 709, DateTimeKind.Utc).AddTicks(6886), "$2a$12$JhGr01udP4PtUZtEhxO2P.crXvQtBAkmmDcqMwtkp5V3yGDOBynhS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 149, DateTimeKind.Utc).AddTicks(4361), "$2a$12$uqqn4S92rW2gfMTyla4AiupnrXfTYQ7roLC9.YyJyEyve65z75O4G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 427, DateTimeKind.Utc).AddTicks(1484), "$2a$12$LLSnt81MaF./YuFAQBLwiezRg12MrpoYGLJXpQJZNvgiVxsxxZL0i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 690, DateTimeKind.Utc).AddTicks(6447), "$2a$12$l/N6oVocJL6pv.vb6e5CJeidsCJVjVCOJW7.sTma7fZ7vb4dDCRCu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 971, DateTimeKind.Utc).AddTicks(7149), "$2a$12$KkKP8DXg9aM8gCjuFLrmQeQ84H7s.h/VYyK1zXtCy4lJLvz6QrsfC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 37, 238, DateTimeKind.Utc).AddTicks(4883), "$2a$12$f3OBrcEsDC6jRxYMG2pTUOK3aS9ITHB7apDUNwxxbPYppOfnXZkzS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 37, 548, DateTimeKind.Utc).AddTicks(6966), "$2a$12$eupqe43WzI9ueKDJemAPqud8OyDIvL045F/ALrnIT01MWUgLQFthm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 37, 858, DateTimeKind.Utc).AddTicks(5885), "$2a$12$S2iuPS/jXgSYOxYSmwDpd.IpwSMWLyoZsGAzDdW8wQN2NnClehVm." });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4641), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4642) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4651), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4743), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4744) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4747), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4750), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5575), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5578), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5578) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5667), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5670), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5672), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5672) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5674), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5675) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5677), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5679), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5681), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5684), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_OrderId",
                table: "StaffPickupAssignments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_StaffId",
                table: "StaffPickupAssignments",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_UserId",
                table: "StaffPickupAssignments",
                column: "UserId");
        }
    }
}
