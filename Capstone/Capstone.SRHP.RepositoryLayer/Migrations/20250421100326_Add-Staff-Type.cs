using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "StaffType",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreparationStaffId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(835), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(837) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(840), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(842), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(843), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(573), new DateTime(2025, 3, 22, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(579) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(589), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(590), new DateTime(2025, 3, 22, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(592), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(594), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(594) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(595), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(596) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(597), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(598), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(599) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(600), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(601), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(602) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(602), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(603) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(604), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(604) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(605), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(606) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(607), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(607) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(608), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(614) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(704), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(708), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(709), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(711), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(712), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(713), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(715), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(715) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(716), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(717) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(717), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(719), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(720), new DateTime(2025, 4, 18, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(721) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 22, 182, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 22, 182, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 22, 182, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 22, 182, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(992), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(996), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(999), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1002), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1005), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1007), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1010), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 182, DateTimeKind.Utc).AddTicks(3625), "$2a$12$g3TJ8wWxR4MafLd2Vb9SUe.lu.YQqDB5gZ6pK1RCcD5VN3o82kNbq", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 416, DateTimeKind.Utc).AddTicks(1545), "Nguyễn Văn Quân", "$2a$12$i.I6r1PVMcC/M3c3QSKs1.OfisixyLawtk/bWXDMdB1oj/CZ0pbkW", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 647, DateTimeKind.Utc).AddTicks(4629), "Trần Thị Thu", "$2a$12$vRXORkxRv8RVA79KKsP0xOEHbuFBmQJAFJMP8taeGN5OYCoHAJukC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 880, DateTimeKind.Utc).AddTicks(224), "Lê Minh Hoàng", "$2a$12$2bz/90u0YOZS3uxYOv6HIeOfGh4voPtZmAnlsldL5Dsgq4FOpHacG", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 111, DateTimeKind.Utc).AddTicks(978), "Phạm Thị Hằng", "$2a$12$nGHS6oCrNDC32LfBvXgPb.IA6AJPOgr3BHWVLzgfnYnjAck6rF/py", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 339, DateTimeKind.Utc).AddTicks(5825), "Ngô Văn Cường", "$2a$12$vlr6qO.9pD37BzeK3FBer.AJFeo.k5IBbxXgRn3OxU8cknA1izmAW", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 571, DateTimeKind.Utc).AddTicks(668), "Đinh Thị Hà", "$2a$12$Jejk1E.tNHqFc0GODaiiYuPLWENvYhWIgu/mWS.YsDdDq9PoE9krC", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 727, DateTimeKind.Utc).AddTicks(3653), "Đặng Văn Nam", "$2a$12$ry6ERTYZq.8/OMg9slG/ZOodTHPe6dbMlFv27ANPiqtA6eNsC8qmC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 958, DateTimeKind.Utc).AddTicks(291), "Lý Thị Ngọc", "$2a$12$CZ/mZgkj8cxOSIQWwHK.5uQQG0CwmtvtbLXv5P1/XHyYT23AYQM1u", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name", "Password", "StaffType" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 188, DateTimeKind.Utc).AddTicks(1941), "Phan Minh Đức", "$2a$12$A5pcipSyQzXuo8MYhnPNjOf1EwkUDWjFSfpV53dse6QqODBKh/ORm", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "LoyatyPoint", "Name", "Note", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleId", "StaffType", "UpdatedAt", "WorkDays" },
                values: new object[,]
                {
                    { 18, null, new DateTime(2025, 4, 21, 17, 3, 23, 802, DateTimeKind.Utc).AddTicks(8491), "Staff5@gmail.com", null, false, null, "Võ Anh Dũng", null, "$2a$12$.M56CrzcFyEEz7uFKvVkJOrQYLQKzm/80mzOk1L3E3mXqc.hZDh16", "0901234567", null, null, 3, 1, null, null },
                    { 19, null, new DateTime(2025, 4, 21, 17, 3, 24, 34, DateTimeKind.Utc).AddTicks(182), "Staff6@gmail.com", null, false, null, "Nguyễn Thị Mai", null, "$2a$12$J2XUpFpl0tuDhL2edJa76u3YgHuyex5hIRIzLhQn.U/KdchpUMoO2", "0907654321", null, null, 3, 1, null, null },
                    { 20, null, new DateTime(2025, 4, 21, 17, 3, 24, 265, DateTimeKind.Utc).AddTicks(4682), "Staff7@gmail.com", null, false, null, "Bùi Văn Hậu", null, "$2a$12$WLLsuwnUBFTRHQvXQ.fBP.VbBBptP1fw.FEcy.oqvnQwo7.z5g7cm", "0912345678", null, null, 3, 2, null, null },
                    { 21, null, new DateTime(2025, 4, 21, 17, 3, 24, 497, DateTimeKind.Utc).AddTicks(3090), "Staff8@gmail.com", null, false, null, "Trương Thị Lan", null, "$2a$12$/FCj9fBL8NRIJbOZcqMSxuqF8IklTD8KuuhwvH7y/BeReTbgQuDui", "0918765432", null, null, 3, 2, null, null }
                });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6676), new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6835), new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6838), new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6841), new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6841) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6843), new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1071), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1075), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1077), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1080), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1082), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1084), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1086), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1087) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1089), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1089) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1091), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1095), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(1095) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PreparationStaffId",
                table: "Orders",
                column: "PreparationStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_PreparationStaffId",
                table: "Orders",
                column: "PreparationStaffId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_PreparationStaffId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PreparationStaffId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "StaffType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PreparationStaffId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7479), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7482) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7519), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7521), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7521) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7522), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7375), new DateTime(2025, 3, 18, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7388), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7390), new DateTime(2025, 3, 18, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7391), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7393), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7394), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7395) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7396), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7396) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7397), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7399), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7399) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7400), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7401), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7403), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7403) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7404), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7406), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7406) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7407), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7414), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7416), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7416) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7417), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7418), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7420), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7421), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7423), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7424), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7425), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7426) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7427), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7428), new DateTime(2025, 4, 14, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 54, 519, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 54, 519, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 54, 519, DateTimeKind.Utc).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 54, 519, DateTimeKind.Utc).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7598), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7599) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7602), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7605), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7608), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7610), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7611) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7613), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7613) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7615), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 54, 519, DateTimeKind.Utc).AddTicks(3254), "$2a$12$9whtWBlw4.VRixItqUOT3O5Gino9LhMEEQYY5C2cd9lG6LTppC3la" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 54, 754, DateTimeKind.Utc).AddTicks(2751), "Manager 1", "$2a$12$Hkiw1JaGjx0YWD5FJtbybO/cyS8R7PMXpvu8JR0EYqAVy1DODtUm6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 54, 990, DateTimeKind.Utc).AddTicks(3776), "Manager 2", "$2a$12$opzPJ1YU0XOCLkiGUoScZOVeCOej6/3kO8oqb459pVB9ITf19OZGC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 223, DateTimeKind.Utc).AddTicks(1911), "Staff 1", "$2a$12$qxXISfrip57lMTwxiJMARuRCCpy8cgfE4sI1C3tBRY7zTLeLgPJAi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 454, DateTimeKind.Utc).AddTicks(4871), "Staff 2", "$2a$12$gKuNYLJWnfKzaX9POmGh0eD/LlvKqWr8g494fez3VmezM9p4rawBm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 687, DateTimeKind.Utc).AddTicks(239), "Staff 3", "$2a$12$boewuG0W3/wucYj.QNIxROZrYAk7H7qzgz7Tqoe7/ruJOqTF6qa6a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 919, DateTimeKind.Utc).AddTicks(1802), "Staff 4", "$2a$12$ggyIxxP5cKoZ.eKlbSDSDeqwPG0UgyLm0COLVw4LuGDOY7m87k8Nm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 152, DateTimeKind.Utc).AddTicks(5455), "Customer 1", "$2a$12$x5GmXT85IwgmcEdqmXWbS.Ldt8xFNGl6xIfN0t16aUzMphnCuwQH6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 385, DateTimeKind.Utc).AddTicks(3794), "Customer 2", "$2a$12$dM7a4Jlv8tda9v1sIwQe3.ILvDttTfv7J/zzgGQxf1teL5uKfPvTK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 617, DateTimeKind.Utc).AddTicks(9969), "Customer 3", "$2a$12$lduMKUSw1vdoRA.Wf9C7S.w2xEGow0PmX3z.iK/kYnBdUaaBEFF9e" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7131), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7143), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7145), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7147), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7149), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7675), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7679), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7679) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7681), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7682) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7684), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7684) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7686), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7686) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7688), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7690), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7693), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7693) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7695), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7697), new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7698) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
