using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addIsBroadCast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBroadcast",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 7, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3899), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3903), new DateTime(2025, 5, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 7, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3912), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3914), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3915), new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3917), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3919), new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 29, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3920), new DateTime(2025, 5, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3922), new DateTime(2025, 5, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3928), new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3930), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3932), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3933), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3935), new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 7, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3937), new DateTime(2025, 5, 21, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 3, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3939), new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 31, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3940), new DateTime(2025, 5, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3942), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3943), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3945), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 23, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3947), new DateTime(2025, 5, 19, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 22, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3948), new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 20, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3950), new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 20, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3951), new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 20, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 5, 24, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3953), new DateTime(2025, 5, 14, 11, 9, 16, 472, DateTimeKind.Utc).AddTicks(3859) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBroadcast",
                table: "ChatMessages");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4413), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4419), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoggedDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4420), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4421) });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 1,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4226), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 2,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4228), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 3,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4235), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 4,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4236), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 5,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4238), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 6,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4239), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 7,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4240), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 8,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 28, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4242), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 9,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 27, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4243), new DateTime(2025, 5, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 10,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4244), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 11,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4246), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 12,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4247), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 13,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4248), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 14,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4282), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 15,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 6, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4284), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 16,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 2, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4285), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 17,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 5, 30, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4286), new DateTime(2025, 5, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 18,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4288), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 19,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4289), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 20,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4290), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 21,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 5, 18, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 22,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 21, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4293), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 23,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4294), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 24,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4295), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientBatchs",
                keyColumn: "IngredientBatchId",
                keyValue: 25,
                columns: new[] { "BestBeforeDate", "CreatedAt", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 11, 19, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4297), new DateTime(2025, 5, 13, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4129), new DateTime(2025, 4, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4137), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4138), new DateTime(2025, 4, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4140), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4141), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4142), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4144), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4145), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4146), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4147), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4149), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4150), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4151), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4153), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4154), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4159), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4160), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4161), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4162), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4164), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4165), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4166), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4167) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4168), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4169), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4170), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4171), new DateTime(2025, 5, 20, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4172) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3993));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4477), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4481), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4484), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4484) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4486), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4489), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4491), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4492) });

            migrationBuilder.UpdateData(
                table: "SizeDiscounts",
                keyColumn: "SizeDiscountId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4494), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4494) });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 44, DateTimeKind.Utc).AddTicks(3682), "$2a$12$XHluTNYatBuVc7g8dyEq7O7KCPknOm3LChQHK887m2yhveUO536g." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 274, DateTimeKind.Utc).AddTicks(2095), "$2a$12$2/pxmCKL8hWyBDj2jDx9auCD/PVRZjQV2MgVmYoh6y4GxYaA1c8AO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 504, DateTimeKind.Utc).AddTicks(985), "$2a$12$59fPysGPv7f6RpCwPUde9OaHVqUxiucKPYNIWGSph4ENTzEcxPQjK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 734, DateTimeKind.Utc).AddTicks(75), "$2a$12$.wL5px9IYgxeg.qw7yyR..31zZyB3IeP3w8HN0P96y2KNbStzN2R." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 4, 957, DateTimeKind.Utc).AddTicks(1163), "$2a$12$hox.Vctbkuro/fmu1v8pT.PHeCvz5ysSq4JEd.iJd1N29lfI.vO7e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 180, DateTimeKind.Utc).AddTicks(7453), "$2a$12$xEa2wBSLYKiMOb3u7/5mBuVRy9xZxA0kU449JCIWZS/wTvMxqcdDy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 404, DateTimeKind.Utc).AddTicks(3243), "$2a$12$of4ZRZ./zCmIlY9AAq.tBeSjJbNZWfcV8RZbQhNUcQUqzQk72i1uq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 515, DateTimeKind.Utc).AddTicks(1303), "$2a$12$8.LtYaY8jb2vgtI6yE3A.Ogj7eU/nqaVEcgZRxJJSn679ny4L/bRG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 736, DateTimeKind.Utc).AddTicks(6097), "$2a$12$27l2rfAb3nklxq1MAwseju7AlARBArYocANGjkqE9Oxt0fnUY5ZSm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 956, DateTimeKind.Utc).AddTicks(9213), "$2a$12$qMsnfZ/qPHPFLgnCq.lHP.zplwrEahaJnIjztCqSs9.rovZd7KWYe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 626, DateTimeKind.Utc).AddTicks(8354), "$2a$12$jyjf.4E63jKtthjwxb0z4ek1kYQN5Z9e3Advn3AiQexDqMT5xAjmu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 5, 846, DateTimeKind.Utc).AddTicks(4873), "$2a$12$xJqiaQckIVHDw6VkbyYcIOh0pu7Ul1JQpXaazP1v/J5X80Nq9cR/q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 68, DateTimeKind.Utc).AddTicks(3606), "$2a$12$NgK/o0SnPp8So5csTuqAR.gGxeb13AajoXzdxhCrzewIhtjM5d282" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 6, 292, DateTimeKind.Utc).AddTicks(9405), "$2a$12$/cGG4dpPR1IXA2Fsl8nsROdIHGpxM4KGFhWKz8iEcRfsb74s21tPK" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3857), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3862), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3864), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3865) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3866), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3868), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(3869) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4558), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4561), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4563), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4566), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4566) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4567), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4570), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4572), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4574), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4576), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4578), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4580), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4582), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4584), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4586), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4588), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4591), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4601), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4603), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4605), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4607), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4609), new DateTime(2025, 5, 23, 14, 7, 7, 192, DateTimeKind.Utc).AddTicks(4610) });
        }
    }
}
