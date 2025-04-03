using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class nullablecomboidcustomiztion : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "ComboId",
                table: "Customizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8736), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8738) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8741), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8743), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8745), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8745) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8626), new DateTime(2025, 3, 4, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8646), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8647), new DateTime(2025, 3, 4, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8649), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8650), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8652), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8652) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8653), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8655), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8656), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8658), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8659) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8659), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8661), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8662), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8664), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8664) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8666), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8674) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8675), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8677), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8677) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8678), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8680), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8681), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8683), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8684), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8685) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8685), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8687), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8688), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8690), new DateTime(2025, 3, 31, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 34, 507, DateTimeKind.Utc).AddTicks(5919), "$2a$12$fTDsphTIhjiX.XtiujnUVub.Q/EIsCcSbdnV9T.6Em7xIfKu1X5OO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 34, 749, DateTimeKind.Utc).AddTicks(200), "$2a$12$C3zThKELwffvGay05WWs7OvAN9SKHPflvHX59Q/o.hQWogLTpLEVK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 34, 989, DateTimeKind.Utc).AddTicks(255), "$2a$12$9m9OlgsvWv9ZmvccH7.fW.sDvGLoFdlzsuz4sRRo4IYazg.9hxVNa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 234, DateTimeKind.Utc).AddTicks(27), "$2a$12$6ZQDCGKJ9rnMKfHAz76esuMDmXEH30MHR5RNhQI8FLRTxyt2Xlz7i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 470, DateTimeKind.Utc).AddTicks(6629), "$2a$12$UEDRcCZQiAdAmDTcjcrr7.1o591wueODV1/zveHBaPR7B7.X8jwoC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 710, DateTimeKind.Utc).AddTicks(9623), "$2a$12$wEC5ILIcwOcjxBPN9SqiOOOYqDe8TI8B2EkR13eeFMdV0o7ZHMxg2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 35, 942, DateTimeKind.Utc).AddTicks(2405), "$2a$12$D6Qzl0LcKfcNbP.UAKyflOAaIlH10ZcNMVkR0UQ9oZHOjkGVGJFXS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 181, DateTimeKind.Utc).AddTicks(3568), "$2a$12$nrA.88R4wvnoidGEubbIcutS5sJJqrOGO5Bv05mwJMpfQIjCK62O2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 410, DateTimeKind.Utc).AddTicks(6455), "$2a$12$C6D42fHuqVW/3/Tk0wrZ7u.qHY6bl9.tcGO/D822k9oTbOLPd2MkS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 646, DateTimeKind.Utc).AddTicks(2937), "$2a$12$0ocQ1zgpzpFs1QSlZ./K4eA9l.6KF6IWtbKZT8j09rgyaN3FovS9." });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8345), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8352), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8355), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8356), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8358), new DateTime(2025, 4, 3, 19, 24, 36, 882, DateTimeKind.Utc).AddTicks(8358) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Combos_ComboId",
                table: "Customizations");

            migrationBuilder.DropIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations");

            migrationBuilder.AlterColumn<int>(
                name: "ComboId",
                table: "Customizations",
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

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations",
                column: "ComboId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customizations_Combos_ComboId",
                table: "Customizations",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "ComboId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
