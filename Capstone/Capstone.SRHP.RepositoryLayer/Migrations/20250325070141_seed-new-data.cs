using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class seednewdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_DamageDevices_ConditionLogId",
                table: "ReplacementRequests");

            migrationBuilder.RenameColumn(
                name: "ConditionLogId",
                table: "ReplacementRequests",
                newName: "DamageDeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplacementRequests_ConditionLogId",
                table: "ReplacementRequests",
                newName: "IX_ReplacementRequests_DamageDeviceId");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2181), "Tay cầm của nồi lẩu bị gãy và cần được thay thế.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2184), "Tay Cầm Bị Gãy" });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2185), "Đế của nồi lẩu bị nứt và cần được thay thế.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2186), "Đế Nồi Bị Nứt" });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2212), "Nắp của nồi lẩu bị hư hỏng và cần được thay thế.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2213), "Nắp Nồi Hư Hỏng" });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2214), "Đĩa bị vỡ và cần được thay thế.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2215), "Đĩa Bị Vỡ" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1794));

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price", "Size" },
                values: new object[] { 2200000m, new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1684), "Nồi lẩu đồng truyền thống với hệ thống đốt than.", "Đồng", "Nồi Lẩu Đồng Cổ Điển", 730000m, "M" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 3170000m, new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1695), "Nồi lẩu điện với điều khiển nhiệt độ và lớp phủ chống dính.", "Thép Không Gỉ", "Nồi Lẩu Điện Hiện Đại", 1460000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 1710000m, new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1698), "Nồi lẩu nhỏ gọn di động hoàn hảo cho du lịch hoặc các buổi tụ họp nhỏ.", "Nhôm", "Nồi Lẩu Mini Di Động", 490000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 3660000m, new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1700), "Nồi lẩu đa ngăn cho phép nấu nhiều loại nước lẩu khác nhau trong một nồi.", "Thép Không Gỉ", "Nồi Lẩu Hai Ngăn", 1710000m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 1950000m, new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1702), "Nồi lẩu gốm truyền thống giữ nhiệt cực tốt.", "Gốm", "Nồi Lẩu Gốm Truyền Thống", 980000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2081), new DateTime(2025, 2, 23, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2082), 120000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2093), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2093), 135000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2094), new DateTime(2025, 2, 23, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2095), 150000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2096), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2096), 165000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2097), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2099), 95000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2100), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2100), 110000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2101), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2102), 75000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2103), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2103), 90000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2105), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2105), 25000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2106), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2107), 20000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2108), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2109), 18000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2112), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2112), 35000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2113), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2114), 30000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2115), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2115), 32000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2116), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2124), 22000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2125), 25000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2126), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2126), 45000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2127), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2128), 35000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2129), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2129), 65000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2130), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2131), 55000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2132), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2132), 60000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2133), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2134), 50000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2135), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2135), 40000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2136), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2137), 35000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2137), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2138), 38000m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2139), new DateTime(2025, 3, 22, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2140), 42000m });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1907), "Nước Lẩu" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1910), "Hải Sản" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1910), "Rau Củ" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1911), "Mì" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1912), "Đậu Phụ" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1913), "Nấm" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1913), "Thịt" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1914), "Nước Chấm" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1993), "Thịt bò cao cấp cắt lát mỏng hoàn hảo cho lẩu.", "Thịt Bò Cắt Lát" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1997), "Thịt cừu mềm cắt lát, hoàn hảo cho nấu nhanh.", "Thịt Cừu Cắt Lát" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1998), "Thịt ba chỉ heo cắt mỏng với tỷ lệ mỡ-thịt hoàn hảo.", "Ba Chỉ Heo" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1999), "Tôm tươi, đã bóc vỏ và làm sạch.", "Tôm" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2002), "Cá viên đàn hồi làm từ cá tươi xay.", "Cá Viên" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2003), "Mực tươi cắt thành khoanh.", "Mực" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2004), "Rau giòn, lá xanh hoàn hảo cho lẩu.", "Cải Thảo" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2005), "Rau chân vịt tươi, đã rửa sạch và sẵn sàng để nấu.", "Rau Chân Vịt" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2006), "Bắp ngọt cắt thành miếng vừa ăn.", "Bắp" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2007), "Mì lúa mì Nhật Bản dày và dai.", "Mì Udon" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2008), "Miến trong suốt làm từ tinh bột đậu xanh.", "Miến" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2009), "Mì lúa mì xoăn hoàn hảo cho lẩu.", "Mì Ramen" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2010), "Đậu phụ cứng cắt khối giữ nguyên hình dạng trong lẩu.", "Đậu Phụ Cứng" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2011), "Đậu phụ chiên giòn hấp thụ hương vị nước lẩu.", "Đậu Phụ Chiên" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2012), "Nấm hương thơm ngon, tươi hoặc khô.", "Nấm Hương" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2013), "Nấm kim châm mỏng, thân dài.", "Nấm Kim Châm" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2014), "Nước lẩu cay truyền thống với hạt tiêu Tứ Xuyên và dầu ớt.", "Nước Lẩu Tứ Xuyên Cay" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2016), "Nước lẩu cà chua chua ngọt.", "Nước Lẩu Cà Chua" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2017), "Nước lẩu đậm đà làm từ nhiều loại nấm.", "Nước Lẩu Nấm" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2018), "Nước lẩu nhẹ, trong làm từ xương hầm nhiều giờ.", "Nước Lẩu Xương Trong" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2019), "Sốt kem làm từ hạt mè xay.", "Sốt Mè" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2020), "Nước tương pha với tỏi băm.", "Nước Tương Tỏi" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2021), "Dầu cay làm từ ớt ngâm dầu.", "Dầu Ớt" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(2022), "Sốt đậm đà làm từ dầu đậu nành, tỏi, hành và hải sản khô.", "Tương Sa Tế" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4792), "Admin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4804), "Manager" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4830), "Staff" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4831), "Customer" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1520), "Hướng dẫn toàn diện về cách thiết lập và sử dụng nồi lẩu truyền thống.", "Cách Sử Dụng Nồi Lẩu Truyền Thống" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1524), "Học cách thiết lập và sử dụng nồi lẩu điện an toàn.", "Hướng Dẫn Thiết Lập Nồi Lẩu Điện" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1525), "Mẹo và thủ thuật để sử dụng nồi lẩu di động ở bất kỳ đâu.", "Nồi Lẩu Di Động Mọi Lúc Mọi Nơi" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1526), "Cách sử dụng hiệu quả tất cả các ngăn trong nồi lẩu đa ngăn của bạn.", "Làm Chủ Nồi Lẩu Đa Ngăn" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1526), "Học cách chăm sóc và bảo quản nồi lẩu gốm đúng cách.", "Hướng Dẫn Chăm Sóc Nồi Lẩu Gốm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 309, DateTimeKind.Utc).AddTicks(4961), "Admin", "$2a$12$ajXXygIQrPfTGsC2gxY..eZTsd5Zmpk1hRd1mffxAwZymfevpKQZO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 545, DateTimeKind.Utc).AddTicks(5947), "Manager 1", "$2a$12$9pSjqW76fngZFylmOheo5.VStgRxBjqLgpqFKiv7RWAZFcpJUmRsC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 37, 793, DateTimeKind.Utc).AddTicks(3587), "Manager 2", "$2a$12$cAT5WQ0E83Psl62ZlT9rX.yc1DRIxGGsiW1IZ9eUIDLtQsbhS3kRq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 27, DateTimeKind.Utc).AddTicks(2668), "Staff 1", "$2a$12$uIieRFNXKPptLsce5vRtqutkJouH7ftb8STRGW1vEl5ASQp1.ssTO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 256, DateTimeKind.Utc).AddTicks(3732), "Staff 2", "$2a$12$i1vPiFUXO29ANWRwd9omBu/uGz3kur7mJ0TZexsSKSv4bjEpiKME6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 482, DateTimeKind.Utc).AddTicks(6059), "Staff 3", "$2a$12$FohlqzUddP37dF16ZZT9M.RuX.9MacPRJXPK5F6KG1GQrlEzMf3c6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 708, DateTimeKind.Utc).AddTicks(7105), "Staff 4", "$2a$12$hKU9vTf8H8lPn75DR7V9BeJff6XiWlplfS2OJR1kBVhRwV9fcUJ3O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 38, 935, DateTimeKind.Utc).AddTicks(1721), "Customer 1", "$2a$12$YhV.IFBpCAJ/Ls2Eoa0pb.wutgg8N0AIoW7RJOShkaQSSJBRycYci" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 162, DateTimeKind.Utc).AddTicks(1933), "Customer 2", "$2a$12$p2acFe6qlA98wV6PntRthObDeg8tX4bOWXO6GFsBkhKAm6umB.im." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 396, DateTimeKind.Utc).AddTicks(2574), "Customer 3", "$2a$12$LbnWx8uoanLuEdeq.wDYq.f1dOw6y64MWPOZb0FqC6Q63fUF/cQva" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1456), "Đũa" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1461), "Muôi" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1461), "Vợt" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1462), "Bát" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1463), "Đĩa" });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1848), "Bộ 5 đôi đũa tre truyền thống.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1848), "Tre", "Bộ Đũa Tre", 320000m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1856), "Muỗng thép không gỉ bền chắc để múc nước lẩu.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1856), "Thép Không Gỉ", "Muỗng Lẩu Thép Không Gỉ", 245000m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1858), "Vợt lưới mịn để vớt thức ăn từ nồi lẩu.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1859), "Thép Không Gỉ", "Vợt Lưới Kim Loại", 195000m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1860), "Bộ 4 bát gốm cho phần ăn cá nhân.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1861), "Gốm", "Bộ Bát Ăn Gốm", 490000m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1862), "Bộ 6 đĩa melamine bền chắc cho bữa ăn lẩu.", new DateTime(2025, 3, 25, 14, 1, 39, 629, DateTimeKind.Utc).AddTicks(1863), "Đĩa Melamine", 610000m });

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_DamageDevices_DamageDeviceId",
                table: "ReplacementRequests",
                column: "DamageDeviceId",
                principalTable: "DamageDevices",
                principalColumn: "DamageDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementRequests_DamageDevices_DamageDeviceId",
                table: "ReplacementRequests");

            migrationBuilder.RenameColumn(
                name: "DamageDeviceId",
                table: "ReplacementRequests",
                newName: "ConditionLogId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplacementRequests_DamageDeviceId",
                table: "ReplacementRequests",
                newName: "IX_ReplacementRequests_ConditionLogId");

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3894), "The handle of the hotpot is broken and needs to be replaced.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3897), "Broken Handle" });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3898), "The base of the hotpot is cracked and needs to be replaced.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3899), "Cracked Base" });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3900), "The lid of the hotpot is damaged and needs to be replaced.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3901), "Damaged Lid" });

            migrationBuilder.UpdateData(
                table: "DamageDevices",
                keyColumn: "DamageDeviceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "LoggedDate", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3902), "The plates are broken and need to be replaced.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3903), "broken plates" });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3520), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3520), true });

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price", "Size" },
                values: new object[] { 89.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3319), "Traditional copper hotpot with charcoal heating.", "Copper", "Classic Copper Hotpot", 29.99m, "m" });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 129.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3332), "Electric hotpot with temperature control and non-stick coating.", "Stainless Steel", "Modern Electric Hotpot", 59.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 69.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3334), "Compact portable hotpot perfect for travel or small gatherings.", "Aluminum", "Mini Portable Hotpot", 19.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 149.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3426), "Multi-compartment hotpot for different broths in one pot.", "Stainless Steel", "Dual Section Hotpot", 69.99m });

            migrationBuilder.UpdateData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "Material", "Name", "Price" },
                values: new object[] { 79.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3428), "Authentic ceramic hotpot that retains heat exceptionally well.", "Ceramic", "Traditional Ceramic Hotpot", 39.99m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3795), new DateTime(2025, 2, 23, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3797), 0.13m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3807), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3807), 0.14m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3809), new DateTime(2025, 2, 23, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3809), 0.15m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3810), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3811), 0.16m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3811), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3812), 0.12m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3813), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3814), 0.17m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3814), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3815), 0.10m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3816), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3816), 0.15m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3818), 0.06m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3820), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3820), 0.05m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3821), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3822), 0.04m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3823), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3823), 0.07m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3824), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3825), 0.06m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3826), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3826), 0.065m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3827), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3835), 0.05m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3835), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3836), 0.055m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3838), 0.08m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3838), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3839), 0.07m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3840), 0.009m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3841), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3842), 0.008m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3843), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3843), 0.0085m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3844), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3848), 0.0075m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3849), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3850), 0.005m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3851), 0.004m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3852), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3852), 0.0045m });

            migrationBuilder.UpdateData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EffectiveDate", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3853), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3854), 0.006m });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3633), "Broth" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3635), "Seafood" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3636), "Vegetables" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3636), "Noodles" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3637), "Tofu" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3638), "Mushrooms" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3638), "Meats" });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3639), "Sauces" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3677), "Thinly sliced premium beef perfect for hotpot.", "Sliced Beef" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3683), "Tender sliced lamb meat, perfect for quick cooking.", "Lamb Slices" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3684), "Thinly sliced pork belly with perfect fat-to-meat ratio.", "Pork Belly" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3686), "Fresh, peeled and deveined shrimp.", "Shrimp" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3687), "Bouncy fish balls made from fresh fish paste.", "Fish Balls" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3688), "Fresh squid sliced into rings.", "Squid" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3690), "Crisp, leafy vegetable perfect for hotpot.", "Napa Cabbage" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3692), "Fresh spinach leaves, washed and ready to cook.", "Spinach" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3693), "Sweet corn cut into bite-sized pieces.", "Corn" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3694), "Thick, chewy Japanese wheat noodles.", "Udon Noodles" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3695), "Transparent noodles made from mung bean starch.", "Glass Noodles" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3696), "Curly wheat noodles perfect for hotpot.", "Ramen Noodles" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3697), "Firm tofu cubes that hold their shape in hotpot.", "Firm Tofu" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3699), "Deep-fried tofu puffs that absorb broth flavors.", "Tofu Puffs" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3700), "Flavorful shiitake mushrooms, fresh or dried.", "Shiitake Mushrooms" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3701), "Delicate, long-stemmed enoki mushrooms.", "Enoki Mushrooms" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3702), "Traditional spicy broth with Sichuan peppercorns and chili oil.", "Spicy Sichuan Broth" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3703), "Tangy tomato-based broth, slightly sweet and sour.", "Tomato Broth" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3704), "Rich umami broth made from various mushrooms.", "Mushroom Broth" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3729), "Light, clear broth made from simmering bones for hours.", "Clear Bone Broth" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3732), "Creamy sauce made from ground sesame seeds.", "Sesame Sauce" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3733), "Soy sauce infused with fresh minced garlic.", "Garlic Soy Sauce" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3734), "Spicy oil made from infusing oil with chili peppers.", "Chili Oil" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3735), "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.", "Shacha Sauce" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(453), "Admin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(464), "Manager" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(465), "Staff" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(465), "Customer" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3157), "A comprehensive guide to setting up and using a traditional hotpot.", "How to Use Traditional Hotpot" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3161), "Learn how to safely set up and use your electric hotpot.", "Electric Hotpot Setup Guide" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3162), "Tips and tricks for using your portable hotpot anywhere.", "Portable Hotpot on the Go" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3163), "How to effectively use all compartments in your multi-section hotpot.", "Multi-compartment Hotpot Mastery" });

            migrationBuilder.UpdateData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3164), "Learn how to properly care for and maintain your ceramic hotpot.", "Ceramic Hotpot Care Guide" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(573), "Admin", "$2a$12$XC5yzcQzr.7nHZDp.81PTeaxtUEGFl712QoJHU/olJpvf16Q/j.r6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 31, 833, DateTimeKind.Utc).AddTicks(6274), "Manager1", "$2a$12$FoRV8I4MTkatKlA7QSPvmuIThhx454ARxV1fyW7QgcYuQis3nCR8a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 32, 59, DateTimeKind.Utc).AddTicks(9314), "Manager2", "$2a$12$9uyK98F5wdd3a/vO7TZ33eU/6NdkpCVdd0DUCg5KdHgvzCsjH8n/." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 32, 291, DateTimeKind.Utc).AddTicks(2790), "Staff1", "$2a$12$TCoEev3jbcFCLbhA0LNqy..imbYccjJaWQ.xtgFWr7zP7alj1nhpC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 32, 520, DateTimeKind.Utc).AddTicks(862), "Staff2", "$2a$12$waUVjFYxUAEQ/2D4IbJ/EOAyKW/2GXCvTmCOXaXnbbaVwm/D8BuSu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 32, 746, DateTimeKind.Utc).AddTicks(6036), "Staff3", "$2a$12$mOPjmO6uPPyt.xuHhzQGZORTiy5RbBW.z52axDuxqXJO9QHrCW.ka" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 32, 974, DateTimeKind.Utc).AddTicks(341), "Staff4", "$2a$12$sVTtkK1fw.lRfYHj/K9hI.ScuM0UEHWBt6CokBAt4KVlqL6LtPDna" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 199, DateTimeKind.Utc).AddTicks(7638), "Customer1", "$2a$12$3tTIOh2dv3D7NeUHzlWkD.V6AfTDKctO5RWiNkMYoT9kuvsb7uL1u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 425, DateTimeKind.Utc).AddTicks(4109), "Customer2", "$2a$12$J5.bCaMRVXuNR/2vGO9qe.jBuQ3ryB507gNOWYPbDK0yQ1jShOgSG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Name", "Password" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 655, DateTimeKind.Utc).AddTicks(9900), "Customer3", "$2a$12$PVHZH90NtSV8uRwEQQohLu5X9G68AbtUE6Kl8LUV/3gIo2q35.eoC" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3090), "Chopsticks" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3094), "Ladles" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3095), "Strainers" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3096), "Bowls" });

            migrationBuilder.UpdateData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3097), "Plates" });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3583), "Set of 5 pairs of traditional bamboo chopsticks.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3583), "Bamboo", "Bamboo Chopsticks Set", 12.99m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3589), "Durable stainless steel ladle for serving hotpot broth.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3590), "Stainless Steel", "Stainless Steel Hotpot Ladle", 9.99m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3592), "Fine mesh strainer for retrieving food from the hotpot.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3592), "Stainless Steel", "Wire Mesh Strainer", 7.99m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Material", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3593), "Set of 4 ceramic bowls for individual servings.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3594), "Ceramic", "Ceramic Serving Bowl Set", 19.99m });

            migrationBuilder.UpdateData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "LastMaintainDate", "Name", "Price" },
                values: new object[] { new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3595), "Set of 6 durable melamine plates for hotpot dining.", new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3595), "Melamine Plates", 24.99m });

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementRequests_DamageDevices_ConditionLogId",
                table: "ReplacementRequests",
                column: "ConditionLogId",
                principalTable: "DamageDevices",
                principalColumn: "DamageDeviceId");
        }
    }
}
