using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class paymentreceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentReceipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReceipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_PaymentReceipts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentReceipts_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1164), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1169), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1171), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1172), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1039), new DateTime(2025, 3, 4, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1041) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1050), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1051) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1052), new DateTime(2025, 3, 4, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1054), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1055), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1056), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1058), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1059), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1060), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1062), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1063), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1064), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1066), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1067), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1069), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1074), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1075), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1076), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1078), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1079), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1080), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1082), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1083), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1084), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1086), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1087), new DateTime(2025, 3, 31, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(1088) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(875));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(888));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 55, 256, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 55, 256, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 55, 256, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 55, 256, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 55, 256, DateTimeKind.Utc).AddTicks(6874), "$2a$12$tMiq9.WX29CtQEZkCXwjMujlXxXWVASwtQiUW3S2xIrIPSu29RBRq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 55, 491, DateTimeKind.Utc).AddTicks(1578), "$2a$12$WywLozLjlYj.DC/R/Ugq3eHASr/eXmvLaffGwx4fXwATo6bTghCgy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 55, 726, DateTimeKind.Utc).AddTicks(4019), "$2a$12$hupko0vnSdea/48hIBcq1etaNqanWQbaXxvZ1Sx9ryUm4MitnrDTW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 55, 957, DateTimeKind.Utc).AddTicks(568), "$2a$12$sOdZuitV2tumK1nM9m4vguouvwMoHf2SJVZon0LRddn2RSjaggY6." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 56, 181, DateTimeKind.Utc).AddTicks(4220), "$2a$12$auGvEb5kuyFwcjWEgF4cI.zkWTtSaGtnHxfEnLZ8jFvj8vwuoIMDK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 56, 407, DateTimeKind.Utc).AddTicks(7432), "$2a$12$DAt7S.EN5acQwwf09PWXJejV94aiSWdNXoAliBGK6mjx5OEDouM7W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 56, 633, DateTimeKind.Utc).AddTicks(9108), "$2a$12$KRexE3HMGSbhzYtFUYsIsutftA5wFud4tE3tWptnO2lCVkjj54KkC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 56, 856, DateTimeKind.Utc).AddTicks(2736), "$2a$12$cRRYZlpfRXpFDqUToRpouuLu8gni4KI1BPhpO8RYOoneh276fhw/2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 80, DateTimeKind.Utc).AddTicks(2057), "$2a$12$wd4/hdF2KQhW0zpEJRk26ex/G9E6ODJwfsfRjsiHhklnlkyvozx6G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 301, DateTimeKind.Utc).AddTicks(5001), "$2a$12$z71L4.1Y2.gFt0d1q3GJUeIJNl6voC1F0JiKRiraQujH0UKnrUgN6" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 12, 40, 57, 526, DateTimeKind.Utc).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(703), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(711), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(713), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(715), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(716) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(717), new DateTime(2025, 4, 3, 12, 40, 57, 527, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_OrderId",
                table: "PaymentReceipts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_PaymentId",
                table: "PaymentReceipts",
                column: "PaymentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentReceipts");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2194), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2199), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2200), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2202), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2203) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2088), new DateTime(2025, 3, 3, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2099), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2101), new DateTime(2025, 3, 3, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2102) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2103), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2103) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2105), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2106), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2108), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2109), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2110) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2110), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2112), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2113), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2115), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2116), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2118), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2119), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2125), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2126) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2127), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2128), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2130), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2130) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2131), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2133), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2133) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2134), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2135) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2136), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2137), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2138), new DateTime(2025, 3, 30, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 44, 930, DateTimeKind.Utc).AddTicks(2662), "$2a$12$ODb6e3o0ywysReRGO2JnMuzlq9bRWJk9SPgrjiF2uCVrsQ2ZI7eaa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 167, DateTimeKind.Utc).AddTicks(4723), "$2a$12$/mnFgjdVK1aKcK.9Mk9GJulJfwd2dLL01QrzvO9DytqaNrQEOCqoe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 405, DateTimeKind.Utc).AddTicks(2636), "$2a$12$QjPTh382Y18ziGrndWXwAuH.Q825Dlm4HY3PzZ8hfNFAjwbKkwH8C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 638, DateTimeKind.Utc).AddTicks(5361), "$2a$12$1XrOU4ZYlmTQsZNdNeVr7.coqS4/RSfLvumb9CMSTPRP25egFSdgy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 45, 870, DateTimeKind.Utc).AddTicks(2641), "$2a$12$3.WtZxi.MR9mSjq4OVSIE.pKHGBO9piuTfsVXY5Ud0pA97Wj/Vpi." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 104, DateTimeKind.Utc).AddTicks(407), "$2a$12$5ebaFQDM5VpG1iE8yng4y.9hLkVN4IRAJe3JO0LxUMqEt3K4.Xehi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 337, DateTimeKind.Utc).AddTicks(3164), "$2a$12$GPO1B9EiYlxJB5JnMfA1Uevv7yryxn7jKDQUY5MZVYZTJWWcEY0ae" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 568, DateTimeKind.Utc).AddTicks(7972), "$2a$12$Y9BCUAAdizKYvG06rjVqUuXYwFaFxWrMTrjkz0xT4JHdXTulIKSI2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 46, 800, DateTimeKind.Utc).AddTicks(9676), "$2a$12$ePZaCAzdVQp1tLdhGgsjquq1Eroloy.kkOhHAfrl2EiD2bdG3XLPK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 32, DateTimeKind.Utc).AddTicks(3131), "$2a$12$WpNtYjvWsEJ5mDwV2DPHXuj05QjTVEXGrvS2L0pg71hNqW.7Rsdua" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1816), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1822), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1824), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1825) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1826), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1828), new DateTime(2025, 4, 2, 13, 43, 47, 265, DateTimeKind.Utc).AddTicks(1828) });
        }
    }
}
