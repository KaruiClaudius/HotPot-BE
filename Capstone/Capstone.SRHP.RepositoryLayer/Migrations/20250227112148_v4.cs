using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotpotTypes",
                columns: new[] { "HotpotTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5005), false, "Traditional", null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5008), false, "Electric", null },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5008), false, "Portable", null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5009), false, "Multi-compartment", null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5010), false, "Ceramic", null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "IngredientTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5473), false, "Meat", null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5475), false, "Seafood", null },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5481), false, "Vegetables", null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5497), false, "Noodles", null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5499), false, "Tofu", null },
                    { 6, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5500), false, "Mushrooms", null },
                    { 7, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5501), false, "Broths", null },
                    { 8, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5502), false, "Sauces", null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 18, 21, 46, 94, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 18, 21, 46, 94, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 18, 21, 46, 94, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 18, 21, 46, 94, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.InsertData(
                table: "TurtorialVideos",
                columns: new[] { "TurtorialVideoId", "CreatedAt", "Description", "IsDelete", "Name", "UpdatedAt", "VideoURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5141), "A comprehensive guide to setting up and using a traditional hotpot.", false, "How to Use Traditional Hotpot", null, "https://www.youtube.com/watch?v=traditional-hotpot-guide" },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5143), "Learn how to safely set up and use your electric hotpot.", false, "Electric Hotpot Setup Guide", null, "https://www.youtube.com/watch?v=electric-hotpot-setup" },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5150), "Tips and tricks for using your portable hotpot anywhere.", false, "Portable Hotpot on the Go", null, "https://www.youtube.com/watch?v=portable-hotpot-guide" },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5152), "How to effectively use all compartments in your multi-section hotpot.", false, "Multi-compartment Hotpot Mastery", null, "https://www.youtube.com/watch?v=multi-compartment-guide" },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5227), "Learn how to properly care for and maintain your ceramic hotpot.", false, "Ceramic Hotpot Care Guide", null, "https://www.youtube.com/watch?v=ceramic-hotpot-care" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "Name", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 2, 27, 18, 21, 46, 94, DateTimeKind.Utc).AddTicks(7318), "Admin@gmail.com", null, false, "Admin", "$2a$12$kaRrDGaPknHjgVOaqDPEZe8o8CvB0L4s1lrQeU6YQclEQezxLZv7y", null, null, null, 1, null },
                    { 2, null, new DateTime(2025, 2, 27, 18, 21, 46, 337, DateTimeKind.Utc).AddTicks(1167), "Manager1@gmail.com", null, false, "Manager", "$2a$12$WTJvLI4K/e3fpouYow5KyeJmTKAUe5cw8TPew9TdhDHKRslFtXzE6", null, null, null, 2, null },
                    { 3, null, new DateTime(2025, 2, 27, 18, 21, 46, 570, DateTimeKind.Utc).AddTicks(9693), "Manager2@gmail.com", null, false, "Manager", "$2a$12$jrRUSNpF/btW23VhPijqZOrnkKmREEl/BIM1Ea9mdJyDo8VptuiUu", null, null, null, 2, null },
                    { 4, null, new DateTime(2025, 2, 27, 18, 21, 46, 802, DateTimeKind.Utc).AddTicks(7200), "Staff1@gmail.com", null, false, "Staff", "$2a$12$7iiY0vGjDZiP5NuzFkg4DexDheiwif6oi.HBIwMeU8hXOZ/Lq7IGC", null, null, null, 3, null },
                    { 5, null, new DateTime(2025, 2, 27, 18, 21, 47, 32, DateTimeKind.Utc).AddTicks(7956), "Staff2@gmail.com", null, false, "Staff", "$2a$12$kuGM/m538jV.EFULWqoS5uGHzaUBDHg/8u43u8PXTgob5aA11pHQe", null, null, null, 3, null },
                    { 6, null, new DateTime(2025, 2, 27, 18, 21, 47, 267, DateTimeKind.Utc).AddTicks(8750), "Staff3@gmail.com", null, false, "Staff", "$2a$12$QoRs00KeMoA/FbDUUqlVz.ZfPsKlops0wWQCDia2iWxqJhf.qxWNm", null, null, null, 3, null },
                    { 7, null, new DateTime(2025, 2, 27, 18, 21, 47, 500, DateTimeKind.Utc).AddTicks(3847), "Staff4@gmail.com", null, false, "Staff", "$2a$12$GsspE07/sEXpphYT2G.dxOwSy6D4MRmITTweqIZuTq/iveYUMfBWW", null, null, null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "UtensilTypes",
                columns: new[] { "UtensilTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5065), false, "Chopsticks", null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5084), false, "Ladles", null },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5086), false, "Strainers", null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5101), false, "Bowls", null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5102), false, "Plates", null }
                });

            migrationBuilder.InsertData(
                table: "Hotpots",
                columns: new[] { "HotpotId", "CreatedAt", "Description", "HotpotTypeID", "ImageURL", "InventoryID", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Size", "Status", "TurtorialVideoID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5291), "Traditional copper hotpot with charcoal heating.", 1, "https://example.com/images/classic-copper-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Copper", "Classic Copper Hotpot", 89.99m, 25, 4, true, 1, null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5294), "Electric hotpot with temperature control and non-stick coating.", 2, "https://example.com/images/modern-electric-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Modern Electric Hotpot", 129.99m, 30, 6, true, 2, null },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5297), "Compact portable hotpot perfect for travel or small gatherings.", 3, "https://example.com/images/mini-portable-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluminum", "Mini Portable Hotpot", 59.99m, 40, 2, true, 3, null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5299), "Multi-compartment hotpot for different broths in one pot.", 4, "https://example.com/images/dual-section-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Dual Section Hotpot", 149.99m, 20, 6, true, 4, null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5301), "Authentic ceramic hotpot that retains heat exceptionally well.", 5, "https://example.com/images/traditional-ceramic-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceramic", "Traditional Ceramic Hotpot", 79.99m, 15, 4, true, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CreatedAt", "Description", "ImageURL", "IngredientTypeID", "IsDelete", "MinStockLevel", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5607), "Thinly sliced premium beef perfect for hotpot.", "https://example.com/images/sliced-beef.jpg", 1, false, 20, "Sliced Beef", 100, null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5610), "Tender sliced lamb meat, perfect for quick cooking.", "https://example.com/images/lamb-slices.jpg", 1, false, 15, "Lamb Slices", 80, null },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5611), "Thinly sliced pork belly with perfect fat-to-meat ratio.", "https://example.com/images/pork-belly.jpg", 1, false, 15, "Pork Belly", 75, null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5613), "Fresh, peeled and deveined shrimp.", "https://example.com/images/shrimp.jpg", 2, false, 20, "Shrimp", 90, null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5614), "Bouncy fish balls made from fresh fish paste.", "https://example.com/images/fish-balls.jpg", 2, false, 30, "Fish Balls", 120, null },
                    { 6, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5616), "Fresh squid sliced into rings.", "https://example.com/images/squid.jpg", 2, false, 15, "Squid", 60, null },
                    { 7, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5622), "Crisp, leafy vegetable perfect for hotpot.", "https://example.com/images/napa-cabbage.jpg", 3, false, 25, "Napa Cabbage", 100, null },
                    { 8, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5628), "Fresh spinach leaves, washed and ready to cook.", "https://example.com/images/spinach.jpg", 3, false, 20, "Spinach", 80, null },
                    { 9, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5631), "Sweet corn cut into bite-sized pieces.", "https://example.com/images/corn.jpg", 3, false, 15, "Corn", 70, null },
                    { 10, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5633), "Thick, chewy Japanese wheat noodles.", "https://example.com/images/udon-noodles.jpg", 4, false, 20, "Udon Noodles", 80, null },
                    { 11, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5636), "Transparent noodles made from mung bean starch.", "https://example.com/images/glass-noodles.jpg", 4, false, 20, "Glass Noodles", 85, null },
                    { 12, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5639), "Curly wheat noodles perfect for hotpot.", "https://example.com/images/ramen-noodles.jpg", 4, false, 25, "Ramen Noodles", 90, null },
                    { 13, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5640), "Firm tofu cubes that hold their shape in hotpot.", "https://example.com/images/firm-tofu.jpg", 5, false, 15, "Firm Tofu", 60, null },
                    { 14, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5642), "Deep-fried tofu puffs that absorb broth flavors.", "https://example.com/images/tofu-puffs.jpg", 5, false, 15, "Tofu Puffs", 65, null },
                    { 15, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5644), "Flavorful shiitake mushrooms, fresh or dried.", "https://example.com/images/shiitake.jpg", 6, false, 15, "Shiitake Mushrooms", 70, null },
                    { 16, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5646), "Delicate, long-stemmed enoki mushrooms.", "https://example.com/images/enoki.jpg", 6, false, 15, "Enoki Mushrooms", 65, null },
                    { 17, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5648), "Traditional spicy broth with Sichuan peppercorns and chili oil.", "https://example.com/images/sichuan-broth.jpg", 7, false, 10, "Spicy Sichuan Broth", 50, null },
                    { 18, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5649), "Tangy tomato-based broth, slightly sweet and sour.", "https://example.com/images/tomato-broth.jpg", 7, false, 10, "Tomato Broth", 45, null },
                    { 19, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5651), "Rich umami broth made from various mushrooms.", "https://example.com/images/mushroom-broth.jpg", 7, false, 10, "Mushroom Broth", 40, null },
                    { 20, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5652), "Light, clear broth made from simmering bones for hours.", "https://example.com/images/bone-broth.jpg", 7, false, 10, "Clear Bone Broth", 55, null },
                    { 21, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5654), "Creamy sauce made from ground sesame seeds.", "https://example.com/images/sesame-sauce.jpg", 8, false, 10, "Sesame Sauce", 40, null },
                    { 22, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5683), "Soy sauce infused with fresh minced garlic.", "https://example.com/images/garlic-soy.jpg", 8, false, 10, "Garlic Soy Sauce", 45, null },
                    { 23, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5686), "Spicy oil made from infusing oil with chili peppers.", "https://example.com/images/chili-oil.jpg", 8, false, 10, "Chili Oil", 50, null },
                    { 24, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5688), "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.", "https://example.com/images/shacha-sauce.jpg", 8, false, 10, "Shacha Sauce", 35, null }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(4848), false, null, 2 },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(4855), false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(4959), false, null, 4 },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(4962), false, null, 5 },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(4963), false, null, 6 },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(4963), false, null, 7 }
                });

            migrationBuilder.InsertData(
                table: "Utensils",
                columns: new[] { "UtensilId", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Status", "UpdatedAt", "UtensilTypeID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5356), "Set of 5 pairs of traditional bamboo chopsticks.", "https://example.com/images/bamboo-chopsticks.jpg", false, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5349), "Bamboo", "Bamboo Chopsticks Set", 12.99m, 100, true, null, 1 },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5359), "Durable stainless steel ladle for serving hotpot broth.", "https://example.com/images/steel-ladle.jpg", false, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5357), "Stainless Steel", "Stainless Steel Hotpot Ladle", 9.99m, 75, true, null, 2 },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5361), "Fine mesh strainer for retrieving food from the hotpot.", "https://example.com/images/mesh-strainer.jpg", false, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5360), "Stainless Steel", "Wire Mesh Strainer", 7.99m, 80, true, null, 3 },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5363), "Set of 4 ceramic bowls for individual servings.", "https://example.com/images/ceramic-bowls.jpg", false, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5362), "Ceramic", "Ceramic Serving Bowl Set", 19.99m, 50, true, null, 4 },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5366), "Set of 6 durable melamine plates for hotpot dining.", "https://example.com/images/melamine-plates.jpg", false, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Utc).AddTicks(5364), "Melamine", "Melamine Plates", 24.99m, 60, true, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5426), 1, false, "CP-2023-0001", null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5427), 1, false, "CP-2023-0002", null },
                    { 3, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5429), 2, false, "EL-2023-0001", null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5430), 2, false, "EL-2023-0002", null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5431), 3, false, "PT-2023-0001", null },
                    { 6, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5432), 4, false, "MC-2023-0001", null },
                    { 7, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5434), 5, false, "CR-2023-0001", null }
                });

            migrationBuilder.InsertData(
                table: "IngredientPrices",
                columns: new[] { "IngredientPriceId", "CreatedAt", "EffectiveDate", "IngredientID", "IsDelete", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 28, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5754), new DateTime(2025, 1, 28, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5745), 1, false, 12.99m, null },
                    { 2, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5756), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5756), 1, false, 13.99m, null },
                    { 3, new DateTime(2025, 1, 28, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5758), new DateTime(2025, 1, 28, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5757), 2, false, 14.99m, null },
                    { 4, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5760), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5760), 2, false, 15.99m, null },
                    { 5, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5762), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5761), 3, false, 11.99m, null },
                    { 6, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5764), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5763), 4, false, 16.99m, null },
                    { 7, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5766), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5765), 5, false, 9.99m, null },
                    { 8, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5767), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5767), 6, false, 14.99m, null },
                    { 9, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5769), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5769), 7, false, 5.99m, null },
                    { 10, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5771), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5770), 8, false, 4.99m, null },
                    { 11, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5773), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5772), 9, false, 3.99m, null },
                    { 12, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5778), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5777), 10, false, 6.99m, null },
                    { 13, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5781), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5780), 11, false, 5.99m, null },
                    { 14, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5783), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5782), 12, false, 6.49m, null },
                    { 15, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5784), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5784), 13, false, 4.99m, null },
                    { 16, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5786), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5786), 14, false, 5.49m, null },
                    { 17, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5788), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5788), 15, false, 7.99m, null },
                    { 18, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5790), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5789), 16, false, 6.99m, null },
                    { 19, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5792), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(5791), 17, false, 8.99m, null },
                    { 20, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8002), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(7996), 18, false, 7.99m, null },
                    { 21, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8011), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8010), 19, false, 8.49m, null },
                    { 22, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8013), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8012), 20, false, 7.49m, null },
                    { 23, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8015), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8014), 21, false, 4.99m, null },
                    { 24, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8017), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8016), 22, false, 3.99m, null },
                    { 25, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8020), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8019), 23, false, 4.49m, null },
                    { 26, new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8021), new DateTime(2025, 2, 27, 18, 21, 47, 728, DateTimeKind.Local).AddTicks(8021), 24, false, 5.99m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HotPotInventorys",
                keyColumn: "HotPotInventoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "IngredientPrices",
                keyColumn: "IngredientPriceId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utensils",
                keyColumn: "UtensilId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotpots",
                keyColumn: "HotpotId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UtensilTypes",
                keyColumn: "UtensilTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HotpotTypes",
                keyColumn: "HotpotTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "IngredientTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TurtorialVideos",
                keyColumn: "TurtorialVideoId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 18, 25, 28, 94, DateTimeKind.Utc).AddTicks(5179));
        }
    }
}
