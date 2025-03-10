using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixuserseedphone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7047), new DateTime(2025, 2, 8, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7038) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7050), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7052), new DateTime(2025, 2, 8, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7051) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7054), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7053) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7056), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7058), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7057) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7060), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7062), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7061) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7064), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7066), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7065) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7068), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7067) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7069), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7071), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7071) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7073), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7143), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7145), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7147), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7148), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7150), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7152), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7154), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7229), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7228) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7231), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7231) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7233), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7235), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7234) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7237), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3319));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 44, 943, DateTimeKind.Utc).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 44, 943, DateTimeKind.Utc).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 44, 943, DateTimeKind.Utc).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 44, 943, DateTimeKind.Utc).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 20, DateTimeKind.Utc).AddTicks(1212), "$2a$12$PbpfLqL0lQXpllaaB5WzOuGShtgNua8J70baKgftpIr623BzzInaG", "0111111111" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 46, 790, DateTimeKind.Utc).AddTicks(7231), "$2a$12$ue94dYjwSd0BEsA6GmDUTOjBzhkBzSgiZiR1z5DtZ4mHN9rb1JdNy", "0222222222" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 46, 561, DateTimeKind.Utc).AddTicks(3483), "$2a$12$hEJaYbGerjQmXnmGjkdlJuj1pVA0wXDzoRZ6EJ/z/tEpLOlzKc2hK", "0333333333" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 46, 330, DateTimeKind.Utc).AddTicks(659), "$2a$12$xzVIb6SqJvc.T9xGrrSQt.7/bOB.yAawgCvWlPZh1.pZnkXQhDOn.", "0444444444" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 46, 100, DateTimeKind.Utc).AddTicks(5095), "$2a$12$Pg8J02/.qbgdPo6MEPEnU.N7SBIiVkm.plkRfUaBjLDSc8B5oa1Q2", "0555555555" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 45, 867, DateTimeKind.Utc).AddTicks(8391), "$2a$12$3qNSBoORBcTjZ6o5vmM/IuRE0G7Y.5igbq7Q3pZ2PX2XfrXso72cG", "0666666666" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 45, 638, DateTimeKind.Utc).AddTicks(7954), "$2a$12$nHwI/OboOWdMiW3OjojQfONC6ITSw5LXNVq4HrzbCdOXRt76obRiK", "0777777777" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 45, 410, DateTimeKind.Utc).AddTicks(2095), "$2a$12$Ujuazb/DYihkZuvcYL/ByuzDYZ4RDXuPJNR4WV3IieFOTBYhIHxoe", "0888888888" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 45, 174, DateTimeKind.Utc).AddTicks(6295), "$2a$12$fjqXbt0yI5F2/kxrgRX/RuQY8P20677iC/sAIRNbvqkG9hJ7gVkUe", "0999999999" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 44, 943, DateTimeKind.Utc).AddTicks(966), "$2a$12$TpIGdp6U3qrawyqelRruau/J0gQDNnsz8cJqEYtbxs8G.YAnj/0Lm", "0987654321" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3787), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3783) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3791), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3793), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3792) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3795), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Local).AddTicks(3798), new DateTime(2025, 3, 10, 14, 45, 47, 251, DateTimeKind.Utc).AddTicks(3797) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7234), new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7237), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7239), new DateTime(2025, 2, 8, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7241), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7243), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7244), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7246), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7248), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7250), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7252), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7254), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7256), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7258), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7259), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7266), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7268), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7270), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7272), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7273), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7275), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7277), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7279), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7281), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7283), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7285), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7284) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7286), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7286) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 32, 596, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 688, DateTimeKind.Utc).AddTicks(6524), "$2a$12$oXGqWfAs5/QoGd5ocvXhWuEKjvx9SkpbEhMpiwGC0YNgqZoSOO0na", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 457, DateTimeKind.Utc).AddTicks(904), "$2a$12$yZP07UM4ZgGT.0ebAK2NE.M.S9V0ZrbP82npm/aWyDLjzjtdtMLfS", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 225, DateTimeKind.Utc).AddTicks(1207), "$2a$12$1W5r4YWT2zympc/1whNDFeMp4K1HQF3BUZHGsq18FtM0Df.GSCmjC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 994, DateTimeKind.Utc).AddTicks(5811), "$2a$12$KRctPrMRryu4EApV3PH.l.1yVX61NhGMzfAKMProh4.TmfibCgM4C", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 763, DateTimeKind.Utc).AddTicks(9994), "$2a$12$1gXs6p0m3V0eUggD7xgd/.2IXS8hSM7cFVXaTZ/Iv0YT4AY9c0tDO", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 536, DateTimeKind.Utc).AddTicks(4750), "$2a$12$TpIc2LwXjCZifVihcowoMOH0JOp287p.Reiar7gVUn79pqFZw7Vlq", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 306, DateTimeKind.Utc).AddTicks(1791), "$2a$12$jCdCrqa1KfLOQ.sgtzqIaOy3ij49FYhA6PnGKl0RQBKTku956XNTm", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 33, 73, DateTimeKind.Utc).AddTicks(8882), "$2a$12$WUClYB.kTS9gg98woJVZLuKdgZw42/EmEqgYdezS.z20Va54O4II.", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 32, 839, DateTimeKind.Utc).AddTicks(4035), "$2a$12$c/n2q8iUAiRhUKEI0G/5nes6TsrlPQp6Bcm8iwuBJqBFCTosZ0uJK", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 32, 597, DateTimeKind.Utc).AddTicks(119), "$2a$12$tnSlCx0T6tknUI3gsmqMOOdVYdUz0qYjaSoKU5Ixi5hJnctgH8oDq", null });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6709), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6703) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6712), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6714), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6717), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6716) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Local).AddTicks(6719), new DateTime(2025, 3, 10, 14, 0, 34, 918, DateTimeKind.Utc).AddTicks(6718) });
        }
    }
}
