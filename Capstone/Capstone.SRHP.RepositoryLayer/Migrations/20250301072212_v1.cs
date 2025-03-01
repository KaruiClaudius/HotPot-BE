using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone.HPTY.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
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
                    Percent = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
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
                name: "HotpotTypes",
                columns: table => new
                {
                    HotpotTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotpotTypes", x => x.HotpotTypeId);
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
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
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
                name: "Hotpots",
                columns: table => new
                {
                    HotpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastMaintainDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotpotTypeID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    TurtorialVideoID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotpots", x => x.HotpotId);
                    table.ForeignKey(
                        name: "FK_Hotpots_HotpotTypes_HotpotTypeID",
                        column: x => x.HotpotTypeID,
                        principalTable: "HotpotTypes",
                        principalColumn: "HotpotTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotpots_TurtorialVideos_TurtorialVideoID",
                        column: x => x.TurtorialVideoID,
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
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HotpotBrothID = table.Column<int>(type: "int", nullable: false),
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
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: true),
                    PaymentID = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Orders_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
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
                name: "ComboIngredients",
                columns: table => new
                {
                    ComboIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
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
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    HotpotBrothID = table.Column<int>(type: "int", nullable: false),
                    ComboID = table.Column<int>(type: "int", nullable: false),
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
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Response = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Feedback_Users_UserID",
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
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ConditionLogs_HotPotInventorys_HotPotInventoryId",
                        column: x => x.HotPotInventoryId,
                        principalTable: "HotPotInventorys",
                        principalColumn: "HotPotInventoryId");
                    table.ForeignKey(
                        name: "FK_ConditionLogs_Utensils_UtensilID",
                        column: x => x.UtensilID,
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
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    UtensilID = table.Column<int>(type: "int", nullable: true),
                    IngredientID = table.Column<int>(type: "int", nullable: true),
                    HotpotID = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_OrderDetails_Hotpots_HotpotID",
                        column: x => x.HotpotID,
                        principalTable: "Hotpots",
                        principalColumn: "HotpotId");
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
                    SessionChatSessionId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatSessions_SessionChatSessionId",
                        column: x => x.SessionChatSessionId,
                        principalTable: "ChatSessions",
                        principalColumn: "ChatSessionId");
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

            migrationBuilder.InsertData(
                table: "HotpotTypes",
                columns: new[] { "HotpotTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1284), false, "Traditional", null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1287), false, "Electric", null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1288), false, "Portable", null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1289), false, "Multi-compartment", null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1290), false, "Ceramic", null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "IngredientTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3067), false, "Broth", null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3069), false, "Seafood", null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3075), false, "Vegetables", null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3092), false, "Noodles", null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3094), false, "Tofu", null },
                    { 6, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3095), false, "Mushrooms", null },
                    { 7, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3097), false, "Meats", null },
                    { 8, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3098), false, "Sauces", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 9, 942, DateTimeKind.Utc).AddTicks(9423), false, "Admin", null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 9, 942, DateTimeKind.Utc).AddTicks(9432), false, "Manager", null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 9, 942, DateTimeKind.Utc).AddTicks(9433), false, "Staff", null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 9, 942, DateTimeKind.Utc).AddTicks(9434), false, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "TurtorialVideos",
                columns: new[] { "TurtorialVideoId", "CreatedAt", "Description", "IsDelete", "Name", "UpdatedAt", "VideoURL" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2679), "A comprehensive guide to setting up and using a traditional hotpot.", false, "How to Use Traditional Hotpot", null, "https://www.youtube.com/watch?v=traditional-hotpot-guide" },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2695), "Learn how to safely set up and use your electric hotpot.", false, "Electric Hotpot Setup Guide", null, "https://www.youtube.com/watch?v=electric-hotpot-setup" },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2697), "Tips and tricks for using your portable hotpot anywhere.", false, "Portable Hotpot on the Go", null, "https://www.youtube.com/watch?v=portable-hotpot-guide" },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2699), "How to effectively use all compartments in your multi-section hotpot.", false, "Multi-compartment Hotpot Mastery", null, "https://www.youtube.com/watch?v=multi-compartment-guide" },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2701), "Learn how to properly care for and maintain your ceramic hotpot.", false, "Ceramic Hotpot Care Guide", null, "https://www.youtube.com/watch?v=ceramic-hotpot-care" }
                });

            migrationBuilder.InsertData(
                table: "UtensilTypes",
                columns: new[] { "UtensilTypeId", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(1355), false, "Chopsticks", null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(1375), false, "Ladles", null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(1377), false, "Strainers", null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(1384), false, "Bowls", null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(1387), false, "Plates", null }
                });

            migrationBuilder.InsertData(
                table: "Hotpots",
                columns: new[] { "HotpotId", "CreatedAt", "Description", "HotpotTypeID", "ImageURL", "InventoryID", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Size", "Status", "TurtorialVideoID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2804), "Traditional copper hotpot with charcoal heating.", 1, "https://example.com/images/classic-copper-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Copper", "Classic Copper Hotpot", 89.99m, 25, 4, true, 1, null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2808), "Electric hotpot with temperature control and non-stick coating.", 2, "https://example.com/images/modern-electric-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Modern Electric Hotpot", 129.99m, 30, 6, true, 2, null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2811), "Compact portable hotpot perfect for travel or small gatherings.", 3, "https://example.com/images/mini-portable-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluminum", "Mini Portable Hotpot", 59.99m, 40, 2, true, 3, null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2814), "Multi-compartment hotpot for different broths in one pot.", 4, "https://example.com/images/dual-section-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stainless Steel", "Dual Section Hotpot", 149.99m, 20, 6, true, 4, null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2817), "Authentic ceramic hotpot that retains heat exceptionally well.", 5, "https://example.com/images/traditional-ceramic-hotpot.jpg", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceramic", "Traditional Ceramic Hotpot", 79.99m, 15, 4, true, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CreatedAt", "Description", "ImageURL", "IngredientTypeID", "IsDelete", "MinStockLevel", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3152), "Thinly sliced premium beef perfect for hotpot.", "https://example.com/images/sliced-beef.jpg", 1, false, 20, "Sliced Beef", 100, null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3154), "Tender sliced lamb meat, perfect for quick cooking.", "https://example.com/images/lamb-slices.jpg", 1, false, 15, "Lamb Slices", 80, null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3157), "Thinly sliced pork belly with perfect fat-to-meat ratio.", "https://example.com/images/pork-belly.jpg", 1, false, 15, "Pork Belly", 75, null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3160), "Fresh, peeled and deveined shrimp.", "https://example.com/images/shrimp.jpg", 2, false, 20, "Shrimp", 90, null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3162), "Bouncy fish balls made from fresh fish paste.", "https://example.com/images/fish-balls.jpg", 2, false, 30, "Fish Balls", 120, null },
                    { 6, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3164), "Fresh squid sliced into rings.", "https://example.com/images/squid.jpg", 2, false, 15, "Squid", 60, null },
                    { 7, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3167), "Crisp, leafy vegetable perfect for hotpot.", "https://example.com/images/napa-cabbage.jpg", 3, false, 25, "Napa Cabbage", 100, null },
                    { 8, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3169), "Fresh spinach leaves, washed and ready to cook.", "https://example.com/images/spinach.jpg", 3, false, 20, "Spinach", 80, null },
                    { 9, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3171), "Sweet corn cut into bite-sized pieces.", "https://example.com/images/corn.jpg", 3, false, 15, "Corn", 70, null },
                    { 10, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3174), "Thick, chewy Japanese wheat noodles.", "https://example.com/images/udon-noodles.jpg", 4, false, 20, "Udon Noodles", 80, null },
                    { 11, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3176), "Transparent noodles made from mung bean starch.", "https://example.com/images/glass-noodles.jpg", 4, false, 20, "Glass Noodles", 85, null },
                    { 12, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3178), "Curly wheat noodles perfect for hotpot.", "https://example.com/images/ramen-noodles.jpg", 4, false, 25, "Ramen Noodles", 90, null },
                    { 13, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3180), "Firm tofu cubes that hold their shape in hotpot.", "https://example.com/images/firm-tofu.jpg", 5, false, 15, "Firm Tofu", 60, null },
                    { 14, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3183), "Deep-fried tofu puffs that absorb broth flavors.", "https://example.com/images/tofu-puffs.jpg", 5, false, 15, "Tofu Puffs", 65, null },
                    { 15, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3185), "Flavorful shiitake mushrooms, fresh or dried.", "https://example.com/images/shiitake.jpg", 6, false, 15, "Shiitake Mushrooms", 70, null },
                    { 16, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3280), "Delicate, long-stemmed enoki mushrooms.", "https://example.com/images/enoki.jpg", 6, false, 15, "Enoki Mushrooms", 65, null },
                    { 17, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3282), "Traditional spicy broth with Sichuan peppercorns and chili oil.", "https://example.com/images/sichuan-broth.jpg", 7, false, 10, "Spicy Sichuan Broth", 50, null },
                    { 18, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3284), "Tangy tomato-based broth, slightly sweet and sour.", "https://example.com/images/tomato-broth.jpg", 7, false, 10, "Tomato Broth", 45, null },
                    { 19, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3287), "Rich umami broth made from various mushrooms.", "https://example.com/images/mushroom-broth.jpg", 7, false, 10, "Mushroom Broth", 40, null },
                    { 20, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3289), "Light, clear broth made from simmering bones for hours.", "https://example.com/images/bone-broth.jpg", 7, false, 10, "Clear Bone Broth", 55, null },
                    { 21, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3291), "Creamy sauce made from ground sesame seeds.", "https://example.com/images/sesame-sauce.jpg", 8, false, 10, "Sesame Sauce", 40, null },
                    { 22, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3293), "Soy sauce infused with fresh minced garlic.", "https://example.com/images/garlic-soy.jpg", 8, false, 10, "Garlic Soy Sauce", 45, null },
                    { 23, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3296), "Spicy oil made from infusing oil with chili peppers.", "https://example.com/images/chili-oil.jpg", 8, false, 10, "Chili Oil", 50, null },
                    { 24, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3298), "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.", "https://example.com/images/shacha-sauce.jpg", 8, false, 10, "Shacha Sauce", 35, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "ImageURL", "IsDelete", "Name", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiry", "RoleID", "UpdatedAt" },
                values: new object[,]
                {
                    { -10, null, new DateTime(2025, 3, 1, 14, 22, 12, 77, DateTimeKind.Utc).AddTicks(9711), "Customer3@gmail.com", null, false, "Customer3", "$2a$12$3nbv/70z1RPPZ7l92fmCie8BC/brdfHCY3jAYDQnF53aSY0LY6IU6", null, null, null, 4, null },
                    { -9, null, new DateTime(2025, 3, 1, 14, 22, 11, 843, DateTimeKind.Utc).AddTicks(4849), "Customer2@gmail.com", null, false, "Customer2", "$2a$12$cSyhXht2zfrds.B8r.l91enXZrmZTdpEffMiQ64Bon0yuNfk79XzO", null, null, null, 4, null },
                    { -8, null, new DateTime(2025, 3, 1, 14, 22, 11, 606, DateTimeKind.Utc).AddTicks(1935), "Customer1@gmail.com", null, false, "Customer1", "$2a$12$d2fKk6F3bCB/4lwkRFPrAe14Z3bo8vYAft/9VuL7qSgLiJqr4YKa2", null, null, null, 4, null },
                    { -7, null, new DateTime(2025, 3, 1, 14, 22, 11, 367, DateTimeKind.Utc).AddTicks(7338), "Staff4@gmail.com", null, false, "Staff4", "$2a$12$4KeAi.QkbfoYus/RQBRc4u1pMKvnIzDmnNiEkiEE0iMYQ4hKiDOQC", null, null, null, 3, null },
                    { -6, null, new DateTime(2025, 3, 1, 14, 22, 11, 129, DateTimeKind.Utc).AddTicks(5563), "Staff3@gmail.com", null, false, "Staff3", "$2a$12$ginqo3C3hpoUZ/W1etLdU.FvdbRhZ99m0ruuUvOJh53nBtBPCbKY.", null, null, null, 3, null },
                    { -5, null, new DateTime(2025, 3, 1, 14, 22, 10, 895, DateTimeKind.Utc).AddTicks(4630), "Staff2@gmail.com", null, false, "Staff2", "$2a$12$OtDudNgJWWEZsWqqZ9DydOHloijG2CvUoOOxapnpxi8MD/bzff1j6", null, null, null, 3, null },
                    { -4, null, new DateTime(2025, 3, 1, 14, 22, 10, 655, DateTimeKind.Utc).AddTicks(5076), "Staff1@gmail.com", null, false, "Staff1", "$2a$12$oytR2MxeuYEQ08CmawuEzea6TuHkxb/Hw77XloBssFdjD9Mo0/Fva", null, null, null, 3, null },
                    { -3, null, new DateTime(2025, 3, 1, 14, 22, 10, 419, DateTimeKind.Utc).AddTicks(1494), "Manager2@gmail.com", null, false, "Manager2", "$2a$12$muji2Py2D52xpW9IfcXPEOqo5N9De6MdngLeoF9vq8sLpYiVZJWxK", null, null, null, 2, null },
                    { -2, null, new DateTime(2025, 3, 1, 14, 22, 10, 181, DateTimeKind.Utc).AddTicks(4268), "Manager1@gmail.com", null, false, "Manager1", "$2a$12$4PLiR.YwaY9jFFIrhqieT.QqlLVsjwTnA1dpj7go68Lif5LIWoXSq", null, null, null, 2, null },
                    { -1, null, new DateTime(2025, 3, 1, 14, 22, 9, 942, DateTimeKind.Utc).AddTicks(9620), "Admin@gmail.com", null, false, "Admin", "$2a$12$wFWgkdl0y7zHb/qrrfyE2uyESrIPQBVGJBoBrCDR/7vn5nsetZrma", null, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Utensils",
                columns: new[] { "UtensilId", "CreatedAt", "Description", "ImageURL", "IsDelete", "LastMaintainDate", "Material", "Name", "Price", "Quantity", "Status", "UpdatedAt", "UtensilTypeID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2902), "Set of 5 pairs of traditional bamboo chopsticks.", "https://example.com/images/bamboo-chopsticks.jpg", false, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(2886), "Bamboo", "Bamboo Chopsticks Set", 12.99m, 100, true, null, 1 },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2905), "Durable stainless steel ladle for serving hotpot broth.", "https://example.com/images/steel-ladle.jpg", false, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(2903), "Stainless Steel", "Stainless Steel Hotpot Ladle", 9.99m, 75, true, null, 2 },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2908), "Fine mesh strainer for retrieving food from the hotpot.", "https://example.com/images/mesh-strainer.jpg", false, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(2907), "Stainless Steel", "Wire Mesh Strainer", 7.99m, 80, true, null, 3 },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2912), "Set of 4 ceramic bowls for individual servings.", "https://example.com/images/ceramic-bowls.jpg", false, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(2910), "Ceramic", "Ceramic Serving Bowl Set", 19.99m, 50, true, null, 4 },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2915), "Set of 6 durable melamine plates for hotpot dining.", "https://example.com/images/melamine-plates.jpg", false, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(2913), "Melamine", "Melamine Plates", 24.99m, 60, true, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1207), false, null, -8 },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1209), false, null, -9 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "IsDelete", "LoyatyPoint", "UpdatedAt", "UserID" },
                values: new object[] { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1209), false, 200.0, null, -10 });

            migrationBuilder.InsertData(
                table: "HotPotInventorys",
                columns: new[] { "HotPotInventoryId", "CreatedAt", "HotpotId", "IsDelete", "SeriesNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2967), 1, false, "CP-2023-0001", false, null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2969), 1, false, "CP-2023-0002", false, null },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2971), 2, false, "EL-2023-0001", false, null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2973), 2, false, "EL-2023-0002", false, null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2974), 3, false, "PT-2023-0001", false, null },
                    { 6, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2976), 4, false, "MC-2023-0001", false, null },
                    { 7, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(2978), 5, false, "CR-2023-0001", false, null }
                });

            migrationBuilder.InsertData(
                table: "IngredientPrices",
                columns: new[] { "IngredientPriceId", "CreatedAt", "EffectiveDate", "IngredientID", "IsDelete", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 30, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3379), new DateTime(2025, 1, 30, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3371), 1, false, 12.99m, null },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3381), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3381), 1, false, 13.99m, null },
                    { 3, new DateTime(2025, 1, 30, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3384), new DateTime(2025, 1, 30, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3383), 2, false, 14.99m, null },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3387), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3386), 2, false, 15.99m, null },
                    { 5, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3389), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3389), 3, false, 11.99m, null },
                    { 6, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3392), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3392), 4, false, 16.99m, null },
                    { 7, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3395), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3394), 5, false, 9.99m, null },
                    { 8, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3397), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3396), 6, false, 14.99m, null },
                    { 9, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3400), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3399), 7, false, 5.99m, null },
                    { 10, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3402), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3401), 8, false, 4.99m, null },
                    { 11, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3404), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3404), 9, false, 3.99m, null },
                    { 12, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3407), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3406), 10, false, 6.99m, null },
                    { 13, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3409), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3408), 11, false, 5.99m, null },
                    { 14, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3411), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3411), 12, false, 6.49m, null },
                    { 15, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3414), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3413), 13, false, 4.99m, null },
                    { 16, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3416), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3415), 14, false, 5.49m, null },
                    { 17, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3419), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3418), 15, false, 7.99m, null },
                    { 18, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3421), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3420), 16, false, 6.99m, null },
                    { 19, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3423), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3423), 17, false, 8.99m, null },
                    { 20, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3434), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3433), 18, false, 7.99m, null },
                    { 21, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3436), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3435), 19, false, 8.49m, null },
                    { 22, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3439), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3438), 20, false, 7.49m, null },
                    { 23, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3441), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3440), 21, false, 4.99m, null },
                    { 24, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3443), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3443), 22, false, 3.99m, null },
                    { 25, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3446), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3445), 23, false, 4.49m, null },
                    { 26, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3448), new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Local).AddTicks(3447), 24, false, 5.99m, null }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1157), false, null, -2 },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1159), false, null, -3 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "CreatedAt", "IsDelete", "UpdatedAt", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1085), false, null, -4 },
                    { 2, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1092), false, null, -5 },
                    { 3, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1093), false, null, -6 },
                    { 4, new DateTime(2025, 3, 1, 14, 22, 12, 317, DateTimeKind.Utc).AddTicks(1094), false, null, -7 }
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
                name: "IX_ChatMessages_SessionChatSessionId",
                table: "ChatMessages",
                column: "SessionChatSessionId");

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
                name: "IX_ComboIngredients_ComboID_IngredientID",
                table: "ComboIngredients",
                columns: new[] { "ComboID", "IngredientID" });

            migrationBuilder.CreateIndex(
                name: "IX_ComboIngredients_IngredientID",
                table: "ComboIngredients",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_HotpotBrothID",
                table: "Combos",
                column: "HotpotBrothID");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_IngredientId",
                table: "Combos",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionLogs_HotPotInventoryId",
                table: "ConditionLogs",
                column: "HotPotInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionLogs_UtensilID",
                table: "ConditionLogs",
                column: "UtensilID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomizationIngredients_CustomizationID_IngredientID",
                table: "CustomizationIngredients",
                columns: new[] { "CustomizationID", "IngredientID" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizationIngredients_IngredientID",
                table: "CustomizationIngredients",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_ComboID",
                table: "Customizations",
                column: "ComboID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_HotpotBrothID",
                table: "Customizations",
                column: "HotpotBrothID");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_IngredientId",
                table: "Customizations",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UserID",
                table: "Customizations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ManagerId",
                table: "Feedback",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrderID",
                table: "Feedback",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserID",
                table: "Feedback",
                column: "UserID");

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
                name: "IX_Hotpots_HotpotTypeID",
                table: "Hotpots",
                column: "HotpotTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotpots_TurtorialVideoID",
                table: "Hotpots",
                column: "TurtorialVideoID");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPrices_IngredientID",
                table: "IngredientPrices",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeID",
                table: "Ingredients",
                column: "IngredientTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserID",
                table: "Managers",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ComboID",
                table: "OrderDetails",
                column: "ComboID",
                unique: true,
                filter: "[ComboID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomizationID",
                table: "OrderDetails",
                column: "CustomizationID",
                unique: true,
                filter: "[CustomizationID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_HotpotID",
                table: "OrderDetails",
                column: "HotpotID",
                unique: true,
                filter: "[HotpotID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IngredientID",
                table: "OrderDetails",
                column: "IngredientID",
                unique: true,
                filter: "[IngredientID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UtensilID",
                table: "OrderDetails",
                column: "UtensilID",
                unique: true,
                filter: "[UtensilID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountID",
                table: "Orders",
                column: "DiscountID",
                unique: true,
                filter: "[DiscountID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentID",
                table: "Orders",
                column: "PaymentID",
                unique: true,
                filter: "[PaymentID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

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
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOrders_StaffID",
                table: "ShippingOrders",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserID",
                table: "Staffs",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Utensils_UtensilTypeID",
                table: "Utensils",
                column: "UtensilTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_ManagerID",
                table: "WorkShifts",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_StaffID",
                table: "WorkShifts",
                column: "StaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ComboIngredients");

            migrationBuilder.DropTable(
                name: "CustomizationIngredients");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "IngredientPrices");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ReplacementRequests");

            migrationBuilder.DropTable(
                name: "ShippingOrders");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "ChatSessions");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "ConditionLogs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "HotPotInventorys");

            migrationBuilder.DropTable(
                name: "Utensils");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Hotpots");

            migrationBuilder.DropTable(
                name: "UtensilTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "IngredientTypes");

            migrationBuilder.DropTable(
                name: "HotpotTypes");

            migrationBuilder.DropTable(
                name: "TurtorialVideos");
        }
    }
}
