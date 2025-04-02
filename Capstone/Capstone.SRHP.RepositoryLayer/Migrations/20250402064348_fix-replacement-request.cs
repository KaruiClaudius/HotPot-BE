using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixreplacementrequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Users_CustomerId",
                table: "ReplacementRequests");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ReplacementRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2194), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2199), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2200), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2202), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2203) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2088), new DateTime(2025, 3, 3, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2099), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2101), new DateTime(2025, 3, 3, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2102) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2103), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2103) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2105), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2106), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2108), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2109), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2110) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2110), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2112), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2113), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2115), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2116), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2118), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2119), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2125), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2126) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2127), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2128), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2130), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2130) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2131), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2133), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2133) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2134), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2135) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2136), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2137), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2138), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2662), "$2a$12$ODb6e3o0ywysReRGO2JnMuzlq9bRWJk9SPgrjiF2uCVrsQ2ZI7eaa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 167, DateTimeKind.Utc).AddTicks(4723), "$2a$12$/mnFgjdVK1aKcK.9Mk9GJulJfwd2dLL01QrzvO9DytqaNrQEOCqoe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 405, DateTimeKind.Utc).AddTicks(2636), "$2a$12$QjPTh382Y18ziGrndWXwAuH.Q825Dlm4HY3PzZ8hfNFAjwbKkwH8C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 638, DateTimeKind.Utc).AddTicks(5361), "$2a$12$1XrOU4ZYlmTQsZNdNeVr7.coqS4/RSfLvumb9CMSTPRP25egFSdgy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 870, DateTimeKind.Utc).AddTicks(2641), "$2a$12$3.WtZxi.MR9mSjq4OVSIE.pKHGBO9piuTfsVXY5Ud0pA97Wj/Vpi." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 104, DateTimeKind.Utc).AddTicks(407), "$2a$12$5ebaFQDM5VpG1iE8yng4y.9hLkVN4IRAJe3JO0LxUMqEt3K4.Xehi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 337, DateTimeKind.Utc).AddTicks(3164), "$2a$12$GPO1B9EiYlxJB5JnMfA1Uevv7yryxn7jKDQUY5MZVYZTJWWcEY0ae" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 568, DateTimeKind.Utc).AddTicks(7972), "$2a$12$Y9BCUAAdizKYvG06rjVqUuXYwFaFxWrMTrjkz0xT4JHdXTulIKSI2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 800, DateTimeKind.Utc).AddTicks(9676), "$2a$12$ePZaCAzdVQp1tLdhGgsjquq1Eroloy.kkOhHAfrl2EiD2bdG3XLPK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 32, DateTimeKind.Utc).AddTicks(3131), "$2a$12$WpNtYjvWsEJ5mDwV2DPHXuj05QjTVEXGrvS2L0pg71hNqW.7Rsdua" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1816), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1822), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1824), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1825) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1826), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1828), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Users_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Users_CustomerId",
                table: "ReplacementRequests");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4779), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4783) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4785), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4786) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4787), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4789), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4668), new DateTime(2025, 3, 2, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4682), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4684), new DateTime(2025, 3, 2, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4684) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4685), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4687), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4688) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4689), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4689) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4690), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4692), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4693) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4694), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4695) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4696), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4697) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4697), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4698) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4699), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4701), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4701) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4702), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4703) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4705), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4713) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4714), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4716), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4718), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4719) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4720), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4721), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4722) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4723), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4723) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4724), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4725) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4726), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4727), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4728) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4729), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4731), new DateTime(2025, 3, 29, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 2, 7, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 2, 7, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 2, 7, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 2, 7, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 2, 7, DateTimeKind.Utc).AddTicks(7085), "$2a$12$3uAnzT3kWUBDBdF0Ecnj8ugUtI27u3QTVdoUIPvJGxXSoW5.e8Nbu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 2, 251, DateTimeKind.Utc).AddTicks(6967), "$2a$12$e9c.B/ztJfj1o2TQktsdhe9NTtFUFIgqg1OZlPG4FtoUyQKM8ashW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 2, 490, DateTimeKind.Utc).AddTicks(8115), "$2a$12$ToHYMZIjRE38nI1o80Z8Iu9uEMSqGxZMgBDb9KcF3WVf4F.DGFEa." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 2, 720, DateTimeKind.Utc).AddTicks(5034), "$2a$12$iW9GVhbQJVR/QjvwEZM8FeKrzPRie5f6FwiZjegJLumWzLh7cmkbO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 2, 955, DateTimeKind.Utc).AddTicks(2950), "$2a$12$i.jb6jKIam7C/x1h9fnELeZHE.VSiZ.GEA3e1zgEnThYgay613NIa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 3, 185, DateTimeKind.Utc).AddTicks(6314), "$2a$12$8kkpHELTGbhPH8GO9FywBOTkhPhmjFPSZV1LWP./5lNXwKpXGYfvq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 3, 413, DateTimeKind.Utc).AddTicks(8862), "$2a$12$5pXzJ3vLex21hBmeLBNiHuPAb98NTzapKByXyc4Uu7/KrOY3/Ag6e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 3, 647, DateTimeKind.Utc).AddTicks(3136), "$2a$12$kwWFSXNlqWHErRCqwJbRv.58bjRQiYygotad9TAcHRW4jKSZqntpm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 3, 894, DateTimeKind.Utc).AddTicks(4759), "$2a$12$hEzH6fsp32VMFENcTT4VjOfQfGo3ncK9tVzG1X.Kwbl1rbYVecH/K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 137, DateTimeKind.Utc).AddTicks(8923), "$2a$12$eVBE.0j7knxSEQFUEdZFpe3gBH6YsAFDoy3QlTxKOKqTVteG/vQre" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4333), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4340), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4341) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4343), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4343) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4345), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4345) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4347), new DateTime(2025, 4, 1, 16, 23, 4, 381, DateTimeKind.Utc).AddTicks(4347) });

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Users_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
