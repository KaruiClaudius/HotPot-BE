using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addnotificationentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TargetId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MessageTemplate = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DefaultTargetType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    UserNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.UserNotificationId);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4325), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4366), new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4374), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4376), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4377), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4378), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4380), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4381), new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 18, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4382), new DateTime(2025, 5, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4384), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4386), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4387), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4388), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4390), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4391), new DateTime(2025, 5, 11, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4392), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 21, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4394), new DateTime(2025, 5, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4395), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4396), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4398), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4399), new DateTime(2025, 5, 9, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 12, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4400), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4402), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4403), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287), new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4404), new DateTime(2025, 5, 4, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4287) });

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
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 22, 24, 50, 762, DateTimeKind.Utc).AddTicks(4100));

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedAt",
                table: "Notifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetType_TargetId",
                table: "Notifications",
                columns: new[] { "TargetType", "TargetId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId_IsRead",
                table: "UserNotifications",
                columns: new[] { "UserId", "IsRead" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationTemplates");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7963), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7967) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7968), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7969) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7776), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7779), new DateTime(2025, 5, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7786), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7788), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7789), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7791), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7792), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 17, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7794), new DateTime(2025, 5, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 16, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7795), new DateTime(2025, 5, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7796), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7798), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7799), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7801), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7802), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 26, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7804), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 22, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7805), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 19, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7837), new DateTime(2025, 5, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7839), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7840), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7842), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 11, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7843), new DateTime(2025, 5, 7, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 10, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7844), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7846), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7847), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7849), new DateTime(2025, 5, 2, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7679), new DateTime(2025, 4, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7688), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7690), new DateTime(2025, 4, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7692), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7692) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7693), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7695), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7696), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7698), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7698) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7699), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7700), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7702), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7702) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7703), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7705), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7705) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7706), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7708), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7712) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7713), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7714) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7715), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7716), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7718), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7719), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7721), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7721) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7722), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7723) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7723), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7725), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7726), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7728), new DateTime(2025, 5, 9, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7728) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7598));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8029), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8034), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8037), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8040), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8042), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8045), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8047), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8048) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 28, 302, DateTimeKind.Utc).AddTicks(9819), "$2a$12$rzsMsSnPdcCBHR1oey7PM.2SgC0lHeNhiG8DfY1e/GaH1sI94rfgy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 28, 538, DateTimeKind.Utc).AddTicks(2749), "$2a$12$Tkf.twe2M.wPh6EMRhHqSuNbOiUH.987tANio7YsCPBX1hBcy0Z1i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 28, 777, DateTimeKind.Utc).AddTicks(159), "$2a$12$ainBNk.WmmoFsXvZov/LCOsyKExeRsJWhalswcZJkjxeKv2AN3tt6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 13, DateTimeKind.Utc).AddTicks(8510), "$2a$12$NnahWZPaaz/lMoip78eVL.RkAe8wmHbIEqrMuDO2Wl3H9PAunE5/i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 250, DateTimeKind.Utc).AddTicks(7412), "$2a$12$AFqx9qhcJU9L.JghK/DmTuqzSBwziJxjvqYbVtz.3V6dzi7EKRi4S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 485, DateTimeKind.Utc).AddTicks(9749), "$2a$12$6vZE/QBR49Fk.0Na5.8kYeScT1YGol/fbjor7QUH.G8V7YwQOrGxK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 720, DateTimeKind.Utc).AddTicks(7354), "$2a$12$D/xJlrdIaAFRAC2fPqTMdejolw.TN/lBNEnCtqamdGM8ieIa7QNFq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 895, DateTimeKind.Utc).AddTicks(6094), "$2a$12$7NEWxoBmQ6ivkg1V5ivNUudlWCGAHdTd4dDN4TFEAI43t3lskJOyy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 134, DateTimeKind.Utc).AddTicks(881), "$2a$12$gWgP0SENFqaK3QaqGOpI/u28YcG3xI5/w1UdXAXXf81EHgorcL5t6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 373, DateTimeKind.Utc).AddTicks(6715), "$2a$12$GR9A7kCGztPd.6awzBGwJeaG1y81xRZX5093.4XhWzvxHclKT.65." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 29, 956, DateTimeKind.Utc).AddTicks(2608), "$2a$12$gIOwoBMCXEich9SPwLnSxOv5JrLWgKGXSEVZxHYcRyyAgETzurlXa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 191, DateTimeKind.Utc).AddTicks(9205), "$2a$12$2SKIG.3Vf5KKaeu3XEamhOMgLwge8AbqhUSHH1jk4XjiWuEGm16Ya" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 426, DateTimeKind.Utc).AddTicks(794), "$2a$12$GbYP4f.gJmsRLFg7ra4OP.RtvAxuKVtvZSQgprw.HTJs7P5stJw3." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 30, 660, DateTimeKind.Utc).AddTicks(7087), "$2a$12$odU0424ywM7k45zMk5FzgOoHi2cODIP.8rXfwS8RTwc2RvIFcbFTm" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7403), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7403) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7408), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7411), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7413), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7415), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8112), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8115), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8116) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8118), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8118) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8120), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8122), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8125), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8125) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8127), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8127) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8129), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8131), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8132) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8134), new DateTime(2025, 5, 12, 19, 35, 31, 612, DateTimeKind.Utc).AddTicks(8134) });
        }
    }
}
