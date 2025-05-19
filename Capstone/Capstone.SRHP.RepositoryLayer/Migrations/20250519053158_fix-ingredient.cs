using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixingredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementValue",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "PackagingId",
                table: "SellOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitSize",
                table: "IngredientPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IngredientPackagings",
                columns: table => new
                {
                    PackagingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPackagings", x => x.PackagingId);
                    table.ForeignKey(
                        name: "FK_IngredientPackagings_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6857), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6866), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 2, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6727), 12500, new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 12500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 2, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6730), 2, 10000, new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 10000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 29, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6738), 3, 11250, new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 11250 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6739), 4, 7000, new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 7000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6741), 5, 18000, new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 18000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6742), 6, 6000, new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 6000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 24, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6744), 7, 16000, new DateTime(2025, 5, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 16000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 23, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6745), 8, 10500, new DateTime(2025, 5, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 10500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6747), 9, 7500, new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 7500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 7, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6748), 10, 15000, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 15000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 8, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6750), 11, 9000, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 9000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 7, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6751), 12, 13750, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 13750 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6753), 13, 12000, new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 12000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 2, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6755), 14, 8750, new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 8750 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 29, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6757), 15, 6000, new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 6000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 5, 26, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6758), 16, 5250, new DateTime(2025, 5, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 5250 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6759), 17, 12500, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 12500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6761), 18, 12500, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 12500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6762), 19, 12500, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 12500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 6, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6764), 20, 12500, new DateTime(2025, 5, 14, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 12500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 8, 17, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6765), 21, 6000, new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 6000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 11, 15, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6767), 22, 7500, new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 7500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 11, 15, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6768), 23, 4500, new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 4500 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519053158", new DateTime(2025, 11, 15, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6770), 24, 6000, new DateTime(2025, 5, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 6000 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BATCH-20250519114148", new DateTime(2025, 6, 9, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6771), 1, 7500, new DateTime(2025, 5, 18, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6533), 7500 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6409), new DateTime(2025, 4, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6411), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6420), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6421), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6422), new DateTime(2025, 4, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6422), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6423), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6424), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6425), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6425), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6426), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6427), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6427), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6428), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6429), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6430), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6430), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6431), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6432), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6432), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6433), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6434), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6435), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6435), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6436), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6437), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6437), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6438), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6439), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6446), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6447), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6447), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6448), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6449), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6449), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6450), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6451), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6451), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6452), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6453), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6454), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6454), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6455), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6456), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6456), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6457), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6458), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6458), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6459), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6460), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "UnitSize" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6461), new DateTime(2025, 5, 16, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6461), 0 });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6928), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6932), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6933) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6935), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6936) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6938), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6940), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6943), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6946), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 54, 655, DateTimeKind.Utc).AddTicks(7537), "$2a$12$j2mE2Xf1AxjuzsH/LdWpl.AmP.zg1R60VlrtDVz6GNs0OxscqncDm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 54, 905, DateTimeKind.Utc).AddTicks(347), "$2a$12$ysWQPWok7K83MB2YUSEHvuHshDuw4pC50JcKtMT8Vz.HpYasP3pfy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 157, DateTimeKind.Utc).AddTicks(7875), "$2a$12$Y2IK.Ay.RU3M5G/WsEw8DuXPOuTd7SrQ/CCVL/lM9zzg/o9YVbOkG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 390, DateTimeKind.Utc).AddTicks(8527), "$2a$12$oGIbFrEJx8eBsaDFK0i9vOPhcH7bg9rWI2U4kT4mLM1hVWLjqe5Sy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 616, DateTimeKind.Utc).AddTicks(5793), "$2a$12$Dus2q05fNuSfZAIwK62elO7nnglKD8FBFOhamtSAFItO56wxv/zEW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 55, 842, DateTimeKind.Utc).AddTicks(2998), "$2a$12$7cdGT1HmeIdkcXtgvmwFK.PN1o.PSg45Rsd4VcZ8.DipfqJKo1fFO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 68, DateTimeKind.Utc).AddTicks(5409), "$2a$12$BN.nSNZyp4ydUjpP4hhZmusaVpi3P0OI8c.AwD7.0GPrtFl4eyeJ6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 251, DateTimeKind.Utc).AddTicks(2003), "$2a$12$k0dYQrJ9cV0Qf0oSy498p.UTIL60cyuXHufwWEXzTAyv2SnOdYwNG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 502, DateTimeKind.Utc).AddTicks(7587), "$2a$12$8IvIuQHsT4gupdJxUGtK2ugs70n7Fqj0Ox1wBm2a5AlNixkRSrXvq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 753, DateTimeKind.Utc).AddTicks(769), "$2a$12$tPi44WSLeUpnfpNlyIFvzuFDLmF174iFcHy5ksP8Gy/TkFvSsZDKK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 294, DateTimeKind.Utc).AddTicks(2143), "$2a$12$R5x.HyJvV2zvnUoNYwE2c.73cxVIM3y2azelpGH3MEt9GOsMPfa/K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 520, DateTimeKind.Utc).AddTicks(6458), "$2a$12$jL/D3/LbGhPYH2PzuRaQK.FEQmyTnWSxnjYf.jhFLpNFilJ2bEaRS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 56, 763, DateTimeKind.Utc).AddTicks(4599), "$2a$12$O3havNcnLuR8PWpOE/beHOq5fg7XxioKrYERNK5K72hmiNB8IIu9i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 57, 4, DateTimeKind.Utc).AddTicks(2495), "$2a$12$TGWDiSt8yPsVUfBB6WOAa.XWPdHdNiy74UiIAOb1hfJjP/0O5v.tO" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6130), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6135), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6137), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6139), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6141), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7000), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7003), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7004) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7006), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7008), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7008) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7010), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7012), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7014), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7015) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7017), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7017) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7019), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7021), new DateTime(2025, 5, 19, 12, 31, 58, 9, DateTimeKind.Utc).AddTicks(7021) });

            migrationBuilder.CreateIndex(
                name: "IX_SellOrderDetails_PackagingId",
                table: "SellOrderDetails",
                column: "PackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPackagings_IngredientId",
                table: "IngredientPackagings",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellOrderDetails_IngredientPackagings_PackagingId",
                table: "SellOrderDetails",
                column: "PackagingId",
                principalTable: "IngredientPackagings",
                principalColumn: "PackagingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellOrderDetails_IngredientPackagings_PackagingId",
                table: "SellOrderDetails");

            migrationBuilder.DropTable(
                name: "IngredientPackagings");

            migrationBuilder.DropIndex(
                name: "IX_SellOrderDetails_PackagingId",
                table: "SellOrderDetails");

            migrationBuilder.DropColumn(
                name: "PackagingId",
                table: "SellOrderDetails");

            migrationBuilder.DropColumn(
                name: "UnitSize",
                table: "IngredientPrices");

            migrationBuilder.AddColumn<double>(
                name: "MeasurementValue",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4559), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4566), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4568), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BEEF-2025-04-01", new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4325), 50, new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 50 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BEEF-2025-04-15", new DateTime(2025, 6, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4366), 1, 30, new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "LAMB-2025-04-01", new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4374), 2, 40, new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 40 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "PORK-2025-04-01", new DateTime(2025, 5, 24, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4376), 3, 45, new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 45 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SHRIMP-2025-04-01", new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4377), 4, 35, new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 35 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "FISHBALL-2025-04-01", new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4378), 5, 60, new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 60 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SQUID-2025-04-01", new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4380), 6, 30, new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "CABBAGE-2025-04-01", new DateTime(2025, 5, 19, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4381), 7, 40, new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 40 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SPINACH-2025-04-01", new DateTime(2025, 5, 18, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4382), 8, 35, new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 35 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "CORN-2025-04-01", new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4384), 9, 30, new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "UDON-2025-04-01", new DateTime(2025, 7, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4386), 10, 50, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 50 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "GLASS-2025-04-01", new DateTime(2025, 8, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4387), 11, 45, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 45 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "RAMEN-2025-04-01", new DateTime(2025, 7, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4388), 12, 55, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 55 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "TOFU-2025-04-01", new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4390), 13, 40, new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 40 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "FRIEDTOFU-2025-04-01", new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4391), 14, 35, new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 35 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SHIITAKE-2025-04-01", new DateTime(2025, 5, 24, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4392), 15, 30, new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "ENOKI-2025-04-01", new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4394), 16, 35, new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 35 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SICHUAN-2025-04-01", new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4395), 17, 25, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 25 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "TOMATO-2025-04-01", new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4396), 18, 25, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 25 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "MUSHBROTH-2025-04-01", new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4398), 19, 25, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 25 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "BONE-2025-04-01", new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4399), 20, 25, new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 25 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SESAME-2025-04-01", new DateTime(2025, 8, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4400), 21, 30, new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "GARLICSOY-2025-04-01", new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4402), 22, 30, new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "CHILI-2025-04-01", new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4403), 23, 30, new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "ReceivedDate", "RemainingQuantity" },
                values: new object[] { "SHACHA-2025-04-01", new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4404), 24, 30, new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), 30 });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4205), new DateTime(2025, 4, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4223), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4225), new DateTime(2025, 4, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4226), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4228), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4229), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4230), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4231), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4233), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4234), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4235), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4237), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4239), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4241), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4249), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4250), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4251), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4253), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4254), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4255), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4257), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4258), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4259), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4260), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4262), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4066), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4073), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4075), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4076), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4077), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4079), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4080), 400.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4081), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4082), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4083), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4085), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4086), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4087), 300.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4088), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4089), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4090), 150.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4092), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4093), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4094), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4095), 500.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4096), 200.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4097), 250.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4098), 150.0 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "MeasurementValue" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4100), 200.0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4646), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4651), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4654), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4657), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4659), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4662), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4664), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 47, 496, DateTimeKind.Utc).AddTicks(2337), "$2a$12$o1vFTTTf7bZPlIkaUL8DpeEOGZFQWt1l5nF1PeoXwxk1dOQs.QwKm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 47, 727, DateTimeKind.Utc).AddTicks(1077), "$2a$12$tWtB0nBntY29WnWNzCK.GOwK22lcZbwkhUg3JWzxVKQG4/goNmf5a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 47, 965, DateTimeKind.Utc).AddTicks(1677), "$2a$12$tUHI7qOGhi9LbKATAsC1s.z4cgxm39LqV.LMYK9Mh3ZyLyJ0a64Uu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 202, DateTimeKind.Utc).AddTicks(9850), "$2a$12$qfXdfyUyOZ3REfAJCrhSeus0ZFGuJQb3bLKc8cVrjjn4OulBsuY72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 437, DateTimeKind.Utc).AddTicks(9708), "$2a$12$mjhTpsGeia7qKMvP6uRZ3.8f6EUDNJvy5xlChlwISw3RBMGeYoRBu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 669, DateTimeKind.Utc).AddTicks(3021), "$2a$12$X3KH7DIsXBQtXK3zBh.owufmKxnGkibv9LxHCcYBYlM.PyBp9hld2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 48, 900, DateTimeKind.Utc).AddTicks(485), "$2a$12$irEV1fMe74ixXqd8wj/b0.VG5bXAvQqJwz2FgRT51.KpQRNiF6lAG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 70, DateTimeKind.Utc).AddTicks(193), "$2a$12$OCOzquFakXWaALCS7FGCEe90iqPkYld.PTiwTApCJ2WGqBwids8Fe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 301, DateTimeKind.Utc).AddTicks(1939), "$2a$12$sxSikHu2iSKi.iMPa4Ayk.Yd2l.tBGLOMf/5wn9B53tsgCiQsABwy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 533, DateTimeKind.Utc).AddTicks(4279), "$2a$12$hcouVy/uf61glGWS7kRkSeJaJkCLyKBagFrgCfPyq4MWOuUUTeeRS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 131, DateTimeKind.Utc).AddTicks(1552), "$2a$12$6Evsy6kQBtiDUvG6NU.GQ.wKquItlF1Oh1T9QoZYG5e3PKDecfcoC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 365, DateTimeKind.Utc).AddTicks(1731), "$2a$12$/lAgNtvrmwuHrbkt0ifgAuJzCa9hebPiBg1EOTGtsq0rjOWb.DNc6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 598, DateTimeKind.Utc).AddTicks(3253), "$2a$12$27MXt2PzlzK1j/YBWXAKf.9JJoi7YAeSjTYdNs.3SK./QlrD0gQ7K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 49, 835, DateTimeKind.Utc).AddTicks(4165), "$2a$12$cNzTOdDep6KzFBBNi3CCUuE2Z9e0EdTfmrHHh0y.DYhJp2DxtlR/W" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3826), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3833), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3835), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3836) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3839), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4756), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4760), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4762), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4764), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4765) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4767), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4769), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4771), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4773), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4775), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4777), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4778) });
        }
    }
}
