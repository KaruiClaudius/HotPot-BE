using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1757), new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1760), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1763), new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1765), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1765) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1767), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1769), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1771), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1775), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1775) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1779), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1781), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1783), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1785), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1787), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1788), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1802), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1804), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1805), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1807), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1809), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1811), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1810) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1813), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1815), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1817), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1818), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1818) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1820), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1822), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1821) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5522), "$2a$12$dfmxLBDFN0trt23oZ9Lb/ugs70GpUL38wyzq0hEXTRSlv9jgycpO." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 138, DateTimeKind.Utc).AddTicks(7736), "$2a$12$HbwXjqSeP8lNUs.qrU9QWunxtHglu7K2UqXKgBBBMn7jCAHiZntPK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 394, DateTimeKind.Utc).AddTicks(4935), "$2a$12$LmQlJa81LVlsO56J6cvv1e26.01hY5Tl4fvm5hTygJ082JbkUVEpO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 620, DateTimeKind.Utc).AddTicks(3117), "$2a$12$W71I.G9kVk7NH85AJlo7j.oF86BQwse80UTFjyYzE0KjBuSp/kYoO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 847, DateTimeKind.Utc).AddTicks(1190), "$2a$12$XcWwsjV8Owybb9ZUqDm4ZOlCqjT1HJzHAUaOj3XSGCkiwzWipuBUe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 73, DateTimeKind.Utc).AddTicks(2186), "$2a$12$9ir3AlAv7vmq5mT6K1f4r.udVjmKu75jdTIw48973ELiXFFF7c8E6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 299, DateTimeKind.Utc).AddTicks(1706), "$2a$12$nQyIvUDdu6X0ZyQ9NlJrfOvELSNMbHp3IYRQap3JPJKoWP9RYxVfK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 525, DateTimeKind.Utc).AddTicks(5088), "$2a$12$ecW33/sCcypqapgYZYjdB.jMWRkMlnHSFqEvCI5XGavekVEWhpPjO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 750, DateTimeKind.Utc).AddTicks(9110), "$2a$12$asaldSQN4MsECjPlxRsohuinOnNg1bRBxOD4yGfM9bITIOTvlrXqK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 976, DateTimeKind.Utc).AddTicks(7728), "$2a$12$.KjQ1DEwXxsq91x0BA4E8ukYAS6j0a4jx3rhW8ciREwNuAwzqjvKe" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7505), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7509), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7511), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7510) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7513), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7516), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7514) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8503));

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
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2922), new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2912) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2924), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2926), new DateTime(2025, 2, 13, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2926) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2928), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2930), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2929) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2932), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2934), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2933) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2935), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2935) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2938), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2936) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2939), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2939) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2941), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2943) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2945), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2945) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2947), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2951), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2951) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2953), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2955), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2954) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2957), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2957) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2959), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2958) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2961), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2962), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2962) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2964), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2963) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2965), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2965) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2967), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2969), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2968) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2970), new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2970) });

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 147, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8454));

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(8343));

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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 25, 833, DateTimeKind.Utc).AddTicks(5756), "$2a$12$zADlrQ7HKrXWXhF4MF/k0e0/0fnzgj2n78cpDufLny.0C.pW0nxky" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 67, DateTimeKind.Utc).AddTicks(3026), "$2a$12$0RX7QpfGFNwma6D2SVlMduGjLtmhBADZ/rg2nhPp1kJpwWzPWDOVC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 301, DateTimeKind.Utc).AddTicks(4785), "$2a$12$UBUmmvGBsSF9m0.c7Gf12uYiGN6bgQDAZrZ.JJ8NAAt.P9kC0DYZW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 533, DateTimeKind.Utc).AddTicks(4246), "$2a$12$gzhaVg/uMlsQqIk7sIfeR.I3TZYI1K2sPsYnKUnWGZz3UKw28YCbW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 764, DateTimeKind.Utc).AddTicks(1317), "$2a$12$tNFCTLk/nOz/dHnYlXAgB.yX6eCZr2dkH0GNEfoNNT/nLPf/IiO7m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 26, 994, DateTimeKind.Utc).AddTicks(4641), "$2a$12$DRcturW03PBCk8zjxd4XbuLP3z7SHu/xpCNCUMeMjaR9psDVDCOE2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 225, DateTimeKind.Utc).AddTicks(8365), "$2a$12$1njT3zmXi8LH1TF835wC7ez/jTRH5YuEf/2yW/SCJ1qPuQb2ZPTtS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 455, DateTimeKind.Utc).AddTicks(8246), "$2a$12$zCbsfP5TsEThXJaxD.PQ0OvUd3uZncfDMgd3Lb3OQXA5HxwUKpz/O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 686, DateTimeKind.Utc).AddTicks(2585), "$2a$12$WTnZ6IBwPODxqon2Rp9es.04geeu/J2sk9Lx96TYzrfWqUpPIKg.G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 27, 916, DateTimeKind.Utc).AddTicks(4882), "$2a$12$4IeP.n.jLhKCxHmVACCAT.19ok0/IQp24eCZTTdtwRwONIZl9S6tC" });

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
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9076), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9079), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9081), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9083), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Local).AddTicks(9088), new DateTime(2025, 3, 15, 10, 11, 28, 146, DateTimeKind.Utc).AddTicks(9087) });
        }
    }
}
