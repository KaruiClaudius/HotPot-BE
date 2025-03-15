using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixidntablenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8499), 8 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8502), 9 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8503), 10 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2922), new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2912), 1 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2924), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2924), 1 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2926), new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2926), 2 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2928), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2928), 2 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2930), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2929), 3 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2932), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2931), 4 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2934), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2933), 5 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2935), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2935), 6 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2938), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2936), 7 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2939), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2939), 8 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2941), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2940), 9 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2943), 10 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2945), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2945), 11 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2947), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2946), 12 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2951), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2951), 13 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2953), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2952), 14 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2955), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2954), 15 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2957), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2957), 16 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2959), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2958), 17 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2961), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2960), 18 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2962), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2962), 19 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2964), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2963), 20 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2965), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2965), 21 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2967), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2967), 22 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2969), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2968), 23 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2970), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2970), 24 });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2738), 7 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2742), 7 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2744), 7 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2746), 2 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2748), 2 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2787), 2 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2789), 3 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2791), 3 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2794), 3 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2796), 4 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2798), 4 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2800), 4 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2802), 5 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2804), 5 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2812), 6 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2814), 6 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2816), 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2818), 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2821), 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2823), 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2824), 8 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2826), 8 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2828), 8 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2830), 8 });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8450), 2 });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8454), 3 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 25, 833, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 25, 833, DateTimeKind.Utc).AddTicks(5587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 25, 833, DateTimeKind.Utc).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 25, 833, DateTimeKind.Utc).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8333), 4 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8341), 5 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8342), 6 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8343), 7 });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 25, 833, DateTimeKind.Utc).AddTicks(5756), "$2a$12$zADlrQ7HKrXWXhF4MF/k0e0/0fnzgj2n78cpDufLny.0C.pW0nxky", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 67, DateTimeKind.Utc).AddTicks(3026), "$2a$12$0RX7QpfGFNwma6D2SVlMduGjLtmhBADZ/rg2nhPp1kJpwWzPWDOVC", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 301, DateTimeKind.Utc).AddTicks(4785), "$2a$12$UBUmmvGBsSF9m0.c7Gf12uYiGN6bgQDAZrZ.JJ8NAAt.P9kC0DYZW", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 533, DateTimeKind.Utc).AddTicks(4246), "$2a$12$gzhaVg/uMlsQqIk7sIfeR.I3TZYI1K2sPsYnKUnWGZz3UKw28YCbW", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 764, DateTimeKind.Utc).AddTicks(1317), "$2a$12$tNFCTLk/nOz/dHnYlXAgB.yX6eCZr2dkH0GNEfoNNT/nLPf/IiO7m", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 994, DateTimeKind.Utc).AddTicks(4641), "$2a$12$DRcturW03PBCk8zjxd4XbuLP3z7SHu/xpCNCUMeMjaR9psDVDCOE2", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 225, DateTimeKind.Utc).AddTicks(8365), "$2a$12$1njT3zmXi8LH1TF835wC7ez/jTRH5YuEf/2yW/SCJ1qPuQb2ZPTtS", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 455, DateTimeKind.Utc).AddTicks(8246), "$2a$12$zCbsfP5TsEThXJaxD.PQ0OvUd3uZncfDMgd3Lb3OQXA5HxwUKpz/O", 4 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 686, DateTimeKind.Utc).AddTicks(2585), "$2a$12$WTnZ6IBwPODxqon2Rp9es.04geeu/J2sk9Lx96TYzrfWqUpPIKg.G", 4 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 916, DateTimeKind.Utc).AddTicks(4882), "$2a$12$4IeP.n.jLhKCxHmVACCAT.19ok0/IQp24eCZTTdtwRwONIZl9S6tC", 4 });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9076), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9072), 1 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9079), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9077), 2 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9081), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9080), 3 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9083), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9082), 4 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9088), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9087), 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7269), 0 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7272), 0 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7272), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2021), new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2013), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2024), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2024), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2026), new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2026), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2028), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2028), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2030), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2030), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2032), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2032), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2034), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2033), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2036), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2035), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2039), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2037), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2040), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2040), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2042), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2042), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2044), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2043), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2046), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2045), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2047), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2047), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2057), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2056), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2059), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2058), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2060), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2060), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2062), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2062), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2064), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2063), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2066), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2065), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2067), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2067), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2069), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2069), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2074), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2073), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2076), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2075), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2077), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2077), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "IngredientId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2080), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2079), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1810), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1812), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1815), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1818), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1820), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1823), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1825), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1827), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1829), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1831), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1834), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1836), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1839), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1841), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1850), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1852), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1854), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1856), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1924), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1927), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1929), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1933), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1935), 0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "IngredientTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1937), 0 });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7221), 0 });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7224), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 45, 487, DateTimeKind.Utc).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 45, 487, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 45, 487, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 45, 487, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7103), 0 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7110), 0 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7111), 0 });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7112), 0 });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 45, 487, DateTimeKind.Utc).AddTicks(4007), "$2a$12$fJK.FZabEf/eSTwV1bZ0S.uHWe2BMQpNBwM0kewxWWYTsVd4ws046", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 45, 735, DateTimeKind.Utc).AddTicks(3553), "$2a$12$OS069FdfBvlkdh6XWj3V1.MpDpmht7OZomgFD.7aUeyzQgBQQLbsa", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 45, 987, DateTimeKind.Utc).AddTicks(5020), "$2a$12$bVfviQw9bmcdg9JBLHiMcOZDXZtnM96dqQs09tkyJXLuhyAhkXVde", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 231, DateTimeKind.Utc).AddTicks(8327), "$2a$12$R4t.Vvmk6Ysb.AD57MgUFuc0e53Q6fiTuMII4n8jdmezy3dS1Kpsy", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 478, DateTimeKind.Utc).AddTicks(2831), "$2a$12$v9WgsPHFNhk9l9BH5FDzu.tKsoMVAu.c6loLWCX9SSobw.970OI.C", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 718, DateTimeKind.Utc).AddTicks(8427), "$2a$12$tXULswH5pbOSJDGRCyb7muEHK3hALfsgeB7.10.pFFX8s7ojX2TkW", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 964, DateTimeKind.Utc).AddTicks(708), "$2a$12$UB4e0T9QlIML8gb.ehcPOeRkAO1PVneApnhSd7kzESBsqC9b.wX46", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 207, DateTimeKind.Utc).AddTicks(1776), "$2a$12$EFb5LGeCgsLzbPfnCbIcRus59Roycu/moSRKJpH4CktmIJd2RUEp6", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 448, DateTimeKind.Utc).AddTicks(4611), "$2a$12$gXy3tAetUH2BjhpxAlISCOmPkqHKVftz8J47pRjl1C4A8RY5B2D5.", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password", "RoleId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 690, DateTimeKind.Utc).AddTicks(9061), "$2a$12$5MqTYuR7/cB.GC/Plem2a.FVPA6r7YTqBHwioqAbRD6b8hNylc3Hi", 0 });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1577), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1566), 0 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1584), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1583), 0 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1587), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1585), 0 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1590), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1588), 0 });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate", "UtensilTypeId" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1592), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1591), 0 });
        }
    }
}
