using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StaffPickupAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffAssignments",
                columns: table => new
                {
                    StaffAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAssignments", x => x.StaffAssignmentId);
                    table.ForeignKey(
                        name: "FK_StaffAssignments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffAssignments_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAssignments_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5392), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5398), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5399), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5227), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5230), new DateTime(2025, 5, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5242), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5244), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5245), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5247), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5248), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 17, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5249), new DateTime(2025, 5, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 16, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5251), new DateTime(2025, 5, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5253), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5254), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5255), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5257), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5259), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5260), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5261), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5263), new DateTime(2025, 5, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5264), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5266), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5267), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5269), new DateTime(2025, 5, 7, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5270), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5272), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5273), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5275), new DateTime(2025, 5, 2, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5066), new DateTime(2025, 4, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5082), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5085), new DateTime(2025, 4, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5088), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5090), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5092), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5093) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5094), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5095), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5102) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5103), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5104) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5105), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5106), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5108), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5109), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5110), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5112), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5119), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5156), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5158), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5160), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5161), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5163), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5163) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5164), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5165) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5166), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5167), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5169), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5170), new DateTime(2025, 5, 9, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5480), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5489), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5492), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5493) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5495), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5498), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5501), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5503), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 122, DateTimeKind.Utc).AddTicks(6636), "$2a$12$Av9EK9cSPixbrOky6onSe.HdFuFK1MRaXfpyHKbdchkHE20cjtwGC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 402, DateTimeKind.Utc).AddTicks(3617), "$2a$12$AINQpfxpCnDFqGWTuMdW.eElrEHBY7XOlwxTSJmSc09nD6OitF/am" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 663, DateTimeKind.Utc).AddTicks(5306), "$2a$12$oWlZvhfQMQIHHzzsIs.NquY57lyc/dcvu1IkJ9D641tSTlE0vfaZK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 35, 932, DateTimeKind.Utc).AddTicks(1133), "$2a$12$TmJ4RyTzDHeU.4lvj.JElu5ySjaAVlXWgbvlvMpUEE98ssKVps4fK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 191, DateTimeKind.Utc).AddTicks(2987), "$2a$12$/1rQYmXT5vc1o/L1gRtpHe00IZCj41zbBJU/3kMdFi5e.7rPhOc/u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 446, DateTimeKind.Utc).AddTicks(8664), "$2a$12$SPVh5362DwW1Ou1cNGw8A.noAVHTT/S1InbJAqCJyjoFU.ooako2a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 709, DateTimeKind.Utc).AddTicks(6886), "$2a$12$JhGr01udP4PtUZtEhxO2P.crXvQtBAkmmDcqMwtkp5V3yGDOBynhS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 149, DateTimeKind.Utc).AddTicks(4361), "$2a$12$uqqn4S92rW2gfMTyla4AiupnrXfTYQ7roLC9.YyJyEyve65z75O4G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 427, DateTimeKind.Utc).AddTicks(1484), "$2a$12$LLSnt81MaF./YuFAQBLwiezRg12MrpoYGLJXpQJZNvgiVxsxxZL0i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 690, DateTimeKind.Utc).AddTicks(6447), "$2a$12$l/N6oVocJL6pv.vb6e5CJeidsCJVjVCOJW7.sTma7fZ7vb4dDCRCu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 36, 971, DateTimeKind.Utc).AddTicks(7149), "$2a$12$KkKP8DXg9aM8gCjuFLrmQeQ84H7s.h/VYyK1zXtCy4lJLvz6QrsfC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 37, 238, DateTimeKind.Utc).AddTicks(4883), "$2a$12$f3OBrcEsDC6jRxYMG2pTUOK3aS9ITHB7apDUNwxxbPYppOfnXZkzS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 37, 548, DateTimeKind.Utc).AddTicks(6966), "$2a$12$eupqe43WzI9ueKDJemAPqud8OyDIvL045F/ALrnIT01MWUgLQFthm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 37, 858, DateTimeKind.Utc).AddTicks(5885), "$2a$12$S2iuPS/jXgSYOxYSmwDpd.IpwSMWLyoZsGAzDdW8wQN2NnClehVm." });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4641), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4642) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4651), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4743), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4744) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4747), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4750), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5575), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5578), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5578) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5667), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5670), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5672), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5672) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5674), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5675) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5677), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5679), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5681), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5684), new DateTime(2025, 5, 12, 18, 17, 38, 953, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_UserId",
                table: "StaffPickupAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAssignments_ManagerId",
                table: "StaffAssignments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAssignments_OrderId",
                table: "StaffAssignments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAssignments_StaffId",
                table: "StaffAssignments",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffPickupAssignments_Users_UserId",
                table: "StaffPickupAssignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffPickupAssignments_Users_UserId",
                table: "StaffPickupAssignments");

            migrationBuilder.DropTable(
                name: "StaffAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StaffPickupAssignments_UserId",
                table: "StaffPickupAssignments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StaffPickupAssignments");

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
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 2, 20, 49, 828, DateTimeKind.Utc).AddTicks(5238));

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
        }
    }
}
