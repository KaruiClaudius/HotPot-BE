using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleToRentOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderSize",
                table: "RentOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VehicleAssignedDate",
                table: "RentOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "RentOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleNotes",
                table: "RentOrders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VehicleReturnedDate",
                table: "RentOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4056), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4062), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4063), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 13, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3901), "FPT", new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3904), "FPT", new DateTime(2025, 5, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 13, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3912), "FPT", new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 9, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3914), "FPT", new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3916), "FPT", new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3917), "FPT", new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3919), "FPT", new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 4, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3920), "FPT", new DateTime(2025, 5, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 3, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3922), "FPT", new DateTime(2025, 5, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3923), "FPT", new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 7, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3925), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 8, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3926), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 7, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3928), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3929), "FPT", new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 13, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3931), "FPT", new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 9, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3932), "FPT", new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 6, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3934), "FPT", new DateTime(2025, 5, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3935), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3937), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3939), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 6, 29, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3940), "FPT", new DateTime(2025, 5, 25, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 8, 28, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3941), "FPT", new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 11, 26, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3943), "FPT", new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 11, 26, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3944), "FPT", new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BATCH-20250530095106", new DateTime(2025, 11, 26, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3946), "FPT", new DateTime(2025, 5, 20, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3593), new DateTime(2025, 4, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3605), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3606), new DateTime(2025, 4, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3608), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3609), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3611), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3611) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3612), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3613) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3614), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3615), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3616), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3617) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3618), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3619), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3621), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3621) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3622), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3623), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3636), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3637) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3637), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3638) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3639), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3640), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3642) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3643), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3645), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3646), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3647), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3649), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3649) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3650), new DateTime(2025, 5, 27, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4127), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4133), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4136), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4138), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4141), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4144), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4146), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 66, DateTimeKind.Utc).AddTicks(9569), "$2a$12$Pk2OwM90vZgCqI06UoPJheJZdQDXPAKRqfPNSWV4dDaP7LKxRPizW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 301, DateTimeKind.Utc).AddTicks(8624), "$2a$12$giEVyKbmqBPqUl9uU1BF3OK9M3EnzWCDK5P/IQ4Lt3QfVXobVM.D." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 540, DateTimeKind.Utc).AddTicks(1077), "$2a$12$TWNL0OR18.Gkd8D/HNqKcOj.bEKfX.iV41t.IvoBGbeKCghbbqUwe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 3, 774, DateTimeKind.Utc).AddTicks(7904), "$2a$12$ZxPppLKyitnw/8W3gIOmYO2WddJOAO25D/m4B1aXxfTmQXfQsXCQe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 9, DateTimeKind.Utc).AddTicks(5222), "$2a$12$SgwYACuWVi08h.DDAiYuv.PcfT1a2VRdjwUR.PJMHf2ILaHJWgxSC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 245, DateTimeKind.Utc).AddTicks(7308), "$2a$12$b9rXNF6NYajM5BiDkohkm.Q3Uv.ft8pDwRUfSULq2oFWCUcjx8F3S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 485, DateTimeKind.Utc).AddTicks(4842), "$2a$12$8BVuKit0eZufsnMZfkzDxOa57sfZ1Gij5hZP8qbBHCfQyzxaJujYy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 656, DateTimeKind.Utc).AddTicks(8297), "$2a$12$7/kAdqVjAI4c03fy14vvbOUldXAHcMfMBGfA47kbOrlQhZaA151Om" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 895, DateTimeKind.Utc).AddTicks(8235), "$2a$12$uJbhIYhyviDuWtSoJJfPW.e7yBCBu7wroev15aDn8i/RN6bCzsXFK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 135, DateTimeKind.Utc).AddTicks(7256), "$2a$12$ucmP.wJuhXKg0M/XQGvLQOIEIz3GbJc7psNvbd4FPpLVMpfg7EZ2." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 718, DateTimeKind.Utc).AddTicks(5627), "$2a$12$p8aJmEh7kAhBdmzOqDxyeeigs6xsY4C9nqvP6tTxau2wZYgNw9zPq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 4, 951, DateTimeKind.Utc).AddTicks(3262), "$2a$12$sN54HLWBh8MUY7m7XUuW3uSNubeHQrYhi4gvhUHs.ndOD/IohRsy6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 185, DateTimeKind.Utc).AddTicks(936), "$2a$12$s8Iqqe6oq.JhHimdTviSleuUkFcRezsrt0W7SdS9aiRgj.k5zoRa6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 5, 418, DateTimeKind.Utc).AddTicks(9308), "$2a$12$7j7KVs0..cF.k7YvnfUVSObDxwqfTCQLqhdMqjXMLGIlNFVOIgiHK" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3302), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3303) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3308), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3308) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3310), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3311) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3312), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3314), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4211), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4213), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4216), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4218), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4220), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4223), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4225), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4227), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4229), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4232), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4234), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4236), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4241), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4275), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4277), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4277) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4286), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4289), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4293), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4294) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4296), new DateTime(2025, 5, 30, 9, 51, 6, 374, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.CreateIndex(
                name: "IX_RentOrders_VehicleId",
                table: "RentOrders",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_Vehicles_VehicleId",
                table: "RentOrders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_Vehicles_VehicleId",
                table: "RentOrders");

            migrationBuilder.DropIndex(
                name: "IX_RentOrders_VehicleId",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "OrderSize",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "VehicleAssignedDate",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "VehicleNotes",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "VehicleReturnedDate",
                table: "RentOrders");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4090), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4096), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4098), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BEEF-2025-04-01", new DateTime(2025, 6, 7, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3899), null, new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BEEF-2025-04-15", new DateTime(2025, 6, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3903), null, new DateTime(2025, 5, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "LAMB-2025-04-01", new DateTime(2025, 6, 7, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3912), null, new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "PORK-2025-04-01", new DateTime(2025, 6, 3, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3914), null, new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SHRIMP-2025-04-01", new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3915), null, new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "FISHBALL-2025-04-01", new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3917), null, new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SQUID-2025-04-01", new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3919), null, new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "CABBAGE-2025-04-01", new DateTime(2025, 5, 29, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3920), null, new DateTime(2025, 5, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SPINACH-2025-04-01", new DateTime(2025, 5, 28, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3922), null, new DateTime(2025, 5, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "CORN-2025-04-01", new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3928), null, new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "UDON-2025-04-01", new DateTime(2025, 7, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3930), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "GLASS-2025-04-01", new DateTime(2025, 8, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3932), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "RAMEN-2025-04-01", new DateTime(2025, 7, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3933), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "TOFU-2025-04-01", new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3935), null, new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "FRIEDTOFU-2025-04-01", new DateTime(2025, 6, 7, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3937), null, new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SHIITAKE-2025-04-01", new DateTime(2025, 6, 3, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3939), null, new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "ENOKI-2025-04-01", new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3940), null, new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SICHUAN-2025-04-01", new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3942), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "TOMATO-2025-04-01", new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3943), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "MUSHBROTH-2025-04-01", new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3945), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "BONE-2025-04-01", new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3947), null, new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SESAME-2025-04-01", new DateTime(2025, 8, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3948), null, new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "GARLICSOY-2025-04-01", new DateTime(2025, 11, 20, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3950), null, new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "CHILI-2025-04-01", new DateTime(2025, 11, 20, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3951), null, new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BatchNumber", "BestBeforeDate", "CreatedAt", "ProvideCompany", "ReceivedDate" },
                values: new object[] { "SHACHA-2025-04-01", new DateTime(2025, 11, 20, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3953), null, new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3712), new DateTime(2025, 4, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3716) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3725), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3727), new DateTime(2025, 4, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3729), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3730), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3732), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3734), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3736), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3737), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3739), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3739) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3740), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3741) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3742), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3744), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3800), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3802), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3811), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3811) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3812), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3814), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3816), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3816) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3819), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3820), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3822), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3824), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3825), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3827), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 13, 183, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 13, 183, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 13, 183, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 13, 183, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4179), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4183), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4187), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4190), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4196), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4199), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 13, 183, DateTimeKind.Utc).AddTicks(7994), "$2a$12$U35cbwNeuZcWG8oioyT.O.EZUJcF7s.rLvEuuWxl2TXrb1X.9ASEC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 13, 418, DateTimeKind.Utc).AddTicks(2484), "$2a$12$0Xt/Io92UcNRoUG7pKvhT.yRvXSPjoDDkGcCzShfP4U6L1hNwoEGe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 13, 653, DateTimeKind.Utc).AddTicks(4347), "$2a$12$9KVYuoiVoTV2UdXIqV0VsuWhhfSkoKKRdEXrTFQ6q4E7k9RfbZ.S6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 13, 887, DateTimeKind.Utc).AddTicks(1081), "$2a$12$ZMI.vIrtYooUBqwZY6SP.OfvUWEpD.lgkuqCHm/0tl2eb5OA0aapK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 14, 119, DateTimeKind.Utc).AddTicks(862), "$2a$12$b8XT4pL3tMw2yZMswPxhPe7fspKqonqgM6IWE9UoEzpFbR/8ow3a6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 14, 350, DateTimeKind.Utc).AddTicks(3781), "$2a$12$oO7WjZ3Nuj2HyV18lXbaUe5HF4f5UBieReofLvqdhkkndHA06EOxi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 14, 581, DateTimeKind.Utc).AddTicks(9680), "$2a$12$l5G.FfseQDYMkjY1GziZOeN/SWKnXnIvK54zxNXxHXWRuMGH3RWY." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 15, 751, DateTimeKind.Utc).AddTicks(2152), "$2a$12$xC/Yp4iClcSw60KXi7yRcOxjBTixdhK3ZxzbArj242an9NVGGvFAC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 15, 996, DateTimeKind.Utc).AddTicks(6889), "$2a$12$ZNRQHaRn7Xkr/2HzE8ci/uQOpI5N/vQQAVXcVrFXo39r.rb.TZiEu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 233, DateTimeKind.Utc).AddTicks(7448), "$2a$12$80tVNZO5Ys3j2rAAowYFretMqzPWXMbCGeMIBFOrxRmv05d0.Tvtu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 14, 816, DateTimeKind.Utc).AddTicks(9606), "$2a$12$gGZR97EYIQOPRVvrdHqkSury22j6UdGWF5W9Y7JTGWqHRluaPtVrq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 15, 54, DateTimeKind.Utc).AddTicks(8448), "$2a$12$T4YFlX6JGrhjo6CMN3lq9ec0Xnr87gySqPXiZnX7vfzTFm.6xjg2C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 15, 286, DateTimeKind.Utc).AddTicks(3824), "$2a$12$sDdXPbBpRHlos9zYkSfuVOGayxDkyOv3aF1XUStiWp5fctEBDgcCi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 15, 518, DateTimeKind.Utc).AddTicks(6571), "$2a$12$DGo80MYzC4sPdTgm9rCSruFO.RJPouRQtM6ayZ0ZYE7l3GUDRg5rC" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3385), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3386) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3394), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3396), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3397) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3399), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3399) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3401), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3402) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4343), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4347), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4348) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4350), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4353), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4355), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4356) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4358), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4358) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4360), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4363), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4366), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4368), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4371), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4372) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4374), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4374) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4376), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4377) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4379), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4382), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4382) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4384), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4385) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4398), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4398) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4400), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4401) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4403), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4406), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4408), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(4409) });
        }
    }
}
