using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 0m),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointCost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Hotpots",
                columns: table => new
                {
                    HotpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastMaintainDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotpots", x => x.HotpotId);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTypes",
                columns: table => new
                {
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypes", x => x.IngredientTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SizeDiscounts",
                columns: table => new
                {
                    SizeDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinSize = table.Column<int>(type: "int", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeDiscounts", x => x.SizeDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "TurtorialVideos",
                columns: table => new
                {
                    TurtorialVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurtorialVideos", x => x.TurtorialVideoId);
                });

            migrationBuilder.CreateTable(
                name: "UtensilTypes",
                columns: table => new
                {
                    UtensilTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtensilTypes", x => x.UtensilTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DaysOfWeek = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotPotInventorys",
                columns: table => new
                {
                    HotPotInventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HotpotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotPotInventorys", x => x.HotPotInventoryId);
                    table.ForeignKey(
                        name: "FK_HotPotInventorys_Hotpots_HotpotId",
                        column: x => x.HotpotId,
                        principalTable: "Hotpots",
                        principalColumn: "HotpotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MinStockLevel = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientTypes_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "IngredientTypes",
                        principalColumn: "IngredientTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LoyatyPoint = table.Column<double>(type: "float", nullable: true),
                    WorkDays = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utensils",
                columns: table => new
                {
                    UtensilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastMaintainDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtensilTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utensils", x => x.UtensilId);
                    table.ForeignKey(
                        name: "FK_Utensils_UtensilTypes_UtensilTypeId",
                        column: x => x.UtensilTypeId,
                        principalTable: "UtensilTypes",
                        principalColumn: "UtensilTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    ComboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsCustomizable = table.Column<bool>(type: "bit", nullable: false),
                    HotpotBrothId = table.Column<int>(type: "int", nullable: false),
                    AppliedDiscountId = table.Column<int>(type: "int", nullable: true),
                    TurtorialVideoId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboId);
                    table.ForeignKey(
                        name: "FK_Combos_Ingredients_HotpotBrothId",
                        column: x => x.HotpotBrothId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combos_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_Combos_SizeDiscounts_AppliedDiscountId",
                        column: x => x.AppliedDiscountId,
                        principalTable: "SizeDiscounts",
                        principalColumn: "SizeDiscountId");
                    table.ForeignKey(
                        name: "FK_Combos_TurtorialVideos_TurtorialVideoId",
                        column: x => x.TurtorialVideoId,
                        principalTable: "TurtorialVideos",
                        principalColumn: "TurtorialVideoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientPrices",
                columns: table => new
                {
                    IngredientPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPrices", x => x.IngredientPriceId);
                    table.ForeignKey(
                        name: "FK_IngredientPrices_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatSessions",
                columns: table => new
                {
                    ChatSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSessions", x => x.ChatSessionId);
                    table.ForeignKey(
                        name: "FK_ChatSessions_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatSessions_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    HasSellItems = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasRentItems = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
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

            migrationBuilder.CreateTable(
                name: "DamageDevices",
                columns: table => new
                {
                    DamageDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtensilId = table.Column<int>(type: "int", nullable: true),
                    HotPotInventoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageDevices", x => x.DamageDeviceId);
                    table.ForeignKey(
                        name: "FK_DamageDevices_HotPotInventorys_HotPotInventoryId",
                        column: x => x.HotPotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_DamageDevices_Utensils_UtensilId",
                        column: x => x.UtensilId,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
                });

            migrationBuilder.CreateTable(
                name: "ComboAllowedIngredientTypes",
                columns: table => new
                {
                    ComboAllowedIngredientTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    MinQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboAllowedIngredientTypes", x => x.ComboAllowedIngredientTypeId);
                    table.ForeignKey(
                        name: "FK_ComboAllowedIngredientTypes_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComboAllowedIngredientTypes_IngredientTypes_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "IngredientTypes",
                        principalColumn: "IngredientTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboIngredients",
                columns: table => new
                {
                    ComboIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboIngredients", x => x.ComboIngredientId);
                    table.ForeignKey(
                        name: "FK_ComboIngredients_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComboIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customizations",
                columns: table => new
                {
                    CustomizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HotpotBrothId = table.Column<int>(type: "int", nullable: false),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    AppliedDiscountId = table.Column<int>(type: "int", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.CustomizationId);
                    table.ForeignKey(
                        name: "FK_Customizations_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_Ingredients_HotpotBrothId",
                        column: x => x.HotpotBrothId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customizations_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_Customizations_SizeDiscounts_AppliedDiscountId",
                        column: x => x.AppliedDiscountId,
                        principalTable: "SizeDiscounts",
                        principalColumn: "SizeDiscountId");
                    table.ForeignKey(
                        name: "FK_Customizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    ChatMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserId = table.Column<int>(type: "int", nullable: false),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "ChatSessions",
                        principalColumn: "ChatSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Response = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Feedback_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Feedback_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotpotDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DamageFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RentalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReturnCondition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_RentOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_SellOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingOrders",
                columns: table => new
                {
                    ShippingOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    ProofImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProofImageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProofTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingOrders", x => x.ShippingOrderId);
                    table.ForeignKey(
                        name: "FK_ShippingOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingOrders_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReplacementRequests",
                columns: table => new
                {
                    ReplacementRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AssignedStaffId = table.Column<int>(type: "int", nullable: true),
                    ConditionLogId = table.Column<int>(type: "int", nullable: true),
                    EquipmentType = table.Column<int>(type: "int", nullable: false),
                    HotPotInventoryId = table.Column<int>(type: "int", nullable: true),
                    UtensilId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementRequests", x => x.ReplacementRequestId);
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_DamageDevices_ConditionLogId",
                        column: x => x.ConditionLogId,
                        principalTable: "DamageDevices",
                        principalColumn: "DamageDeviceId");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_HotPotInventorys_HotPotInventoryId",
                        column: x => x.HotPotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Users_AssignedStaffId",
                        column: x => x.AssignedStaffId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Utensils_UtensilId",
                        column: x => x.UtensilId,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
                });

            migrationBuilder.CreateTable(
                name: "CustomizationIngredients",
                columns: table => new
                {
                    CustomizationIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CustomizationId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizationIngredients", x => x.CustomizationIngredientId);
                    table.ForeignKey(
                        name: "FK_CustomizationIngredients_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomizationIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentOrderDetails",
                columns: table => new
                {
                    RentOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UtensilId = table.Column<int>(type: "int", nullable: true),
                    HotpotInventoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentOrderDetails", x => x.RentOrderDetailId);
                    table.ForeignKey(
                        name: "FK_RentOrderDetails_HotPotInventorys_HotpotInventoryId",
                        column: x => x.HotpotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_RentOrderDetails_RentOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "RentOrders",
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
                        name: "FK_SellOrderDetails_SellOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "SellOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Hotpots",
                columns: new[] { "HotpotId", "BasePrice", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Size", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 89.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3319), "Traditional copper hotpot with charcoal heating.", "https://example.com/images/classic-copper-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Copper", "Classic Copper Hotpot", 29.99m, 5, "m", true, null },
                    { 2, 129.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3332), "Electric hotpot with temperature control and non-stick coating.", "https://example.com/images/modern-electric-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Modern Electric Hotpot", 59.99m, 2, "L", true, null },
                    { 3, 69.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3334), "Compact portable hotpot perfect for travel or small gatherings.", "https://example.com/images/mini-portable-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluminum", "Mini Portable Hotpot", 19.99m, 2, "S", true, null },
                    { 4, 149.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3426), "Multi-compartment hotpot for different broths in one pot.", "https://example.com/images/dual-section-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Dual Section Hotpot", 69.99m, 2, "L", true, null },
                    { 5, 79.99m, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3428), "Authentic ceramic hotpot that retains heat exceptionally well.", "https://example.com/images/traditional-ceramic-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceramic", "Traditional Ceramic Hotpot", 39.99m, 4, "M", true, null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "IngredientTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3633), false, "Broth", null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3635), false, "Seafood", null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3636), false, "Vegetables", null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3636), false, "Noodles", null },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3637), false, "Tofu", null },
                    { 6, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3638), false, "Mushrooms", null },
                    { 7, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3638), false, "Meats", null },
                    { 8, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3639), false, "Sauces", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(453), false, "Admin", null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(464), false, "Manager", null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(465), false, "Staff", null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(465), false, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "TurtorialVideos",
                columns: new[] { "TurtorialVideoId", "CreatedAt", "Description", "IsDelete", "Name", "UpdatedAt", "VideoURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3157), "A comprehensive guide to setting up and using a traditional hotpot.", false, "How to Use Traditional Hotpot", null, "https://www.youtube.com/watch?v=traditional-hotpot-guide" },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3161), "Learn how to safely set up and use your electric hotpot.", false, "Electric Hotpot Setup Guide", null, "https://www.youtube.com/watch?v=electric-hotpot-setup" },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3162), "Tips and tricks for using your portable hotpot anywhere.", false, "Portable Hotpot on the Go", null, "https://www.youtube.com/watch?v=portable-hotpot-guide" },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3163), "How to effectively use all compartments in your multi-section hotpot.", false, "Multi-compartment Hotpot Mastery", null, "https://www.youtube.com/watch?v=multi-compartment-guide" },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3164), "Learn how to properly care for and maintain your ceramic hotpot.", false, "Ceramic Hotpot Care Guide", null, "https://www.youtube.com/watch?v=ceramic-hotpot-care" }
                });

            migrationBuilder.InsertData(
                table: "UtensilTypes",
                columns: new[] { "UtensilTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3090), false, "Chopsticks", null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3094), false, "Ladles", null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3095), false, "Strainers", null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3096), false, "Bowls", null },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3097), false, "Plates", null }
                });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3500), 1, false, "CP-2023-0001", true, null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3503), 1, false, "CP-2023-0002", true, null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3504), 2, false, "EL-2023-0001", true, null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3505), 2, false, "EL-2023-0002", true, null },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3505), 3, false, "PT-2023-0001", true, null },
                    { 6, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3513), 4, false, "MC-2023-0001", true, null },
                    { 7, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3518), 5, false, "CR-2023-0001", true, null },
                    { 8, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3519), 1, false, "CP-2023-0003", true, null },
                    { 9, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3520), 1, false, "CP-2023-0004", true, null },
                    { 10, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3520), 1, false, "CP-2023-0005", true, null },
                    { 11, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3521), 3, false, "PT-2023-0002", true, null },
                    { 12, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3522), 4, false, "MC-2023-0002", true, null },
                    { 13, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3523), 5, false, "CR-2023-0002", true, null },
                    { 14, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3524), 5, false, "CR-2023-0003", true, null },
                    { 15, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3525), 5, false, "CR-2023-0004", false, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CreatedAt", "Description", "ImageURL", "IngredientTypeId", "IsDelete", "MinStockLevel", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3677), "Thinly sliced premium beef perfect for hotpot.", "https://example.com/images/sliced-beef.jpg", 7, false, 20, "Sliced Beef", 100, null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3683), "Tender sliced lamb meat, perfect for quick cooking.", "https://example.com/images/lamb-slices.jpg", 7, false, 15, "Lamb Slices", 80, null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3684), "Thinly sliced pork belly with perfect fat-to-meat ratio.", "https://example.com/images/pork-belly.jpg", 7, false, 15, "Pork Belly", 75, null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3686), "Fresh, peeled and deveined shrimp.", "https://example.com/images/shrimp.jpg", 2, false, 20, "Shrimp", 90, null },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3687), "Bouncy fish balls made from fresh fish paste.", "https://example.com/images/fish-balls.jpg", 2, false, 30, "Fish Balls", 120, null },
                    { 6, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3688), "Fresh squid sliced into rings.", "https://example.com/images/squid.jpg", 2, false, 15, "Squid", 60, null },
                    { 7, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3690), "Crisp, leafy vegetable perfect for hotpot.", "https://example.com/images/napa-cabbage.jpg", 3, false, 25, "Napa Cabbage", 100, null },
                    { 8, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3692), "Fresh spinach leaves, washed and ready to cook.", "https://example.com/images/spinach.jpg", 3, false, 20, "Spinach", 80, null },
                    { 9, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3693), "Sweet corn cut into bite-sized pieces.", "https://example.com/images/corn.jpg", 3, false, 15, "Corn", 70, null },
                    { 10, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3694), "Thick, chewy Japanese wheat noodles.", "https://example.com/images/udon-noodles.jpg", 4, false, 20, "Udon Noodles", 80, null },
                    { 11, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3695), "Transparent noodles made from mung bean starch.", "https://example.com/images/glass-noodles.jpg", 4, false, 20, "Glass Noodles", 85, null },
                    { 12, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3696), "Curly wheat noodles perfect for hotpot.", "https://example.com/images/ramen-noodles.jpg", 4, false, 25, "Ramen Noodles", 90, null },
                    { 13, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3697), "Firm tofu cubes that hold their shape in hotpot.", "https://example.com/images/firm-tofu.jpg", 5, false, 15, "Firm Tofu", 60, null },
                    { 14, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3699), "Deep-fried tofu puffs that absorb broth flavors.", "https://example.com/images/tofu-puffs.jpg", 5, false, 15, "Tofu Puffs", 65, null },
                    { 15, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3700), "Flavorful shiitake mushrooms, fresh or dried.", "https://example.com/images/shiitake.jpg", 6, false, 15, "Shiitake Mushrooms", 70, null },
                    { 16, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3701), "Delicate, long-stemmed enoki mushrooms.", "https://example.com/images/enoki.jpg", 6, false, 15, "Enoki Mushrooms", 65, null },
                    { 17, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3702), "Traditional spicy broth with Sichuan peppercorns and chili oil.", "https://example.com/images/sichuan-broth.jpg", 1, false, 10, "Spicy Sichuan Broth", 50, null },
                    { 18, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3703), "Tangy tomato-based broth, slightly sweet and sour.", "https://example.com/images/tomato-broth.jpg", 1, false, 10, "Tomato Broth", 45, null },
                    { 19, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3704), "Rich umami broth made from various mushrooms.", "https://example.com/images/mushroom-broth.jpg", 1, false, 10, "Mushroom Broth", 40, null },
                    { 20, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3729), "Light, clear broth made from simmering bones for hours.", "https://example.com/images/bone-broth.jpg", 1, false, 10, "Clear Bone Broth", 55, null },
                    { 21, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3732), "Creamy sauce made from ground sesame seeds.", "https://example.com/images/sesame-sauce.jpg", 8, false, 10, "Sesame Sauce", 40, null },
                    { 22, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3733), "Soy sauce infused with fresh minced garlic.", "https://example.com/images/garlic-soy.jpg", 8, false, 10, "Garlic Soy Sauce", 45, null },
                    { 23, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3734), "Spicy oil made from infusing oil with chili peppers.", "https://example.com/images/chili-oil.jpg", 8, false, 10, "Chili Oil", 50, null },
                    { 24, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3735), "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.", "https://example.com/images/shacha-sauce.jpg", 8, false, 10, "Shacha Sauce", 35, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "LoyatyPoint", "Name", "Note", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleId", "UpdatedAt", "WorkDays" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 25, 11, 11, 31, 605, DateTimeKind.Utc).AddTicks(573), "Admin@gmail.com", null, false, null, "Admin", null, "$2a$12$XC5yzcQzr.7nHZDp.81PTeaxtUEGFl712QoJHU/olJpvf16Q/j.r6", "987654321", null, null, 1, null, null },
                    { 2, null, new DateTime(2025, 3, 25, 11, 11, 31, 833, DateTimeKind.Utc).AddTicks(6274), "Manager1@gmail.com", null, false, null, "Manager1", null, "$2a$12$FoRV8I4MTkatKlA7QSPvmuIThhx454ARxV1fyW7QgcYuQis3nCR8a", "999999999", null, null, 2, null, null },
                    { 3, null, new DateTime(2025, 3, 25, 11, 11, 32, 59, DateTimeKind.Utc).AddTicks(9314), "Manager2@gmail.com", null, false, null, "Manager2", null, "$2a$12$9uyK98F5wdd3a/vO7TZ33eU/6NdkpCVdd0DUCg5KdHgvzCsjH8n/.", "888888888", null, null, 2, null, null },
                    { 4, null, new DateTime(2025, 3, 25, 11, 11, 32, 291, DateTimeKind.Utc).AddTicks(2790), "Staff1@gmail.com", null, false, null, "Staff1", null, "$2a$12$TCoEev3jbcFCLbhA0LNqy..imbYccjJaWQ.xtgFWr7zP7alj1nhpC", "777777777", null, null, 3, null, null },
                    { 5, null, new DateTime(2025, 3, 25, 11, 11, 32, 520, DateTimeKind.Utc).AddTicks(862), "Staff2@gmail.com", null, false, null, "Staff2", null, "$2a$12$waUVjFYxUAEQ/2D4IbJ/EOAyKW/2GXCvTmCOXaXnbbaVwm/D8BuSu", "666666666", null, null, 3, null, null },
                    { 6, null, new DateTime(2025, 3, 25, 11, 11, 32, 746, DateTimeKind.Utc).AddTicks(6036), "Staff3@gmail.com", null, false, null, "Staff3", null, "$2a$12$mOPjmO6uPPyt.xuHhzQGZORTiy5RbBW.z52axDuxqXJO9QHrCW.ka", "555555555", null, null, 3, null, null },
                    { 7, null, new DateTime(2025, 3, 25, 11, 11, 32, 974, DateTimeKind.Utc).AddTicks(341), "Staff4@gmail.com", null, false, null, "Staff4", null, "$2a$12$sVTtkK1fw.lRfYHj/K9hI.ScuM0UEHWBt6CokBAt4KVlqL6LtPDna", "444444444", null, null, 3, null, null },
                    { 8, null, new DateTime(2025, 3, 25, 11, 11, 33, 199, DateTimeKind.Utc).AddTicks(7638), "Customer1@gmail.com", null, false, null, "Customer1", null, "$2a$12$3tTIOh2dv3D7NeUHzlWkD.V6AfTDKctO5RWiNkMYoT9kuvsb7uL1u", "333333333", null, null, 4, null, null },
                    { 9, null, new DateTime(2025, 3, 25, 11, 11, 33, 425, DateTimeKind.Utc).AddTicks(4109), "Customer2@gmail.com", null, false, null, "Customer2", null, "$2a$12$J5.bCaMRVXuNR/2vGO9qe.jBuQ3ryB507gNOWYPbDK0yQ1jShOgSG", "222222222", null, null, 4, null, null },
                    { 10, null, new DateTime(2025, 3, 25, 11, 11, 33, 655, DateTimeKind.Utc).AddTicks(9900), "Customer3@gmail.com", null, false, 200.0, "Customer3", null, "$2a$12$PVHZH90NtSV8uRwEQQohLu5X9G68AbtUE6Kl8LUV/3gIo2q35.eoC", "111111111", null, null, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Utensils",
                columns: new[] { "UtensilId", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Status", "UpdatedAt", "UtensilTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3583), "Set of 5 pairs of traditional bamboo chopsticks.", "https://example.com/images/bamboo-chopsticks.jpg", false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3583), "Bamboo", "Bamboo Chopsticks Set", 12.99m, 100, true, null, 1 },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3589), "Durable stainless steel ladle for serving hotpot broth.", "https://example.com/images/steel-ladle.jpg", false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3590), "Stainless Steel", "Stainless Steel Hotpot Ladle", 9.99m, 75, true, null, 2 },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3592), "Fine mesh strainer for retrieving food from the hotpot.", "https://example.com/images/mesh-strainer.jpg", false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3592), "Stainless Steel", "Wire Mesh Strainer", 7.99m, 80, true, null, 3 },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3593), "Set of 4 ceramic bowls for individual servings.", "https://example.com/images/ceramic-bowls.jpg", false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3594), "Ceramic", "Ceramic Serving Bowl Set", 19.99m, 50, true, null, 4 },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3595), "Set of 6 durable melamine plates for hotpot dining.", "https://example.com/images/melamine-plates.jpg", false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3595), "Melamine", "Melamine Plates", 24.99m, 60, true, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "DamageDevices",
                columns: new[] { "DamageDeviceId", "CreatedAt", "Description", "HotPotInventoryId", "IsDelete", "LoggedDate", "Name", "Status", "UpdatedAt", "UtensilId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3894), "The handle of the hotpot is broken and needs to be replaced.", 15, false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3897), "Broken Handle", 1, null, null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3898), "The base of the hotpot is cracked and needs to be replaced.", 10, false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3899), "Cracked Base", 2, null, null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3900), "The lid of the hotpot is damaged and needs to be replaced.", 9, false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3901), "Damaged Lid", 3, null, null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3902), "The plates are broken and need to be replaced.", null, false, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3903), "broken plates", 4, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "IngredientPrices",
                columns: new[] { "IngredientPriceId", "CreatedAt", "EffectiveDate", "IngredientId", "IsDelete", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3795), new DateTime(2025, 2, 23, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3797), 1, false, 0.13m, null },
                    { 2, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3807), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3807), 1, false, 0.14m, null },
                    { 3, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3809), new DateTime(2025, 2, 23, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3809), 2, false, 0.15m, null },
                    { 4, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3810), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3811), 2, false, 0.16m, null },
                    { 5, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3811), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3812), 3, false, 0.12m, null },
                    { 6, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3813), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3814), 4, false, 0.17m, null },
                    { 7, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3814), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3815), 5, false, 0.10m, null },
                    { 8, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3816), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3816), 6, false, 0.15m, null },
                    { 9, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3818), 7, false, 0.06m, null },
                    { 10, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3820), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3820), 8, false, 0.05m, null },
                    { 11, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3821), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3822), 9, false, 0.04m, null },
                    { 12, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3823), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3823), 10, false, 0.07m, null },
                    { 13, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3824), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3825), 11, false, 0.06m, null },
                    { 14, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3826), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3826), 12, false, 0.065m, null },
                    { 15, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3827), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3835), 13, false, 0.05m, null },
                    { 16, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3835), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3836), 14, false, 0.055m, null },
                    { 17, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3838), 15, false, 0.08m, null },
                    { 18, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3838), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3839), 16, false, 0.07m, null },
                    { 19, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3840), 17, false, 0.009m, null },
                    { 20, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3841), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3842), 18, false, 0.008m, null },
                    { 21, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3843), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3843), 19, false, 0.0085m, null },
                    { 22, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3844), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3848), 20, false, 0.0075m, null },
                    { 23, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3849), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3850), 21, false, 0.005m, null },
                    { 24, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3851), 22, false, 0.004m, null },
                    { 25, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3852), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3852), 23, false, 0.0045m, null },
                    { 26, new DateTime(2025, 3, 25, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3853), new DateTime(2025, 3, 22, 11, 11, 33, 891, DateTimeKind.Utc).AddTicks(3854), 24, false, 0.006m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ReceiverUserId",
                table: "ChatMessages",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderUserId",
                table: "ChatMessages",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SessionId",
                table: "ChatMessages",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessions_CustomerId",
                table: "ChatSessions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessions_ManagerId",
                table: "ChatSessions",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboAllowedIngredientTypes_ComboId",
                table: "ComboAllowedIngredientTypes",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboAllowedIngredientTypes_IngredientTypeId",
                table: "ComboAllowedIngredientTypes",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboIngredients_ComboId_IngredientId",
                table: "ComboIngredients",
                columns: new[] { "ComboId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_ComboIngredients_IngredientId",
                table: "ComboIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_AppliedDiscountId",
                table: "Combos",
                column: "AppliedDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_HotpotBrothId",
                table: "Combos",
                column: "HotpotBrothId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_IngredientId",
                table: "Combos",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_TurtorialVideoId",
                table: "Combos",
                column: "TurtorialVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizationIngredients_CustomizationId_IngredientId",
                table: "CustomizationIngredients",
                columns: new[] { "CustomizationId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizationIngredients_IngredientId",
                table: "CustomizationIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_AppliedDiscountId",
                table: "Customizations",
                column: "AppliedDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_ComboId",
                table: "Customizations",
                column: "ComboId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_HotpotBrothId",
                table: "Customizations",
                column: "HotpotBrothId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_IngredientId",
                table: "Customizations",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UserId",
                table: "Customizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageDevices_HotPotInventoryId",
                table: "DamageDevices",
                column: "HotPotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageDevices_UtensilId",
                table: "DamageDevices",
                column: "UtensilId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApprovedByUserId",
                table: "Feedback",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ManagerId",
                table: "Feedback",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrderId",
                table: "Feedback",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotPotInventorys_HotpotId",
                table: "HotPotInventorys",
                column: "HotpotId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPrices_IngredientId",
                table: "IngredientPrices",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId",
                unique: true,
                filter: "[DiscountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

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
                name: "IX_ReplacementRequests_AssignedStaffId",
                table: "ReplacementRequests",
                column: "AssignedStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_ConditionLogId",
                table: "ReplacementRequests",
                column: "ConditionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_HotPotInventoryId",
                table: "ReplacementRequests",
                column: "HotPotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_UtensilId",
                table: "ReplacementRequests",
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
                name: "IX_ShippingOrders_OrderId",
                table: "ShippingOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOrders_StaffId",
                table: "ShippingOrders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_RentOrderDetailId",
                table: "StaffPickupAssignments",
                column: "RentOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPickupAssignments_StaffId",
                table: "StaffPickupAssignments",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkShift_MangerWorkShiftsId",
                table: "UserWorkShift",
                column: "MangerWorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkShift1_StaffWorkShiftsId",
                table: "UserWorkShift1",
                column: "StaffWorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Utensils_UtensilTypeId",
                table: "Utensils",
                column: "UtensilTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ComboAllowedIngredientTypes");

            migrationBuilder.DropTable(
                name: "ComboIngredients");

            migrationBuilder.DropTable(
                name: "CustomizationIngredients");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "IngredientPrices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ReplacementRequests");

            migrationBuilder.DropTable(
                name: "SellOrderDetails");

            migrationBuilder.DropTable(
                name: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "StaffPickupAssignments");

            migrationBuilder.DropTable(
                name: "UserWorkShift");

            migrationBuilder.DropTable(
                name: "UserWorkShift1");

            migrationBuilder.DropTable(
                name: "ChatSessions");

            migrationBuilder.DropTable(
                name: "DamageDevices");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "SellOrders");

            migrationBuilder.DropTable(
                name: "RentOrderDetails");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "HotPotInventorys");

            migrationBuilder.DropTable(
                name: "RentOrders");

            migrationBuilder.DropTable(
                name: "Utensils");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "SizeDiscounts");

            migrationBuilder.DropTable(
                name: "TurtorialVideos");

            migrationBuilder.DropTable(
                name: "Hotpots");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UtensilTypes");

            migrationBuilder.DropTable(
                name: "IngredientTypes");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
