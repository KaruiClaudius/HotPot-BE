using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixingredientquantityncomboncustomize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxQuantity",
                table: "ComboAllowedIngredientTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Ingredients",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinStockLevel",
                table: "Ingredients",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "Ingredients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "CustomizationIngredients",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "CustomizationIngredients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ComboIngredients",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "ComboIngredients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "ComboAllowedIngredientTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MinQuantity",
                table: "ComboAllowedIngredientTypes",
                type: "decimal(18,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 2, 12, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3428), new DateTime(2025, 2, 12, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3418), 0.13m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3431), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3430), 0.14m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 2, 12, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3433), new DateTime(2025, 2, 12, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3432), 0.15m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3435), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3434), 0.16m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3436), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3436), 0.12m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3438), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3438), 0.17m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3440), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3439), 0.10m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3443), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3442), 0.15m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3444), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3444), 0.06m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3446), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3446), 0.05m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3448), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3447), 0.04m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3450), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3449), 0.07m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3451), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3451), 0.06m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3453), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3453), 0.065m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3459), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3459), 0.05m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3461), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3460), 0.055m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3463), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3462), 0.08m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3464), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3464), 0.07m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3466), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3465), 0.009m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3468), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3467), 0.008m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3469), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3469), 0.0085m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3471), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3471), 0.0075m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3473), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3472), 0.005m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3535), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3534), 0.004m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3537), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3536), 0.0045m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3539), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3538), 0.006m });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3304), 7, "g", 20m, 100m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3306), 7, "g", 15m, 80m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3308), 7, "g", 15m, 75m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3311), "g", 20m, 90m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3313), "g", 30m, 120m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3315), "g", 15m, 60m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3318), "g", 25m, 100m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3320), "g", 20m, 80m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3322), "g", 15m, 70m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3324), "g", 20m, 80m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3326), "g", 20m, 85m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3328), "g", 25m, 90m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3330), "g", 15m, 60m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3332), "g", 15m, 65m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3341), "g", 15m, 70m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3343), "g", 15m, 65m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3346), 1, "ml", 10m, 50m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3348), 1, "ml", 10m, 45m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3350), 1, "ml", 10m, 40m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3352), 1, "ml", 10m, 55m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3353), "ml", 10m, 40m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3357), "ml", 10m, 45m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3359), "ml", 10m, 50m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(3361), "ml", 10m, 35m });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 33, 774, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 33, 774, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 33, 774, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 33, 774, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 33, 774, DateTimeKind.Utc).AddTicks(6839), "$2a$12$76HNlBF2nFohr6TNAtJOvOFqsiP.oy7CEVav3stlflHd5bzgP1YpG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 34, 12, DateTimeKind.Utc).AddTicks(938), "$2a$12$oKKPQfD45YCwZls5QIsJ0OCR2e9PlIgnWiz4bR0FQaetW2P1bjv8C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 34, 251, DateTimeKind.Utc).AddTicks(3473), "$2a$12$Gg14cp7Tb3YKE..UwBZH.umzFlufjUb/gJO5LzNvCkXT3mKcda5Cm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 34, 483, DateTimeKind.Utc).AddTicks(9412), "$2a$12$fYdz2Cn.NcCKrN54wJ052e4Fjs7tJdm0FtNorVOf15Prix0EL5BDO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 34, 722, DateTimeKind.Utc).AddTicks(3554), "$2a$12$8PqSNhhcdVIPs6zSKTJyG.IOyQBnaZGMn9NySiB29CK/8SyCVrXxS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 34, 954, DateTimeKind.Utc).AddTicks(9397), "$2a$12$ujD/J.bp8j5pQ.etxKxgROkqjI2/MWrxTOAqO3GOCZJpCKtsVsYnW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 35, 185, DateTimeKind.Utc).AddTicks(9712), "$2a$12$ITq2tvuVJlwD9/F6AQKuau0CnMYNyQ9DkuQliogJPF.vd7Je8CTKu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 35, 415, DateTimeKind.Utc).AddTicks(8283), "$2a$12$0E2N.7CDV9R9x5ljw2Ep.u6gC90Gw/no7KGTowArFDJQWSMzToop." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 35, 644, DateTimeKind.Utc).AddTicks(7644), "$2a$12$2WR1sOs4j9nNNkEpVGJPf.cgHdWSi6YdxCpoJs3RGH7vbczBPvya." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 35, 875, DateTimeKind.Utc).AddTicks(900), "$2a$12$pNohBYUgs7ZlCMInc7AvIuo7zJBKpjuaYGrm9prPB7Rdu6xY9/ZSu" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 14, 12, 40, 36, 103, DateTimeKind.Local).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(2910), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(2917), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Utc).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(2920), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Utc).AddTicks(2919) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(2923), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Local).AddTicks(2925), new DateTime(2025, 3, 14, 12, 40, 36, 104, DateTimeKind.Utc).AddTicks(2924) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "CustomizationIngredients");

            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "ComboIngredients");

            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "ComboAllowedIngredientTypes");

            migrationBuilder.DropColumn(
                name: "MinQuantity",
                table: "ComboAllowedIngredientTypes");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<int>(
                name: "MinStockLevel",
                table: "Ingredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "CustomizationIngredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ComboIngredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AddColumn<int>(
                name: "MaxQuantity",
                table: "ComboAllowedIngredientTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3507), new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3497), 12.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3510), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3509), 13.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3512), new DateTime(2025, 2, 12, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3511), 14.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3514), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3514), 15.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3516), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3516), 11.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3519), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3518), 16.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3521), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3520), 9.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3523), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3522), 14.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3529), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3528), 5.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3531), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3530), 4.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3533), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3532), 3.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3535), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3535), 6.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3539), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3537), 5.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3541), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3540), 6.49m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3556), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3555), 4.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3559), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3559), 5.49m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3562), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3561), 7.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3564), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3563), 6.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3566), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3565), 8.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3568), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3568), 7.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3571), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3570), 8.49m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3573), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3573), 7.49m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3575), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3575), 4.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3577), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3577), 3.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3579), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3579), 4.49m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3582), new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3581), 5.99m });

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
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3401), 1, 20, 100 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3404), 1, 15, 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3406), 1, 15, 75 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3408), 20, 90 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3410), 30, 120 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3412), 15, 60 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3414), 25, 100 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3416), 20, 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3418), 15, 70 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3420), 20, 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3424), 20, 85 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3426), 25, 90 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3427), 15, 60 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3429), 15, 65 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3431), 15, 70 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3433), 15, 65 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3435), 7, 10, 50 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3437), 7, 10, 45 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3439), 7, 10, 40 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IngredientTypeID", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3440), 7, 10, 55 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3442), 10, 40 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3444), 10, 45 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3446), 10, 50 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 42, 49, 373, DateTimeKind.Local).AddTicks(3448), 10, 35 });

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
    }
}
