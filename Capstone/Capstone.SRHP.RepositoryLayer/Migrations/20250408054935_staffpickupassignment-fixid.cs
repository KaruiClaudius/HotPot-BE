using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class staffpickupassignmentfixid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffPickupAssignments_RentOrderDetails_RentOrderDetailId",
                table: "StaffPickupAssignments");

            migrationBuilder.RenameColumn(
                name: "RentOrderDetailId",
                table: "StaffPickupAssignments",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffPickupAssignments_RentOrderDetailId",
                table: "StaffPickupAssignments",
                newName: "IX_StaffPickupAssignments_OrderId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StaffPickupAssignments_RentOrders_OrderId",
                table: "StaffPickupAssignments",
                column: "OrderId",
                principalTable: "RentOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffPickupAssignments_RentOrders_OrderId",
                table: "StaffPickupAssignments");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "StaffPickupAssignments",
                newName: "RentOrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffPickupAssignments_OrderId",
                table: "StaffPickupAssignments",
                newName: "IX_StaffPickupAssignments_RentOrderDetailId");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2541), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2544) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2546), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2548), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2549) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2550), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2432), new DateTime(2025, 3, 8, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2451), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2452), new DateTime(2025, 3, 8, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2454), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2456), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2457) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2458), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2459) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2460), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2461), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2462) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2463), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2465), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2466), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2467) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2468), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2470), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2471), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2473), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2482) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2483), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2484) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2485), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2486), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2488), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2489) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2489), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2491), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2492), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2493) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2494), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2494) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2495), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2497), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2498), new DateTime(2025, 4, 4, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2625), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2630), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2633), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2635), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2636) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2638), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2641), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2643), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 157, DateTimeKind.Utc).AddTicks(5877), "$2a$12$K5ZHLcVYhDBrEfK3Nm9b6O.Sr/fBm5sHdc/PVbXkouMBt7z19mX2a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 384, DateTimeKind.Utc).AddTicks(6709), "$2a$12$pOe3FmoOWFquEbs6FBeGQOsUTwMhrBjx772DdJ2IMx2uC8jtHBS.m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 615, DateTimeKind.Utc).AddTicks(8189), "$2a$12$3dMsijUpUXmg46yS/3zLueXuhJ.8DrVrXCdwzL2dizugTw0FNfJma" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 50, 842, DateTimeKind.Utc).AddTicks(4638), "$2a$12$UPZleLY5eUkURZjgNQTIeuQ06lIyVLuoFdVyAY1BDpjtp..weljwq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 69, DateTimeKind.Utc).AddTicks(7134), "$2a$12$quNmzghqgVxbXBRCIvO94.gvaFNHHKvHmlFkGIQspbpjrwpOuZBGy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 297, DateTimeKind.Utc).AddTicks(806), "$2a$12$Kme5FUV5Pw4xEhegigeZ9OvJAqmHhsR9qbiS4wWdgzpVs/wibrHC6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 524, DateTimeKind.Utc).AddTicks(6178), "$2a$12$yMu3c9Vh3G/gc40cEt8wduTXeKUH/3ZJdXiiunhskh5fcWAvRytc6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 751, DateTimeKind.Utc).AddTicks(1997), "$2a$12$gOknzdzLqfFMrz4mjKEYCea/22NRTFR11OWgSHMrayiG1QScWhGq." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 51, 977, DateTimeKind.Utc).AddTicks(8014), "$2a$12$XElTjIfS2.g37e.GCI2fqeg/h5GPCuH/GQpastcvmRq8M3Dwc6.H6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 204, DateTimeKind.Utc).AddTicks(4922), "$2a$12$dmmdR5hmENyuV3mR/bOnQea18SoUJY.wtFgl9ty4yX/7n9gnvVnAi" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2235), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2244), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2244) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2246), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2246) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2248), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2249), new DateTime(2025, 4, 7, 11, 34, 52, 431, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.AddForeignKey(
                name: "FK_StaffPickupAssignments_RentOrderDetails_RentOrderDetailId",
                table: "StaffPickupAssignments",
                column: "RentOrderDetailId",
                principalTable: "RentOrderDetails",
                principalColumn: "RentOrderDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
