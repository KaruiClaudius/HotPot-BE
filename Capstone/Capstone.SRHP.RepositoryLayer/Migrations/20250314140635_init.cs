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
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MinStockLevel = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IngredientTypeID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientTypes_IngredientTypeID",
                        column: x => x.IngredientTypeID,
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
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
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
                    UtensilTypeID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utensils", x => x.UtensilId);
                    table.ForeignKey(
                        name: "FK_Utensils_UtensilTypes_UtensilTypeID",
                        column: x => x.UtensilTypeID,
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
                    HotpotBrothID = table.Column<int>(type: "int", nullable: false),
                    AppliedDiscountID = table.Column<int>(type: "int", nullable: true),
                    TurtorialVideoID = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboId);
                    table.ForeignKey(
                        name: "FK_Combos_Ingredients_HotpotBrothID",
                        column: x => x.HotpotBrothID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combos_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_Combos_SizeDiscounts_AppliedDiscountID",
                        column: x => x.AppliedDiscountID,
                        principalTable: "SizeDiscounts",
                        principalColumn: "SizeDiscountId");
                    table.ForeignKey(
                        name: "FK_Combos_TurtorialVideos_TurtorialVideoID",
                        column: x => x.TurtorialVideoID,
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
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPrices", x => x.IngredientPriceId);
                    table.ForeignKey(
                        name: "FK_IngredientPrices_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    LoyatyPoint = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserID",
                        column: x => x.UserID,
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
                    UserID = table.Column<int>(type: "int", nullable: false),
                    WorkDays = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Users_UserID",
                        column: x => x.UserID,
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
                    HotpotDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    WorkDays = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboAllowedIngredientTypes",
                columns: table => new
                {
                    ComboAllowedIngredientTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    MinQuantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ComboID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboIngredients", x => x.ComboIngredientId);
                    table.ForeignKey(
                        name: "FK_ComboIngredients_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComboIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
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
                    UserID = table.Column<int>(type: "int", nullable: false),
                    HotpotBrothID = table.Column<int>(type: "int", nullable: false),
                    ComboID = table.Column<int>(type: "int", nullable: false),
                    AppliedDiscountID = table.Column<int>(type: "int", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.CustomizationId);
                    table.ForeignKey(
                        name: "FK_Customizations_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_Ingredients_HotpotBrothID",
                        column: x => x.HotpotBrothID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customizations_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_Customizations_SizeDiscounts_AppliedDiscountID",
                        column: x => x.AppliedDiscountID,
                        principalTable: "SizeDiscounts",
                        principalColumn: "SizeDiscountId");
                    table.ForeignKey(
                        name: "FK_Customizations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
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
                        name: "FK_ChatSessions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatSessions_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
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
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Feedback_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId");
                    table.ForeignKey(
                        name: "FK_Feedback_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Feedback_Users_UserID",
                        column: x => x.UserID,
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingOrders",
                columns: table => new
                {
                    ShippingOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_ShippingOrders_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingOrders_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "CustomizationIngredients",
                columns: table => new
                {
                    CustomizationIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomizationID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizationIngredients", x => x.CustomizationIngredientId);
                    table.ForeignKey(
                        name: "FK_CustomizationIngredients_Customizations_CustomizationID",
                        column: x => x.CustomizationID,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomizationIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ConditionLogs",
                columns: table => new
                {
                    ConditionLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ScheduleType = table.Column<int>(type: "int", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtensilID = table.Column<int>(type: "int", nullable: true),
                    HotPotInventoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionLogs", x => x.ConditionLogId);
                    table.ForeignKey(
                        name: "FK_ConditionLogs_Utensils_UtensilID",
                        column: x => x.UtensilID,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
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
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    VolumeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    UtensilID = table.Column<int>(type: "int", nullable: true),
                    IngredientID = table.Column<int>(type: "int", nullable: true),
                    HotpotInventoryID = table.Column<int>(type: "int", nullable: true),
                    CustomizationID = table.Column<int>(type: "int", nullable: true),
                    ComboID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Customizations_CustomizationID",
                        column: x => x.CustomizationID,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_HotPotInventorys_HotpotInventoryID",
                        column: x => x.HotpotInventoryID,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Utensils_UtensilID",
                        column: x => x.UtensilID,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
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
                        name: "FK_ReplacementRequests_ConditionLogs_ConditionLogId",
                        column: x => x.ConditionLogId,
                        principalTable: "ConditionLogs",
                        principalColumn: "ConditionLogId");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_HotPotInventorys_HotPotInventoryId",
                        column: x => x.HotPotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Staffs_AssignedStaffId",
                        column: x => x.AssignedStaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId");
                    table.ForeignKey(
                        name: "FK_ReplacementRequests_Utensils_UtensilId",
                        column: x => x.UtensilId,
                        principalTable: "Utensils",
                        principalColumn: "UtensilId");
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
                    OrderDetailId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotpots", x => x.HotpotId);
                    table.ForeignKey(
                        name: "FK_Hotpots_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailId");
                });

            migrationBuilder.InsertData(
                table: "Hotpots",
                columns: new[] { "HotpotId", "BasePrice", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "OrderDetailId", "Price", "Quantity", "Size", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 89.99m, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2491), "Traditional copper hotpot with charcoal heating.", "https://example.com/images/classic-copper-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Copper", "Classic Copper Hotpot", null, 29.99m, 5, "m", true, null },
                    { 2, 129.99m, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2499), "Electric hotpot with temperature control and non-stick coating.", "https://example.com/images/modern-electric-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Modern Electric Hotpot", null, 59.99m, 2, "L", true, null },
                    { 3, 69.99m, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2501), "Compact portable hotpot perfect for travel or small gatherings.", "https://example.com/images/mini-portable-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluminum", "Mini Portable Hotpot", null, 19.99m, 2, "S", true, null },
                    { 4, 149.99m, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2504), "Multi-compartment hotpot for different broths in one pot.", "https://example.com/images/dual-section-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Dual Section Hotpot", null, 69.99m, 2, "L", true, null },
                    { 5, 79.99m, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2507), "Authentic ceramic hotpot that retains heat exceptionally well.", "https://example.com/images/traditional-ceramic-hotpot.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceramic", "Traditional Ceramic Hotpot", null, 39.99m, 4, "M", true, null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "IngredientTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2742), false, "Broth", null },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2744), false, "Seafood", null },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2745), false, "Vegetables", null },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2746), false, "Noodles", null },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2747), false, "Tofu", null },
                    { 6, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2748), false, "Mushrooms", null },
                    { 7, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2749), false, "Meats", null },
                    { 8, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2750), false, "Sauces", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5831), false, "Admin", null },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5841), false, "Manager", null },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5842), false, "Staff", null },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(5843), false, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "TurtorialVideos",
                columns: new[] { "TurtorialVideoId", "CreatedAt", "Description", "IsDelete", "Name", "UpdatedAt", "VideoURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2271), "A comprehensive guide to setting up and using a traditional hotpot.", false, "How to Use Traditional Hotpot", null, "https://www.youtube.com/watch?v=traditional-hotpot-guide" },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2395), "Learn how to safely set up and use your electric hotpot.", false, "Electric Hotpot Setup Guide", null, "https://www.youtube.com/watch?v=electric-hotpot-setup" },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2396), "Tips and tricks for using your portable hotpot anywhere.", false, "Portable Hotpot on the Go", null, "https://www.youtube.com/watch?v=portable-hotpot-guide" },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2398), "How to effectively use all compartments in your multi-section hotpot.", false, "Multi-compartment Hotpot Mastery", null, "https://www.youtube.com/watch?v=multi-compartment-guide" },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2399), "Learn how to properly care for and maintain your ceramic hotpot.", false, "Ceramic Hotpot Care Guide", null, "https://www.youtube.com/watch?v=ceramic-hotpot-care" }
                });

            migrationBuilder.InsertData(
                table: "UtensilTypes",
                columns: new[] { "UtensilTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2174), false, "Chopsticks", null },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2194), false, "Ladles", null },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2195), false, "Strainers", null },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2196), false, "Bowls", null },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2198), false, "Plates", null }
                });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2565), 1, false, "CP-2023-0001", false, null },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2566), 1, false, "CP-2023-0002", false, null },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2567), 2, false, "EL-2023-0001", false, null },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2568), 2, false, "EL-2023-0002", false, null },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2570), 3, false, "PT-2023-0001", false, null },
                    { 6, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2571), 4, false, "MC-2023-0001", false, null },
                    { 7, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2572), 5, false, "CR-2023-0001", false, null },
                    { 8, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2573), 1, false, "CP-2023-0003", false, null },
                    { 9, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2574), 1, false, "CP-2023-0004", false, null },
                    { 10, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2576), 1, false, "CP-2023-0005", false, null },
                    { 11, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2577), 3, false, "PT-2023-0002", false, null },
                    { 12, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2578), 4, false, "MC-2023-0002", false, null },
                    { 13, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2579), 5, false, "CR-2023-0002", false, null },
                    { 14, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2580), 5, false, "CR-2023-0003", false, null },
                    { 15, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2585), 5, false, "CR-2023-0004", false, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CreatedAt", "Description", "ImageURL", "IngredientTypeId", "IsDelete", "MeasurementUnit", "MinStockLevel", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2848), "Thinly sliced premium beef perfect for hotpot.", "https://example.com/images/sliced-beef.jpg", 7, false, "g", 20m, "Sliced Beef", 100m, null },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2850), "Tender sliced lamb meat, perfect for quick cooking.", "https://example.com/images/lamb-slices.jpg", 7, false, "g", 15m, "Lamb Slices", 80m, null },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2852), "Thinly sliced pork belly with perfect fat-to-meat ratio.", "https://example.com/images/pork-belly.jpg", 7, false, "g", 15m, "Pork Belly", 75m, null },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2854), "Fresh, peeled and deveined shrimp.", "https://example.com/images/shrimp.jpg", 2, false, "g", 20m, "Shrimp", 90m, null },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2856), "Bouncy fish balls made from fresh fish paste.", "https://example.com/images/fish-balls.jpg", 2, false, "g", 30m, "Fish Balls", 120m, null },
                    { 6, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2858), "Fresh squid sliced into rings.", "https://example.com/images/squid.jpg", 2, false, "g", 15m, "Squid", 60m, null },
                    { 7, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2860), "Crisp, leafy vegetable perfect for hotpot.", "https://example.com/images/napa-cabbage.jpg", 3, false, "g", 25m, "Napa Cabbage", 100m, null },
                    { 8, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2863), "Fresh spinach leaves, washed and ready to cook.", "https://example.com/images/spinach.jpg", 3, false, "g", 20m, "Spinach", 80m, null },
                    { 9, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2865), "Sweet corn cut into bite-sized pieces.", "https://example.com/images/corn.jpg", 3, false, "g", 15m, "Corn", 70m, null },
                    { 10, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2894), "Thick, chewy Japanese wheat noodles.", "https://example.com/images/udon-noodles.jpg", 4, false, "g", 20m, "Udon Noodles", 80m, null },
                    { 11, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2897), "Transparent noodles made from mung bean starch.", "https://example.com/images/glass-noodles.jpg", 4, false, "g", 20m, "Glass Noodles", 85m, null },
                    { 12, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2899), "Curly wheat noodles perfect for hotpot.", "https://example.com/images/ramen-noodles.jpg", 4, false, "g", 25m, "Ramen Noodles", 90m, null },
                    { 13, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2901), "Firm tofu cubes that hold their shape in hotpot.", "https://example.com/images/firm-tofu.jpg", 5, false, "g", 15m, "Firm Tofu", 60m, null },
                    { 14, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2903), "Deep-fried tofu puffs that absorb broth flavors.", "https://example.com/images/tofu-puffs.jpg", 5, false, "g", 15m, "Tofu Puffs", 65m, null },
                    { 15, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7114), "Flavorful shiitake mushrooms, fresh or dried.", "https://example.com/images/shiitake.jpg", 6, false, "g", 15m, "Shiitake Mushrooms", 70m, null },
                    { 16, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7166), "Delicate, long-stemmed enoki mushrooms.", "https://example.com/images/enoki.jpg", 6, false, "g", 15m, "Enoki Mushrooms", 65m, null },
                    { 17, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7178), "Traditional spicy broth with Sichuan peppercorns and chili oil.", "https://example.com/images/sichuan-broth.jpg", 1, false, "ml", 10m, "Spicy Sichuan Broth", 50m, null },
                    { 18, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7188), "Tangy tomato-based broth, slightly sweet and sour.", "https://example.com/images/tomato-broth.jpg", 1, false, "ml", 10m, "Tomato Broth", 45m, null },
                    { 19, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7198), "Rich umami broth made from various mushrooms.", "https://example.com/images/mushroom-broth.jpg", 1, false, "ml", 10m, "Mushroom Broth", 40m, null },
                    { 20, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7207), "Light, clear broth made from simmering bones for hours.", "https://example.com/images/bone-broth.jpg", 1, false, "ml", 10m, "Clear Bone Broth", 55m, null },
                    { 21, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7217), "Creamy sauce made from ground sesame seeds.", "https://example.com/images/sesame-sauce.jpg", 8, false, "ml", 10m, "Sesame Sauce", 40m, null },
                    { 22, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7227), "Soy sauce infused with fresh minced garlic.", "https://example.com/images/garlic-soy.jpg", 8, false, "ml", 10m, "Garlic Soy Sauce", 45m, null },
                    { 23, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7239), "Spicy oil made from infusing oil with chili peppers.", "https://example.com/images/chili-oil.jpg", 8, false, "ml", 10m, "Chili Oil", 50m, null },
                    { 24, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7248), "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.", "https://example.com/images/shacha-sauce.jpg", 8, false, "ml", 10m, "Shacha Sauce", 35m, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "Name", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 14, 21, 6, 32, 377, DateTimeKind.Utc).AddTicks(6005), "Admin@gmail.com", null, false, "Admin", "$2a$12$5UBhC4v1TB1pbNY39K15e.endofTEZE35A9eR8rN8kO1nMVAhRZqu", "987654321", null, null, 1, null },
                    { 2, null, new DateTime(2025, 3, 14, 21, 6, 32, 614, DateTimeKind.Utc).AddTicks(9112), "Manager1@gmail.com", null, false, "Manager1", "$2a$12$m2SKgzZcRs1/s2M265CB4OrPmhu5jc3JoYaCqQgWfhCeg4ypaRfeO", "999999999", null, null, 2, null },
                    { 3, null, new DateTime(2025, 3, 14, 21, 6, 32, 858, DateTimeKind.Utc).AddTicks(399), "Manager2@gmail.com", null, false, "Manager2", "$2a$12$9njIrraUktRnBCCwqBlzg.ESPXkvVKEhFruxgGe8Dgzp1owCR4uf6", "888888888", null, null, 2, null },
                    { 4, null, new DateTime(2025, 3, 14, 21, 6, 33, 90, DateTimeKind.Utc).AddTicks(3533), "Staff1@gmail.com", null, false, "Staff1", "$2a$12$EWsgSQMUwyxZ.uzYuiBBw.Bs508CNFvMAWvAU8LaSVncGZ7PXQPKi", "777777777", null, null, 3, null },
                    { 5, null, new DateTime(2025, 3, 14, 21, 6, 33, 319, DateTimeKind.Utc).AddTicks(8727), "Staff2@gmail.com", null, false, "Staff2", "$2a$12$fLIUJKIHMJKhiZxtbIy8d.3dsO6XnB.W7Uhv.MPoHr2aYkeBqreRq", "666666666", null, null, 3, null },
                    { 6, null, new DateTime(2025, 3, 14, 21, 6, 33, 548, DateTimeKind.Utc).AddTicks(9980), "Staff3@gmail.com", null, false, "Staff3", "$2a$12$SI6eBK4eoK31G8GWskn/bOfhZvEjTR0iXD1omQH6DWTc1P1s8EIy.", "555555555", null, null, 3, null },
                    { 7, null, new DateTime(2025, 3, 14, 21, 6, 33, 778, DateTimeKind.Utc).AddTicks(8495), "Staff4@gmail.com", null, false, "Staff4", "$2a$12$CD81vuMBWQGYZaAGTkpXh.GOylAIsWJHCBlGSNch2cf7v3.WSFnCG", "444444444", null, null, 3, null },
                    { 8, null, new DateTime(2025, 3, 14, 21, 6, 34, 11, DateTimeKind.Utc).AddTicks(8050), "Customer1@gmail.com", null, false, "Customer1", "$2a$12$l6V/4zT4mEFFG.7IAXV6LexE/1mExVfpIxkYFDIMIIGxS9F1EA/xC", "333333333", null, null, 4, null },
                    { 9, null, new DateTime(2025, 3, 14, 21, 6, 34, 241, DateTimeKind.Utc).AddTicks(5730), "Customer2@gmail.com", null, false, "Customer2", "$2a$12$p5njz4kMez7BIXvo4ZGJqOF8A/RFB6eYr.rUSwwU8WYR/fwU1yvJ6", "222222222", null, null, 4, null },
                    { 10, null, new DateTime(2025, 3, 14, 21, 6, 34, 470, DateTimeKind.Utc).AddTicks(5249), "Customer3@gmail.com", null, false, "Customer3", "$2a$12$b8hV5omzyhj1YIncRPpOv.WWhs4HrfFEAU0g4uIdYWFSwau.TA.mq", "111111111", null, null, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Utensils",
                columns: new[] { "UtensilId", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Status", "UpdatedAt", "UtensilTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2685), "Set of 5 pairs of traditional bamboo chopsticks.", "https://example.com/images/bamboo-chopsticks.jpg", false, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2679), "Bamboo", "Bamboo Chopsticks Set", 12.99m, 100, true, null, 1 },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2687), "Durable stainless steel ladle for serving hotpot broth.", "https://example.com/images/steel-ladle.jpg", false, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2686), "Stainless Steel", "Stainless Steel Hotpot Ladle", 9.99m, 75, true, null, 2 },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2690), "Fine mesh strainer for retrieving food from the hotpot.", "https://example.com/images/mesh-strainer.jpg", false, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2688), "Stainless Steel", "Wire Mesh Strainer", 7.99m, 80, true, null, 3 },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2692), "Set of 4 ceramic bowls for individual servings.", "https://example.com/images/ceramic-bowls.jpg", false, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2691), "Ceramic", "Ceramic Serving Bowl Set", 19.99m, 50, true, null, 4 },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(2695), "Set of 6 durable melamine plates for hotpot dining.", "https://example.com/images/melamine-plates.jpg", false, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2693), "Melamine", "Melamine Plates", 24.99m, 60, true, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "Note", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2075), false, null, null, 8 },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2082), false, null, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "LoyatyPoint", "Note", "UpdatedAt", "UserId" },
                values: new object[] { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2083), false, 200.0, null, null, 10 });

            migrationBuilder.InsertData(
                table: "IngredientPrices",
                columns: new[] { "IngredientPriceId", "CreatedAt", "EffectiveDate", "IngredientId", "IsDelete", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7438), new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7429), 1, false, 0.13m, null },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7441), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7440), 1, false, 0.14m, null },
                    { 3, new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7444), new DateTime(2025, 2, 12, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7442), 2, false, 0.15m, null },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7446), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7446), 2, false, 0.16m, null },
                    { 5, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7448), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7448), 3, false, 0.12m, null },
                    { 6, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7450), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7450), 4, false, 0.17m, null },
                    { 7, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7452), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7451), 5, false, 0.10m, null },
                    { 8, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7454), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7453), 6, false, 0.15m, null },
                    { 9, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7455), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7455), 7, false, 0.06m, null },
                    { 10, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7458), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7457), 8, false, 0.05m, null },
                    { 11, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7460), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7459), 9, false, 0.04m, null },
                    { 12, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7461), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7461), 10, false, 0.07m, null },
                    { 13, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7463), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7462), 11, false, 0.06m, null },
                    { 14, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7464), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7464), 12, false, 0.065m, null },
                    { 15, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7469), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7468), 13, false, 0.05m, null },
                    { 16, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7470), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7470), 14, false, 0.055m, null },
                    { 17, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7473), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7473), 15, false, 0.08m, null },
                    { 18, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7475), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7474), 16, false, 0.07m, null },
                    { 19, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7477), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7476), 17, false, 0.009m, null },
                    { 20, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7478), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7478), 18, false, 0.008m, null },
                    { 21, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7481), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7480), 19, false, 0.0085m, null },
                    { 22, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7482), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7482), 20, false, 0.0075m, null },
                    { 23, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7484), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7483), 21, false, 0.005m, null },
                    { 24, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7485), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7485), 22, false, 0.004m, null },
                    { 25, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7487), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7486), 23, false, 0.0045m, null },
                    { 26, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7488), new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Local).AddTicks(7488), 24, false, 0.006m, null }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserId", "WorkDays" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2028), false, null, 2, 0 },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(2032), false, null, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "CreatedAt", "IsDelete", "UpdatedAt", "UserId", "WorkDays" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1903), false, null, 4, 0 },
                    { 2, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1911), false, null, 5, 0 },
                    { 3, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1912), false, null, 6, 0 },
                    { 4, new DateTime(2025, 3, 14, 21, 6, 34, 703, DateTimeKind.Utc).AddTicks(1913), false, null, 7, 0 }
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
                name: "IX_ComboIngredients_ComboID_IngredientID",
                table: "ComboIngredients",
                columns: new[] { "ComboId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_ComboIngredients_IngredientID",
                table: "ComboIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_AppliedDiscountID",
                table: "Combos",
                column: "AppliedDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_HotpotBrothID",
                table: "Combos",
                column: "HotpotBrothId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_IngredientId",
                table: "Combos",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_TurtorialVideoID",
                table: "Combos",
                column: "TurtorialVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionLogs_HotPotInventoryId",
                table: "ConditionLogs",
                column: "HotPotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionLogs_UtensilID",
                table: "ConditionLogs",
                column: "UtensilId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomizationIngredients_CustomizationID_IngredientID",
                table: "CustomizationIngredients",
                columns: new[] { "CustomizationId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizationIngredients_IngredientID",
                table: "CustomizationIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_AppliedDiscountID",
                table: "Customizations",
                column: "AppliedDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_ComboID",
                table: "Customizations",
                column: "ComboId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_HotpotBrothID",
                table: "Customizations",
                column: "HotpotBrothId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_IngredientId",
                table: "Customizations",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UserID",
                table: "Customizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApprovedByUserId",
                table: "Feedback",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ManagerId",
                table: "Feedback",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrderID",
                table: "Feedback",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserID",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotPotInventorys_HotpotId",
                table: "HotPotInventorys",
                column: "HotpotId");

            migrationBuilder.CreateIndex(
                name: "IX_HotPotInventorys_SeriesNumber",
                table: "HotPotInventorys",
                column: "SeriesNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotpots_OrderDetailId",
                table: "Hotpots",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPrices_IngredientID",
                table: "IngredientPrices",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeID",
                table: "Ingredients",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserID",
                table: "Managers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagerWorkShift_WorkShiftsId",
                table: "ManagerWorkShift",
                column: "WorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ComboID",
                table: "OrderDetails",
                column: "ComboId",
                unique: true,
                filter: "[ComboId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomizationID",
                table: "OrderDetails",
                column: "CustomizationId",
                unique: true,
                filter: "[CustomizationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_HotpotInventoryID",
                table: "OrderDetails",
                column: "HotpotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IngredientID",
                table: "OrderDetails",
                column: "IngredientId",
                unique: true,
                filter: "[IngredientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UtensilID",
                table: "OrderDetails",
                column: "UtensilId",
                unique: true,
                filter: "[UtensilId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountID",
                table: "Orders",
                column: "DiscountId",
                unique: true,
                filter: "[DiscountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserID",
                table: "Payments",
                column: "UserId");

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
                name: "IX_ShippingOrders_OrderID",
                table: "ShippingOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOrders_StaffID",
                table: "ShippingOrders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserID",
                table: "Staffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffWorkShift_WorkShiftsId",
                table: "StaffWorkShift",
                column: "WorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Utensils_UtensilTypeID",
                table: "Utensils",
                column: "UtensilTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionLogs_HotPotInventorys_HotPotInventoryId",
                table: "ConditionLogs",
                column: "HotPotInventoryId",
                principalTable: "HotPotInventorys",
                principalColumn: "HotPotInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotPotInventorys_Hotpots_HotpotId",
                table: "HotPotInventorys",
                column: "HotpotId",
                principalTable: "Hotpots",
                principalColumn: "HotpotId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Users_UserID",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Combos_ComboID",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Combos_ComboID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientTypes_IngredientTypeID",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Ingredients_HotpotBrothID",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_Ingredients_IngredientId",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Ingredients_IngredientID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Customizations_SizeDiscounts_AppliedDiscountID",
                table: "Customizations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_HotPotInventorys_HotpotInventoryID",
                table: "OrderDetails");

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
                name: "ManagerWorkShift");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ReplacementRequests");

            migrationBuilder.DropTable(
                name: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "StaffWorkShift");

            migrationBuilder.DropTable(
                name: "ChatSessions");

            migrationBuilder.DropTable(
                name: "ConditionLogs");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "TurtorialVideos");

            migrationBuilder.DropTable(
                name: "IngredientTypes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "SizeDiscounts");

            migrationBuilder.DropTable(
                name: "HotPotInventorys");

            migrationBuilder.DropTable(
                name: "Hotpots");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Utensils");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "UtensilTypes");
        }
    }
}
