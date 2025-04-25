using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class refactordb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Ingredients_HotpotBrothId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Ingredients_IngredientId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Ingredients_HotpotBrothId",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Ingredients_IngredientId",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_DamageDevices_Utensils_UtensilId",
                table: "DamageDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Utensils_UtensilId",
                table: "ReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReplacementRequests_UtensilId",
                table: "ReplacementRequests");

            migrationBuilder.DropIndex(
                name: "IX_DamageDevices_UtensilId",
                table: "DamageDevices");

            migrationBuilder.DropIndex(
                name: "IX_Customizations_HotpotBrothId",
                table: "Customizations");

            migrationBuilder.DropIndex(
                name: "IX_Customizations_IngredientId",
                table: "Customizations");

            migrationBuilder.DropIndex(
                name: "IX_Combos_HotpotBrothId",
                table: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Combos_IngredientId",
                table: "Combos");

            migrationBuilder.DeleteData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "UtensilId",
                table: "ReplacementRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UtensilId",
                table: "DamageDevices");

            migrationBuilder.DropColumn(
                name: "HotpotBrothId",
                table: "Customizations");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Customizations");

            migrationBuilder.DropColumn(
                name: "HotpotBrothId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Combos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MeasurementValue",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "DamageDevices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientBatchs",
                columns: table => new
                {
                    IngredientBatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    InitialQuantity = table.Column<int>(type: "int", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "int", nullable: false),
                    BestBeforeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientBatchs", x => x.IngredientBatchId);
                    table.ForeignKey(
                        name: "FK_IngredientBatchs_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FinishDate", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8996), null, new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "FinishDate", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9001), null, new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "FinishDate", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9003), null, new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9003) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7418), "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/noilaudongcodien.jpg?alt=media\\u0026token=6f345d27-7ff9-43e6-8beb-e50f29578436\"]" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7935), "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/noi-lau-dien-sunhouse-shd4523-gia-re.jpg?alt=media\\u0026token=2d6c1dd9-c484-4dde-94a2-bdf52e511d0b\"]" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7963), "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/noi-lau-mini-lebenlang-lbec0808-shr-1000x1000.jpg?alt=media\\u0026token=92f6bcd1-169c-43c0-8e73-013cb8a68637\"]" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7989), "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-hai-ngan.jpg?alt=media%token=4c530d54-dafd-45fe-8d77-7b6c45a81b5a\"]" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8015), "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau%20inox.jpg?alt=media\\u0026token=e4963f3f-5130-4485-9932-39cecd7a98af\",\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau%20inox%202.jpg?alt=media\\u0026token=4dda3d4c-3ba3-4cd0-96fc-d4ff505c5887\"]" });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8889), new DateTime(2025, 3, 26, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8892) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8899), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8901), new DateTime(2025, 3, 26, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8902), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8903) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8904), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8905), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8907), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8907) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8908), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8910), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8911), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8912), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8914), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8916), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8917), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8919), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8924), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8926), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8927), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8928) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8929), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8930), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8931), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8933), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8934), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8936), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8937), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8938), new DateTime(2025, 4, 22, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8743), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/89d16277-5f5d-45f0-9be4-6d710ecf2eaa.png?alt=media&token=a0db0650-a99e-4044-8552-88b096956487", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8747), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/thit-cuu-cat-lat.jpg?alt=media&token=c2d6bbbd-b69d-450a-8d0e-396b135f35f3", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8748), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/ba-chi-heo.png?alt=media&token=83bbc055-4726-4c68-8ede-f0a0ea17c2d4", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8749), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/shrimps.jpg?alt=media&token=3ef01d1a-0df5-4f5a-b8db-b1fe34ae89ca", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8751), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/C%C3%A1-vi%C3%AAn-g%E1%BA%A7n-nh%C6%B0-%C4%91%C6%B0%E1%BB%A3c-l%C3%A0m-m%C3%B3n-%C4%83n-ph%E1%BB%95-bi%E1%BA%BFn-nh%C6%B0-c%C3%A1-vi%C3%AAn-chi%C3%AAn.jpg?alt=media&token=98bd96d8-124e-4883-afa0-4482913cadfa", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8752), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/M%E1%BB%B1c-t%C6%B0%C6%A1i-2-532x532.jpg?alt=media&token=1cd9d76a-0435-4fc3-b773-64af8b515e76", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8753), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/1ad2d8b1-30c1-45c6-aa26-fe898a065120.png?alt=media&token=918e0ce5-e455-4391-9d17-f7430b41c195", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8754), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/spinach.png?alt=media&token=4ae0c9f7-e3a3-48bc-b56a-8594a0d081f2", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8755), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/corn.jpg?alt=media&token=3d64d225-6be7-4c8f-b8b4-8b19a220d09b", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8756), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/udon.png?alt=media&token=c05be1ca-db95-4dd2-8d36-c9567b3f7ea0", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8758), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/1663922149_8W3viNBAwDyUEHTj_1663931837-php9bcja8.png?alt=media&token=8a3b05d0-3cdb-4916-b451-f1ee01d38cbf", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8759), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/mi-ramen-luoc-cap-dong%20(2).png?alt=media&token=5826d348-02c2-4ded-b350-c70cc7ebc42e", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8760), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/tofu.png?alt=media&token=31b50c1e-c030-43a7-9eed-a9543f30b51d", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8761), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/fried-tofu.png?alt=media&token=e645c47c-95f5-4a45-9407-4d99464e0023", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8762), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/mnam-huong.png?alt=media&token=f6e2ec47-ad19-4688-b20b-ffba6ae5fd7a", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8764), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/nam-kim-cham.png?alt=media&token=060215f1-02b2-402e-83e4-ba93d2535928", 0.0, "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8765), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-tu-xuyen-cay.png?alt=media&token=cb8f5064-ee26-499b-8fe9-f3f4a6adc473", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8766), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-ca-chua.png?alt=media&token=8fcf88b3-6128-4689-aab0-e64a48ce8b5a", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8767), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-nam.jpg?alt=media&token=d2080167-804c-4909-9bef-1d7e8e7dcfdc", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8768), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-xuong-trong.jpg?alt=media&token=49407a13-5f3e-47a0-8126-bab93c157b69", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8769), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/sot-me.jpg?alt=media&token=560bf6c4-26fb-4adb-b543-308089fd0e40", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8771), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/sot-tuong-toi.png?alt=media&token=fe07fff2-694d-420f-aea0-9bd6723f0798", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8809), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/dau-ot.png?alt=media&token=0ed694a6-cdfe-4a7a-b788-8f679ab5a86f", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ImageURL", "MeasurementValue", "Unit" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8811), "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/sot-sa-te.png?alt=media&token=fae51735-1dc5-4fb2-b950-27163f9eebdc", 0.0, "ml" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9116), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9118) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9122), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9125), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9128), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9130), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9131) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9133), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9135), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9136) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 248, DateTimeKind.Utc).AddTicks(6633), "$2a$12$qPHMPdAWNY2wJijYbh6ysua5pYdvFN92UDfrZGz2kOtqlD/oR1Cxu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 484, DateTimeKind.Utc).AddTicks(9007), "$2a$12$FvNGv.w6bcFfTe1XtxYif.iGkcZyOstAMlchtWGyzNIrOGCt/zMxC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 722, DateTimeKind.Utc).AddTicks(4803), "$2a$12$DHoPUMmWIQ.0Sgk.5i9Zw.eVI9a63ILwg/pwdYx1wkONzjadk7eaG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 28, 954, DateTimeKind.Utc).AddTicks(6952), "$2a$12$rzYeZqGs3lXB1R.hnuyzluAcpZBMO7lwu/eOXVgYdbpV3v5qIK.ba" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 186, DateTimeKind.Utc).AddTicks(7929), "$2a$12$DsssiIBhZR6qG77qPgAu6.SWnDjHUt4jr1gGQRrQSrjdmX8Hfbfse" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 417, DateTimeKind.Utc).AddTicks(9675), "$2a$12$F63eHBxbVuuAvvcMbSi.uecYflYGWJ7tZWl3mOLQAoI2taLsOmkjG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 649, DateTimeKind.Utc).AddTicks(3816), "$2a$12$VmsNlgn0CfR1pYujxBCFGOLVu9BHh8d8mIqfH.sj/Mu8LuIwW6o4O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 803, DateTimeKind.Utc).AddTicks(6732), "$2a$12$1bhu3q5cSAv7nt7NE3hj.uIF26CvcQEvyO1tsdgKSWlDKAPX6O9JG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 34, DateTimeKind.Utc).AddTicks(5183), "$2a$12$x2G2xGfY4QK99Bw39KgdhOX/CiNh6Rer8UtikBWzFCI4.uxzI56mW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 266, DateTimeKind.Utc).AddTicks(3764), "$2a$12$FprL1Iaj8BRMgkWY1qiO8.pEbuxfeNDWE4svkKrixpQqnnzcuHYYa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 29, 879, DateTimeKind.Utc).AddTicks(2160), "$2a$12$DNVoxs8yE6.iPcdcg9AxTepTPLZmQLgfdNj2PZcUTshpTG3Cfv672" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 109, DateTimeKind.Utc).AddTicks(5184), "$2a$12$Jw4d7AFD/qybiQ.Peo.FZeVsl8Bfpr5uxaqLo7NUsO0fTajaWujXW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 340, DateTimeKind.Utc).AddTicks(6901), "$2a$12$5iNG3oPwGWZzZ.hPA8gkZutDiNA9p/qbBoRp/Pvk.Rx0akYNEIB1y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 30, 572, DateTimeKind.Utc).AddTicks(3285), "$2a$12$dB4uOa0ZG2zTfZUOlTlefel/CERhLmPo9.XNqymd4mF.d.vYqnDwW" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8593), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8607), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8609), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8611), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8613), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9188), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9189) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9191), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9193), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9195), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9198), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9200), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9201) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9202), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9205), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9207), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9209), new DateTime(2025, 4, 25, 14, 16, 31, 498, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientBatchs_IngredientId",
                table: "IngredientBatchs",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientBatchs");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MeasurementValue",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "DamageDevices");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryTime",
                table: "ShippingOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentType",
                table: "ReplacementRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtensilId",
                table: "ReplacementRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtensilId",
                table: "DamageDevices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotpotBrothId",
                table: "Customizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Customizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotpotBrothId",
                table: "Combos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Combos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate", "UtensilId" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(835), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(837), null });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate", "UtensilId" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(840), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(841), null });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate", "UtensilId" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(842), new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(843), null });

            migrationBuilder.InsertData(
                table: "DamageDevices",
                columns: new[] { "DamageDeviceId", "CreatedAt", "Description", "HotPotInventoryId", "IsDelete", "LoggedDate", "Name", "Status", "UpdatedAt", "UtensilId" },
                values: new object[] { 4, new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(843), "Đĩa bị vỡ và cần được thay thế.", null, false, new DateTime(2025, 4, 21, 17, 3, 25, 427, DateTimeKind.Utc).AddTicks(844), "Đĩa Bị Vỡ", 4, null, 5 });

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
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6466), "https://example.com/images/classic-copper-hotpot.jpg" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6476), "https://example.com/images/modern-electric-hotpot.jpg" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6478), "https://example.com/images/mini-portable-hotpot.jpg" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6479), "https://example.com/images/dual-section-hotpot.jpg" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageURL" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6481), "https://example.com/images/traditional-ceramic-hotpot.jpg" });

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
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6976), "https://example.com/images/sliced-beef.jpg", 100 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6979), "https://example.com/images/lamb-slices.jpg", 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6981), "https://example.com/images/pork-belly.jpg", 75 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6982), "https://example.com/images/shrimp.jpg", 90 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6984), "https://example.com/images/fish-balls.jpg", 120 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6985), "https://example.com/images/squid.jpg", 60 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6986), "https://example.com/images/napa-cabbage.jpg", 100 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6987), "https://example.com/images/spinach.jpg", 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6988), "https://example.com/images/corn.jpg", 70 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6990), "https://example.com/images/udon-noodles.jpg", 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6991), "https://example.com/images/glass-noodles.jpg", 85 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6992), "https://example.com/images/ramen-noodles.jpg", 90 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6993), "https://example.com/images/firm-tofu.jpg", 60 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6995), "https://example.com/images/tofu-puffs.jpg", 65 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6996), "https://example.com/images/shiitake.jpg", 70 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6997), "https://example.com/images/enoki.jpg", 65 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6998), "https://example.com/images/sichuan-broth.jpg", 50 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(6999), "https://example.com/images/tomato-broth.jpg", 45 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7000), "https://example.com/images/mushroom-broth.jpg", 40 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7001), "https://example.com/images/bone-broth.jpg", 55 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7003), "https://example.com/images/sesame-sauce.jpg", 40 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7004), "https://example.com/images/garlic-soy.jpg", 45 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7005), "https://example.com/images/chili-oil.jpg", 50 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ImageURL", "Quantity" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 426, DateTimeKind.Utc).AddTicks(7006), "https://example.com/images/shacha-sauce.jpg", 35 });

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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 182, DateTimeKind.Utc).AddTicks(3625), "$2a$12$g3TJ8wWxR4MafLd2Vb9SUe.lu.YQqDB5gZ6pK1RCcD5VN3o82kNbq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 416, DateTimeKind.Utc).AddTicks(1545), "$2a$12$i.I6r1PVMcC/M3c3QSKs1.OfisixyLawtk/bWXDMdB1oj/CZ0pbkW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 647, DateTimeKind.Utc).AddTicks(4629), "$2a$12$vRXORkxRv8RVA79KKsP0xOEHbuFBmQJAFJMP8taeGN5OYCoHAJukC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 22, 880, DateTimeKind.Utc).AddTicks(224), "$2a$12$2bz/90u0YOZS3uxYOv6HIeOfGh4voPtZmAnlsldL5Dsgq4FOpHacG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 111, DateTimeKind.Utc).AddTicks(978), "$2a$12$nGHS6oCrNDC32LfBvXgPb.IA6AJPOgr3BHWVLzgfnYnjAck6rF/py" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 339, DateTimeKind.Utc).AddTicks(5825), "$2a$12$vlr6qO.9pD37BzeK3FBer.AJFeo.k5IBbxXgRn3OxU8cknA1izmAW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 571, DateTimeKind.Utc).AddTicks(668), "$2a$12$Jejk1E.tNHqFc0GODaiiYuPLWENvYhWIgu/mWS.YsDdDq9PoE9krC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 727, DateTimeKind.Utc).AddTicks(3653), "$2a$12$ry6ERTYZq.8/OMg9slG/ZOodTHPe6dbMlFv27ANPiqtA6eNsC8qmC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 958, DateTimeKind.Utc).AddTicks(291), "$2a$12$CZ/mZgkj8cxOSIQWwHK.5uQQG0CwmtvtbLXv5P1/XHyYT23AYQM1u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 25, 188, DateTimeKind.Utc).AddTicks(1941), "$2a$12$A5pcipSyQzXuo8MYhnPNjOf1EwkUDWjFSfpV53dse6QqODBKh/ORm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 23, 802, DateTimeKind.Utc).AddTicks(8491), "$2a$12$.M56CrzcFyEEz7uFKvVkJOrQYLQKzm/80mzOk1L3E3mXqc.hZDh16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 34, DateTimeKind.Utc).AddTicks(182), "$2a$12$J2XUpFpl0tuDhL2edJa76u3YgHuyex5hIRIzLhQn.U/KdchpUMoO2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 265, DateTimeKind.Utc).AddTicks(4682), "$2a$12$WLLsuwnUBFTRHQvXQ.fBP.VbBBptP1fw.FEcy.oqvnQwo7.z5g7cm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 21, 17, 3, 24, 497, DateTimeKind.Utc).AddTicks(3090), "$2a$12$/FCj9fBL8NRIJbOZcqMSxuqF8IklTD8KuuhwvH7y/BeReTbgQuDui" });

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
                name: "IX_ReplacementRequests_UtensilId",
                table: "ReplacementRequests",
                column: "UtensilId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageDevices_UtensilId",
                table: "DamageDevices",
                column: "UtensilId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_HotpotBrothId",
                table: "Customizations",
                column: "HotpotBrothId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_IngredientId",
                table: "Customizations",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_HotpotBrothId",
                table: "Combos",
                column: "HotpotBrothId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_IngredientId",
                table: "Combos",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Ingredients_HotpotBrothId",
                table: "Combos",
                column: "HotpotBrothId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Ingredients_IngredientId",
                table: "Combos",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customizations_Ingredients_HotpotBrothId",
                table: "Customizations",
                column: "HotpotBrothId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customizations_Ingredients_IngredientId",
                table: "Customizations",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageDevices_Utensils_UtensilId",
                table: "DamageDevices",
                column: "UtensilId",
                principalTable: "Utensils",
                principalColumn: "UtensilId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Utensils_UtensilId",
                table: "ReplacementRequests",
                column: "UtensilId",
                principalTable: "Utensils",
                principalColumn: "UtensilId");
        }
    }
}
