using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixcustomizationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8036), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8039), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8041), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8042) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8042), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7930), new DateTime(2025, 3, 2, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7942), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7943) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7944), new DateTime(2025, 3, 2, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7945), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7946) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7947), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7948) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7948), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7949) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7950), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7951) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7952), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7954), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7954) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7955), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7955) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7956), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7958), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7958) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7959), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7961), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7962) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7963), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7973) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7974), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7975), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7976) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7977), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7977) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7979), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7979) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7980), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7982), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7982) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7983), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7984) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7985), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7985) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7986), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7987), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7989), new DateTime(2025, 3, 29, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 24, 139, DateTimeKind.Utc).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 24, 139, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 24, 139, DateTimeKind.Utc).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 24, 139, DateTimeKind.Utc).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 24, 139, DateTimeKind.Utc).AddTicks(6700), "$2a$12$c7GxWYvW7wuHJA63nhFf/.V6Im9W0TLPtzs9mgq4KlZT5SdvRcvum" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 24, 372, DateTimeKind.Utc).AddTicks(9351), "$2a$12$GpXbg4hqBZqkKi2xZuOpyOeHDTx.eqW4mBV.il44VR9tv4FzNH2QW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 24, 605, DateTimeKind.Utc).AddTicks(3368), "$2a$12$BZ0.Lf9RRUAB8SjIqwFTX.UEIEcMWdN31kDxnrfTg20DcztqNw.hm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 24, 835, DateTimeKind.Utc).AddTicks(6725), "$2a$12$E8i9dipNTAxX9vrZzV6GMOoznXdhzM31PA/OPk0JgDswfAvFWwOL2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 25, 63, DateTimeKind.Utc).AddTicks(9134), "$2a$12$Tg0YuEU0tW09HnCI4PzvUOJLLQR9M5HQwdPnUC2dODEBTkKuUdWHK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 25, 290, DateTimeKind.Utc).AddTicks(5640), "$2a$12$g/Czr7B1hgTyEdaLYfe6VuTXG6PH4bW/xat9o.0qmxxlE/nezUcXK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 25, 517, DateTimeKind.Utc).AddTicks(660), "$2a$12$c758TYeui3E7BxYlMHDH5eMxQLjD47Hu5Cdp7e2wDGIRN910wiFka" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 25, 744, DateTimeKind.Utc).AddTicks(1359), "$2a$12$FS7PJ1CKgicIswB4RgsfcePyBiDRCvvAMsJ2qK.oY8h4hLef2xLxa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 25, 972, DateTimeKind.Utc).AddTicks(3086), "$2a$12$NL1QmtmM.wFMWd4kYqERxOosvprinQJ3G.eh1JQMPnitH2HNyeL8e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 198, DateTimeKind.Utc).AddTicks(9901), "$2a$12$dnWShgIHVEuKWVzvS7ZMp.Z1QMHqL4YYGzmRjYbVLqdCGmupebJJi" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7685), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7695), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7697), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7698), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7699) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7700), new DateTime(2025, 4, 1, 5, 9, 26, 425, DateTimeKind.Utc).AddTicks(7700) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1513), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1520), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1521) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1522), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1523), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1403), new DateTime(2025, 2, 25, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1406) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1415), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1417), new DateTime(2025, 2, 25, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1419), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1421), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1423), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1423) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1424), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1426), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1427), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1429), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1431), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1432), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1434), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1435), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1436) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1438), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1447), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1448), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1449) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1450), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1452), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1453), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1454) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1455), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1457), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1459), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1460), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1462), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1464), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6662), "$2a$12$UBSpElKMzPHpvQLpAhZnye6E9RKqG4RUPSH66NJg9Q/v9nyMweMGa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 125, DateTimeKind.Utc).AddTicks(939), "$2a$12$9BWubZ39jKZ0jqoexV1vAuwloU.tn//8xjxavLj15wGcdXcTK/eiO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 351, DateTimeKind.Utc).AddTicks(3085), "$2a$12$6ujiU0ZVpWbQMFF3nrnuL.t1Gl.gLf2E2KhmHh93qE2Zts0yWMrry" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 576, DateTimeKind.Utc).AddTicks(6774), "$2a$12$I1mbuv7cwUvY1kKAPwGCCui2miMLL3psYs9fCeM90vhgcyOyCC5Za" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 807, DateTimeKind.Utc).AddTicks(1123), "$2a$12$O8npWMqiu4W32S2sJvniSu2T4fy9WiQxM9lRDvUwFGLSCUcIp.8Kq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 50, DateTimeKind.Utc).AddTicks(6043), "$2a$12$ETJ6Y4Pth0b1geacUwbgWu0KoqkX3SykszsYHASBKQy0kjnhA.2Ru" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 300, DateTimeKind.Utc).AddTicks(5687), "$2a$12$kGccGkYjaZfHEuSBZTIAAe1VdKXDmO8JM7JJQhF7eB4/iC713Y0Wq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 553, DateTimeKind.Utc).AddTicks(9081), "$2a$12$f426ZAnJHJH5jr9PnNue0eiP/pbSNzuFCDA/YwJfwi6hbQ.X64Zj2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 795, DateTimeKind.Utc).AddTicks(8865), "$2a$12$R69qG9Le0fmj42MLXocomuOc7YVLM.3wLyrwXX6ZUc2Mn14zxBcB." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 32, DateTimeKind.Utc).AddTicks(9928), "$2a$12$PZWqziioMaMRYKp/mbQZR.sjccwSb.kL0Mc2C6Cjme7b4RVte..3K" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1110), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1119), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1119) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1121), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1122) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1123), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1123) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1125), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1125) });
        }
    }
}
