using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatSessions_SessionChatSessionId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SessionChatSessionId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "SessionChatSessionId",
                table: "ChatMessages");

            migrationBuilder.AddColumn<decimal>(
                name: "HotpotDeposit",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IngredientsDeposit",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "Hotpots",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                columns: new[] { "BasePrice", "CreatedAt", "Price" },
                values: new object[] { 89.99m, new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8763), 29.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "BasePrice", "CreatedAt", "Price" },
                values: new object[] { 129.99m, new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8767), 59.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "BasePrice", "CreatedAt", "Price" },
                values: new object[] { 69.99m, new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8770), 19.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "BasePrice", "CreatedAt", "Price" },
                values: new object[] { 149.99m, new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8773), 69.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "BasePrice", "CreatedAt", "Price" },
                values: new object[] { 79.99m, new DateTime(2025, 3, 7, 19, 6, 50, 18, DateTimeKind.Local).AddTicks(8777), 39.99m });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotpotDeposit",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IngredientsDeposit",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Hotpots");

            migrationBuilder.AddColumn<int>(
                name: "SessionChatSessionId",
                table: "ChatMessages",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(513), 89.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(516), 129.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(518), 59.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(521), 149.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(523), 79.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 4, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(912), new DateTime(2025, 2, 4, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(915), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 4, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(917), new DateTime(2025, 2, 4, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(919), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(921), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(923), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(922) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(925), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(926), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(928), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(930), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(932), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(933), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(936), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(938), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(940), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(941), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(943), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(945), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(947), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(958), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(960), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(962), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(964), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(965), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(967), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(969), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 34, 999, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 34, 999, DateTimeKind.Utc).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 34, 999, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 34, 999, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 885, DateTimeKind.Utc).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 885, DateTimeKind.Utc).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 885, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 885, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 583, DateTimeKind.Utc).AddTicks(3150), "$2a$12$YAsneHTUm.vjoJsgUUlNvO2MjVGWi3fqjMvE6mLMzxMb67RusjdRC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 281, DateTimeKind.Utc).AddTicks(4240), "$2a$12$.ikdZ5pNLTKercfpSfMoBOBnUiMK94Sk3wWkUx5a66v9uSFjbB.RC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 36, 967, DateTimeKind.Utc).AddTicks(6420), "$2a$12$GHwTWBMOKUlrV3IWcN1wnO9xoglRA2uvpR3VPW5itljNnZuZaxGiK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 36, 662, DateTimeKind.Utc).AddTicks(8530), "$2a$12$S1XaUjfuZvkOWDlkBSD0cOyL5v3hCMGwX5FBTuXzPuUWVkdO5vygC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 36, 385, DateTimeKind.Utc).AddTicks(7736), "$2a$12$JPPJYy0n.bhGT5H7UsqpzOJxytnja8IiwJWrVi1vwXb6z.aMM32am" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 36, 126, DateTimeKind.Utc).AddTicks(4666), "$2a$12$p9APIAt9qzkSHpdcKRrDP.ghrUL/ZX4AteZSnVe/JV3CyAwfmEiem" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 35, 847, DateTimeKind.Utc).AddTicks(9780), "$2a$12$q85KLnwfzXRGTa2rsCNGD.nP1dGO7.Xq.3G95UrbK60cRNAYYe33q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 35, 562, DateTimeKind.Utc).AddTicks(5335), "$2a$12$h1J9sbmz3zIcrH0ObnR2tei8SCsOXwcikbRTsBPqj2Yw2ynCLzGBK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 35, 283, DateTimeKind.Utc).AddTicks(768), "$2a$12$WHDv1GgKPVTEySsaRZo8/.4iczixXuPNBUcDJsoNi2V6XVWh53.7i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 34, 999, DateTimeKind.Utc).AddTicks(6210), "$2a$12$EXnMIaJiuNNaU2KgOhOIbuHEz7WJcqCFOP0Jc5Sbq0QNQbeMRQUh." });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(373));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(580), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(583), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(586), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(588), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Local).AddTicks(591), new DateTime(2025, 3, 6, 1, 53, 37, 886, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SessionChatSessionId",
                table: "ChatMessages",
                column: "SessionChatSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatSessions_SessionChatSessionId",
                table: "ChatMessages",
                column: "SessionChatSessionId",
                principalTable: "ChatSessions",
                principalColumn: "ChatSessionId");
        }
    }
}
