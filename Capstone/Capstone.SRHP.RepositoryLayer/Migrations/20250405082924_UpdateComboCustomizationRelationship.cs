using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComboCustomizationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Combos_ComboId",
                table: "Customizations");

            migrationBuilder.DropIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3075), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3079), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3081), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3083), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2965), new DateTime(2025, 3, 6, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2977), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2979), new DateTime(2025, 3, 6, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2981), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2982) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2983), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2984) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2984), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2986), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2987), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2988) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2989), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2991), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2991) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2992), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2993) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2994), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2995) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2996), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2998), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2998) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2999), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3008), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3009) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3010), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3012), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3012) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3013), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3015), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3016), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3018), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3019), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3021), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3022) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3023), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3023) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3024), new DateTime(2025, 4, 2, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(3025) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5026), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5032), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5033) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5035), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5038), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5042), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5042) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5045), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5048), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 177, DateTimeKind.Utc).AddTicks(4646), "$2a$12$oevRlwFgHzOW.PLRdMTWh.q6Z6NueGtQcU1dPqZGmgxz83Q37SfIa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 407, DateTimeKind.Utc).AddTicks(635), "$2a$12$ooQK45fg7wP/DEcmaIvAX.RcHIDlvnQHq5wI3DoFcv72a1vgtMkoG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 634, DateTimeKind.Utc).AddTicks(166), "$2a$12$8nN0BUlw29zdsrPsaIFfg.KibAiiDWZCm4cmU5kvWPqG9/kEP1/4y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 20, 878, DateTimeKind.Utc).AddTicks(1603), "$2a$12$i/693.tSIWMZjWjNZuM30eoRamL44lL9ZOXMnBFEj.ORQRWPWyd6y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 122, DateTimeKind.Utc).AddTicks(3619), "$2a$12$xSC8BkWuCk2D8gQ1ot8Pg.tQmglNEfhxj1/L.4EAmKEhbtnOM8bwK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 350, DateTimeKind.Utc).AddTicks(6721), "$2a$12$nClArMXWXQcrzwAAASatNOp4IEg6qyMp63u0gr8v3y4ADQZBUFkYK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 586, DateTimeKind.Utc).AddTicks(1155), "$2a$12$XVOJwLJk1viy8D4anyWB8.rKsPEweUDyTJdlKOo0RmM0D512rMRf2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 21, 829, DateTimeKind.Utc).AddTicks(4677), "$2a$12$RZ0uH.ySFYbojZjYJvVVUufmkqAvp6kn/3WuS9mL73sBOank0mjd." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 74, DateTimeKind.Utc).AddTicks(7261), "$2a$12$LCIwhSlA83npijuRhpScZOFOk72xqxJq3cy.hWJk03gHlsoNQx906" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 305, DateTimeKind.Utc).AddTicks(9301), "$2a$12$lv8Djage90SV8unmIRx2Bu/l91w6/ZCZpWkTCWymLw7iowCcOqcYG" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2708), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2708) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2715), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2718), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2718) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2721), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2723), new DateTime(2025, 4, 5, 15, 29, 22, 557, DateTimeKind.Utc).AddTicks(2723) });

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customizations_Combos_ComboId",
                table: "Customizations",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "ComboId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Combos_ComboId",
                table: "Customizations");

            migrationBuilder.DropIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1724), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1731), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1732) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1732), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1733) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1734), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1735) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1581), new DateTime(2025, 3, 5, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1597), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1600), new DateTime(2025, 3, 5, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1601), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1603), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1604), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1606), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1607), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1609), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1611), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1612), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1614), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1615), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1617), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1618), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1625) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1626), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1627) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1628), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1630), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1631), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1633), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1634) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1635), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1636) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1636), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1638) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1639), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1644), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1645), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1647), new DateTime(2025, 4, 1, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 14, 315, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 14, 315, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 14, 315, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 14, 315, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1879), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1881) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1887), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1891), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1891) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1894), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1894) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1897), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1897) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1901), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1901) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1904), new DateTime(2025, 4, 4, 20, 18, 16, 635, DateTimeKind.Utc).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 14, 315, DateTimeKind.Utc).AddTicks(9963), "$2a$12$o/08r2VrVvT/tp3u0hHEbe202bNTh0v2L.vkyzFCtM0/lVWZrFhjS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 14, 560, DateTimeKind.Utc).AddTicks(4047), "$2a$12$ZxKgQMmR6lncORIr0SEmFetK/R3Z0xXccUa44HRr/JcTR2fkfuTPa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 14, 801, DateTimeKind.Utc).AddTicks(3120), "$2a$12$SVo58sXjjh4CKq5g7kiT2OjA8lgq.dwRKAbfHGbbqMrDeUKdQFBqS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 15, 33, DateTimeKind.Utc).AddTicks(3096), "$2a$12$c57vmfkIeYX4qwvYIUaHCucg7z0rXroUkpajfx2kWDKY89Wxl6fKm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 15, 262, DateTimeKind.Utc).AddTicks(3629), "$2a$12$GsS29kzxItf4a8GL9DVNLOwHRwYiZi7kOXyAn19qWfUFhGIyAV9Fi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 15, 492, DateTimeKind.Utc).AddTicks(2947), "$2a$12$Vuc.uJhcRtHmVXd6H9Hwm.9.NRSMeejta2P3WVjIi3I4/rf9OSP1u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 15, 720, DateTimeKind.Utc).AddTicks(3512), "$2a$12$9hdXB/b3RCT3Y9fLO1Anougl9gxOg/kLvEuby2KNizXwr6ueu3d4e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 15, 949, DateTimeKind.Utc).AddTicks(709), "$2a$12$ZxR49sk1V5WKUpUIu4.dyOeMAObVxkhSVea6V4ZC2r9oJbmbyq3w2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 177, DateTimeKind.Utc).AddTicks(1809), "$2a$12$9jKbmu.JAhV9H7Xrl2epLe9Z.cx6jG812zJX2og9pSEWUj1FENwHm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 405, DateTimeKind.Utc).AddTicks(4332), "$2a$12$FjjX35rJ68g2ehut7BOQb.v8gBzkUYZQzRJZDVfFk5Yo2KNn3Ptou" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7746), new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7746) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7754), new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7754) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7756), new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7756) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7757), new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7758) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7760), new DateTime(2025, 4, 4, 20, 18, 16, 634, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations",
                column: "ComboId",
                unique: true,
                filter: "[ComboId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customizations_Combos_ComboId",
                table: "Customizations",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "ComboId");
        }
    }
}
