using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixhotpotstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Hotpots");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "HotPotInventorys",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1513), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1520), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1521) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1522), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1523), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1032), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1037), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1038), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1039), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1040), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1048), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1053), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1054), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1055), 2 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1056), 2 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1057), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1057), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1058), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1059), 0 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1060), 2 });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1403), new DateTime(2025, 2, 25, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1406) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1415), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1417), new DateTime(2025, 2, 25, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1419), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1421), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1423), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1423) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1424), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1426), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1427), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1429), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1431), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1432), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1434), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1435), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1436) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1438), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1447), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1448), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1449) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1450), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1452), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1453), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1454) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1455), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1457), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1459), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1460), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1462), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1464), new DateTime(2025, 3, 24, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 38, 895, DateTimeKind.Utc).AddTicks(6662), "$2a$12$UBSpElKMzPHpvQLpAhZnye6E9RKqG4RUPSH66NJg9Q/v9nyMweMGa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 125, DateTimeKind.Utc).AddTicks(939), "$2a$12$9BWubZ39jKZ0jqoexV1vAuwloU.tn//8xjxavLj15wGcdXcTK/eiO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 351, DateTimeKind.Utc).AddTicks(3085), "$2a$12$6ujiU0ZVpWbQMFF3nrnuL.t1Gl.gLf2E2KhmHh93qE2Zts0yWMrry" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 576, DateTimeKind.Utc).AddTicks(6774), "$2a$12$I1mbuv7cwUvY1kKAPwGCCui2miMLL3psYs9fCeM90vhgcyOyCC5Za" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 39, 807, DateTimeKind.Utc).AddTicks(1123), "$2a$12$O8npWMqiu4W32S2sJvniSu2T4fy9WiQxM9lRDvUwFGLSCUcIp.8Kq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 50, DateTimeKind.Utc).AddTicks(6043), "$2a$12$ETJ6Y4Pth0b1geacUwbgWu0KoqkX3SykszsYHASBKQy0kjnhA.2Ru" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 300, DateTimeKind.Utc).AddTicks(5687), "$2a$12$kGccGkYjaZfHEuSBZTIAAe1VdKXDmO8JM7JJQhF7eB4/iC713Y0Wq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 553, DateTimeKind.Utc).AddTicks(9081), "$2a$12$f426ZAnJHJH5jr9PnNue0eiP/pbSNzuFCDA/YwJfwi6hbQ.X64Zj2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 40, 795, DateTimeKind.Utc).AddTicks(8865), "$2a$12$R69qG9Le0fmj42MLXocomuOc7YVLM.3wLyrwXX6ZUc2Mn14zxBcB." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 32, DateTimeKind.Utc).AddTicks(9928), "$2a$12$PZWqziioMaMRYKp/mbQZR.sjccwSb.kL0Mc2C6Cjme7b4RVte..3K" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1110), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1119), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1119) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1121), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1122) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1123), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1123) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1125), new DateTime(2025, 3, 27, 1, 11, 41, 265, DateTimeKind.Utc).AddTicks(1125) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Hotpots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "HotPotInventorys",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2181), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2184) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2185), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2212), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2214), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1759), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1763), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1764), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1765), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1766), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1773), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1793), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1794), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1795), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1796), false });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1798), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1799), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1800), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1800), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1801), false });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1684), true });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1695), true });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1698), true });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1700), true });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1702), true });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2081), new DateTime(2025, 2, 23, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2082) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2093), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2093) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2094), new DateTime(2025, 2, 23, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2096), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2097), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2099) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2100), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2101), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2102) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2103), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2103) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2105), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2106), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2108), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2112), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2113), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2115), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2116), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2126), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2126) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2127), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2129), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2130), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2132), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2133), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2135), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2135) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2136), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2137) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2137), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2139), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4961), "$2a$12$ajXXygIQrPfTGsC2gxY..eZTsd5Zmpk1hRd1mffxAwZymfevpKQZO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 545, DateTimeKind.Utc).AddTicks(5947), "$2a$12$9pSjqW76fngZFylmOheo5.VStgRxBjqLgpqFKiv7RWAZFcpJUmRsC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 793, DateTimeKind.Utc).AddTicks(3587), "$2a$12$cAT5WQ0E83Psl62ZlT9rX.yc1DRIxGGsiW1IZ9eUIDLtQsbhS3kRq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 27, DateTimeKind.Utc).AddTicks(2668), "$2a$12$uIieRFNXKPptLsce5vRtqutkJouH7ftb8STRGW1vEl5ASQp1.ssTO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 256, DateTimeKind.Utc).AddTicks(3732), "$2a$12$i1vPiFUXO29ANWRwd9omBu/uGz3kur7mJ0TZexsSKSv4bjEpiKME6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 482, DateTimeKind.Utc).AddTicks(6059), "$2a$12$FohlqzUddP37dF16ZZT9M.RuX.9MacPRJXPK5F6KG1GQrlEzMf3c6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 708, DateTimeKind.Utc).AddTicks(7105), "$2a$12$hKU9vTf8H8lPn75DR7V9BeJff6XiWlplfS2OJR1kBVhRwV9fcUJ3O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 935, DateTimeKind.Utc).AddTicks(1721), "$2a$12$YhV.IFBpCAJ/Ls2Eoa0pb.wutgg8N0AIoW7RJOShkaQSSJBRycYci" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 162, DateTimeKind.Utc).AddTicks(1933), "$2a$12$p2acFe6qlA98wV6PntRthObDeg8tX4bOWXO6GFsBkhKAm6umB.im." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 396, DateTimeKind.Utc).AddTicks(2574), "$2a$12$LbnWx8uoanLuEdeq.wDYq.f1dOw6y64MWPOZb0FqC6Q63fUF/cQva" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1848), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1856), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1856) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1858), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1860), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1861) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1862), new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1863) });
        }
    }
}
