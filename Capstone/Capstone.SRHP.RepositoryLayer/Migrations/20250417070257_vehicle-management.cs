using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class vehiclemanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofImage",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "ProofImageType",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "ProofTimestamp",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "SignatureData",
                table: "ShippingOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderSize",
                table: "ShippingOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "ShippingOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });

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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 54, 754, DateTimeKind.Utc).AddTicks(2751), "$2a$12$Hkiw1JaGjx0YWD5FJtbybO/cyS8R7PMXpvu8JR0EYqAVy1DODtUm6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 54, 990, DateTimeKind.Utc).AddTicks(3776), "$2a$12$opzPJ1YU0XOCLkiGUoScZOVeCOej6/3kO8oqb459pVB9ITf19OZGC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 223, DateTimeKind.Utc).AddTicks(1911), "$2a$12$qxXISfrip57lMTwxiJMARuRCCpy8cgfE4sI1C3tBRY7zTLeLgPJAi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 454, DateTimeKind.Utc).AddTicks(4871), "$2a$12$gKuNYLJWnfKzaX9POmGh0eD/LlvKqWr8g494fez3VmezM9p4rawBm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 687, DateTimeKind.Utc).AddTicks(239), "$2a$12$boewuG0W3/wucYj.QNIxROZrYAk7H7qzgz7Tqoe7/ruJOqTF6qa6a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 55, 919, DateTimeKind.Utc).AddTicks(1802), "$2a$12$ggyIxxP5cKoZ.eKlbSDSDeqwPG0UgyLm0COLVw4LuGDOY7m87k8Nm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 152, DateTimeKind.Utc).AddTicks(5455), "$2a$12$x5GmXT85IwgmcEdqmXWbS.Ldt8xFNGl6xIfN0t16aUzMphnCuwQH6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 385, DateTimeKind.Utc).AddTicks(3794), "$2a$12$dM7a4Jlv8tda9v1sIwQe3.ILvDttTfv7J/zzgGQxf1teL5uKfPvTK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 17, 14, 2, 56, 617, DateTimeKind.Utc).AddTicks(9969), "$2a$12$lduMKUSw1vdoRA.Wf9C7S.w2xEGow0PmX3z.iK/kYnBdUaaBEFF9e" });

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

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "CreatedAt", "IsDelete", "LicensePlate", "Name", "Notes", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7675), false, "59P1-12345", "Honda Wave Alpha", "Xe máy giao hàng tiêu chuẩn, màu xanh dương, đã được bảo dưỡng tháng 3/2025", 1, 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7676) },
                    { 2, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7679), false, "59P2-23456", "Yamaha Sirius", "Xe máy giao hàng nhanh, màu đỏ, tiết kiệm nhiên liệu", 1, 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7679) },
                    { 3, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7681), false, "59P2-34567", "Honda Vision", "Xe tay ga dành cho đơn hàng nhỏ, màu trắng, có thùng hàng 60L", 2, 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7682) },
                    { 4, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7684), false, "59P3-45678", "Suzuki Raider", "Xe máy giao hàng tốc độ cao, phù hợp cho đơn hàng khẩn cấp", 1, 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7684) },
                    { 5, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7686), false, "51A-12345", "Toyota Vios", "Xe ô tô 4 chỗ, phù hợp cho đơn hàng lớn hoặc khoảng cách xa", 1, 2, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7686) },
                    { 6, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7688), false, "51A-23456", "Mitsubishi Xpander", "Xe ô tô 7 chỗ, đang trong quá trình bảo dưỡng định kỳ, sẽ sẵn sàng vào 25/04/2025", 1, 2, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7689) },
                    { 7, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7690), false, "59P3-56789", "Honda SH Mode", "Xe tay ga cao cấp, phù hợp cho giao hàng trong khu vực trung tâm thành phố", 1, 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7691) },
                    { 8, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7693), false, "51A-34567", "Ford Ranger", "Xe bán tải, phù hợp cho vận chuyển hàng hóa lớn và đường xa", 1, 2, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7693) },
                    { 9, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7695), false, "59P4-67890", "Piaggio Vespa", "Xe tay ga phong cách Ý, phù hợp cho giao hàng cao cấp", 1, 1, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7695) },
                    { 10, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7697), false, "51A-45678", "Hyundai Accent", "Xe sedan 4 chỗ, tiết kiệm nhiên liệu, phù hợp cho giao hàng khoảng cách xa", 1, 2, new DateTime(2025, 4, 17, 14, 2, 56, 849, DateTimeKind.Utc).AddTicks(7698) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOrders_VehicleId",
                table: "ShippingOrders",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingOrders_Vehicle_VehicleId",
                table: "ShippingOrders",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingOrders_Vehicle_VehicleId",
                table: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_ShippingOrders_VehicleId",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "OrderSize",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "ShippingOrders");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProofImage",
                table: "ShippingOrders",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProofImageType",
                table: "ShippingOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProofTimestamp",
                table: "ShippingOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SignatureData",
                table: "ShippingOrders",
                type: "varbinary(max)",
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
        }
    }
}
