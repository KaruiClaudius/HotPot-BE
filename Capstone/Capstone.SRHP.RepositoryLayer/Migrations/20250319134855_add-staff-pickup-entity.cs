using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addstaffpickupentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentableOrderDetailId",
                table: "RentOrderDetails",
                newName: "RentOrderDetailId");

            migrationBuilder.CreateTable(
                name: "StaffPickupAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentOrderDetailId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPickupAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_StaffPickupAssignments_RentOrderDetails_RentOrderDetailId",
                        column: x => x.RentOrderDetailId,
                        principalTable: "RentOrderDetails",
                        principalColumn: "RentOrderDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffPickupAssignments_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 48, 55, 120, DateTimeKind.Local).AddTicks(8269));

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

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_RentOrderDetailId",
                table: "StaffPickupAssignments",
                column: "RentOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_StaffId",
                table: "StaffPickupAssignments",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffPickupAssignments");

            migrationBuilder.RenameColumn(
                name: "RentOrderDetailId",
                table: "RentOrderDetails",
                newName: "RentableOrderDetailId");

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 15, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2284), new DateTime(2025, 2, 15, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2276) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2286), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2286) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 15, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2288), new DateTime(2025, 2, 15, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2287) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2290), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2292), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2291) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2294), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2295), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2297), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2297) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2299), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2300), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2300) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2302), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2302) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2304), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2303) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2305), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2307), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2318), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2317) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2319), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2319) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2321), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2323), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2325), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2324) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2326), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2326) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2328), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2328) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2330), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2329) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2331), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2331) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2333), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2335), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2336), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 9, 887, DateTimeKind.Utc).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 9, 887, DateTimeKind.Utc).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 9, 887, DateTimeKind.Utc).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 9, 887, DateTimeKind.Utc).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 9, 887, DateTimeKind.Utc).AddTicks(3727), "$2a$12$JtxRh4BEGSO1tUhFUt7.5.21EY.Oh4i7Gi8mpcLg/tTPdBVAT7F6a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 115, DateTimeKind.Utc).AddTicks(1033), "$2a$12$1Kg4vj5c73rslgFUSI8LJuCLRIwXhnSDN027dYN5hA4cyKO.aqSfK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 352, DateTimeKind.Utc).AddTicks(6276), "$2a$12$PSJEKTBKT/sRG.iaROMAsuMwnBFLjb9OTI9OYUbEAMIQ3UZnK76Cy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 581, DateTimeKind.Utc).AddTicks(9226), "$2a$12$BlrbT1auc5nOF7G1Gu1Cqe9ToU.uvbYadJUD43okeWk5jwP2FnJdW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 808, DateTimeKind.Utc).AddTicks(2616), "$2a$12$ClDzxZ1ReA78T7UDgTm0aeZz1KyRmiiPggiH2JD736MXr5QBnCKVi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 34, DateTimeKind.Utc).AddTicks(3627), "$2a$12$AhDRUvOyaAjm309XCl/phu1lA6EKFBKXSNOH8P1E2S/018JUpivbW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 260, DateTimeKind.Utc).AddTicks(7737), "$2a$12$WsR2HgcBRBGJv/mnJfVqlOZ0hDlA/LZQJRHfFcEKE1i3k.wC3ZpQC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 487, DateTimeKind.Utc).AddTicks(3378), "$2a$12$4UPs/27dzjkxxE9h.9yTz.Mj0v6zvtGYeoyM40jb./zyARV31IXp." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 713, DateTimeKind.Utc).AddTicks(5624), "$2a$12$3ih5UW1yI/P.nlvjBERGA.5kUcMwkZKqMtEXO9GP9mNFAeghaWSW6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 940, DateTimeKind.Utc).AddTicks(4331), "$2a$12$mzrm1/jv2p7vazMZzIsx3.y2YU6cRP42DCnv5xhORfyUuP1fIVv5y" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2009), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Utc).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2013), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Utc).AddTicks(2011) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2015), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2017), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Utc).AddTicks(2016) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Local).AddTicks(2019), new DateTime(2025, 3, 17, 23, 10, 12, 167, DateTimeKind.Utc).AddTicks(2018) });
        }
    }
}
