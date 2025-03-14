using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixorderdetailrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotpots_OrderDetails_OrderDetailId",
                table: "Hotpots");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ComboID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CustomizationID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_IngredientID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_UtensilID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Hotpots_OrderDetailId",
                table: "Hotpots");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Hotpots");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7773), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7775), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7777), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7778), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7780), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7781), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7783), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7784), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7785), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7787), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7788), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7789), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7791), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7792), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Local).AddTicks(7800), true });

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
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2021), new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2024), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2026), new DateTime(2025, 2, 12, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2028), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2030), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2032), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2034), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2036), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2039), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2040), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2042), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2042) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2044), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2043) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2046), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2047), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2047) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2057), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2056) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2059), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2058) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2060), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2060) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2062), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2062) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2064), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2066), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2065) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2067), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2067) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2069), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2074), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2073) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2076), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2075) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2077), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2077) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2080), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(2079) });

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7224));

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 23, 10, 47, 928, DateTimeKind.Utc).AddTicks(7112));

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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 45, 487, DateTimeKind.Utc).AddTicks(4007), "$2a$12$fJK.FZabEf/eSTwV1bZ0S.uHWe2BMQpNBwM0kewxWWYTsVd4ws046" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 45, 735, DateTimeKind.Utc).AddTicks(3553), "$2a$12$OS069FdfBvlkdh6XWj3V1.MpDpmht7OZomgFD.7aUeyzQgBQQLbsa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 45, 987, DateTimeKind.Utc).AddTicks(5020), "$2a$12$bVfviQw9bmcdg9JBLHiMcOZDXZtnM96dqQs09tkyJXLuhyAhkXVde" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 231, DateTimeKind.Utc).AddTicks(8327), "$2a$12$R4t.Vvmk6Ysb.AD57MgUFuc0e53Q6fiTuMII4n8jdmezy3dS1Kpsy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 478, DateTimeKind.Utc).AddTicks(2831), "$2a$12$v9WgsPHFNhk9l9BH5FDzu.tKsoMVAu.c6loLWCX9SSobw.970OI.C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 718, DateTimeKind.Utc).AddTicks(8427), "$2a$12$tXULswH5pbOSJDGRCyb7muEHK3hALfsgeB7.10.pFFX8s7ojX2TkW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 46, 964, DateTimeKind.Utc).AddTicks(708), "$2a$12$UB4e0T9QlIML8gb.ehcPOeRkAO1PVneApnhSd7kzESBsqC9b.wX46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 207, DateTimeKind.Utc).AddTicks(1776), "$2a$12$EFb5LGeCgsLzbPfnCbIcRus59Roycu/moSRKJpH4CktmIJd2RUEp6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 448, DateTimeKind.Utc).AddTicks(4611), "$2a$12$gXy3tAetUH2BjhpxAlISCOmPkqHKVftz8J47pRjl1C4A8RY5B2D5." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 690, DateTimeKind.Utc).AddTicks(9061), "$2a$12$5MqTYuR7/cB.GC/Plem2a.FVPA6r7YTqBHwioqAbRD6b8hNylc3Hi" });

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
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1577), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1566) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1584), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1583) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1587), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1585) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1590), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Local).AddTicks(1592), new DateTime(2025, 3, 14, 23, 10, 47, 929, DateTimeKind.Utc).AddTicks(1591) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ComboID",
                table: "OrderDetails",
                column: "ComboID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomizationID",
                table: "OrderDetails",
                column: "CustomizationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IngredientID",
                table: "OrderDetails",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UtensilID",
                table: "OrderDetails",
                column: "UtensilID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ComboID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CustomizationID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_IngredientID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_UtensilID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Hotpots",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2565), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2566), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2567), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2568), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2570), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2571), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2572), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2573), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2574), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2576), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2577), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2578), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2579), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2580), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2585), false });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDetailId" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2491), null });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDetailId" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2499), null });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OrderDetailId" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2501), null });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OrderDetailId" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2504), null });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OrderDetailId" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2507), null });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7438), new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7441), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7444), new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7446), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7448), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7448) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7450), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7452), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7454), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7455), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7455) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7458), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7460), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7459) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7461), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7463), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7464), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7469), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7470), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7473), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7475), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7477), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7476) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7478), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7478) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7481), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7482), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7482) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7484), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7485), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7485) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7487), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7488), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7488) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(6005), "$2a$12$5UBhC4v1TB1pbNY39K15e.endofTEZE35A9eR8rN8kO1nMVAhRZqu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 32, 614, DateTimeKind.Utc).AddTicks(9112), "$2a$12$m2SKgzZcRs1/s2M265CB4OrPmhu5jc3JoYaCqQgWfhCeg4ypaRfeO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 32, 858, DateTimeKind.Utc).AddTicks(399), "$2a$12$9njIrraUktRnBCCwqBlzg.ESPXkvVKEhFruxgGe8Dgzp1owCR4uf6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 33, 90, DateTimeKind.Utc).AddTicks(3533), "$2a$12$EWsgSQMUwyxZ.uzYuiBBw.Bs508CNFvMAWvAU8LaSVncGZ7PXQPKi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 33, 319, DateTimeKind.Utc).AddTicks(8727), "$2a$12$fLIUJKIHMJKhiZxtbIy8d.3dsO6XnB.W7Uhv.MPoHr2aYkeBqreRq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 33, 548, DateTimeKind.Utc).AddTicks(9980), "$2a$12$SI6eBK4eoK31G8GWskn/bOfhZvEjTR0iXD1omQH6DWTc1P1s8EIy." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 33, 778, DateTimeKind.Utc).AddTicks(8495), "$2a$12$CD81vuMBWQGYZaAGTkpXh.GOylAIsWJHCBlGSNch2cf7v3.WSFnCG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 11, DateTimeKind.Utc).AddTicks(8050), "$2a$12$l6V/4zT4mEFFG.7IAXV6LexE/1mExVfpIxkYFDIMIIGxS9F1EA/xC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 241, DateTimeKind.Utc).AddTicks(5730), "$2a$12$p5njz4kMez7BIXvo4ZGJqOF8A/RFB6eYr.rUSwwU8WYR/fwU1yvJ6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 470, DateTimeKind.Utc).AddTicks(5249), "$2a$12$b8hV5omzyhj1YIncRPpOv.WWhs4HrfFEAU0g4uIdYWFSwau.TA.mq" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2685), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2679) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2687), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2686) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2690), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2688) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2692), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2691) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2695), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2693) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ComboID",
                table: "OrderDetails",
                column: "ComboID",
                unique: true,
                filter: "[ComboID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomizationID",
                table: "OrderDetails",
                column: "CustomizationID",
                unique: true,
                filter: "[CustomizationID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IngredientID",
                table: "OrderDetails",
                column: "IngredientID",
                unique: true,
                filter: "[IngredientID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UtensilID",
                table: "OrderDetails",
                column: "UtensilID",
                unique: true,
                filter: "[UtensilID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hotpots_OrderDetailId",
                table: "Hotpots",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotpots_OrderDetails_OrderDetailId",
                table: "Hotpots",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId");
        }
    }
}
