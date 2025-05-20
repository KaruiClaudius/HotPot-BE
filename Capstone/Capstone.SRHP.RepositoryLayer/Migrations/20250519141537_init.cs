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
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    WorkShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ShiftEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.WorkShiftId);
                });

            migrationBuilder.CreateTable(
                name: "HotPotInventorys",
                columns: table => new
                {
                    HotPotInventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HotpotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeasurementValue = table.Column<double>(type: "float", nullable: false),
                    MinStockLevel = table.Column<int>(type: "int", nullable: false),
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
                    StaffType = table.Column<int>(type: "int", nullable: true),
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
                    AppliedDiscountId = table.Column<int>(type: "int", nullable: true),
                    TurtorialVideoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboId);
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
                name: "DamageDevices",
                columns: table => new
                {
                    DamageDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "IngredientBatchs",
                columns: table => new
                {
                    IngredientBatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    InitialQuantity = table.Column<int>(type: "int", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "int", nullable: false),
                    BestBeforeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientBatchs", x => x.IngredientBatchId);
                    table.ForeignKey(
                        name: "FK_IngredientBatchs_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
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
                    OrderCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    PreparationStaffId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Orders_Users_PreparationStaffId",
                        column: x => x.PreparationStaffId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserManagerWorkShifts",
                columns: table => new
                {
                    ManagersUserId = table.Column<int>(type: "int", nullable: false),
                    MangerWorkShiftsWorkShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManagerWorkShifts", x => new { x.ManagersUserId, x.MangerWorkShiftsWorkShiftId });
                    table.ForeignKey(
                        name: "FK_UserManagerWorkShifts_Users_ManagersUserId",
                        column: x => x.ManagersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserManagerWorkShifts_WorkShifts_MangerWorkShiftsWorkShiftId",
                        column: x => x.MangerWorkShiftsWorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "WorkShiftId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "UserStaffWorkShifts",
                columns: table => new
                {
                    StaffUserId = table.Column<int>(type: "int", nullable: false),
                    StaffWorkShiftsWorkShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStaffWorkShifts", x => new { x.StaffUserId, x.StaffWorkShiftsWorkShiftId });
                    table.ForeignKey(
                        name: "FK_UserStaffWorkShifts_Users_StaffUserId",
                        column: x => x.StaffUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStaffWorkShifts_WorkShifts_StaffWorkShiftsWorkShiftId",
                        column: x => x.StaffWorkShiftsWorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "WorkShiftId",
                        onDelete: ReferentialAction.Cascade);
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
                    ComboId = table.Column<int>(type: "int", nullable: true),
                    AppliedDiscountId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
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
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    AssignedStaffId = table.Column<int>(type: "int", nullable: true),
                    DamageDeviceId = table.Column<int>(type: "int", nullable: true),
                    HotPotInventoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementRequests", x => x.ReplacementRequestId);
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_DamageDevices_DamageDeviceId",
                        column: x => x.DamageDeviceId,
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
                        principalColumn: "UserId");
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
                    Purpose = table.Column<int>(type: "int", nullable: false),
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
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    DeliveryNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    OrderSize = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_ShippingOrders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

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
                name: "PaymentReceipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReceipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_PaymentReceipts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentReceipts_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
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
                    UtensilId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_SellOrderDetails_Utensils_UtensilId",
                        column: x => x.UtensilId,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
                });

            migrationBuilder.CreateTable(
                name: "IngredientUsages",
                columns: table => new
                {
                    IngredientUsageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientBatchId = table.Column<int>(type: "int", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: true),
                    ComboId = table.Column<int>(type: "int", nullable: true),
                    CustomizationId = table.Column<int>(type: "int", nullable: true),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUsages", x => x.IngredientUsageId);
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_IngredientBatchs_IngredientBatchId",
                        column: x => x.IngredientBatchId,
                        principalTable: "IngredientBatchs",
                        principalColumn: "IngredientBatchId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_IngredientUsages_SellOrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "SellOrderDetails",
                        principalColumn: "SellOrderDetailId");
                });

            migrationBuilder.InsertData(
                table: "Hotpots",
                columns: new[] { "HotpotId", "BasePrice", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2200000m, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3571), "Nồi lẩu đồng truyền thống với hệ thống đốt than.", "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/noilaudongcodien.jpg?alt=media\\u0026token=6f345d27-7ff9-43e6-8beb-e50f29578436\"]", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồng", "Nồi Lẩu Đồng Cổ Điển", 730000m, 5, "M", null },
                    { 2, 3170000m, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4154), "Nồi lẩu điện với điều khiển nhiệt độ và lớp phủ chống dính.", "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/noi-lau-dien-sunhouse-shd4523-gia-re.jpg?alt=media\\u0026token=2d6c1dd9-c484-4dde-94a2-bdf52e511d0b\"]", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thép Không Gỉ", "Nồi Lẩu Điện Hiện Đại", 1460000m, 2, "L", null },
                    { 3, 1710000m, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4178), "Nồi lẩu nhỏ gọn di động hoàn hảo cho du lịch hoặc các buổi tụ họp nhỏ.", "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/noi-lau-mini-lebenlang-lbec0808-shr-1000x1000.jpg?alt=media\\u0026token=92f6bcd1-169c-43c0-8e73-013cb8a68637\"]", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhôm", "Nồi Lẩu Mini Di Động", 490000m, 2, "S", null },
                    { 4, 3660000m, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4213), "Nồi lẩu đa ngăn cho phép nấu nhiều loại nước lẩu khác nhau trong một nồi.", "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-hai-ngan.jpg?alt=media%token=4c530d54-dafd-45fe-8d77-7b6c45a81b5a\"]", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thép Không Gỉ", "Nồi Lẩu Hai Ngăn", 1710000m, 2, "L", null },
                    { 5, 1950000m, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(4247), "Nồi lẩu gốm truyền thống giữ nhiệt cực tốt.", "[\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau%20inox.jpg?alt=media\\u0026token=e4963f3f-5130-4485-9932-39cecd7a98af\",\"https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau%20inox%202.jpg?alt=media\\u0026token=4dda3d4c-3ba3-4cd0-96fc-d4ff505c5887\"]", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gốm", "Nồi Lẩu Gốm Truyền Thống", 980000m, 4, "M", null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "IngredientTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6623), false, "Nước Lẩu", null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6626), false, "Hải Sản", null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6627), false, "Rau Củ", null },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6628), false, "Mì", null },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6629), false, "Đậu Phụ", null },
                    { 6, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6629), false, "Nấm", null },
                    { 7, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6630), false, "Thịt", null },
                    { 8, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6630), false, "Nước Chấm", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4601), false, "Admin", null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4612), false, "Manager", null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4613), false, "Staff", null },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4614), false, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "SizeDiscounts",
                columns: new[] { "SizeDiscountId", "CreatedAt", "DiscountPercentage", "EndDate", "IsDelete", "MinSize", "StartDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7113), 4.00m, null, false, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7114) },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7117), 8.00m, null, false, 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7118) },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7120), 12.00m, null, false, 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7121) },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7150), 16.00m, null, false, 8, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7151) },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7153), 20.00m, null, false, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7154) },
                    { 6, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7156), 24.00m, null, false, 15, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7156) },
                    { 7, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7158), 28.00m, null, false, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7159) }
                });

            migrationBuilder.InsertData(
                table: "TurtorialVideos",
                columns: new[] { "TurtorialVideoId", "CreatedAt", "Description", "IsDelete", "Name", "UpdatedAt", "VideoURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3436), "Hướng dẫn toàn diện về cách thiết lập và sử dụng nồi lẩu truyền thống.", false, "Cách Sử Dụng Nồi Lẩu Truyền Thống", null, "https://www.youtube.com/watch?v=traditional-hotpot-guide" },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3443), "Học cách thiết lập và sử dụng nồi lẩu điện an toàn.", false, "Hướng Dẫn Thiết Lập Nồi Lẩu Điện", null, "https://www.youtube.com/watch?v=electric-hotpot-setup" },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3444), "Mẹo và thủ thuật để sử dụng nồi lẩu di động ở bất kỳ đâu.", false, "Nồi Lẩu Di Động Mọi Lúc Mọi Nơi", null, "https://www.youtube.com/watch?v=portable-hotpot-guide" },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3445), "Cách sử dụng hiệu quả tất cả các ngăn trong nồi lẩu đa ngăn của bạn.", false, "Làm Chủ Nồi Lẩu Đa Ngăn", null, "https://www.youtube.com/watch?v=multi-compartment-guide" },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3446), "Học cách chăm sóc và bảo quản nồi lẩu gốm đúng cách.", false, "Hướng Dẫn Chăm Sóc Nồi Lẩu Gốm", null, "https://www.youtube.com/watch?v=ceramic-hotpot-care" }
                });

            migrationBuilder.InsertData(
                table: "UtensilTypes",
                columns: new[] { "UtensilTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3355), false, "Đũa", null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3360), false, "Muôi", null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3361), false, "Vợt", null },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3362), false, "Bát", null },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(3362), false, "Đĩa", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CreatedAt", "IsDelete", "LicensePlate", "Name", "Notes", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7214), false, "59P1-12345", "Honda Wave Alpha", "Xe máy giao hàng tiêu chuẩn, màu xanh dương, đã được bảo dưỡng tháng 3/2025", 1, 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7215) },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7217), false, "59P2-23456", "Yamaha Sirius", "Xe máy giao hàng nhanh, màu đỏ, tiết kiệm nhiên liệu", 1, 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7218) },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7220), false, "59P2-34567", "Honda Vision", "Xe tay ga dành cho đơn hàng nhỏ, màu trắng, có thùng hàng 60L", 2, 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7220) },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7222), false, "59P3-45678", "Suzuki Raider", "Xe máy giao hàng tốc độ cao, phù hợp cho đơn hàng khẩn cấp", 1, 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7223) },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7225), false, "51A-12345", "Toyota Vios", "Xe ô tô 4 chỗ, phù hợp cho đơn hàng lớn hoặc khoảng cách xa", 1, 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7225) },
                    { 6, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7227), false, "51A-23456", "Mitsubishi Xpander", "Xe ô tô 7 chỗ, đang trong quá trình bảo dưỡng định kỳ, sẽ sẵn sàng vào 25/04/2025", 1, 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7227) },
                    { 7, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7229), false, "59P3-56789", "Honda SH Mode", "Xe tay ga cao cấp, phù hợp cho giao hàng trong khu vực trung tâm thành phố", 1, 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7230) },
                    { 8, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7231), false, "51A-34567", "Ford Ranger", "Xe bán tải, phù hợp cho vận chuyển hàng hóa lớn và đường xa", 1, 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7232) },
                    { 9, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7234), false, "59P4-67890", "Piaggio Vespa", "Xe tay ga phong cách Ý, phù hợp cho giao hàng cao cấp", 1, 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7234) },
                    { 10, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7236), false, "51A-45678", "Hyundai Accent", "Xe sedan 4 chỗ, tiết kiệm nhiên liệu, phù hợp cho giao hàng khoảng cách xa", 1, 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7236) }
                });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6249), 1, false, "CP-2023-0001", 0, null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6265), 1, false, "CP-2023-0002", 0, null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6270), 2, false, "EL-2023-0001", 0, null },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6271), 2, false, "EL-2023-0002", 0, null },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6272), 3, false, "PT-2023-0001", 0, null },
                    { 6, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6273), 4, false, "MC-2023-0001", 0, null },
                    { 7, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6274), 5, false, "CR-2023-0001", 0, null },
                    { 8, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6408), 1, false, "CP-2023-0003", 0, null },
                    { 9, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6409), 1, false, "CP-2023-0004", 2, null },
                    { 10, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6410), 1, false, "CP-2023-0005", 2, null },
                    { 11, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6411), 3, false, "PT-2023-0002", 0, null },
                    { 12, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6412), 4, false, "MC-2023-0002", 0, null },
                    { 13, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6413), 5, false, "CR-2023-0002", 0, null },
                    { 14, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6414), 5, false, "CR-2023-0003", 0, null },
                    { 15, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6415), 5, false, "CR-2023-0004", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CreatedAt", "Description", "ImageURL", "IngredientTypeId", "IsDelete", "MeasurementValue", "MinStockLevel", "Name", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6684), "Thịt bò cao cấp cắt lát mỏng hoàn hảo cho lẩu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/89d16277-5f5d-45f0-9be4-6d710ecf2eaa.png?alt=media&token=a0db0650-a99e-4044-8552-88b096956487", 7, false, 250.0, 20, "Thịt Bò Cắt Lát", "g", null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6691), "Thịt cừu mềm cắt lát, hoàn hảo cho nấu nhanh.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/thit-cuu-cat-lat.jpg?alt=media&token=c2d6bbbd-b69d-450a-8d0e-396b135f35f3", 7, false, 250.0, 15, "Thịt Cừu Cắt Lát", "g", null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6692), "Thịt ba chỉ heo cắt mỏng với tỷ lệ mỡ-thịt hoàn hảo.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/ba-chi-heo.png?alt=media&token=83bbc055-4726-4c68-8ede-f0a0ea17c2d4", 7, false, 250.0, 15, "Ba Chỉ Heo", "g", null },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6694), "Tôm tươi, đã bóc vỏ và làm sạch.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/shrimps.jpg?alt=media&token=3ef01d1a-0df5-4f5a-b8db-b1fe34ae89ca", 2, false, 200.0, 20, "Tôm", "g", null },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6695), "Cá viên đàn hồi làm từ cá tươi xay.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/C%C3%A1-vi%C3%AAn-g%E1%BA%A7n-nh%C6%B0-%C4%91%C6%B0%E1%BB%A3c-l%C3%A0m-m%C3%B3n-%C4%83n-ph%E1%BB%95-bi%E1%BA%BFn-nh%C6%B0-c%C3%A1-vi%C3%AAn-chi%C3%AAn.jpg?alt=media&token=98bd96d8-124e-4883-afa0-4482913cadfa", 2, false, 300.0, 30, "Cá Viên", "g", null },
                    { 6, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6696), "Mực tươi cắt thành khoanh.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/M%E1%BB%B1c-t%C6%B0%C6%A1i-2-532x532.jpg?alt=media&token=1cd9d76a-0435-4fc3-b773-64af8b515e76", 2, false, 200.0, 15, "Mực", "g", null },
                    { 7, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6698), "Rau giòn, lá xanh hoàn hảo cho lẩu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/1ad2d8b1-30c1-45c6-aa26-fe898a065120.png?alt=media&token=918e0ce5-e455-4391-9d17-f7430b41c195", 3, false, 400.0, 25, "Cải Thảo", "g", null },
                    { 8, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6699), "Rau chân vịt tươi, đã rửa sạch và sẵn sàng để nấu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/spinach.png?alt=media&token=4ae0c9f7-e3a3-48bc-b56a-8594a0d081f2", 3, false, 300.0, 20, "Rau Chân Vịt", "g", null },
                    { 9, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6700), "Bắp ngọt cắt thành miếng vừa ăn.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/corn.jpg?alt=media&token=3d64d225-6be7-4c8f-b8b4-8b19a220d09b", 3, false, 250.0, 15, "Bắp", "g", null },
                    { 10, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6701), "Mì lúa mì Nhật Bản dày và dai.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/udon.png?alt=media&token=c05be1ca-db95-4dd2-8d36-c9567b3f7ea0", 4, false, 300.0, 20, "Mì Udon", "g", null },
                    { 11, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6702), "Miến trong suốt làm từ tinh bột đậu xanh.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/1663922149_8W3viNBAwDyUEHTj_1663931837-php9bcja8.png?alt=media&token=8a3b05d0-3cdb-4916-b451-f1ee01d38cbf", 4, false, 200.0, 20, "Miến", "g", null },
                    { 12, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6704), "Mì lúa mì xoăn hoàn hảo cho lẩu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/mi-ramen-luoc-cap-dong%20(2).png?alt=media&token=5826d348-02c2-4ded-b350-c70cc7ebc42e", 4, false, 250.0, 25, "Mì Ramen", "g", null },
                    { 13, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6705), "Đậu phụ cứng cắt khối giữ nguyên hình dạng trong lẩu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/tofu.png?alt=media&token=31b50c1e-c030-43a7-9eed-a9543f30b51d", 5, false, 300.0, 15, "Đậu Phụ Cứng", "g", null },
                    { 14, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6706), "Đậu phụ chiên giòn hấp thụ hương vị nước lẩu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/fried-tofu.png?alt=media&token=e645c47c-95f5-4a45-9407-4d99464e0023", 5, false, 250.0, 15, "Đậu Phụ Chiên", "g", null },
                    { 15, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6707), "Nấm hương thơm ngon, tươi hoặc khô.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/mnam-huong.png?alt=media&token=f6e2ec47-ad19-4688-b20b-ffba6ae5fd7a", 6, false, 200.0, 15, "Nấm Hương", "g", null },
                    { 16, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6708), "Nấm kim châm mỏng, thân dài.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/nam-kim-cham.png?alt=media&token=060215f1-02b2-402e-83e4-ba93d2535928", 6, false, 150.0, 15, "Nấm Kim Châm", "g", null },
                    { 17, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6710), "Nước lẩu cay truyền thống với hạt tiêu Tứ Xuyên và dầu ớt.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-tu-xuyen-cay.png?alt=media&token=cb8f5064-ee26-499b-8fe9-f3f4a6adc473", 1, false, 500.0, 10, "Nước Lẩu Tứ Xuyên Cay", "ml", null },
                    { 18, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6711), "Nước lẩu cà chua chua ngọt.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-ca-chua.png?alt=media&token=8fcf88b3-6128-4689-aab0-e64a48ce8b5a", 1, false, 500.0, 10, "Nước Lẩu Cà Chua", "ml", null },
                    { 19, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6712), "Nước lẩu đậm đà làm từ nhiều loại nấm.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-nam.jpg?alt=media&token=d2080167-804c-4909-9bef-1d7e8e7dcfdc", 1, false, 500.0, 10, "Nước Lẩu Nấm", "ml", null },
                    { 20, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6713), "Nước lẩu nhẹ, trong làm từ xương hầm nhiều giờ.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/lau-xuong-trong.jpg?alt=media&token=49407a13-5f3e-47a0-8126-bab93c157b69", 1, false, 500.0, 10, "Nước Lẩu Xương Trong", "ml", null },
                    { 21, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6714), "Sốt kem làm từ hạt mè xay.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/sot-me.jpg?alt=media&token=560bf6c4-26fb-4adb-b543-308089fd0e40", 8, false, 200.0, 10, "Sốt Mè", "ml", null },
                    { 22, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6716), "Nước tương pha với tỏi băm.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/sot-tuong-toi.png?alt=media&token=fe07fff2-694d-420f-aea0-9bd6723f0798", 8, false, 250.0, 10, "Nước Tương Tỏi", "ml", null },
                    { 23, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6717), "Dầu cay làm từ ớt ngâm dầu.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/dau-ot.png?alt=media&token=0ed694a6-cdfe-4a7a-b788-8f679ab5a86f", 8, false, 150.0, 10, "Dầu Ớt", "ml", null },
                    { 24, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6718), "Sốt đậm đà làm từ dầu đậu nành, tỏi, hành và hải sản khô.", "https://firebasestorage.googleapis.com/v0/b/foodshop-aa498.appspot.com/o/sot-sa-te.png?alt=media&token=fae51735-1dc5-4fb2-b950-27163f9eebdc", 8, false, 200.0, 10, "Tương Sa Tế", "ml", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "LoyatyPoint", "Name", "Note", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleId", "StaffType", "UpdatedAt", "WorkDays" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 5, 19, 21, 15, 32, 934, DateTimeKind.Utc).AddTicks(4770), "Admin@gmail.com", null, false, null, "Admin", null, "$2a$12$ULKCz/gUooEZOZgHMgN8z.omhaLJbN7/hSx2zOmYosEyepCADwiCG", "987654321", null, null, 1, null, null, null },
                    { 2, null, new DateTime(2025, 5, 19, 21, 15, 33, 185, DateTimeKind.Utc).AddTicks(2193), "Manager1@gmail.com", null, false, null, "Nguyễn Văn Quân", null, "$2a$12$h0Gt/rkXvb9d9VEKkBSwBe5fFEd4e0TQxaePLFOinNirF7Uy0ZJ9.", "999999999", null, null, 2, null, null, null },
                    { 3, null, new DateTime(2025, 5, 19, 21, 15, 33, 442, DateTimeKind.Utc).AddTicks(9121), "Manager2@gmail.com", null, false, null, "Trần Thị Thu", null, "$2a$12$wNenfg.Oy3aJHsLxU1sraO4Zy0eAjq42wDVZckZWLECLW8hlbEb7u", "888888888", null, null, 2, null, null, null },
                    { 4, null, new DateTime(2025, 5, 19, 21, 15, 33, 691, DateTimeKind.Utc).AddTicks(2197), "Staff1@gmail.com", null, false, null, "Lê Minh Hoàng", null, "$2a$12$.xlblFxGOvZvi/yt/HsRuuSY.s2aAITK0TPKueaVXlCoi6ZPCwp.W", "777777777", null, null, 3, 1, null, null },
                    { 5, null, new DateTime(2025, 5, 19, 21, 15, 33, 937, DateTimeKind.Utc).AddTicks(2858), "Staff2@gmail.com", null, false, null, "Phạm Thị Hằng", null, "$2a$12$ha5WFYAahaMSnF1nXrdlsuGv3zxsxusD5KqVBWleTrhpd3rcI0qUe", "666666666", null, null, 3, 1, null, null },
                    { 6, null, new DateTime(2025, 5, 19, 21, 15, 34, 180, DateTimeKind.Utc).AddTicks(2641), "Staff3@gmail.com", null, false, null, "Ngô Văn Cường", null, "$2a$12$xLr3XOgexepVJSiONAUZmumd9VaSZkHQ06IxzH9/bC0Qd6AESDjLS", "555555555", null, null, 3, 2, null, null },
                    { 7, null, new DateTime(2025, 5, 19, 21, 15, 34, 427, DateTimeKind.Utc).AddTicks(3098), "Staff4@gmail.com", null, false, null, "Đinh Thị Hà", null, "$2a$12$YazWmc8/cBia4X0ewL805eg9DfEVzJmz2Y0EK5JWMS0WQ4Kvg6Msi", "444444444", null, null, 3, 2, null, null },
                    { 8, null, new DateTime(2025, 5, 19, 21, 15, 35, 776, DateTimeKind.Utc).AddTicks(8407), "Customer1@gmail.com", null, false, null, "Đặng Văn Nam", null, "$2a$12$bG9rWIU/u.PrCKmcPOOjau0otpIXuvnkUQYuqCkwBgojwzb2OLkba", "333333333", null, null, 4, null, null, null },
                    { 9, null, new DateTime(2025, 5, 19, 21, 15, 36, 73, DateTimeKind.Utc).AddTicks(8990), "Customer2@gmail.com", null, false, null, "Lý Thị Ngọc", null, "$2a$12$dEpY8sP.l8DiU2dEg3IKAOcK6yydFxYrDoClLjqAirrWf9K4yrh1m", "222222222", null, null, 4, null, null, null },
                    { 10, null, new DateTime(2025, 5, 19, 21, 15, 36, 345, DateTimeKind.Utc).AddTicks(2939), "Customer3@gmail.com", null, false, 200.0, "Phan Minh Đức", null, "$2a$12$M4iAAOT3o0PwHrOgeUmHjOUUo6AY1v8w6.yfVlMBQkmKjTxrsoLTq", "111111111", null, null, 4, null, null, null },
                    { 18, null, new DateTime(2025, 5, 19, 21, 15, 34, 714, DateTimeKind.Utc).AddTicks(6233), "Staff5@gmail.com", null, false, null, "Võ Anh Dũng", null, "$2a$12$ZrQvU5h2yuqN.vrrUYM9pO/JW.ix2uRM6Cb1Gf.gVqKsWSqh9aPqy", "0901234567", null, null, 3, 1, null, null },
                    { 19, null, new DateTime(2025, 5, 19, 21, 15, 34, 971, DateTimeKind.Utc).AddTicks(1267), "Staff6@gmail.com", null, false, null, "Nguyễn Thị Mai", null, "$2a$12$X/jrL8k3Jg3dIlF1/WTuweIlKawz1Er.pjdpJQRBeY0zYkDZ4A45G", "0907654321", null, null, 3, 1, null, null },
                    { 20, null, new DateTime(2025, 5, 19, 21, 15, 35, 253, DateTimeKind.Utc).AddTicks(4474), "Staff7@gmail.com", null, false, null, "Bùi Văn Hậu", null, "$2a$12$d7467t0P10skc/seoE1NfO81TIM05c.fZfHZdNHRzO9zteKxAWYH6", "0912345678", null, null, 3, 2, null, null },
                    { 21, null, new DateTime(2025, 5, 19, 21, 15, 35, 507, DateTimeKind.Utc).AddTicks(5122), "Staff8@gmail.com", null, false, null, "Trương Thị Lan", null, "$2a$12$FaeBWItWSfDTwE0G/zpZ1.f7bOU0mAUF30/pTsqtgbZytZSwScaHy", "0918765432", null, null, 3, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Utensils",
                columns: new[] { "UtensilId", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Status", "UpdatedAt", "UtensilTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6528), "Bộ 5 đôi đũa tre truyền thống.", "https://example.com/images/bamboo-chopsticks.jpg", false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6529), "Tre", "Bộ Đũa Tre", 320000m, 100, true, null, 1 },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6539), "Muỗng thép không gỉ bền chắc để múc nước lẩu.", "https://example.com/images/steel-ladle.jpg", false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6539), "Thép Không Gỉ", "Muỗng Lẩu Thép Không Gỉ", 245000m, 75, true, null, 2 },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6541), "Vợt lưới mịn để vớt thức ăn từ nồi lẩu.", "https://example.com/images/mesh-strainer.jpg", false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6541), "Thép Không Gỉ", "Vợt Lưới Kim Loại", 195000m, 80, true, null, 3 },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6543), "Bộ 4 bát gốm cho phần ăn cá nhân.", "https://example.com/images/ceramic-bowls.jpg", false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6543), "Gốm", "Bộ Bát Ăn Gốm", 490000m, 50, true, null, 4 },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6545), "Bộ 6 đĩa melamine bền chắc cho bữa ăn lẩu.", "https://example.com/images/melamine-plates.jpg", false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6545), "Melamine", "Đĩa Melamine", 610000m, 60, true, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "DamageDevices",
                columns: new[] { "DamageDeviceId", "CreatedAt", "Description", "FinishDate", "HotPotInventoryId", "IsDelete", "LoggedDate", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7049), "Tay cầm của nồi lẩu bị gãy và cần được thay thế.", null, 15, false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7052), "Tay Cầm Bị Gãy", 1, null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7053), "Đế của nồi lẩu bị nứt và cần được thay thế.", null, 10, false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7053), "Đế Nồi Bị Nứt", 2, null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7054), "Nắp của nồi lẩu bị hư hỏng và cần được thay thế.", null, 9, false, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(7055), "Nắp Nồi Hư Hỏng", 3, null }
                });

            migrationBuilder.InsertData(
                table: "IngredientBatchs",
                columns: new[] { "IngredientBatchId", "BatchNumber", "BestBeforeDate", "CreatedAt", "IngredientId", "InitialQuantity", "IsDelete", "ReceivedDate", "RemainingQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "BEEF-2025-04-01", new DateTime(2025, 6, 2, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6913), 1, 50, false, new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 50, null },
                    { 2, "BEEF-2025-04-15", new DateTime(2025, 6, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6917), 1, 30, false, new DateTime(2025, 5, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 3, "LAMB-2025-04-01", new DateTime(2025, 6, 2, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6926), 2, 40, false, new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 40, null },
                    { 4, "PORK-2025-04-01", new DateTime(2025, 5, 29, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6928), 3, 45, false, new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 45, null },
                    { 5, "SHRIMP-2025-04-01", new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6929), 4, 35, false, new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 35, null },
                    { 6, "FISHBALL-2025-04-01", new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6931), 5, 60, false, new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 60, null },
                    { 7, "SQUID-2025-04-01", new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6932), 6, 30, false, new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 8, "CABBAGE-2025-04-01", new DateTime(2025, 5, 24, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6934), 7, 40, false, new DateTime(2025, 5, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 40, null },
                    { 9, "SPINACH-2025-04-01", new DateTime(2025, 5, 23, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6935), 8, 35, false, new DateTime(2025, 5, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 35, null },
                    { 10, "CORN-2025-04-01", new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6937), 9, 30, false, new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 11, "UDON-2025-04-01", new DateTime(2025, 7, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6938), 10, 50, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 50, null },
                    { 12, "GLASS-2025-04-01", new DateTime(2025, 8, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6940), 11, 45, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 45, null },
                    { 13, "RAMEN-2025-04-01", new DateTime(2025, 7, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6941), 12, 55, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 55, null },
                    { 14, "TOFU-2025-04-01", new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6943), 13, 40, false, new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 40, null },
                    { 15, "FRIEDTOFU-2025-04-01", new DateTime(2025, 6, 2, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6944), 14, 35, false, new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 35, null },
                    { 16, "SHIITAKE-2025-04-01", new DateTime(2025, 5, 29, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6945), 15, 30, false, new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 17, "ENOKI-2025-04-01", new DateTime(2025, 5, 26, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6947), 16, 35, false, new DateTime(2025, 5, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 35, null },
                    { 18, "SICHUAN-2025-04-01", new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6948), 17, 25, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 25, null },
                    { 19, "TOMATO-2025-04-01", new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6950), 18, 25, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 25, null },
                    { 20, "MUSHBROTH-2025-04-01", new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6951), 19, 25, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 25, null },
                    { 21, "BONE-2025-04-01", new DateTime(2025, 6, 18, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6952), 20, 25, false, new DateTime(2025, 5, 14, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 25, null },
                    { 22, "SESAME-2025-04-01", new DateTime(2025, 8, 17, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6954), 21, 30, false, new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 23, "GARLICSOY-2025-04-01", new DateTime(2025, 11, 15, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6955), 22, 30, false, new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 24, "CHILI-2025-04-01", new DateTime(2025, 11, 15, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6957), 23, 30, false, new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null },
                    { 25, "SHACHA-2025-04-01", new DateTime(2025, 11, 15, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6958), 24, 30, false, new DateTime(2025, 5, 9, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6888), 30, null }
                });

            migrationBuilder.InsertData(
                table: "IngredientPrices",
                columns: new[] { "IngredientPriceId", "CreatedAt", "EffectiveDate", "IngredientId", "IsDelete", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6817), new DateTime(2025, 4, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6819), 1, false, 120000m, null },
                    { 2, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6827), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6827), 1, false, 135000m, null },
                    { 3, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6831), new DateTime(2025, 4, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6832), 2, false, 150000m, null },
                    { 4, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6833), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6833), 2, false, 165000m, null },
                    { 5, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6834), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6835), 3, false, 95000m, null },
                    { 6, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6836), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6836), 4, false, 110000m, null },
                    { 7, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6837), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6838), 5, false, 75000m, null },
                    { 8, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6839), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6839), 6, false, 90000m, null },
                    { 9, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6840), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6841), 7, false, 25000m, null },
                    { 10, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6842), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6842), 8, false, 20000m, null },
                    { 11, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6843), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6844), 9, false, 18000m, null },
                    { 12, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6845), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6845), 10, false, 35000m, null },
                    { 13, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6846), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6847), 11, false, 30000m, null },
                    { 14, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6848), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6848), 12, false, 32000m, null },
                    { 15, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6849), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6855), 13, false, 22000m, null },
                    { 16, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6856), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6857), 14, false, 25000m, null },
                    { 17, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6858), 15, false, 45000m, null },
                    { 18, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6859), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6860), 16, false, 35000m, null },
                    { 19, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6861), 17, false, 65000m, null },
                    { 20, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6862), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6863), 18, false, 55000m, null },
                    { 21, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6864), 19, false, 60000m, null },
                    { 22, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6865), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6866), 20, false, 50000m, null },
                    { 23, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6866), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6867), 21, false, 40000m, null },
                    { 24, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6868), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6869), 22, false, 35000m, null },
                    { 25, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6869), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6870), 23, false, 38000m, null },
                    { 26, new DateTime(2025, 5, 19, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6871), new DateTime(2025, 5, 16, 21, 15, 36, 598, DateTimeKind.Utc).AddTicks(6871), 24, false, 42000m, null }
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
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UserId",
                table: "Customizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageDevices_HotPotInventoryId",
                table: "DamageDevices",
                column: "HotPotInventoryId");

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
                name: "IX_IngredientBatchs_IngredientId",
                table: "IngredientBatchs",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPrices_IngredientId",
                table: "IngredientPrices",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_ComboId",
                table: "IngredientUsages",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_CustomizationId",
                table: "IngredientUsages",
                column: "CustomizationId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_IngredientBatchId",
                table: "IngredientUsages",
                column: "IngredientBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_IngredientId",
                table: "IngredientUsages",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_OrderDetailId",
                table: "IngredientUsages",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUsages_OrderId",
                table: "IngredientUsages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedAt",
                table: "Notifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetType_TargetId",
                table: "Notifications",
                columns: new[] { "TargetType", "TargetId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId",
                unique: true,
                filter: "[DiscountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PreparationStaffId",
                table: "Orders",
                column: "PreparationStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_OrderId",
                table: "PaymentReceipts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_PaymentId",
                table: "PaymentReceipts",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

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
                name: "IX_ReplacementRequests_AssignedStaffId",
                table: "ReplacementRequests",
                column: "AssignedStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_CustomerId",
                table: "ReplacementRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_DamageDeviceId",
                table: "ReplacementRequests",
                column: "DamageDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementRequests_HotPotInventoryId",
                table: "ReplacementRequests",
                column: "HotPotInventoryId");

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
                name: "IX_SellOrderDetails_UtensilId",
                table: "SellOrderDetails",
                column: "UtensilId");

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
                name: "IX_ShippingOrders_VehicleId",
                table: "ShippingOrders",
                column: "VehicleId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserManagerWorkShifts_MangerWorkShiftsWorkShiftId",
                table: "UserManagerWorkShifts",
                column: "MangerWorkShiftsWorkShiftId");

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
                name: "IX_UserStaffWorkShifts_StaffWorkShiftsWorkShiftId",
                table: "UserStaffWorkShifts",
                column: "StaffWorkShiftsWorkShiftId");

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
                name: "IngredientUsages");

            migrationBuilder.DropTable(
                name: "NotificationTemplates");

            migrationBuilder.DropTable(
                name: "PaymentReceipts");

            migrationBuilder.DropTable(
                name: "RentOrderDetails");

            migrationBuilder.DropTable(
                name: "ReplacementRequests");

            migrationBuilder.DropTable(
                name: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "StaffAssignments");

            migrationBuilder.DropTable(
                name: "UserManagerWorkShifts");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserStaffWorkShifts");

            migrationBuilder.DropTable(
                name: "ChatSessions");

            migrationBuilder.DropTable(
                name: "IngredientBatchs");

            migrationBuilder.DropTable(
                name: "SellOrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RentOrders");

            migrationBuilder.DropTable(
                name: "DamageDevices");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "SellOrders");

            migrationBuilder.DropTable(
                name: "Utensils");

            migrationBuilder.DropTable(
                name: "HotPotInventorys");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "IngredientTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UtensilTypes");

            migrationBuilder.DropTable(
                name: "Hotpots");

            migrationBuilder.DropTable(
                name: "SizeDiscounts");

            migrationBuilder.DropTable(
                name: "TurtorialVideos");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
