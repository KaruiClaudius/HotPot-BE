using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class removeinventoryIDhotpot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Hotpots");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3507), new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3497) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3510), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3512), new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3514), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3514) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3516), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3516) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3519), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3518) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3521), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3523), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3522) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3529), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3528) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3531), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3533), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3532) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3535), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3535) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3539), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3537) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3541), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3556), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3555) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3559), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3559) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3562), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3561) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3564), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3563) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3566), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3568), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3568) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3571), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3573), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3573) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3575), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3575) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3577), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3577) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3579), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3579) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3582), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3581) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 46, 523, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 46, 523, DateTimeKind.Utc).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 46, 523, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 46, 523, DateTimeKind.Utc).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 46, 523, DateTimeKind.Utc).AddTicks(6727), "$2a$12$ZU7bfNUoA8hC2gxUKS3xReiA162.79q/rKhVSNIxNlXoK.Oysk6qO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 46, 819, DateTimeKind.Utc).AddTicks(4928), "$2a$12$1XoFda5voUPh83FSkqEf4eDvUwloigZqJ9zDQHGo1kZK8JOqamZ1u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 47, 81, DateTimeKind.Utc).AddTicks(3735), "$2a$12$gYg6P/NdoThCld0q1lLsAuNbBtkC2YD3/N8lrdxiSLGHu8NQ7anr." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 47, 419, DateTimeKind.Utc).AddTicks(5944), "$2a$12$qJcmVBZfwKPjMxYmpbi5AeiuamR2bI.6haHQzJukb99WtjHDrKtqi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 47, 694, DateTimeKind.Utc).AddTicks(8703), "$2a$12$txxBdgpKW7AlA6xr7nE7U.zs5brFR4zzJ/Qh2QYepQRTVDYLHE63e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 47, 956, DateTimeKind.Utc).AddTicks(5022), "$2a$12$FyOrGF6XOGev0XRR2ne0Rubhpwjhmt0PpuGqhf2nvo0AS5M.zzClC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 48, 214, DateTimeKind.Utc).AddTicks(4259), "$2a$12$eNWyFAd7WqAVN26JBijdie4cnwFfQCYzoyD7OGhY3pVNXjCzohG.u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 48, 557, DateTimeKind.Utc).AddTicks(5233), "$2a$12$LFzt5k4tfgfvXX7/MpxQhO.opO.vkTuL3fUHSDtH/EQg0uOjbPvt6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 48, 814, DateTimeKind.Utc).AddTicks(6156), "$2a$12$u4RA/zkNkJGDF/uFOi3Fue5wrKvWMSPB1EEDeDXDNi8XSrW53CG.." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 85, DateTimeKind.Utc).AddTicks(8162), "$2a$12$Mn6nOGdImee2mnWc4mBrKewn.cYIksn9nqF/8ZuIUqtEXTkcYVDgi" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3160), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(3149) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3163), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3166), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(3164) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3169), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(3167) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3172), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Utc).AddTicks(3170) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Hotpots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "InventoryID" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5586), 0 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "InventoryID" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5590), 0 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "InventoryID" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5592), 0 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "InventoryID" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5594), 0 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "InventoryID" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5596), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 11, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5972), new DateTime(2025, 2, 11, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5962) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5975), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 11, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5977), new DateTime(2025, 2, 11, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5976) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5979), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5981), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5983), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5986), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5988), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5987) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5990), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5992), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5994), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5996), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5997), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5997) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5999), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6010), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6012), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6012) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6014), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6014) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6016), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6016) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6018), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6017) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6021), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6022), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6024), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6028), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6030), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6031), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6033), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 55, 890, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 55, 890, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 55, 890, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 55, 890, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 55, 890, DateTimeKind.Utc).AddTicks(8912), "$2a$12$TOQFfztyZEznHiHlWQOCuOkEeJBd2nTAziVP5SxOrspr1V/IJpPxK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 56, 207, DateTimeKind.Utc).AddTicks(188), "$2a$12$cmMhm02EMMg/1kGPCLkwYuFhTBsPjEz6YiPrmNFH.SEjG0se2Lllm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 56, 518, DateTimeKind.Utc).AddTicks(5492), "$2a$12$hfdF0.ET/w7nZsu/jKDP5eCX4YoYfVZ3pmJx.r5502/ZpK2Tco4iC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 56, 821, DateTimeKind.Utc).AddTicks(2954), "$2a$12$v3fCX5oJP.ZQA4ZZRPYyOuQCIfVcgLxjfp5YHzTyLkqI1ie0ZN1jq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 57, 88, DateTimeKind.Utc).AddTicks(9602), "$2a$12$R72VCO169K/eMSVptud42e5vJY7EWiC0ZX4DnGWu/gZEOpig28xIK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 57, 351, DateTimeKind.Utc).AddTicks(6356), "$2a$12$fn2AH2kVaLLZGcNMrVjQ7O.mTmRPL.AEwBOFIHjZN3EBy//s46L9m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 57, 617, DateTimeKind.Utc).AddTicks(6443), "$2a$12$UsAbxEVisk8UhHEHJdBp9ea3MDTwMe4ThZfckTpipm7cad6voiy1C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 57, 869, DateTimeKind.Utc).AddTicks(8327), "$2a$12$ZrIJEE3.po0nk3lgUDkF0OT4yLpDM4sJo.UgqT6he22iANBOzKjtW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 120, DateTimeKind.Utc).AddTicks(4887), "$2a$12$vJPMfa8gA23zlv1m.jbhCu9Kd.INZXgVoIdCF07NwOpfJWKrUV2WW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 380, DateTimeKind.Utc).AddTicks(165), "$2a$12$KVAs3JHQ.ti/KPT4icsQse04qYtfAwNWABt4QQeMlUpCdAFXlexx6" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5652), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5643) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5655), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5653) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5657), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5656) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5660), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5658) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Local).AddTicks(5662), new DateTime(2025, 3, 13, 1, 5, 58, 628, DateTimeKind.Utc).AddTicks(5661) });
        }
    }
}
