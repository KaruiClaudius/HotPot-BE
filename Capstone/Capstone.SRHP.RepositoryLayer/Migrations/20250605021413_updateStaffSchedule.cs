using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateStaffSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5792), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5796) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5798), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5800), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 19, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5603), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 26, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5606), new DateTime(2025, 6, 4, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 19, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5614), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 15, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5616), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 12, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5618), new DateTime(2025, 6, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 7, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5620), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 12, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5621), new DateTime(2025, 6, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 10, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5623), new DateTime(2025, 6, 4, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 9, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5624), new DateTime(2025, 6, 4, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 12, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5626), new DateTime(2025, 6, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 8, 4, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5628), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 9, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5629), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 8, 4, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5631), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 12, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5632), new DateTime(2025, 6, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 19, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5634), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 15, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5635), new DateTime(2025, 6, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 6, 12, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5637), new DateTime(2025, 6, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 7, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5638), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 7, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5640), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 7, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5642), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 7, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5643), new DateTime(2025, 5, 31, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 9, 3, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5645), new DateTime(2025, 5, 26, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 12, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5646), new DateTime(2025, 5, 26, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 12, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5648), new DateTime(2025, 5, 26, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250605091412", new DateTime(2025, 12, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5649), new DateTime(2025, 5, 26, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5261), new DateTime(2025, 5, 6, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5264) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5271), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5272) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5273), new DateTime(2025, 5, 6, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5274) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5275), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5276), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5277) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5278), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5278) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5279), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5280), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5282), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5282) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5283), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5284) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5285), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5285) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5286), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5287), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5288) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5289), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5290), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5296), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5296) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5297), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5298) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5299), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5300), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5301) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5301), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5302) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5303), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5303) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5304), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5305) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5306), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5306) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5307), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5308) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5308), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5309) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5310), new DateTime(2025, 6, 2, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5311) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 9, 588, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 9, 588, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 9, 588, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 9, 588, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5863), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5865) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5868), 6.00m, new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5869) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5871), 8.00m, new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5874), 10.00m, new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5877), 12.00m, new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5877) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5879), 15.00m, new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5882), 20.00m, new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5882) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 9, 588, DateTimeKind.Utc).AddTicks(1936), "$2a$12$1SXiy9CSz7XSTbvDHbuX1.Yo7eyxOkdO7yFmI2KreD241nk/AI7cm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 9, 828, DateTimeKind.Utc).AddTicks(9838), "$2a$12$Uw8ZtAiixQooxaDaMpK7N.sW0ri5OfqENV/bUWBBtr09bIeI5a.OG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 10, 69, DateTimeKind.Utc).AddTicks(575), "$2a$12$l7bK4gpV6LW0RwR4tnTXl.3iRwaansBASYYed7/RyaC7zwOmC9Dx2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 10, 309, DateTimeKind.Utc).AddTicks(7350), "$2a$12$H7QuvuQQMLSHeY38WFzd0.gcThYa/OkHlXpuX0r2hbF/R2x.QwhLe", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 10, 547, DateTimeKind.Utc).AddTicks(6681), "$2a$12$mLyg1qul3OrruHfOlnabNuIeZcuhFYjfMUQr65xLmQCmhY46K9SMu", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 10, 785, DateTimeKind.Utc).AddTicks(9320), "$2a$12$q6iIe4rgASl7.rL//3oEAOL2MCiIDCVgDKo3f2bsc7ZZdZEJmTbEa", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 11, 23, DateTimeKind.Utc).AddTicks(5845), "$2a$12$dW4zy30hS9obRggeMfmh7ul8edAe8CaK68qbJyD3ey6FvmR2Bsv2K", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 222, DateTimeKind.Utc).AddTicks(2962), "$2a$12$zAoFXRe1LmQ1iSAgonGa7OflE7sni63B9XITVyVJIkJLIQP9UKZr6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 460, DateTimeKind.Utc).AddTicks(5483), "$2a$12$FiQfy6bvqg3tEq5qgg55BuMjs5VV9wf2mZal4W2jEH7/WILZPF7ki" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 702, DateTimeKind.Utc).AddTicks(4100), "$2a$12$qdQKyOJ9J5oDVP8Ysupmoutys7sk4ag3VIkWc.QA4LJw3/huJX4xi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 11, 263, DateTimeKind.Utc).AddTicks(5210), "$2a$12$LET25pV292qOUvEPKv3zRO1bUGsUUV31f3CvcdRKOqhov11iOpRyq", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 11, 506, DateTimeKind.Utc).AddTicks(1761), "$2a$12$w6OnWqv2O5N35R9GV6X0zuRlJMQJok6Ch2PIB9X6kpKkBxb5hCF5C", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 11, 746, DateTimeKind.Utc).AddTicks(2058), "$2a$12$O06ebGhSegA./ImsIcgWIuTi3w24OhGb7aHtzXgIWzC1OqDL3wW7C", 127 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 11, 984, DateTimeKind.Utc).AddTicks(4217), "$2a$12$j/bYwCpWAKtZzb1.xa4AQ.kCw9O40eULwY5OSRK4Me9BXt.bIL6S2", 127 });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5001), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5001) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5009), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5012), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5012) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5014), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5017), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5017) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5950), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5953), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5956), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5956) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5958), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5960), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5962), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5965), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5967), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5968) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5970), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5970) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5972), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5972) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5974), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5976), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5977) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5979), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5981), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5983), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5986), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5992), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6058), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6058) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6060), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6063), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6065), new DateTime(2025, 6, 5, 9, 14, 12, 945, DateTimeKind.Utc).AddTicks(6065) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1388), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1391), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1393), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 17, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1235), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 24, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1238), new DateTime(2025, 6, 2, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 17, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1245), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 13, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1247), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 10, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1249), new DateTime(2025, 6, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 7, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1250), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 10, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1252), new DateTime(2025, 6, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 8, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1253), new DateTime(2025, 6, 2, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 7, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1255), new DateTime(2025, 6, 2, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 10, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1257), new DateTime(2025, 6, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 8, 2, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1258), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 9, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1261), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 8, 2, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1262), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 10, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1264), new DateTime(2025, 6, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 17, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1265), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 13, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1267), new DateTime(2025, 6, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 6, 10, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1268), new DateTime(2025, 6, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 7, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1270), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 7, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1271), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 7, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1273), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 7, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1274), new DateTime(2025, 5, 29, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 9, 1, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1275), new DateTime(2025, 5, 24, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 11, 30, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1277), new DateTime(2025, 5, 24, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 11, 30, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1278), new DateTime(2025, 5, 24, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { "BATCH-20250603175320", new DateTime(2025, 11, 30, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1280), new DateTime(2025, 5, 24, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(916), new DateTime(2025, 5, 4, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(929), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(931), new DateTime(2025, 5, 4, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(932), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(934), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(935), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(937), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(938), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(940), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(941), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(942) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(943), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(944), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(947), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(949), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(950), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(957), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(958), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(960), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(961), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(962), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(964), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(965), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(966) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(966), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(968), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(969), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(970), new DateTime(2025, 5, 31, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(727));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(727));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 17, 75, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 17, 75, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 17, 75, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 17, 75, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1459), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1463), 8.00m, new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1464) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1466), 12.00m, new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1467) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1470), 16.00m, new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1472), 20.00m, new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1475), 24.00m, new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1475) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DiscountPercentage", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1477), 28.00m, new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 17, 75, DateTimeKind.Utc).AddTicks(4260), "$2a$12$XkaXmTslDGJK6NEB/pyMxuIySCmMh973PvwvVvbSFqdfEuV1Ypb4m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 17, 313, DateTimeKind.Utc).AddTicks(3003), "$2a$12$ZLvykhA/robnq4xzXro7F.Wj5nZVkK/UWgH.zn49P0KIUjzDYG1we" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 17, 548, DateTimeKind.Utc).AddTicks(7501), "$2a$12$XSPl8DAsCzro6icpymlIkOBYXrhTGgDYe.MZBNKRPNCSbPVL1.Due" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 17, 786, DateTimeKind.Utc).AddTicks(5761), "$2a$12$6SinHWf5c.btWBxybjcogOFbKcRaZbSdnIT.Fx6VvZbhN6jx8TQe.", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 18, 12, DateTimeKind.Utc).AddTicks(2487), "$2a$12$5VF7s11VkNSAWRUapttGWe76vvfsokN47ra8FaQl0DhSYB0PpLUvW", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 18, 238, DateTimeKind.Utc).AddTicks(3798), "$2a$12$kwjQTgnk0.d3f0nKpBW86evS6M7AqkW/emaKK.IumE5sxsi8e5TSy", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 18, 464, DateTimeKind.Utc).AddTicks(7397), "$2a$12$Ld8J4ngB3uJ6cQbtOxboruESe3uHh1/emFz1Ds8SzY5K3LsPwVQPG", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 19, 594, DateTimeKind.Utc).AddTicks(9840), "$2a$12$qbskq5UF9HpDdlAVezLJVeCpwT0vu6mT0IIRTtBYpuUL63SylrmsK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 19, 820, DateTimeKind.Utc).AddTicks(8507), "$2a$12$wkogOEKDSx4ASot1RFU0Y.azJJ8SnjaVQSrmNaLzadlBkCGIA93sy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 47, DateTimeKind.Utc).AddTicks(446), "$2a$12$7FPtmMaiGWOkSwI2KiCkceh/W8QS7/ns7xgehrWkXXp0TCHz3MSFu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 18, 690, DateTimeKind.Utc).AddTicks(8885), "$2a$12$CQBl1b4iivPJ3oLSrNSiru8NvLBE4h0kGCrrRcToPAil8XvQUTzGq", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 18, 916, DateTimeKind.Utc).AddTicks(7303), "$2a$12$/3mGht.d/2Bx7PwWWtR/weVpOjaVHF1bGKy0oKhn.KzlTAarIKJ/S", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 19, 142, DateTimeKind.Utc).AddTicks(6757), "$2a$12$fXyHJvhS85iheRklGixF6eOD9pswB7dEIyFlT9.Pxyhudmxf8devC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 19, 368, DateTimeKind.Utc).AddTicks(3062), "$2a$12$Wme.ba9RYVpo4xccRMcfjeBcTkMTTHvveVoB.wNnL1qWY61AsTXkC", null });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 17, 53, 20, 272, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(660), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(666), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(668), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(669) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(670), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(672), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1528), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1529) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1531), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1533), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1534) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1536), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1538), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1539) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1540), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1541) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1543), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1545), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1545) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1549), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1549) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1551), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1552) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1553), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1554) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1555), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1556) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1558), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1558) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1560), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1562), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1563) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1564), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1565) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1606), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1609), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1611), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1613), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1616), new DateTime(2025, 6, 3, 17, 53, 20, 273, DateTimeKind.Utc).AddTicks(1616) });
        }
    }
}
