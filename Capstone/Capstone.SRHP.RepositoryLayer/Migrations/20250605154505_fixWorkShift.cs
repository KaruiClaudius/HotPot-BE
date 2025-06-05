using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixWorkShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserManagerWorkShifts",
                keyColumns: new[] { "ManagersUserId", "MangerWorkShiftsWorkShiftId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserManagerWorkShifts",
                keyColumns: new[] { "ManagersUserId", "MangerWorkShiftsWorkShiftId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8649), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8657), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8659), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 19, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8529), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 26, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8532), new DateTime(2025, 6, 4, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 19, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8539), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 15, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8541), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 12, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8542), new DateTime(2025, 6, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 7, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8548), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 12, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8549), new DateTime(2025, 6, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 10, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8551), new DateTime(2025, 6, 4, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 9, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8553), new DateTime(2025, 6, 4, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 12, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8554), new DateTime(2025, 6, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 8, 4, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8556), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 9, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8557), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 8, 4, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8559), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 12, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8560), new DateTime(2025, 6, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 19, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8562), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 15, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8563), new DateTime(2025, 6, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 6, 12, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8565), new DateTime(2025, 6, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 7, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8566), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 7, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8568), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 7, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8569), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 7, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8571), new DateTime(2025, 5, 31, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 9, 3, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8573), new DateTime(2025, 5, 26, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 12, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8574), new DateTime(2025, 5, 26, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 12, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8576), new DateTime(2025, 5, 26, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605224504", new DateTime(2025, 12, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8577), new DateTime(2025, 5, 26, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8266), new DateTime(2025, 5, 6, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8277), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8279), new DateTime(2025, 5, 6, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8280), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8282), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8282) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8283), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8284), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8286), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8287), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8289), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8289) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8290), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8292), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8293), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8295), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8296), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8302) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8303), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8304), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8305), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8307), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8308), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8310), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8310) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8311), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8313), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8315) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8315), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8317), new DateTime(2025, 6, 2, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 0, 995, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 0, 995, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 0, 995, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 0, 995, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8747), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8778), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8781), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8784), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8786), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8789), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8792), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 0, 996, DateTimeKind.Utc).AddTicks(12), "$2a$12$l8m6xSGiu9QZ2oKlAqf5LO8Fbd.awGgxYFa0h5i8jqMp.YdykWXcm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 1, 235, DateTimeKind.Utc).AddTicks(6850), "$2a$12$F0NAd/y8CaOymdHWMMwtYe0GK5KHw0lHyXHjoh6i5lItiaJQVkhwe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 1, 476, DateTimeKind.Utc).AddTicks(4601), "$2a$12$QDjdPs5VoALTLxwwSUteruuClO5QMKuKRyT9cBdkygCrswHa0rA8O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 1, 715, DateTimeKind.Utc).AddTicks(3709), "$2a$12$An610YweyEo/E3OlomgtbuJ2AEYOVYUiIUaiOhS9OlTlC5p3lY5LG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 1, 954, DateTimeKind.Utc).AddTicks(329), "$2a$12$EbKblwPcup30YQ3E4MinC.UTo4yVNjz/aJJtq5VtQk7uh7E1g7ase" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 2, 193, DateTimeKind.Utc).AddTicks(3403), "$2a$12$VZasd5Mo.Hmp3r1yqyzoqObH4KM/3e4QHknptEmjDhw8eWrj6ZmlS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 2, 432, DateTimeKind.Utc).AddTicks(4993), "$2a$12$d3G5jGHTUZ40RNz5E6QRQe9SIJyKFhjSW.jj0jVTp6efWsiECNvte" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 3, 626, DateTimeKind.Utc).AddTicks(7628), "$2a$12$6iGRE6.c7Dm317wX6Yci8.D5CtEiyNbfMcJfS4D.Oip0RpKuzD0Hy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 3, 870, DateTimeKind.Utc).AddTicks(7986), "$2a$12$CXXsz1sQhKvDqLa.sxEqZehp6zwpL68GjygaRgq81vf95Ohq9.H2e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 113, DateTimeKind.Utc).AddTicks(8344), "$2a$12$hpKle2CcloD4ia.4CGTJt.3ef1yTAgSTFLR3DTZ.WLr8qEKv7XOt2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 2, 671, DateTimeKind.Utc).AddTicks(506), "$2a$12$R95vXymBEpsE8A1xrQ/R5.kNDgZQZrVGUROVmT.tXMBiJgTchANF2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 2, 912, DateTimeKind.Utc).AddTicks(2766), "$2a$12$wYF06cyHR/XY5aGb6oLQ9edy6fWXO55G.tKFJs6.mJZbffnetczRG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 3, 151, DateTimeKind.Utc).AddTicks(2794), "$2a$12$EamMvUHNX7S2x9Hzclofxu8s.0LAYb5Ve4nqfXW4ZFq5QVrEYnaF2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 3, 386, DateTimeKind.Utc).AddTicks(7043), "$2a$12$iorPWxw0K2TpM3sqwsEl/./4QhusdVdJ61L8NkScmBPHbmAAIO08u" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7978), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7979) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7983), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7984) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7986), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7986) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7988), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7990), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(7991) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8915), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8919), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8921), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8922) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8924), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8926), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8928), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8931), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8933), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8935), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8937), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8940), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8940) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8942), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8944), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8946), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8949), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8951), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8957), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8959), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8961), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8964), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8966), new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Utc).AddTicks(8966) });

            migrationBuilder.UpdateData(
                table: "WorkShifts",
                keyColumn: "WorkShiftId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "WorkShifts",
                keyColumn: "WorkShiftId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ShiftStartTime" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 45, 4, 353, DateTimeKind.Local).AddTicks(5092), new TimeSpan(0, 13, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5784), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5789), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5791), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 19, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5609), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 26, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5612), new DateTime(2025, 6, 4, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 19, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5620), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 15, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5622), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 12, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5623), new DateTime(2025, 6, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 7, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5625), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 12, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5626), new DateTime(2025, 6, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 10, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5628), new DateTime(2025, 6, 4, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 9, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5629), new DateTime(2025, 6, 4, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 12, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5631), new DateTime(2025, 6, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 8, 4, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5632), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 9, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5634), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 8, 4, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5635), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 12, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5637), new DateTime(2025, 6, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 19, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5638), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 15, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5640), new DateTime(2025, 6, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 6, 12, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5641), new DateTime(2025, 6, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 7, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5643), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 7, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5644), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 7, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5646), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 7, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5647), new DateTime(2025, 5, 31, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 9, 3, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5648), new DateTime(2025, 5, 26, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 12, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5650), new DateTime(2025, 5, 26, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 12, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5652), new DateTime(2025, 5, 26, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605223620", new DateTime(2025, 12, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5653), new DateTime(2025, 5, 26, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5335), new DateTime(2025, 5, 6, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5350), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5351) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5352), new DateTime(2025, 5, 6, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5353), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5355), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5355) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5356), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5357) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5358), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5358) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5359), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5360) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5360), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5361) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5362), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5362) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5363), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5364) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5365), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5366), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5366) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5367), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5368) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5369), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5374) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5375), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5376) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5376), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5377) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5378), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5378) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5379), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5381), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5381) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5382), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5383) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5383), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5384) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5385), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5386) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5386), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5387) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5388), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5389), new DateTime(2025, 6, 2, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 17, 388, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 17, 388, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 17, 388, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 17, 388, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5881), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5882) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5885), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5888), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5891), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5894), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5896), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.InsertData(
                table: "UserManagerWorkShifts",
                columns: new[] { "ManagersUserId", "MangerWorkShiftsWorkShiftId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 17, 388, DateTimeKind.Utc).AddTicks(8303), "$2a$12$u8MYie7K0L3s3eh6qNT6AuP.luNii1ZCbmykMiQG6/ADTfrgQolTK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 17, 627, DateTimeKind.Utc).AddTicks(491), "$2a$12$pInpp6nME/0lLlpqL33zAOttscOv6E/1y3qeeIcz0hanU9W353mM6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 17, 866, DateTimeKind.Utc).AddTicks(4654), "$2a$12$gFqSk11HS0QdqxaYS1L2K.DK.TbR73Y6ckkiV6zgeVTpSp4Eqtsxi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 18, 105, DateTimeKind.Utc).AddTicks(3786), "$2a$12$6DJkjyiCCAUlqkpWuLtb.eXnFblKqFxUtxxAthqs3qY4WlSrfTGDa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 18, 346, DateTimeKind.Utc).AddTicks(8144), "$2a$12$coozH60rVbTvvlZJubxgauWXrOnM81IOYFBNPR3N.8gZ.K6HjP0Ze" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 18, 586, DateTimeKind.Utc).AddTicks(4202), "$2a$12$7UlY9PBsdwRIekvWRtttvuvBOyEJg.2EJNynF55Ile7xlViWjURii" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 18, 826, DateTimeKind.Utc).AddTicks(3053), "$2a$12$9Y3jFJ9Ag5bFFzmviuFSJOiDMRgbQ7JJb46I0GB8ChZK5Vr.duLpa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 16, DateTimeKind.Utc).AddTicks(600), "$2a$12$PY6ikApshqHUp/ihgtBPau/JDzbd2AuumAzVGjBTxNkw1rD1Dd38e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 258, DateTimeKind.Utc).AddTicks(2284), "$2a$12$9Z1oiznpyaBn47Qoy2oHrOBTY6m5rRey.2cU49Mvj9UmPOpUNVLHS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 506, DateTimeKind.Utc).AddTicks(6453), "$2a$12$EhTyIhI6Ysx5BPmwZ7Kvoey8xYbXxE/7Vl.TJaqjijg11XE1.oWUy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 19, 64, DateTimeKind.Utc).AddTicks(9667), "$2a$12$nbQcrieniYiEIeAmwfAJuu.as4YvErCUhAb7GL19m81JeUnwget5i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 19, 302, DateTimeKind.Utc).AddTicks(6751), "$2a$12$RCg6VSX8WrggNp7w7RFqNel92Nfhob0XQSQGqfmOE2XVfagQBCDia" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 19, 539, DateTimeKind.Utc).AddTicks(9134), "$2a$12$Az6LSzCcgJehjDaFEhxVzOBwqsKAGAjp9SgdA6pD2yF9281F0uqfS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 19, 776, DateTimeKind.Utc).AddTicks(6882), "$2a$12$B4TDVHrWCY3RfdjuVAq8a./Q5JUpKOxPsyb7uloAWK0GeJ9GswOZq" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5068), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5069) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5075), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5077), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5079), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5082), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6028), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6031), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6034), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6036), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6036) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6038), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6040), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6043), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6043) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6045), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6045) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6047), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6049), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6052), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6054), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6054) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6056), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6058), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6061), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6063), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6073), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6075), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6076) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6077), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6080), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6082), new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "WorkShifts",
                keyColumn: "WorkShiftId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "WorkShifts",
                keyColumn: "WorkShiftId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ShiftStartTime" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 36, 20, 753, DateTimeKind.Local).AddTicks(1391), new TimeSpan(0, 12, 0, 0, 0) });
        }
    }
}
