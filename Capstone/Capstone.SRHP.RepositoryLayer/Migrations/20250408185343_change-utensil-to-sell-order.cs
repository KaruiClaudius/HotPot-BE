using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class changeutensiltosellorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentOrderDetails_Utensils_UtensilId",
                table: "RentOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_RentOrderDetails_UtensilId",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "UtensilId",
                table: "RentOrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "UtensilId",
                table: "SellOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6860), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6866), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6867), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6868) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6869), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6720), new DateTime(2025, 3, 10, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6732), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6732) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6733), new DateTime(2025, 3, 10, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6734) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6735), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6736), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6737) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6738), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6739), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6741), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6742) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6743), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6745), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6747), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6748), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6750), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6751), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6753), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6759) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6760), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6761), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6762) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6763), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6765), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6767), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6767) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6768), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6769) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6770), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6773), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6773) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6775), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6776), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6777) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6778), new DateTime(2025, 4, 6, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 39, 831, DateTimeKind.Utc).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 39, 831, DateTimeKind.Utc).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 39, 831, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 39, 831, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6962), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6967), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6967) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6969), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6972), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6973) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6975), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6976) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6978), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6978) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6981), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 39, 831, DateTimeKind.Utc).AddTicks(8232), "$2a$12$sJjH1GcEWuiVkaw1qvI/EepN/s5y.6qdSIIb9YluMiEC1y4s1aLaS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 40, 71, DateTimeKind.Utc).AddTicks(7108), "$2a$12$vc55LHiONM7vHjwxYDpP3.d8DuoCrZydXwPKhMyCzic10V48zFSjy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 40, 311, DateTimeKind.Utc).AddTicks(668), "$2a$12$jsoAC0RhWzZ0rlUY0dH52.zzA1nPUSVuvPOb3aT/HNC/ZoRJGHLre" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 40, 552, DateTimeKind.Utc).AddTicks(8101), "$2a$12$yrhWLPePijpn3EBqe7E3BuLAKfO3r6nCr/UfYgVxZuQA5rc2Ilq12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 40, 778, DateTimeKind.Utc).AddTicks(9977), "$2a$12$L3Jo8LPsqqTw4cfg9bmWZ.MScFP231yK1B8lxawnqYSA6H.xvS6pi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 41, 4, DateTimeKind.Utc).AddTicks(9130), "$2a$12$5Lt8yan6ORRHyGRs/rTDR.LzpyZqEDsMBN6pMQRHXbF.sfJkOS/Uu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 41, 230, DateTimeKind.Utc).AddTicks(6762), "$2a$12$E5j65GfYn8dFlXqRxxq2Pe3zjB37FZYwiV5snZ82yBLBaJ1TiUbZy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 41, 456, DateTimeKind.Utc).AddTicks(6155), "$2a$12$iGusWi7WlgBcNj00VRl6b.APWG7LU9VaEmt.U7TIufl6MiFZJcKua" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 41, 683, DateTimeKind.Utc).AddTicks(7401), "$2a$12$HM3/XgtschzVjUYMcbdre.lo7WQ6scQbWY869X5piV0D7eX6wsJoS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 41, 910, DateTimeKind.Utc).AddTicks(2207), "$2a$12$4Xao4bovvHCiNSBRsxs4FOlu2lwBuWp88z.auGAcA68z6lk5KGa6K" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6391), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6397), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6398) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6400), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6402), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6402) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6404), new DateTime(2025, 4, 9, 1, 53, 42, 135, DateTimeKind.Utc).AddTicks(6404) });

            migrationBuilder.CreateIndex(
                name: "IX_SellOrderDetails_UtensilId",
                table: "SellOrderDetails",
                column: "UtensilId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellOrderDetails_Utensils_UtensilId",
                table: "SellOrderDetails",
                column: "UtensilId",
                principalTable: "Utensils",
                principalColumn: "UtensilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellOrderDetails_Utensils_UtensilId",
                table: "SellOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellOrderDetails_UtensilId",
                table: "SellOrderDetails");

            migrationBuilder.DropColumn(
                name: "UtensilId",
                table: "SellOrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "UtensilId",
                table: "RentOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8045), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8051), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8053), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8054) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8055), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8056) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7883), new DateTime(2025, 3, 9, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7888) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7899), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7901), new DateTime(2025, 3, 9, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7902) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7902), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7904), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7904) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7905), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7906) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7907), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7907) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7908), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7909), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7912), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7914), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7915) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7916), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7917), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7918) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7918), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7920), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7929), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7930), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7932), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7993), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7993) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7994), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7995) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7996), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7996) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7998), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8000), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8001), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8003), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8004), new DateTime(2025, 4, 5, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8005) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 32, 235, DateTimeKind.Utc).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 32, 235, DateTimeKind.Utc).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 32, 235, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 32, 235, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8136), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8142), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8145), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8145) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8147), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8150), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8153), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8155), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 32, 235, DateTimeKind.Utc).AddTicks(8118), "$2a$12$TXyxSRCnRNxY/REMML1A3.gAHanLcs/6cHjGezos.yG.KtuodcS3a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 32, 466, DateTimeKind.Utc).AddTicks(5615), "$2a$12$jSge5RBsJKJLEucqD8PxF.Bl5k0MAPDUaUfqRi7nwpNt863EdEluG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 32, 704, DateTimeKind.Utc).AddTicks(2604), "$2a$12$btmnnILbRvlNLgXjb/Apb.R.eHZF2vIE0VvWCGm58Tq92mGlngtUS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 32, 938, DateTimeKind.Utc).AddTicks(3257), "$2a$12$UDiGr/om75OJY2JEzczW4ONtV.vipzVDUpuSbgPo0txU0YTPRIyq6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 33, 178, DateTimeKind.Utc).AddTicks(2694), "$2a$12$jqwjb3adE72Cp46WQY6Jl.W2teiqNLjnkXg5BnO/4ZJdD71T3lZgq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 33, 412, DateTimeKind.Utc).AddTicks(2205), "$2a$12$bN.q6USHXqlLaqTODx3pbeyscvhMAn8rMGqEL7q97WdGuePZ.Okua" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 33, 641, DateTimeKind.Utc).AddTicks(2177), "$2a$12$YnoK/EMgj7Lp/qBLoopWQeHHhPUEDGBBEpyxIEHxVDOjdYMNlG1IS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 33, 871, DateTimeKind.Utc).AddTicks(9026), "$2a$12$wn2gXWWLNZHYc2Dx.xDqdOq14X0dc2B.Z.MA6Rfw7wTmU8gxsokUm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 103, DateTimeKind.Utc).AddTicks(2553), "$2a$12$UjQo0Zl5BaJFYttvIpNhV.fW7Q3RrqEheVZ7orJ38kH/buCz/B33G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 334, DateTimeKind.Utc).AddTicks(8609), "$2a$12$VkqnUS.kcsGSchqVHBPyt.cV1hUTSYSvooH36U2RE8bXCUPP7Xq3i" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7531), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7539), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7539) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7717), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7720), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7721), new DateTime(2025, 4, 8, 12, 49, 34, 563, DateTimeKind.Utc).AddTicks(7722) });

            migrationBuilder.CreateIndex(
                name: "IX_RentOrderDetails_UtensilId",
                table: "RentOrderDetails",
                column: "UtensilId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrderDetails_Utensils_UtensilId",
                table: "RentOrderDetails",
                column: "UtensilId",
                principalTable: "Utensils",
                principalColumn: "UtensilId");
        }
    }
}
