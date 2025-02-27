using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 1, 28, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7360), new DateTime(2025, 1, 28, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7321) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7362), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 1, 28, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7364), new DateTime(2025, 1, 28, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7366), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7368), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7370), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7372), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7371) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7375), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7377), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7378), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7380), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7382), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7384), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7386), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7387), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7389), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7391), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7393), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7433), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7432) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7444), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7446), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7448), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7448) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7450), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7449) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7452), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7454), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7455), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7455) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6337), false, null, -2 },
                    { 2, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6341), false, null, -3 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 30, 247, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 30, 247, DateTimeKind.Utc).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 30, 247, DateTimeKind.Utc).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 30, 247, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6273), false, null, -4 },
                    { 2, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6280), false, null, -5 },
                    { 3, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6281), false, null, -6 },
                    { 4, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6282), false, null, -7 }
                });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 31, 643, DateTimeKind.Utc).AddTicks(1082), "Staff4", "$2a$12$MmNvT8zxjDc6YuIxcIh3OOxtmm8HAweXw1d9MAFFiy7bKaCvq/fQm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 31, 413, DateTimeKind.Utc).AddTicks(5418), "Staff3", "$2a$12$TaTG8RpDsVuUutGCmxLVYeyWv7hPH8YCAe2M7tQdhEiNqdHXcUqDy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 31, 183, DateTimeKind.Utc).AddTicks(7386), "Staff2", "$2a$12$dRT3KW0bJsJJGJdzxRuXn.DVsApbW48qPMpq6ME.RcGAdDZOSlBO6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 30, 949, DateTimeKind.Utc).AddTicks(8832), "Staff1", "$2a$12$XXG.GWK9Myx7Fjp0IiclL.pRoJHZ1G9MV1UZ/bsCptb1WFJpGW3c6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 30, 719, DateTimeKind.Utc).AddTicks(3582), "Manager2", "$2a$12$YlBkdFQ036.drl5qL92ycOJyW9AcqWBOGd215Qyp3v.q6gsngtVFy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 30, 484, DateTimeKind.Utc).AddTicks(8180), "Manager1", "$2a$12$ZTqPUTRT4SIhNluSnqhDIuk/SEIkYbia54AO9.8wdcXIxseW4W.02" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 30, 247, DateTimeKind.Utc).AddTicks(1508), "$2a$12$nk4sjPpaI5KiqqJpKmDT5eo8SFXFF3we6Qc/CG1R3NYNgB5RO92Za" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "Name", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleID", "UpdatedAt" },
                values: new object[,]
                {
                    { -10, null, new DateTime(2025, 2, 27, 19, 49, 32, 333, DateTimeKind.Utc).AddTicks(9348), "Customer3@gmail.com", null, false, "Customer3", "$2a$12$Sn7e24yA01kXWdG1YrafzOFmksAx8OpndGi9foqvSlmm3YeUyKZEu", null, null, null, 4, null },
                    { -9, null, new DateTime(2025, 2, 27, 19, 49, 32, 103, DateTimeKind.Utc).AddTicks(6419), "Customer2@gmail.com", null, false, "Customer2", "$2a$12$3Wwe3r3XPmLNSBFdXSxS1eh2ptkFpR8ebp09PSGWByOtrNzT0Vlni", null, null, null, 4, null },
                    { -8, null, new DateTime(2025, 2, 27, 19, 49, 31, 873, DateTimeKind.Utc).AddTicks(2468), "Customer1@gmail.com", null, false, "Customer1", "$2a$12$qa8YUolS1Q5oVjLOx816aOHg5scf/fqvb1ywMlEkr1KUfiprvTiBy", null, null, null, 4, null }
                });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6886), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6889), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6892), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6894), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6893) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Local).AddTicks(6897), new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6896) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6377), false, null, -8 },
                    { 2, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6379), false, null, -9 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "LoyatyPoint", "UpdatedAt", "UserID" },
                values: new object[] { 3, new DateTime(2025, 2, 27, 19, 49, 32, 564, DateTimeKind.Utc).AddTicks(6380), false, 200.0, null, -10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8);

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3192), new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3185) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3195), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3197), new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3196) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3199), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3199) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3201), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3203), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3202) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3205), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3204) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3207), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3209), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3209) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3211), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3211) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3213), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3213) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3215), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3215) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3217), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3216) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3219), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3218) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3221), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3223), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3222) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3225), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3224) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3227), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3229), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3228) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6310), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6304) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6319), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6321), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6323), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6322) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6325), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6324) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6326), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6326) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6328), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 59, DateTimeKind.Utc).AddTicks(2204), "Staff", "$2a$12$VlqIMB3KS90CxLI4IyBjMeDKJOfLClSYKNEMgBq0XvJwO6pSrEXqu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 20, 821, DateTimeKind.Utc).AddTicks(5941), "Staff", "$2a$12$WyuRgSjLsmjMWtEFIx/Lru1orNrjIOIiwdX.XPMrGHMGj/saqo7Ne" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 20, 578, DateTimeKind.Utc).AddTicks(5093), "Staff", "$2a$12$qbv5Dk4gcwHSMvKQbyLyUOrXRVvDk8zJVLLrD4V2Q4vpQl/xrmKM." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 20, 341, DateTimeKind.Utc).AddTicks(3362), "Staff", "$2a$12$L0rDJa.AVYoLEkNfkwaSDO7vRN/5vR8EzisX49tr0He6nFIrgVbR6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 20, 103, DateTimeKind.Utc).AddTicks(2584), "Manager", "$2a$12$u/ZYzR2aK9agCehAKDE4FOEe1.EZ6/tYLz94uIbVYrOPCTDoHvuZm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 19, 863, DateTimeKind.Utc).AddTicks(9298), "Manager", "$2a$12$R9ZAqPARfwmDy4U9ktWL7ujI55quj3Atog6//cpdP0KToKYTng6/q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(4039), "$2a$12$jccEXEJACywdTDZ6qTJvFu/Dj4PSUX2BDLT8d3e7pj1Ix7iMlQV7q" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2758), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2747) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2766), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2768), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2767) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2772), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2774), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2773) });
        }
    }
}
