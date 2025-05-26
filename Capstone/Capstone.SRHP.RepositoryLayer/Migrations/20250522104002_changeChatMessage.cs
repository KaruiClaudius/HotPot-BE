using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class changeChatMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatSessions_SessionId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SessionId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "ChatMessages");

            migrationBuilder.AddColumn<int>(
                name: "ChatSessionId",
                table: "ChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CreatedAt", "IsDelete", "LicensePlate", "Name", "Notes", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 11, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5021), false, "51A-56789", "Kia Morning", "Xe nhỏ gọn, di chuyển linh hoạt trong nội thành", 1, 2, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5022) },
                    { 12, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5023), false, "59P5-12345", "SYM Elegant", "Xe số tiết kiệm nhiên liệu, dễ bảo trì", 1, 1, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5024) },
                    { 13, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5026), false, "51H-67890", "Mazda CX-5", "Xe SUV 5 chỗ, phù hợp vận chuyển hàng hóa trong điều kiện thời tiết xấu", 1, 2, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5026) },
                    { 14, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5028), false, "59P6-23456", "Yamaha Janus", "Xe tay ga tiết kiệm nhiên liệu, nhẹ và dễ lái", 1, 1, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5028) },
                    { 15, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5030), false, "59P6-34567", "Honda Air Blade", "Xe tay ga mạnh mẽ, thích hợp giao hàng ngoài giờ cao điểm", 1, 1, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5031) },
                    { 16, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5032), false, "59X1-45678", "VinFast Klara", "Xe máy điện thân thiện môi trường, hoạt động tốt trong thành phố", 1, 1, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5033) },
                    { 17, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5044), false, "51G-78901", "Chevrolet Spark", "Xe nhỏ gọn 4 chỗ, phù hợp giao hàng trong khu dân cư đông đúc", 1, 2, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5044) },
                    { 18, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5046), false, "51A-89012", "Hyundai Grand i10", "Xe hatchback nhỏ gọn, dễ dàng đỗ xe và di chuyển", 1, 2, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5047) },
                    { 19, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5048), false, "51C-34567", "Suzuki Carry Truck", "Xe tải nhẹ chuyên dùng giao hàng cồng kềnh trong thành phố", 1, 2, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5049) },
                    { 20, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5078), false, "59P7-56789", "Yamaha Exciter", "Xe số phân khối lớn, phù hợp cho giao hàng nhanh và xa", 1, 1, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5079) },
                    { 21, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5081), false, "60F3-56874", "Ferrari La Ferrari", "Siêu xe, lái cho vui :))", 1, 2, new DateTime(2025, 5, 22, 17, 40, 1, 570, DateTimeKind.Utc).AddTicks(5081) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatSessionId",
                table: "ChatMessages",
                column: "ChatSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatSessions_ChatSessionId",
                table: "ChatMessages",
                column: "ChatSessionId",
                principalTable: "ChatSessions",
                principalColumn: "ChatSessionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatSessions_ChatSessionId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_ChatSessionId",
                table: "ChatMessages");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "ChatSessionId",
                table: "ChatMessages");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "ChatMessages",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 437, DateTimeKind.Utc).AddTicks(2964), "$2a$12$lsE.lXzLpOz8xGLcL2aEkuNP9RJ.wo0YVRo1LiN9Nxzk0NZKGZu5C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 678, DateTimeKind.Utc).AddTicks(2333), "$2a$12$n1skR8AvWJxVNHcVBEJI/uljmiVTJKg3G5q/UR1w20QR5NFanMpy6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 8, 920, DateTimeKind.Utc).AddTicks(2396), "$2a$12$7FqURY4X9GGIGk2oZgogKeIaGvQYzIoZpUGaeCSIROAusYCZr9qvi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 22, 12, 6, 9, 207, DateTimeKind.Utc).AddTicks(2252), "$2a$12$X/SctuTTLmYfvbA5ZZUk.eer9Qo5kNYFq1fC8yUVd6yWBUJuBV0jC" });

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
                name: "IX_ChatMessages_SessionId",
                table: "ChatMessages",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatSessions_SessionId",
                table: "ChatMessages",
                column: "SessionId",
                principalTable: "ChatSessions",
                principalColumn: "ChatSessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
