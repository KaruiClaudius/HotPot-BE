using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixreview2revamprolesnorderdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatSessions_Customers_CustomerId",
                table: "ChatSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatSessions_Managers_ManagerId",
                table: "ChatSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Managers_ManagerId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Customers_CustomerId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Staffs_AssignedStaffId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingOrders_Staffs_StaffId",
                table: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ManagerWorkShift");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "StaffWorkShift");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.AddColumn<double>(
                name: "LoyatyPoint",
                table: "Users",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Users",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkDays",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RentOrderDetails",
                columns: table => new
                {
                    RentableOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DamageFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RentalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReturnCondition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UtensilId = table.Column<int>(type: "int", nullable: true),
                    HotpotInventoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentOrderDetails", x => x.RentableOrderDetailId);
                    table.ForeignKey(
                        name: "FK_RentOrderDetails_HotPotInventorys_HotpotInventoryId",
                        column: x => x.HotpotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_RentOrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentOrderDetails_Utensils_UtensilId",
                        column: x => x.UtensilId,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
                });

            migrationBuilder.CreateTable(
                name: "SellOrderDetails",
                columns: table => new
                {
                    SellOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    VolumeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    CustomizationId = table.Column<int>(type: "int", nullable: true),
                    ComboId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrderDetails", x => x.SellOrderDetailId);
                    table.ForeignKey(
                        name: "FK_SellOrderDetails_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_SellOrderDetails_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId");
                    table.ForeignKey(
                        name: "FK_SellOrderDetails_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_SellOrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkShift",
                columns: table => new
                {
                    ManagersUserId = table.Column<int>(type: "int", nullable: false),
                    MangerWorkShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkShift", x => new { x.ManagersUserId, x.MangerWorkShiftsId });
                    table.ForeignKey(
                        name: "FK_UserWorkShift_Users_ManagersUserId",
                        column: x => x.ManagersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkShift_WorkShifts_MangerWorkShiftsId",
                        column: x => x.MangerWorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkShift1",
                columns: table => new
                {
                    StaffUserId = table.Column<int>(type: "int", nullable: false),
                    StaffWorkShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkShift1", x => new { x.StaffUserId, x.StaffWorkShiftsId });
                    table.ForeignKey(
                        name: "FK_UserWorkShift1_Users_StaffUserId",
                        column: x => x.StaffUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkShift1_WorkShifts_StaffWorkShiftsId",
                        column: x => x.StaffWorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 9, 887, DateTimeKind.Utc).AddTicks(3727), null, null, "$2a$12$JtxRh4BEGSO1tUhFUt7.5.21EY.Oh4i7Gi8mpcLg/tTPdBVAT7F6a", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 115, DateTimeKind.Utc).AddTicks(1033), null, null, "$2a$12$1Kg4vj5c73rslgFUSI8LJuCLRIwXhnSDN027dYN5hA4cyKO.aqSfK", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 352, DateTimeKind.Utc).AddTicks(6276), null, null, "$2a$12$PSJEKTBKT/sRG.iaROMAsuMwnBFLjb9OTI9OYUbEAMIQ3UZnK76Cy", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 581, DateTimeKind.Utc).AddTicks(9226), null, null, "$2a$12$BlrbT1auc5nOF7G1Gu1Cqe9ToU.uvbYadJUD43okeWk5jwP2FnJdW", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 10, 808, DateTimeKind.Utc).AddTicks(2616), null, null, "$2a$12$ClDzxZ1ReA78T7UDgTm0aeZz1KyRmiiPggiH2JD736MXr5QBnCKVi", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 34, DateTimeKind.Utc).AddTicks(3627), null, null, "$2a$12$AhDRUvOyaAjm309XCl/phu1lA6EKFBKXSNOH8P1E2S/018JUpivbW", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 260, DateTimeKind.Utc).AddTicks(7737), null, null, "$2a$12$WsR2HgcBRBGJv/mnJfVqlOZ0hDlA/LZQJRHfFcEKE1i3k.wC3ZpQC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 487, DateTimeKind.Utc).AddTicks(3378), null, null, "$2a$12$4UPs/27dzjkxxE9h.9yTz.Mj0v6zvtGYeoyM40jb./zyARV31IXp.", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 713, DateTimeKind.Utc).AddTicks(5624), null, null, "$2a$12$3ih5UW1yI/P.nlvjBERGA.5kUcMwkZKqMtEXO9GP9mNFAeghaWSW6", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LoyatyPoint", "Note", "Password", "WorkDays" },
                values: new object[] { new DateTime(2025, 3, 17, 23, 10, 11, 940, DateTimeKind.Utc).AddTicks(4331), 200.0, null, "$2a$12$mzrm1/jv2p7vazMZzIsx3.y2YU6cRP42DCnv5xhORfyUuP1fIVv5y", null });

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

            migrationBuilder.CreateIndex(
                name: "IX_RentOrderDetails_HotpotInventoryId",
                table: "RentOrderDetails",
                column: "HotpotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RentOrderDetails_OrderId",
                table: "RentOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RentOrderDetails_UtensilId",
                table: "RentOrderDetails",
                column: "UtensilId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrderDetails_ComboId",
                table: "SellOrderDetails",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrderDetails_CustomizationId",
                table: "SellOrderDetails",
                column: "CustomizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrderDetails_IngredientId",
                table: "SellOrderDetails",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrderDetails_OrderId",
                table: "SellOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkShift_MangerWorkShiftsId",
                table: "UserWorkShift",
                column: "MangerWorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkShift1_StaffWorkShiftsId",
                table: "UserWorkShift1",
                column: "StaffWorkShiftsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatSessions_Users_CustomerId",
                table: "ChatSessions",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatSessions_Users_ManagerId",
                table: "ChatSessions",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Users_ManagerId",
                table: "Feedback",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Users_AssignedStaffId",
                table: "ReplacementRequests",
                column: "AssignedStaffId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Users_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingOrders_Users_StaffId",
                table: "ShippingOrders",
                column: "StaffId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatSessions_Users_CustomerId",
                table: "ChatSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatSessions_Users_ManagerId",
                table: "ChatSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Users_ManagerId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Users_AssignedStaffId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_Users_CustomerId",
                table: "ReplacementRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingOrders_Users_StaffId",
                table: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "RentOrderDetails");

            migrationBuilder.DropTable(
                name: "SellOrderDetails");

            migrationBuilder.DropTable(
                name: "UserWorkShift");

            migrationBuilder.DropTable(
                name: "UserWorkShift1");

            migrationBuilder.DropColumn(
                name: "LoyatyPoint",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LoyatyPoint = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: true),
                    CustomizationId = table.Column<int>(type: "int", nullable: true),
                    HotpotInventoryId = table.Column<int>(type: "int", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UtensilId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VolumeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_HotPotInventorys_HotpotInventoryId",
                        column: x => x.HotpotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Utensils_UtensilId",
                        column: x => x.UtensilId,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerWorkShift",
                columns: table => new
                {
                    ManagersManagerId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerWorkShift", x => new { x.ManagersManagerId, x.WorkShiftsId });
                    table.ForeignKey(
                        name: "FK_ManagerWorkShift_Managers_ManagersManagerId",
                        column: x => x.ManagersManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerWorkShift_WorkShifts_WorkShiftsId",
                        column: x => x.WorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffWorkShift",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffWorkShift", x => new { x.StaffId, x.WorkShiftsId });
                    table.ForeignKey(
                        name: "FK_StaffWorkShift_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffWorkShift_WorkShifts_WorkShiftsId",
                        column: x => x.WorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "Note", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6925), false, null, null, 8 },
                    { 2, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6932), false, null, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "LoyatyPoint", "Note", "UpdatedAt", "UserId" },
                values: new object[] { 3, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6932), false, 200.0, null, null, 10 });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1757), new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1760), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1763), new DateTime(2025, 2, 15, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1765), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1765) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1767), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1769), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1771), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1775), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1775) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1779), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1781), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1783), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1785), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1787), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1788), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1802), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1804), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1805), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1807), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1809), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1811), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1810) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1813), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1815), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1817), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1818), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1818) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1820), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1822), new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1821) });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 203, DateTimeKind.Local).AddTicks(1573));

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserId", "WorkDays" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6878), false, null, 2, 0 },
                    { 2, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6882), false, null, 3, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5367));

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "CreatedAt", "IsDelete", "UpdatedAt", "UserId", "WorkDays" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6753), false, null, 4, 0 },
                    { 2, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6761), false, null, 5, 0 },
                    { 3, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6762), false, null, 6, 0 },
                    { 4, new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(6763), false, null, 7, 0 }
                });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 8, 901, DateTimeKind.Utc).AddTicks(5522), "$2a$12$dfmxLBDFN0trt23oZ9Lb/ugs70GpUL38wyzq0hEXTRSlv9jgycpO." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 138, DateTimeKind.Utc).AddTicks(7736), "$2a$12$HbwXjqSeP8lNUs.qrU9QWunxtHglu7K2UqXKgBBBMn7jCAHiZntPK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 394, DateTimeKind.Utc).AddTicks(4935), "$2a$12$LmQlJa81LVlsO56J6cvv1e26.01hY5Tl4fvm5hTygJ082JbkUVEpO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 620, DateTimeKind.Utc).AddTicks(3117), "$2a$12$W71I.G9kVk7NH85AJlo7j.oF86BQwse80UTFjyYzE0KjBuSp/kYoO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 9, 847, DateTimeKind.Utc).AddTicks(1190), "$2a$12$XcWwsjV8Owybb9ZUqDm4ZOlCqjT1HJzHAUaOj3XSGCkiwzWipuBUe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 73, DateTimeKind.Utc).AddTicks(2186), "$2a$12$9ir3AlAv7vmq5mT6K1f4r.udVjmKu75jdTIw48973ELiXFFF7c8E6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 299, DateTimeKind.Utc).AddTicks(1706), "$2a$12$nQyIvUDdu6X0ZyQ9NlJrfOvELSNMbHp3IYRQap3JPJKoWP9RYxVfK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 525, DateTimeKind.Utc).AddTicks(5088), "$2a$12$ecW33/sCcypqapgYZYjdB.jMWRkMlnHSFqEvCI5XGavekVEWhpPjO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 750, DateTimeKind.Utc).AddTicks(9110), "$2a$12$asaldSQN4MsECjPlxRsohuinOnNg1bRBxOD4yGfM9bITIOTvlrXqK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 10, 976, DateTimeKind.Utc).AddTicks(7728), "$2a$12$.KjQ1DEwXxsq91x0BA4E8ukYAS6j0a4jx3rhW8ciREwNuAwzqjvKe" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7505), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7509), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7511), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7510) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7513), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastMaintainDate" },
                values: new object[] { new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Local).AddTicks(7516), new DateTime(2025, 3, 17, 19, 55, 11, 202, DateTimeKind.Utc).AddTicks(7514) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagerWorkShift_WorkShiftsId",
                table: "ManagerWorkShift",
                column: "WorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ComboId",
                table: "OrderDetails",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomizationId",
                table: "OrderDetails",
                column: "CustomizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_HotpotInventoryId",
                table: "OrderDetails",
                column: "HotpotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IngredientId",
                table: "OrderDetails",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UtensilId",
                table: "OrderDetails",
                column: "UtensilId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffWorkShift_WorkShiftsId",
                table: "StaffWorkShift",
                column: "WorkShiftsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatSessions_Customers_CustomerId",
                table: "ChatSessions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatSessions_Managers_ManagerId",
                table: "ChatSessions",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Managers_ManagerId",
                table: "Feedback",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Customers_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_Staffs_AssignedStaffId",
                table: "ReplacementRequests",
                column: "AssignedStaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingOrders_Staffs_StaffId",
                table: "ShippingOrders",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
