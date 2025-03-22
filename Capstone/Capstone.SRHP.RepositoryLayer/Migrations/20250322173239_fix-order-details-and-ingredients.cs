using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixorderdetailsandingredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentOrderDetails_Orders_OrderId",
                table: "RentOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellOrderDetails_Orders_OrderId",
                table: "SellOrderDetails");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "SellOrderDetails");

            migrationBuilder.DropColumn(
                name: "VolumeWeight",
                table: "SellOrderDetails");

            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "DamageFee",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "LateFee",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "RentalNotes",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "RentalStartDate",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "ReturnCondition",
                table: "RentOrderDetails");

            migrationBuilder.DropColumn(
                name: "HotpotDeposit",
                table: "Orders");

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

            migrationBuilder.AddColumn<bool>(
                name: "HasRentItems",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSellItems",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AlterColumn<int>(
                name: "MinQuantity",
                table: "ComboAllowedIngredientTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.CreateTable(
                name: "RentOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotpotDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DamageFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RentalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReturnCondition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_RentOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_SellOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3209));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3839), new DateTime(2025, 2, 21, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3842), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3844), new DateTime(2025, 2, 21, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3846), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3845) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3848), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3850), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3852), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3854), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3856), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3858), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3861), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3863), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3865), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3867), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3876), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3875) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3878), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3877) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3880), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3879) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3882), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3884), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3883) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3886), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3888), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3887) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3889), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3891), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3893), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3897), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3896) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3899), new DateTime(2025, 3, 20, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3698), 20, 100 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3700), 15, 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3702), 15, 75 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3704), 20, 90 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3705), 30, 120 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3707), 15, 60 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3708), 25, 100 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3710), 20, 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3711), 15, 70 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3714), 20, 80 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3716), 20, 85 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3717), 25, 90 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3719), 15, 60 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3720), 15, 65 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3722), 15, 70 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3723), 15, 65 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3725), 10, 50 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3726), 10, 45 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3728), 10, 40 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3729), 10, 55 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3731), 10, 40 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3732), 10, 45 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3734), 10, 50 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3737), 10, 35 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 35, 114, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 35, 114, DateTimeKind.Utc).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 35, 114, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 35, 114, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 35, 114, DateTimeKind.Utc).AddTicks(3935), "$2a$12$J7Ae1O992qezFsYKvVs9L.v6z3TmraKSYH7ORzyEkwosyAUFEEXtG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 35, 361, DateTimeKind.Utc).AddTicks(8254), "$2a$12$GJ6AC958W91ghe2dPDaKguoFQ.aLDiB3OhdjbWeDzXil4GGBJCLVu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 35, 618, DateTimeKind.Utc).AddTicks(2120), "$2a$12$u1.icmBrzCBOupZjk.AWPup65naNMTozOXwGnhVDUycKVLUwbfGnq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 35, 867, DateTimeKind.Utc).AddTicks(8968), "$2a$12$1OP3l/5gI6m/YHge/va0eugSw2fRguouTsgOPBk./MKqxkYi6hd4C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 36, 107, DateTimeKind.Utc).AddTicks(7823), "$2a$12$PFaxY/ktUjwymxuP6t9F9ePJcrMX.v5y6.pJG.JfG3OpR7virPNSK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 36, 356, DateTimeKind.Utc).AddTicks(8668), "$2a$12$TUF5o2C1fbzeHYXkAQv4g.p0qd/n7K0w5WaZdZxrnQKnxghDDCZ5y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 36, 606, DateTimeKind.Utc).AddTicks(6014), "$2a$12$XWpesaKXs5wfriJP/DZOz.zogyLm9YoUXrIZoqPF2HyTPdW/mrDL6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 36, 855, DateTimeKind.Utc).AddTicks(4906), "$2a$12$GPX68E.WljIsA.ayDQy65ObCa7YamYpj1DtuaTi.39Coo5TU0rsgG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 101, DateTimeKind.Utc).AddTicks(6606), "$2a$12$dd6gVDQJF9KPRWU36fh4/OpwVpg89rQPcR1v9OGbtwnjXVW8dznKO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 347, DateTimeKind.Utc).AddTicks(7604), "$2a$12$.hRi25dj778ZOk5YWBA7MeURkVtH8qzS7CBr5kRaeR/9MLra2h3gq" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3587), new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3578) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3591), new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3589) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3593), new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3591) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3595), new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Local).AddTicks(3597), new DateTime(2025, 3, 23, 0, 32, 37, 589, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrderDetails_RentOrders_OrderId",
                table: "RentOrderDetails",
                column: "OrderId",
                principalTable: "RentOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellOrderDetails_SellOrders_OrderId",
                table: "SellOrderDetails",
                column: "OrderId",
                principalTable: "SellOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentOrderDetails_RentOrders_OrderId",
                table: "RentOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellOrderDetails_SellOrders_OrderId",
                table: "SellOrderDetails");

            migrationBuilder.DropTable(
                name: "RentOrders");

            migrationBuilder.DropTable(
                name: "SellOrders");

            migrationBuilder.DropColumn(
                name: "HasRentItems",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HasSellItems",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "SellOrderDetails",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VolumeWeight",
                table: "SellOrderDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "RentOrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DamageFee",
                table: "RentOrderDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "RentOrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "LateFee",
                table: "RentOrderDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentalNotes",
                table: "RentOrderDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalStartDate",
                table: "RentOrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReturnCondition",
                table: "RentOrderDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HotpotDeposit",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AlterColumn<decimal>(
                name: "MinQuantity",
                table: "ComboAllowedIngredientTypes",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "ComboAllowedIngredientTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 17, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8359), new DateTime(2025, 2, 17, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8362), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 17, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8364), new DateTime(2025, 2, 17, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8366), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8366) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8368), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8370), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8372), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8372) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8374), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8376), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8378), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8380), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8382), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8384), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8386), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8394), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8396), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8398), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8399), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8401), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8404), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8406), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8408), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8410), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8411), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8414), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8415), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8163), "g", 20m, 100m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8165), "g", 15m, 80m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8168), "g", 15m, 75m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8170), "g", 20m, 90m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8173), "g", 30m, 120m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8175), "g", 15m, 60m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8177), "g", 25m, 100m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8179), "g", 20m, 80m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8181), "g", 15m, 70m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8183), "g", 20m, 80m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8185), "g", 20m, 85m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8187), "g", 25m, 90m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8189), "g", 15m, 60m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8191), "g", 15m, 65m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8197), "g", 15m, 70m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8199), "g", 15m, 65m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8201), "ml", 10m, 50m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8203), "ml", 10m, 45m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8205), "ml", 10m, 40m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8260), "ml", 10m, 55m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8263), "ml", 10m, 40m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8265), "ml", 10m, 45m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8267), "ml", 10m, 50m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MeasurementUnit", "MinStockLevel", "Quantity" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8269), "ml", 10m, 35m });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 52, 725, DateTimeKind.Utc).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 52, 725, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 52, 725, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 52, 725, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 52, 725, DateTimeKind.Utc).AddTicks(9651), "$2a$12$I9pTnJLVJr8ZHXdHnCWBWelVIt1lB5Qb..buhw.LajNfIOwkVHVFy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 52, 970, DateTimeKind.Utc).AddTicks(7837), "$2a$12$2pHF78LBTIqxmn204I6nHuk6h0ZUwACoo5XqmaiA6cWRnYXH26vAy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 53, 213, DateTimeKind.Utc).AddTicks(5201), "$2a$12$0WnOQQDZJMv1RIv.L7NMOOJH1eeRuvfUB4iT9KjwFHtVnYfzkxOvG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 53, 451, DateTimeKind.Utc).AddTicks(7274), "$2a$12$4ZcDyPKHuPk6wWZZg/U7IeYWkAKpGTxDLIGV89x94SmLX6VIOqBum" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 53, 691, DateTimeKind.Utc).AddTicks(687), "$2a$12$Q3Tr8XIckKh6a/Eaeu2WNuaNj5V1jH/4/R2AR0dPRqZlWi.kvDoZe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 53, 928, DateTimeKind.Utc).AddTicks(132), "$2a$12$d1uyjoplu5lHwNoEoJp83O197yyq7iQziE7p18EO5z/qV8uivUwfi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 54, 166, DateTimeKind.Utc).AddTicks(9647), "$2a$12$t0IfUr//7Fciw4DozKqPpOD0y8VK4W2Lp.2TzeGsIrbHYE5GdLpNS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 54, 404, DateTimeKind.Utc).AddTicks(5392), "$2a$12$Rk0gF5mc6t.m8smkVAgnW.SrKazje4/b3MSxgp.I7zZcPgeL63G7C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 54, 641, DateTimeKind.Utc).AddTicks(195), "$2a$12$Jq9H3IjKslsx1HI7h9L9U.iH6TBGywFOmw2s/AlJKzTo8ZmlZTO2C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 54, 881, DateTimeKind.Utc).AddTicks(275), "$2a$12$RbFXTtSCL2wNIjYDNu7Z.uTx7QDrvfCKIV8v2HbJ0.ZuhXJi6GS02" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8015), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8019), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Utc).AddTicks(8017) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8022), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8024), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8027), new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Utc).AddTicks(8025) });

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrderDetails_Orders_OrderId",
                table: "RentOrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellOrderDetails_Orders_OrderId",
                table: "SellOrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
