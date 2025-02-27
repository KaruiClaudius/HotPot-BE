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
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "HotPotInventorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "HotpotTypes",
                columns: new[] { "HotpotTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2194), false, "Traditional", null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2200), false, "Electric", null },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2201), false, "Portable", null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2202), false, "Multi-compartment", null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2203), false, "Ceramic", null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "IngredientTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2963), false, "Meat", null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2965), false, "Seafood", null },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2972), false, "Vegetables", null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2989), false, "Noodles", null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2991), false, "Tofu", null },
                    { 6, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2995), false, "Mushrooms", null },
                    { 7, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2996), false, "Broths", null },
                    { 8, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2998), false, "Sauces", null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.InsertData(
                table: "TurtorialVideos",
                columns: new[] { "TurtorialVideoId", "CreatedAt", "Description", "IsDelete", "Name", "UpdatedAt", "VideoURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2573), "A comprehensive guide to setting up and using a traditional hotpot.", false, "How to Use Traditional Hotpot", null, "https://www.youtube.com/watch?v=traditional-hotpot-guide" },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2576), "Learn how to safely set up and use your electric hotpot.", false, "Electric Hotpot Setup Guide", null, "https://www.youtube.com/watch?v=electric-hotpot-setup" },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2578), "Tips and tricks for using your portable hotpot anywhere.", false, "Portable Hotpot on the Go", null, "https://www.youtube.com/watch?v=portable-hotpot-guide" },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2579), "How to effectively use all compartments in your multi-section hotpot.", false, "Multi-compartment Hotpot Mastery", null, "https://www.youtube.com/watch?v=multi-compartment-guide" },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2587), "Learn how to properly care for and maintain your ceramic hotpot.", false, "Ceramic Hotpot Care Guide", null, "https://www.youtube.com/watch?v=ceramic-hotpot-care" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "Name", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleID", "UpdatedAt" },
                values: new object[,]
                {
                    { -7, null, new DateTime(2025, 2, 27, 19, 14, 21, 59, DateTimeKind.Utc).AddTicks(2204), "Staff4@gmail.com", null, false, "Staff", "$2a$12$VlqIMB3KS90CxLI4IyBjMeDKJOfLClSYKNEMgBq0XvJwO6pSrEXqu", null, null, null, 3, null },
                    { -6, null, new DateTime(2025, 2, 27, 19, 14, 20, 821, DateTimeKind.Utc).AddTicks(5941), "Staff3@gmail.com", null, false, "Staff", "$2a$12$WyuRgSjLsmjMWtEFIx/Lru1orNrjIOIiwdX.XPMrGHMGj/saqo7Ne", null, null, null, 3, null },
                    { -5, null, new DateTime(2025, 2, 27, 19, 14, 20, 578, DateTimeKind.Utc).AddTicks(5093), "Staff2@gmail.com", null, false, "Staff", "$2a$12$qbv5Dk4gcwHSMvKQbyLyUOrXRVvDk8zJVLLrD4V2Q4vpQl/xrmKM.", null, null, null, 3, null },
                    { -4, null, new DateTime(2025, 2, 27, 19, 14, 20, 341, DateTimeKind.Utc).AddTicks(3362), "Staff1@gmail.com", null, false, "Staff", "$2a$12$L0rDJa.AVYoLEkNfkwaSDO7vRN/5vR8EzisX49tr0He6nFIrgVbR6", null, null, null, 3, null },
                    { -3, null, new DateTime(2025, 2, 27, 19, 14, 20, 103, DateTimeKind.Utc).AddTicks(2584), "Manager2@gmail.com", null, false, "Manager", "$2a$12$u/ZYzR2aK9agCehAKDE4FOEe1.EZ6/tYLz94uIbVYrOPCTDoHvuZm", null, null, null, 2, null },
                    { -2, null, new DateTime(2025, 2, 27, 19, 14, 19, 863, DateTimeKind.Utc).AddTicks(9298), "Manager1@gmail.com", null, false, "Manager", "$2a$12$R9ZAqPARfwmDy4U9ktWL7ujI55quj3Atog6//cpdP0KToKYTng6/q", null, null, null, 2, null },
                    { -1, null, new DateTime(2025, 2, 27, 19, 14, 19, 623, DateTimeKind.Utc).AddTicks(4039), "Admin@gmail.com", null, false, "Admin", "$2a$12$jccEXEJACywdTDZ6qTJvFu/Dj4PSUX2BDLT8d3e7pj1Ix7iMlQV7q", null, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "UtensilTypes",
                columns: new[] { "UtensilTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2374), false, "Chopsticks", null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2393), false, "Ladles", null },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2395), false, "Strainers", null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2397), false, "Bowls", null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2398), false, "Plates", null }
                });

            migrationBuilder.InsertData(
                table: "Hotpots",
                columns: new[] { "HotpotId", "CreatedAt", "Description", "HotpotTypeID", "ImageURL", "InventoryID", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Size", "Status", "TurtorialVideoID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2668), "Traditional copper hotpot with charcoal heating.", 1, "https://example.com/images/classic-copper-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Copper", "Classic Copper Hotpot", 89.99m, 25, 4, true, 1, null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2671), "Electric hotpot with temperature control and non-stick coating.", 2, "https://example.com/images/modern-electric-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Modern Electric Hotpot", 129.99m, 30, 6, true, 2, null },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2674), "Compact portable hotpot perfect for travel or small gatherings.", 3, "https://example.com/images/mini-portable-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluminum", "Mini Portable Hotpot", 59.99m, 40, 2, true, 3, null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2680), "Multi-compartment hotpot for different broths in one pot.", 4, "https://example.com/images/dual-section-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Dual Section Hotpot", 149.99m, 20, 6, true, 4, null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2682), "Authentic ceramic hotpot that retains heat exceptionally well.", 5, "https://example.com/images/traditional-ceramic-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceramic", "Traditional Ceramic Hotpot", 79.99m, 15, 4, true, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CreatedAt", "Description", "ImageURL", "IngredientTypeID", "IsDelete", "MinStockLevel", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3064), "Thinly sliced premium beef perfect for hotpot.", "https://example.com/images/sliced-beef.jpg", 1, false, 20, "Sliced Beef", 100, null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3066), "Tender sliced lamb meat, perfect for quick cooking.", "https://example.com/images/lamb-slices.jpg", 1, false, 15, "Lamb Slices", 80, null },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3068), "Thinly sliced pork belly with perfect fat-to-meat ratio.", "https://example.com/images/pork-belly.jpg", 1, false, 15, "Pork Belly", 75, null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3074), "Fresh, peeled and deveined shrimp.", "https://example.com/images/shrimp.jpg", 2, false, 20, "Shrimp", 90, null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3076), "Bouncy fish balls made from fresh fish paste.", "https://example.com/images/fish-balls.jpg", 2, false, 30, "Fish Balls", 120, null },
                    { 6, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3078), "Fresh squid sliced into rings.", "https://example.com/images/squid.jpg", 2, false, 15, "Squid", 60, null },
                    { 7, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3080), "Crisp, leafy vegetable perfect for hotpot.", "https://example.com/images/napa-cabbage.jpg", 3, false, 25, "Napa Cabbage", 100, null },
                    { 8, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3082), "Fresh spinach leaves, washed and ready to cook.", "https://example.com/images/spinach.jpg", 3, false, 20, "Spinach", 80, null },
                    { 9, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3084), "Sweet corn cut into bite-sized pieces.", "https://example.com/images/corn.jpg", 3, false, 15, "Corn", 70, null },
                    { 10, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3085), "Thick, chewy Japanese wheat noodles.", "https://example.com/images/udon-noodles.jpg", 4, false, 20, "Udon Noodles", 80, null },
                    { 11, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3087), "Transparent noodles made from mung bean starch.", "https://example.com/images/glass-noodles.jpg", 4, false, 20, "Glass Noodles", 85, null },
                    { 12, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3089), "Curly wheat noodles perfect for hotpot.", "https://example.com/images/ramen-noodles.jpg", 4, false, 25, "Ramen Noodles", 90, null },
                    { 13, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3091), "Firm tofu cubes that hold their shape in hotpot.", "https://example.com/images/firm-tofu.jpg", 5, false, 15, "Firm Tofu", 60, null },
                    { 14, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3093), "Deep-fried tofu puffs that absorb broth flavors.", "https://example.com/images/tofu-puffs.jpg", 5, false, 15, "Tofu Puffs", 65, null },
                    { 15, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3094), "Flavorful shiitake mushrooms, fresh or dried.", "https://example.com/images/shiitake.jpg", 6, false, 15, "Shiitake Mushrooms", 70, null },
                    { 16, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3096), "Delicate, long-stemmed enoki mushrooms.", "https://example.com/images/enoki.jpg", 6, false, 15, "Enoki Mushrooms", 65, null },
                    { 17, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3098), "Traditional spicy broth with Sichuan peppercorns and chili oil.", "https://example.com/images/sichuan-broth.jpg", 7, false, 10, "Spicy Sichuan Broth", 50, null },
                    { 18, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3100), "Tangy tomato-based broth, slightly sweet and sour.", "https://example.com/images/tomato-broth.jpg", 7, false, 10, "Tomato Broth", 45, null },
                    { 19, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3101), "Rich umami broth made from various mushrooms.", "https://example.com/images/mushroom-broth.jpg", 7, false, 10, "Mushroom Broth", 40, null },
                    { 20, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3103), "Light, clear broth made from simmering bones for hours.", "https://example.com/images/bone-broth.jpg", 7, false, 10, "Clear Bone Broth", 55, null },
                    { 21, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3105), "Creamy sauce made from ground sesame seeds.", "https://example.com/images/sesame-sauce.jpg", 8, false, 10, "Sesame Sauce", 40, null },
                    { 22, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3107), "Soy sauce infused with fresh minced garlic.", "https://example.com/images/garlic-soy.jpg", 8, false, 10, "Garlic Soy Sauce", 45, null },
                    { 23, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3109), "Spicy oil made from infusing oil with chili peppers.", "https://example.com/images/chili-oil.jpg", 8, false, 10, "Chili Oil", 50, null },
                    { 24, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3110), "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.", "https://example.com/images/shacha-sauce.jpg", 8, false, 10, "Shacha Sauce", 35, null }
                });

            migrationBuilder.InsertData(
                table: "Utensils",
                columns: new[] { "UtensilId", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Status", "UpdatedAt", "UtensilTypeID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2758), "Set of 5 pairs of traditional bamboo chopsticks.", "https://example.com/images/bamboo-chopsticks.jpg", false, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2747), "Bamboo", "Bamboo Chopsticks Set", 12.99m, 100, true, null, 1 },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2766), "Durable stainless steel ladle for serving hotpot broth.", "https://example.com/images/steel-ladle.jpg", false, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2760), "Stainless Steel", "Stainless Steel Hotpot Ladle", 9.99m, 75, true, null, 2 },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2768), "Fine mesh strainer for retrieving food from the hotpot.", "https://example.com/images/mesh-strainer.jpg", false, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2767), "Stainless Steel", "Wire Mesh Strainer", 7.99m, 80, true, null, 3 },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2772), "Set of 4 ceramic bowls for individual servings.", "https://example.com/images/ceramic-bowls.jpg", false, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2770), "Ceramic", "Ceramic Serving Bowl Set", 19.99m, 50, true, null, 4 },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2774), "Set of 6 durable melamine plates for hotpot dining.", "https://example.com/images/melamine-plates.jpg", false, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Utc).AddTicks(2773), "Melamine", "Melamine Plates", 24.99m, 60, true, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2852), 1, false, "CP-2023-0001", false, null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2854), 1, false, "CP-2023-0002", false, null },
                    { 3, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2908), 2, false, "EL-2023-0001", false, null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2910), 2, false, "EL-2023-0002", false, null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2911), 3, false, "PT-2023-0001", false, null },
                    { 6, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2917), 4, false, "MC-2023-0001", false, null },
                    { 7, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(2918), 5, false, "CR-2023-0001", false, null }
                });

            migrationBuilder.InsertData(
                table: "IngredientPrices",
                columns: new[] { "IngredientPriceId", "CreatedAt", "EffectiveDate", "IngredientID", "IsDelete", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3192), new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3185), 1, false, 12.99m, null },
                    { 2, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3195), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3194), 1, false, 13.99m, null },
                    { 3, new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3197), new DateTime(2025, 1, 28, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3196), 2, false, 14.99m, null },
                    { 4, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3199), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3199), 2, false, 15.99m, null },
                    { 5, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3201), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3200), 3, false, 11.99m, null },
                    { 6, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3203), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3202), 4, false, 16.99m, null },
                    { 7, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3205), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3204), 5, false, 9.99m, null },
                    { 8, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3207), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3207), 6, false, 14.99m, null },
                    { 9, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3209), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3209), 7, false, 5.99m, null },
                    { 10, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3211), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3211), 8, false, 4.99m, null },
                    { 11, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3213), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3213), 9, false, 3.99m, null },
                    { 12, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3215), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3215), 10, false, 6.99m, null },
                    { 13, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3217), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3216), 11, false, 5.99m, null },
                    { 14, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3219), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3218), 12, false, 6.49m, null },
                    { 15, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3221), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3220), 13, false, 4.99m, null },
                    { 16, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3223), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3222), 14, false, 5.49m, null },
                    { 17, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3225), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3224), 15, false, 7.99m, null },
                    { 18, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3227), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3226), 16, false, 6.99m, null },
                    { 19, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3229), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(3228), 17, false, 8.99m, null },
                    { 20, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6310), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6304), 18, false, 7.99m, null },
                    { 21, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6319), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6318), 19, false, 8.49m, null },
                    { 22, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6321), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6320), 20, false, 7.49m, null },
                    { 23, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6323), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6322), 21, false, 4.99m, null },
                    { 24, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6325), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6324), 22, false, 3.99m, null },
                    { 25, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6326), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6326), 23, false, 4.49m, null },
                    { 26, new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6328), new DateTime(2025, 2, 27, 19, 14, 21, 295, DateTimeKind.Local).AddTicks(6328), 24, false, 5.99m, null }
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
                table: "Users",
                keyColumn: "UserId",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1);

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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HotPotInventorys");

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
