using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class removeSomeFeedbackColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Users_ApprovedByUserId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ApprovedByUserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Feedback");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4346), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4352), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4354), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4355) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4126), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 12, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4130), new DateTime(2025, 5, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4143), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4145), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4146), new DateTime(2025, 5, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4148), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4150), new DateTime(2025, 5, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4151), new DateTime(2025, 5, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4153), new DateTime(2025, 5, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4155), new DateTime(2025, 5, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4157), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4159), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4160), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4162), new DateTime(2025, 5, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 5, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4164), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 1, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4166), new DateTime(2025, 5, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4168), new DateTime(2025, 5, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4169), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4171), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4173), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4174), new DateTime(2025, 5, 17, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 20, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4176), new DateTime(2025, 5, 12, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 18, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4178), new DateTime(2025, 5, 12, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 18, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4179), new DateTime(2025, 5, 12, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 18, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4181), new DateTime(2025, 5, 12, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3978), new DateTime(2025, 4, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3997), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3999), new DateTime(2025, 4, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4001), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4002) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4003), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4004) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4005), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4006), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4007) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4008), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4009) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4010), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4011), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4012) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4013), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4015), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4016), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4017) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4018), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4020), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4027) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4028), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4029) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4030), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4031), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4033), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4035), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4036), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4039), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4040), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4042), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4043) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4044), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4045), new DateTime(2025, 5, 19, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 6, 731, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 6, 731, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 6, 731, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 6, 731, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4434), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4439), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4589), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4593), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4596), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4599), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4602), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 6, 731, DateTimeKind.Utc).AddTicks(4792), "$2a$12$cCrXoQ8/jni6xHmBlIXNs.fJfDHRCjSWK.lSysBUzAsWGSBvulNLC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 6, 974, DateTimeKind.Utc).AddTicks(9427), "$2a$12$pRI2S6Xzf2n43QtjfhSZa.SwwksYeOkPiJ06iET7sqXPIMsvusV3u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 7, 222, DateTimeKind.Utc).AddTicks(460), "$2a$12$lq/fKxIMOtKKDTdZXAeDouUVa.t4m9/qhhkUg4qZW7eHderKwwXna" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 7, 466, DateTimeKind.Utc).AddTicks(7825), "$2a$12$K4RnkUBTHLMY1WD1YhFWF.YABZJPtQZX3kTyFgRp1F0cfnDS08a7." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 7, 713, DateTimeKind.Utc).AddTicks(7128), "$2a$12$eKihO.1kkndDdaHG0pLHreL67bVgHEEU1/yVrXkxDAIHqjVP.M6oS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 7, 954, DateTimeKind.Utc).AddTicks(2642), "$2a$12$V8C/60cAH2JhpfMTOvaHZeZovscUI83fDjxd4ggYXKA9OOIETrpo." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 196, DateTimeKind.Utc).AddTicks(672), "$2a$12$qKfsCFI3s9gdN2z.c5lla.H.EbHyPl6xcrngl9llqzdFDiQjwnPti" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 9, 458, DateTimeKind.Utc).AddTicks(6577), "$2a$12$bXITqZBZwqMnPU6lTM/y7O16ZI0jdAf6Au3cnC1sBhALlJu.C9LtS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 9, 707, DateTimeKind.Utc).AddTicks(4606), "$2a$12$a7ZfStuHRGyEcdpSzFBK8O7v7y1SF8cBdLedLYV2U2PBPmeczty7a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 9, 953, DateTimeKind.Utc).AddTicks(2405), "$2a$12$G89gimp2CjYF0qSjzvHGqOct65qRM4YAJrytvM6E4xdihyMjDh6WS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 437, DateTimeKind.Utc).AddTicks(2964), "$2a$12$lsE.lXzLpOz8xGLcL2aEkuNP9RJ.wo0YVRo1LiN9Nxzk0NZKGZu5C", "901234567" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 678, DateTimeKind.Utc).AddTicks(2333), "$2a$12$n1skR8AvWJxVNHcVBEJI/uljmiVTJKg3G5q/UR1w20QR5NFanMpy6", "907654321" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 920, DateTimeKind.Utc).AddTicks(2396), "$2a$12$7FqURY4X9GGIGk2oZgogKeIaGvQYzIoZpUGaeCSIROAusYCZr9qvi", "912345678" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 9, 207, DateTimeKind.Utc).AddTicks(2252), "$2a$12$X/SctuTTLmYfvbA5ZZUk.eer9Qo5kNYFq1fC8yUVd6yWBUJuBV0jC", "918765432" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3651), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3659), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3659) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3661), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3662) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3664), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3664) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3666), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(3666) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8469), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8476), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8477) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8479), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8481), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8484), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8486), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8488), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8489) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8490), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8491) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8493), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8493) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8495), new DateTime(2025, 5, 22, 12, 6, 10, 204, DateTimeKind.Utc).AddTicks(8495) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Feedback",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Feedback",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "Feedback",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Feedback",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7816), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7820), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7822), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7640), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7645), new DateTime(2025, 5, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7653), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7654), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7656), new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7658), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7659), new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 25, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7661), new DateTime(2025, 5, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7689), new DateTime(2025, 5, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7691), new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7693), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7694), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7695), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7697), new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7698), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7700), new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7701), new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7703), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7704), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7706), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7707), new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7709), new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7710), new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7711), new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7713), new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7532), new DateTime(2025, 4, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7543), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7544), new DateTime(2025, 4, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7546), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7547), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7548) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7549), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7550), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7552), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7552) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7557), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7558) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7559), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7559) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7560), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7562), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7563), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7565), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7565) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7566), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7575), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7575) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7576), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7577) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7577), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7579), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7580), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7582), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7583), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7585), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7586) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7586), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7587) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7588), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7589) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7589), new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 15, 489, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 15, 489, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 15, 489, DateTimeKind.Utc).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 15, 489, DateTimeKind.Utc).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7881), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7887), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7890), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7893), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7893) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7896), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7899), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7902), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7902) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 15, 489, DateTimeKind.Utc).AddTicks(6528), "$2a$12$X4S4oko42ey0YRtwETFxSuIpPaWBJsgUENs6K4cCH.jLNNVkRyJYS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 15, 725, DateTimeKind.Utc).AddTicks(7776), "$2a$12$oYoI1ec.V91tjIpUD7XIHed7/ebyyztSoL.5FHxO0wJh3Jw3I4I86" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 15, 955, DateTimeKind.Utc).AddTicks(2723), "$2a$12$g8t3ajDdrt8qjtQJB5nwOuUp5qw2tjWbvq.poKms1ZbOlXBzqFi56" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 16, 184, DateTimeKind.Utc).AddTicks(9104), "$2a$12$n4cnFi/13tSekw3JklSIteaP6Qkfjp7gkvk6vhqh5iNgwprqaJJnu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 16, 412, DateTimeKind.Utc).AddTicks(1506), "$2a$12$o3vUwhlmD5BjPS61d1y6beYV1XFkXPTR673vM7Ll1NSPAYl1gq1bS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 16, 641, DateTimeKind.Utc).AddTicks(2505), "$2a$12$NwCgZuzZR3.zmaqrMNUW5OBe5g6/I4m5egyhZ9OIsGYyqdw.Cf0sC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 16, 870, DateTimeKind.Utc).AddTicks(6271), "$2a$12$YUWmT2KLdkcs2d9ch85rr.qOcvzuerzo1lEyTbKXO/lvrSJ.L7y7G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 34, DateTimeKind.Utc).AddTicks(1840), "$2a$12$R4cxf0nirLWsJsMm/Sik1.5LpI38uibuY3uF7rs8Os7v/VnOzyoja" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 278, DateTimeKind.Utc).AddTicks(2527), "$2a$12$HOl8zthRfpEsElIVSpYjIO570uWatYfSHmuYksNh24b6vkMTy4QCa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 529, DateTimeKind.Utc).AddTicks(6017), "$2a$12$e7dwG7l8BxtDGOVfhEu6pe54QBJSH819rH2O9Ci/FOgKugO8UwbNG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 100, DateTimeKind.Utc).AddTicks(6605), "$2a$12$HLLXo9bRQZ9BVQpUtQmZie29ki4K202QuoC89j4GniI8foxaoUEgK", "0901234567" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 328, DateTimeKind.Utc).AddTicks(3108), "$2a$12$Xddu5GXnUP8KOeq/nrTCUOJ7ejcuQNuaMl5f.hW6aqxBOXbEPw9qq", "0907654321" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 556, DateTimeKind.Utc).AddTicks(6372), "$2a$12$Q5Tzbj43XSP18FrYCmSyO.QcaiPMqNvRU8PXFVKFc4CCm6HSI3IVu", "0912345678" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 795, DateTimeKind.Utc).AddTicks(171), "$2a$12$qG4oBss5qDcc3cH1S0BQOOi7kDWzrWhT0tfTq859nIBCgEMDSK/oa", "0918765432" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7138), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7146), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7149), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7149) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7151), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7153), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7973), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7977), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7977) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7979), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7981), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7982) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7984), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7984) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7987), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7989), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7991), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7992) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7994), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7994) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7996), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7996) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId",
                unique: true,
                filter: "[DiscountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApprovedByUserId",
                table: "Feedback",
                column: "ApprovedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Users_ApprovedByUserId",
                table: "Feedback",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
