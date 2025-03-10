using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Feedback",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Feedback",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8018), new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8011) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8021), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8021) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8024), new DateTime(2025, 2, 6, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8026), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8025) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8028), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8030), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8032), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8034), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8036), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8038), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8040), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8039) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8042), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8044), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8046), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8052), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8054), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8056), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8058), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8060), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8062), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8064), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8066), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8065) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8068), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8070), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8110), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8109) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8112), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(8111) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 289, DateTimeKind.Utc).AddTicks(1154), "$2a$12$4pljidGfnlQ8tjIWmtcJA.tjSWW6B3eIGQ5Zre4dKexrEPeGGcTaW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 41, DateTimeKind.Utc).AddTicks(8830), "$2a$12$mBe7cen4iaSiq5ryZIXIIeho8otKrGd2wYPcxsvHWXA4ViVK.Sn06" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 795, DateTimeKind.Utc).AddTicks(1092), "$2a$12$tCyDeHEwP9GZ5EsD4WCX1uj9elCqZNTQ8/z4AhEc7QKQJB1Xd.MFe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 543, DateTimeKind.Utc).AddTicks(7801), "$2a$12$m7iNE6VNTQOU5.VsYCaK/.V4doemI9qf5sLUoJ6/oLHLWTIIVbyje" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 293, DateTimeKind.Utc).AddTicks(1078), "$2a$12$g5ik/V5u4qLa3Lq3knKl2e2iuDXrn5Wr1MTRknrahTkxUlZV3TqSm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 51, 47, DateTimeKind.Utc).AddTicks(4697), "$2a$12$lVvgHSsVq99MJixkds7.YO6aJ5qACZa6GG2Lkj.lN1CTZMW2n2u2y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 800, DateTimeKind.Utc).AddTicks(4822), "$2a$12$0ISDLUITz09N2xBt2OvUYOuMSH6sqY03wzdzbdRbgWw9FGprioyZG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 553, DateTimeKind.Utc).AddTicks(2898), "$2a$12$DkNCtdgxtOv80NdRotDpsOhCkW3lxRXAgFAqdaAkn09GyUnThxGdO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 300, DateTimeKind.Utc).AddTicks(5124), "$2a$12$nIcCdPSknyEOOHe7N84fre6NH8Cv7o0au4FGunC2YRVw0vSpJEcF2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 50, 49, DateTimeKind.Utc).AddTicks(8554), "$2a$12$OdtilG30AypcBV0f7U7TVepjytEsdk7/kfuc5IX/2T/r0DcgGjKhG" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7602), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7605), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7603) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7609), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7607) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7616), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Local).AddTicks(7618), new DateTime(2025, 3, 8, 19, 48, 52, 538, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApprovedByUserId",
                table: "Feedback",
                column: "ApprovedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Users_ApprovedByUserId",
                table: "Feedback",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Users_ApprovedByUserId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ApprovedByUserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Feedback");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 5, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9365), new DateTime(2025, 2, 5, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9368), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 5, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9371), new DateTime(2025, 2, 5, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9373), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9376), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9375) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9378), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9377) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9380), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9383), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9385), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9387), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9390), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9393), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9393) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9395), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9395) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9398), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9409), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9408) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9411), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9413), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9415), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9415) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9418), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9420), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9419) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9422), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9425), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9424) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9427), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9429), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9429) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9431), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9431) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9435), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 47, 444, DateTimeKind.Utc).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 47, 444, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 47, 444, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 47, 444, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 49, 736, DateTimeKind.Utc).AddTicks(9578), "$2a$12$JGYHZ7B9dbdkB7rCwp6XqenhOIMSD9U0j.o3jzliyxQwOTEyyMRTC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 49, 483, DateTimeKind.Utc).AddTicks(4266), "$2a$12$A5TMVc/H2zjzZiuqkjjev.f5gGNCpOrnYpsemQhfAJ0.TJWdJYA8G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 49, 232, DateTimeKind.Utc).AddTicks(6923), "$2a$12$4cOlbYIP0owlrGjdq5JrJe8AjPKKfwVh2q5hCV.A1oKyt7G8vUlT2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 48, 986, DateTimeKind.Utc).AddTicks(3029), "$2a$12$EXNwm46b9/3G23FFqjoFJO5GWt/iTB1Iea5kPVHHaw8YBhdlZAnMi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 48, 735, DateTimeKind.Utc).AddTicks(9934), "$2a$12$/SPYja92Q/IGtxXiCiHdLODsKLBgxJPlHE3wKsjwedqHIr42PS2BC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 48, 485, DateTimeKind.Utc).AddTicks(9523), "$2a$12$6RRYhXlHiVE38b1Itn.XVeHtl.relsX5KRpIs5K3btuZ1CtM1Bnsy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 48, 231, DateTimeKind.Utc).AddTicks(3523), "$2a$12$2qWCT3kUbiCtLm7ePBeIrO4pJ7HTdBru9cnyMzr2rYFgpmBz1V3IO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 47, 978, DateTimeKind.Utc).AddTicks(8934), "$2a$12$NQJFr4mSDH2SkA5yM3lgcOkPvDjB1gfsJejQuaVnmeDqDRzvscqZW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 47, 697, DateTimeKind.Utc).AddTicks(5017), "$2a$12$ZIhfAQiGUUsVEWJgibGghuqAAZ0vsmUSbpqB45GNzRWIwhqZ/r52u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 47, 444, DateTimeKind.Utc).AddTicks(1076), "$2a$12$e57sxtY8OcLwEnqdSbFICePRGa5g6VWyxNvnuuOieImQA0XUpo2A6" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8874), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(8868) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8878), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8881), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(8879) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8884), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(8882) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8886), new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Utc).AddTicks(8885) });
        }
    }
}
