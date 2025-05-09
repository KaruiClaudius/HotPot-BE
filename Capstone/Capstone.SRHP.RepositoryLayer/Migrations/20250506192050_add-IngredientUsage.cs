using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addIngredientUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientUsages",
                columns: table => new
                {
                    IngredientUsageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientBatchId = table.Column<int>(type: "int", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: true),
                    ComboId = table.Column<int>(type: "int", nullable: true),
                    CustomizationId = table.Column<int>(type: "int", nullable: true),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUsages", x => x.IngredientUsageId);
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_IngredientBatchs_IngredientBatchId",
                        column: x => x.IngredientBatchId,
                        principalTable: "IngredientBatchs",
                        principalColumn: "IngredientBatchId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_SellOrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "SellOrderDetails",
                        principalColumn: "SellOrderDetailId");
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5594), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5598) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5600), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5601) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5602), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5442), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5446), new DateTime(2025, 5, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5457), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 17, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5459), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5461), new DateTime(2025, 5, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5463), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5464), new DateTime(2025, 5, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5466), new DateTime(2025, 5, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 11, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5467), new DateTime(2025, 5, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5469), new DateTime(2025, 5, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5471), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5473), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5474), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5476), new DateTime(2025, 5, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5477), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 17, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5479), new DateTime(2025, 5, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5481), new DateTime(2025, 5, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5482), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5484), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5485), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5487), new DateTime(2025, 5, 2, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 5, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5488), new DateTime(2025, 4, 27, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 3, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5490), new DateTime(2025, 4, 27, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 3, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5491), new DateTime(2025, 4, 27, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 3, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5493), new DateTime(2025, 4, 27, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5303), new DateTime(2025, 4, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5322), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5323) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5324), new DateTime(2025, 4, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5325) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5326), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5327), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5328) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5329), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5329) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5330), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5332), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5334), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5336), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5336) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5339), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5341), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5342) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5342), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5344), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5353), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5355), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5356) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5357), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5357) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5358), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5360), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5360) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5361), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5362) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5363), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5364) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5364), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5394), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5395) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5396), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5397) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5398), new DateTime(2025, 5, 4, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5204), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5208), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5210), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5211), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5212), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5213), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5215), 400.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5216), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5217), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5219), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5220), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5221), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5222), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5223), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5227), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5228), 150.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5229), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5231), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5232), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5233), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5234), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5236), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5237), 150.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5238), 200.0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 46, 391, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 46, 391, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 46, 391, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 46, 391, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5663), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5670), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5671) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5673), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5674) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5676), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5679), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5682), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5685), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5686) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 46, 391, DateTimeKind.Utc).AddTicks(1483), "$2a$12$PVQ.e42f60npjvfhEoa0Je.Ts1Q1xkgV0CLPZSFB9g82Aa7uB0D0m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 46, 635, DateTimeKind.Utc).AddTicks(5424), "$2a$12$I20DcDwDiNow53vfUsCviedS945brksClYuZw5XsVReboBKQukvOW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 46, 896, DateTimeKind.Utc).AddTicks(4895), "$2a$12$2tTlbAoVpWh.xplsiwfroOaUNAWAMStexQdwHRJtklJ6m.peRcTPK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 47, 143, DateTimeKind.Utc).AddTicks(22), "$2a$12$10oxqM08nTekWfVrU7bcFesSrszcDB8oLFeS8.tU4Xy63Ane.86zi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 47, 380, DateTimeKind.Utc).AddTicks(9001), "$2a$12$JQvLJzCo.n8ZOUiMHaxLAu0WUqHj9hHSpNKpcVpbIfqBn/Q5vybU." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 47, 614, DateTimeKind.Utc).AddTicks(6421), "$2a$12$kkIWJhFLKErjVD9JvKoW0uOFAeWIH3O9RmM8f8/XmRnu4eKCxXNUq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 47, 851, DateTimeKind.Utc).AddTicks(2323), "$2a$12$snMKf97fwHK0AdIRJK2Xd.H4BMvDEzwpgrpHcSxuawBc.RCDUjzty" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 40, DateTimeKind.Utc).AddTicks(8796), "$2a$12$K0iqFFI.Zhc801WNv9vLSOzwe95MAIZGO8pQnRh4/edgOaPF0dMp2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 297, DateTimeKind.Utc).AddTicks(5687), "$2a$12$lwwStmcY8cnQiTSWrxHqI.pPE758bw3PJAJWNgu18RGR.fBIht7B2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 565, DateTimeKind.Utc).AddTicks(9034), "$2a$12$QJos6/jd5xw35ZM86Vk9zuRB9U8887qX.2887VDHQrCZD0MJ.NN2O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 48, 91, DateTimeKind.Utc).AddTicks(4474), "$2a$12$aeONcKaEQrmypQcHgHJ5zuFWSj0CxYxdoQlWie85usJUWun99Jfo." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 48, 328, DateTimeKind.Utc).AddTicks(2013), "$2a$12$.DcxjCefoj9NmKRnPlsNiOEYVL.gS.WWhzxIByUqefiA1xqhOAQrG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 48, 567, DateTimeKind.Utc).AddTicks(9808), "$2a$12$PwPuHkHHiUSaRDszYS5h3ORxu0L7SWFxcGM6/cQidw6Sm1EFjfH1y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 48, 807, DateTimeKind.Utc).AddTicks(2851), "$2a$12$iqk15Vxkksapl92FSv4bqO6HSxcFDh6KrBODiqfCYq2bBaV/ujUWW" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5040), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5048), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5051), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5053), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5053) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5055), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5055) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5744), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5745) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5747), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5748) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5750), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5752), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5753) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5755), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5755) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5757), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5760), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5760) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5763), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5765), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5795), new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5795) });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_ComboId",
                table: "IngredientUsages",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_CustomizationId",
                table: "IngredientUsages",
                column: "CustomizationId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_IngredientBatchId",
                table: "IngredientUsages",
                column: "IngredientBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_IngredientId",
                table: "IngredientUsages",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_OrderDetailId",
                table: "IngredientUsages",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_OrderId",
                table: "IngredientUsages",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientUsages");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6031), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6037) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6039), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6041), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5878), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5881), new DateTime(2025, 4, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5891), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 8, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5893), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5894), new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5896), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5898), new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 4, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 2, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5901), new DateTime(2025, 4, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5902), new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5904), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5905), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5907), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5908), new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5910), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 8, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5911), new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5913), new DateTime(2025, 4, 26, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5914), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5916), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5917), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5919), new DateTime(2025, 4, 23, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 27, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5920), new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 10, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5922), new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 10, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5923), new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 10, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5925), new DateTime(2025, 4, 18, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5688), new DateTime(2025, 3, 29, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5691) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5700), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5702), new DateTime(2025, 3, 29, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5703) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5704), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5705), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5706) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5707), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5707) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5708), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5783), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5786), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5787), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5789), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5790), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5792), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5793), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5794) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5795), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5802), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5803), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5804) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5805), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5806), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5808), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5809), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5811), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5812), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5813) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5814), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5815) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5815), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5817), new DateTime(2025, 4, 25, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5575), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5579), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5581), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5582), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5583), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5584), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5586), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5587), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5588), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5589), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5591), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5592), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5593), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5594), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5595), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5597), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5598), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5599), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5600), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5601), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5602), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5603), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5605), 0.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(5606), 0.0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6101), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6102) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6107), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6108) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6110), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6111) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6113), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6116), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6119), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6122), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 28, 991, DateTimeKind.Utc).AddTicks(2559), "$2a$12$RcC.Kx7vqwyxWQr8Xm2N5.Sn59h3yyDGzHRfXeqV4nCa9huExKIVq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 219, DateTimeKind.Utc).AddTicks(2317), "$2a$12$e/N17lFSkSgKNfCDdoFMP.JctdMED6wZQfWkyxQTROEteuXAttjje" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 446, DateTimeKind.Utc).AddTicks(3220), "$2a$12$hbsrFZvmyKxsnTL.DfTCdOhR.mMWFG9fbMRUxSpXEXKVP0SGrqSbG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 673, DateTimeKind.Utc).AddTicks(799), "$2a$12$e38fdNjOKy8SvOGxf5JNTOZn3UjZsgjsSUStBjtfB0kjfMqYgU3Pe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 29, 898, DateTimeKind.Utc).AddTicks(5672), "$2a$12$k5xfSftiCgnZKR28ZbAfPOS1OJAxeOk8bWWyQBQKupW/CIhpTmPyu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 124, DateTimeKind.Utc).AddTicks(3222), "$2a$12$Eztg0Slzbj02sMiHVXNWHe0Ub2f/jVlanU7AAFiKGgJDW3GpieHj2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 349, DateTimeKind.Utc).AddTicks(9465), "$2a$12$6AD8oPwZYfCmU6oT5gvdEOtbyKOqvACTdTbO2f/uCYJzrk.Cksswm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 483, DateTimeKind.Utc).AddTicks(2222), "$2a$12$AFVdQLAlIzf1GEoZlKHszOc1UCOiKdrTH0TwviWEH7iby1WKvfnZC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 709, DateTimeKind.Utc).AddTicks(1185), "$2a$12$NGukswJrUDHbK6NYL5RzYOrLdqQsaJPUI7rYh7/1cJghJpFtcHw0u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 935, DateTimeKind.Utc).AddTicks(7083), "$2a$12$RU5JIc7PNw82k7bODwEL6.8yjeBPfhJeU/JLYKmxjvdLIZthBLEAe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 575, DateTimeKind.Utc).AddTicks(2210), "$2a$12$UTmlTXW0khDq0kQtknyKKu0WureqUmP9/Hdwcr957c3h.jrurFdbG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 30, 800, DateTimeKind.Utc).AddTicks(7506), "$2a$12$UUJ2B2W5Z4F10byCuiwPyOc93z.6bEuDZmNrtYBNbBxvQtH2sLQwa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 28, DateTimeKind.Utc).AddTicks(340), "$2a$12$2OyfOTewmDHo6U31S7sDUOccZlU7IJ8CforYvE9ufUy3cyDpe7SjC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 31, 257, DateTimeKind.Utc).AddTicks(5329), "$2a$12$xjhaarixfVTFypF7dsejbuBnKUkatbiUjz8p1/tcZeLSFC9/.66DO" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1645), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1654), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1654) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1657), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1657) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1659), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1661), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(1661) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6206), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6207) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6209), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6212), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6214), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6215) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6217), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6217) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6219), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6222), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6224), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6225) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6227), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6227) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6229), new DateTime(2025, 4, 28, 1, 29, 32, 176, DateTimeKind.Utc).AddTicks(6230) });
        }
    }
}
