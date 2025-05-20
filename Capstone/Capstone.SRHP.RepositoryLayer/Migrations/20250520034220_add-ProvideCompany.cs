using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addProvideCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProvideCompany",
                table: "IngredientBatchs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

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
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7640), null, new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7645), null, new DateTime(2025, 5, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7653), null, new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7654), null, new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7656), null, new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7658), null, new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7659), null, new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 25, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7661), null, new DateTime(2025, 5, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7689), null, new DateTime(2025, 5, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7691), null, new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7693), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7694), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7695), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7697), null, new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7698), null, new DateTime(2025, 5, 17, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7700), null, new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7701), null, new DateTime(2025, 5, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7703), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7704), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7706), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7707), null, new DateTime(2025, 5, 15, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7709), null, new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7710), null, new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7711), null, new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 16, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 5, 20, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7713), null, new DateTime(2025, 5, 10, 10, 42, 18, 765, DateTimeKind.Utc).AddTicks(7612) });

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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 100, DateTimeKind.Utc).AddTicks(6605), "$2a$12$HLLXo9bRQZ9BVQpUtQmZie29ki4K202QuoC89j4GniI8foxaoUEgK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 328, DateTimeKind.Utc).AddTicks(3108), "$2a$12$Xddu5GXnUP8KOeq/nrTCUOJ7ejcuQNuaMl5f.hW6aqxBOXbEPw9qq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 556, DateTimeKind.Utc).AddTicks(6372), "$2a$12$Q5Tzbj43XSP18FrYCmSyO.QcaiPMqNvRU8PXFVKFc4CCm6HSI3IVu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 42, 17, 795, DateTimeKind.Utc).AddTicks(171), "$2a$12$qG4oBss5qDcc3cH1S0BQOOi7kDWzrWhT0tfTq859nIBCgEMDSK/oa" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvideCompany",
                table: "IngredientBatchs");

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
    }
}
