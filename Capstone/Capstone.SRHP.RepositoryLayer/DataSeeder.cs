using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.Utils;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ModelLayer
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Roles
            SeedRoles(modelBuilder);

            // Users
            SeedUsers(modelBuilder);

            // Utensil Types
            SeedUtensilTypes(modelBuilder);

            // Tutorial Videos
            SeedTutorialVideos(modelBuilder);

            // Hotpots
            SeedHotpots(modelBuilder);

            // HotPot Inventory
            SeedHotPotInventory(modelBuilder);

            // Utensils
            SeedUtensils(modelBuilder);

            // Ingredient Types
            SeedIngredientTypes(modelBuilder);

            // Ingredients
            SeedIngredients(modelBuilder);

            // Ingredient Prices
            SeedIngredientPrices(modelBuilder);

            // Damage Devices
            SeedDamageDevices(modelBuilder);

            // Size Discounts
            SeedSizeDiscounts(modelBuilder);

            // Vehicle
            SeedVehicle(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Admin" },
                new Role { RoleId = 2, Name = "Manager" },
                new Role { RoleId = 3, Name = "Staff" },
                new Role { RoleId = 4, Name = "Customer" }
            );
        }
        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, PhoneNumber = "987654321", Name = "Admin", Email = "Admin@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 1 },

                new User { UserId = 2, PhoneNumber = "999999999", Name = "Nguyễn Văn Quân", Email = "Manager1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 2 },
                new User { UserId = 3, PhoneNumber = "888888888", Name = "Trần Thị Thu", Email = "Manager2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 2 },

                new User { UserId = 4, PhoneNumber = "777777777", Name = "Lê Minh Hoàng", Email = "Staff1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Preparation },
                new User { UserId = 5, PhoneNumber = "666666666", Name = "Phạm Thị Hằng", Email = "Staff2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Preparation },
                new User { UserId = 6, PhoneNumber = "555555555", Name = "Ngô Văn Cường", Email = "Staff3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Shipping },
                new User { UserId = 7, PhoneNumber = "444444444", Name = "Đinh Thị Hà", Email = "Staff4@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Shipping },

                // New staff
                new User { UserId = 11, PhoneNumber = "0901234567", Name = "Võ Anh Dũng", Email = "Staff5@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Preparation },
                new User { UserId = 12, PhoneNumber = "0907654321", Name = "Nguyễn Thị Mai", Email = "Staff6@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Preparation },
                new User { UserId = 13, PhoneNumber = "0912345678", Name = "Bùi Văn Hậu", Email = "Staff7@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Shipping },
                new User { UserId = 14, PhoneNumber = "0918765432", Name = "Trương Thị Lan", Email = "Staff8@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3, StaffType = StaffType.Shipping },

                new User { UserId = 8, PhoneNumber = "333333333", Name = "Đặng Văn Nam", Email = "Customer1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                new User { UserId = 9, PhoneNumber = "222222222", Name = "Lý Thị Ngọc", Email = "Customer2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                new User { UserId = 10, PhoneNumber = "111111111", Name = "Phan Minh Đức", Email = "Customer3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4, LoyatyPoint = 200 }
);

        }
        private static void SeedUtensilTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UtensilType>().HasData(
                new UtensilType { UtensilTypeId = 1, Name = "Đũa", },
                new UtensilType { UtensilTypeId = 2, Name = "Muôi", },
                new UtensilType { UtensilTypeId = 3, Name = "Vợt", },
                new UtensilType { UtensilTypeId = 4, Name = "Bát", },
                new UtensilType { UtensilTypeId = 5, Name = "Đĩa", }
            );
        }
        private static void SeedTutorialVideos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurtorialVideo>().HasData(
     new TurtorialVideo
     {
         TurtorialVideoId = 1,
         Name = "Cách Sử Dụng Nồi Lẩu Truyền Thống",
         Description = "Hướng dẫn toàn diện về cách thiết lập và sử dụng nồi lẩu truyền thống.",
         VideoURL = "https://www.youtube.com/watch?v=traditional-hotpot-guide",
     },
     new TurtorialVideo
     {
         TurtorialVideoId = 2,
         Name = "Hướng Dẫn Thiết Lập Nồi Lẩu Điện",
         Description = "Học cách thiết lập và sử dụng nồi lẩu điện an toàn.",
         VideoURL = "https://www.youtube.com/watch?v=electric-hotpot-setup",
     },
     new TurtorialVideo
     {
         TurtorialVideoId = 3,
         Name = "Nồi Lẩu Di Động Mọi Lúc Mọi Nơi",
         Description = "Mẹo và thủ thuật để sử dụng nồi lẩu di động ở bất kỳ đâu.",
         VideoURL = "https://www.youtube.com/watch?v=portable-hotpot-guide",
     },
     new TurtorialVideo
     {
         TurtorialVideoId = 4,
         Name = "Làm Chủ Nồi Lẩu Đa Ngăn",
         Description = "Cách sử dụng hiệu quả tất cả các ngăn trong nồi lẩu đa ngăn của bạn.",
         VideoURL = "https://www.youtube.com/watch?v=multi-compartment-guide",
     },
     new TurtorialVideo
     {
         TurtorialVideoId = 5,
         Name = "Hướng Dẫn Chăm Sóc Nồi Lẩu Gốm",
         Description = "Học cách chăm sóc và bảo quản nồi lẩu gốm đúng cách.",
         VideoURL = "https://www.youtube.com/watch?v=ceramic-hotpot-care",
     }
 );
        }
        private static void SeedHotpots(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotpot>().HasData(
                new Hotpot
                {
                    HotpotId = 1,
                    Name = "Nồi Lẩu Đồng Cổ Điển",
                    Material = "Đồng",
                    Size = "M",
                    Description = "Nồi lẩu đồng truyền thống với hệ thống đốt than.",
                    ImageURL = "https://example.com/images/classic-copper-hotpot.jpg",
                    Price = 730000m, // ~29.99 USD
                    BasePrice = 2200000m, // ~89.99 USD
                    Quantity = 5,
                },
                new Hotpot
                {
                    HotpotId = 2,
                    Name = "Nồi Lẩu Điện Hiện Đại",
                    Material = "Thép Không Gỉ",
                    Size = "L",
                    Description = "Nồi lẩu điện với điều khiển nhiệt độ và lớp phủ chống dính.",
                    ImageURL = "https://example.com/images/modern-electric-hotpot.jpg",
                    Price = 1460000m, // ~59.99 USD
                    BasePrice = 3170000m, // ~129.99 USD
                    Quantity = 2,
                },
                new Hotpot
                {
                    HotpotId = 3,
                    Name = "Nồi Lẩu Mini Di Động",
                    Material = "Nhôm",
                    Size = "S",
                    Description = "Nồi lẩu nhỏ gọn di động hoàn hảo cho du lịch hoặc các buổi tụ họp nhỏ.",
                    ImageURL = "https://example.com/images/mini-portable-hotpot.jpg",
                    Price = 490000m, // ~19.99 USD
                    BasePrice = 1710000m, // ~69.99 USD
                    Quantity = 2,
                },
                new Hotpot
                {
                    HotpotId = 4,
                    Name = "Nồi Lẩu Hai Ngăn",
                    Material = "Thép Không Gỉ",
                    Size = "L",
                    Description = "Nồi lẩu đa ngăn cho phép nấu nhiều loại nước lẩu khác nhau trong một nồi.",
                    ImageURL = "https://example.com/images/dual-section-hotpot.jpg",
                    Price = 1710000m, // ~69.99 USD
                    BasePrice = 3660000m, // ~149.99 USD
                    Quantity = 2,
                },
                new Hotpot
                {
                    HotpotId = 5,
                    Name = "Nồi Lẩu Gốm Truyền Thống",
                    Material = "Gốm",
                    Size = "M",
                    Description = "Nồi lẩu gốm truyền thống giữ nhiệt cực tốt.",
                    ImageURL = "https://example.com/images/traditional-ceramic-hotpot.jpg",
                    Price = 980000m, // ~39.99 USD
                    BasePrice = 1950000m, // ~79.99 USD
                    Quantity = 4,
                }
            );
        }
        private static void SeedHotPotInventory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotPotInventory>().HasData(
                new HotPotInventory
                {
                    HotPotInventoryId = 1,
                    SeriesNumber = "CP-2023-0001",
                    HotpotId = 1,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 2,
                    SeriesNumber = "CP-2023-0002",
                    Status = HotpotStatus.Available,
                    HotpotId = 1,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 3,
                    SeriesNumber = "EL-2023-0001",
                    HotpotId = 2,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 4,
                    SeriesNumber = "EL-2023-0002",
                    HotpotId = 2,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 5,
                    SeriesNumber = "PT-2023-0001",
                    HotpotId = 3,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 6,
                    SeriesNumber = "MC-2023-0001",
                    HotpotId = 4,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 7,
                    SeriesNumber = "CR-2023-0001",
                    HotpotId = 5,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 8,
                    SeriesNumber = "CP-2023-0003",
                    HotpotId = 1,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 9,
                    SeriesNumber = "CP-2023-0004",
                    HotpotId = 1,
                    Status = HotpotStatus.Damaged,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 10,
                    SeriesNumber = "CP-2023-0005",
                    HotpotId = 1,
                    Status = HotpotStatus.Damaged
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 11,
                    SeriesNumber = "PT-2023-0002",
                    HotpotId = 3,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 12,
                    SeriesNumber = "MC-2023-0002",
                    HotpotId = 4,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 13,
                    SeriesNumber = "CR-2023-0002",
                    HotpotId = 5,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 14,
                    SeriesNumber = "CR-2023-0003",
                    HotpotId = 5,
                    Status = HotpotStatus.Available,
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 15,
                    SeriesNumber = "CR-2023-0004",
                    HotpotId = 5,
                    Status = HotpotStatus.Damaged,
                }
            );
        }
        private static void SeedUtensils(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utensil>().HasData(
                new Utensil
                {
                    UtensilId = 1,
                    Name = "Bộ Đũa Tre",
                    Material = "Tre",
                    Description = "Bộ 5 đôi đũa tre truyền thống.",
                    ImageURL = "https://example.com/images/bamboo-chopsticks.jpg",
                    Price = 320000m, // ~12.99 USD
                    Status = true,
                    Quantity = 100,
                    UtensilTypeId = 1,
                },
                new Utensil
                {
                    UtensilId = 2,
                    Name = "Muỗng Lẩu Thép Không Gỉ",
                    Material = "Thép Không Gỉ",
                    Description = "Muỗng thép không gỉ bền chắc để múc nước lẩu.",
                    ImageURL = "https://example.com/images/steel-ladle.jpg",
                    Price = 245000m, // ~9.99 USD
                    Status = true,
                    Quantity = 75,
                    UtensilTypeId = 2,
                },
                new Utensil
                {
                    UtensilId = 3,
                    Name = "Vợt Lưới Kim Loại",
                    Material = "Thép Không Gỉ",
                    Description = "Vợt lưới mịn để vớt thức ăn từ nồi lẩu.",
                    ImageURL = "https://example.com/images/mesh-strainer.jpg",
                    Price = 195000m, // ~7.99 USD
                    Status = true,
                    Quantity = 80,
                    UtensilTypeId = 3,
                },
                new Utensil
                {
                    UtensilId = 4,
                    Name = "Bộ Bát Ăn Gốm",
                    Material = "Gốm",
                    Description = "Bộ 4 bát gốm cho phần ăn cá nhân.",
                    ImageURL = "https://example.com/images/ceramic-bowls.jpg",
                    Price = 490000m, // ~19.99 USD
                    Status = true,
                    Quantity = 50,
                    UtensilTypeId = 4,
                },
                  new Utensil
                  {
                      UtensilId = 5,
                      Name = "Đĩa Melamine",
                      Material = "Melamine",
                      Description = "Bộ 6 đĩa melamine bền chắc cho bữa ăn lẩu.",
                      ImageURL = "https://example.com/images/melamine-plates.jpg",
                      Price = 610000m, // ~24.99 USD
                      Status = true,
                      Quantity = 60,
                      UtensilTypeId = 5,
                  }
);
        }
        private static void SeedIngredientTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientType>().HasData(
                new IngredientType
                {
                    IngredientTypeId = 1,
                    Name = "Nước Lẩu",
                },
                new IngredientType
                {
                    IngredientTypeId = 2,
                    Name = "Hải Sản",
                },
                new IngredientType
                {
                    IngredientTypeId = 3,
                    Name = "Rau Củ",
                },
                new IngredientType
                {
                    IngredientTypeId = 4,
                    Name = "Mì",
                },
                new IngredientType
                {
                    IngredientTypeId = 5,
                    Name = "Đậu Phụ",
                },
                new IngredientType
                {
                    IngredientTypeId = 6,
                    Name = "Nấm",
                },
                new IngredientType
                {
                    IngredientTypeId = 7,
                    Name = "Thịt",
                },
                new IngredientType
                {
                    IngredientTypeId = 8,
                    Name = "Nước Chấm",
                }
            );
        }
        private static void SeedIngredients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(

                new Ingredient
                {
                    IngredientId = 1,
                    Name = "Thịt Bò Cắt Lát",
                    Description = "Thịt bò cao cấp cắt lát mỏng hoàn hảo cho lẩu.",
                    ImageURL = "https://example.com/images/sliced-beef.jpg",
                    MinStockLevel = 20,
                    Quantity = 100,
                    IngredientTypeId = 7,
                },
                new Ingredient
                {
                    IngredientId = 2,
                    Name = "Thịt Cừu Cắt Lát",
                    Description = "Thịt cừu mềm cắt lát, hoàn hảo cho nấu nhanh.",
                    ImageURL = "https://example.com/images/lamb-slices.jpg",
                    MinStockLevel = 15,
                    Quantity = 80,
                    IngredientTypeId = 7,
                },
                new Ingredient
                {
                    IngredientId = 3,
                    Name = "Ba Chỉ Heo",
                    Description = "Thịt ba chỉ heo cắt mỏng với tỷ lệ mỡ-thịt hoàn hảo.",
                    ImageURL = "https://example.com/images/pork-belly.jpg",
                    MinStockLevel = 15,
                    Quantity = 75,
                    IngredientTypeId = 7,
                },

                new Ingredient
                {
                    IngredientId = 4,
                    Name = "Tôm",
                    Description = "Tôm tươi, đã bóc vỏ và làm sạch.",
                    ImageURL = "https://example.com/images/shrimp.jpg",
                    MinStockLevel = 20,
                    Quantity = 90,
                    IngredientTypeId = 2,
                },
                new Ingredient
                {
                    IngredientId = 5,
                    Name = "Cá Viên",
                    Description = "Cá viên đàn hồi làm từ cá tươi xay.",
                    ImageURL = "https://example.com/images/fish-balls.jpg",
                    MinStockLevel = 30,
                    Quantity = 120,
                    IngredientTypeId = 2,
                },
                new Ingredient
                {
                    IngredientId = 6,
                    Name = "Mực",
                    Description = "Mực tươi cắt thành khoanh.",
                    ImageURL = "https://example.com/images/squid.jpg",
                    MinStockLevel = 15,
                    Quantity = 60,
                    IngredientTypeId = 2,
                },


                new Ingredient
                {
                    IngredientId = 7,
                    Name = "Cải Thảo",
                    Description = "Rau giòn, lá xanh hoàn hảo cho lẩu.",
                    ImageURL = "https://example.com/images/napa-cabbage.jpg",
                    MinStockLevel = 25,
                    Quantity = 100,
                    IngredientTypeId = 3,
                },
                new Ingredient
                {
                    IngredientId = 8,
                    Name = "Rau Chân Vịt",
                    Description = "Rau chân vịt tươi, đã rửa sạch và sẵn sàng để nấu.",
                    ImageURL = "https://example.com/images/spinach.jpg",
                    MinStockLevel = 20,
                    Quantity = 80,
                    IngredientTypeId = 3,
                },
                new Ingredient
                {
                    IngredientId = 9,
                    Name = "Bắp",
                    Description = "Bắp ngọt cắt thành miếng vừa ăn.",
                    ImageURL = "https://example.com/images/corn.jpg",
                    MinStockLevel = 15,
                    Quantity = 70,
                    IngredientTypeId = 3,
                },


                new Ingredient
                {
                    IngredientId = 10,
                    Name = "Mì Udon",
                    Description = "Mì lúa mì Nhật Bản dày và dai.",
                    ImageURL = "https://example.com/images/udon-noodles.jpg",
                    MinStockLevel = 20,
                    Quantity = 80,
                    IngredientTypeId = 4,
                },
                new Ingredient
                {
                    IngredientId = 11,
                    Name = "Miến",
                    Description = "Miến trong suốt làm từ tinh bột đậu xanh.",
                    ImageURL = "https://example.com/images/glass-noodles.jpg",
                    MinStockLevel = 20,
                    Quantity = 85,
                    IngredientTypeId = 4,
                },
                new Ingredient
                {
                    IngredientId = 12,
                    Name = "Mì Ramen",
                    Description = "Mì lúa mì xoăn hoàn hảo cho lẩu.",
                    ImageURL = "https://example.com/images/ramen-noodles.jpg",
                    MinStockLevel = 25,
                    Quantity = 90,
                    IngredientTypeId = 4,
                },


                new Ingredient
                {
                    IngredientId = 13,
                    Name = "Đậu Phụ Cứng",
                    Description = "Đậu phụ cứng cắt khối giữ nguyên hình dạng trong lẩu.",
                    ImageURL = "https://example.com/images/firm-tofu.jpg",
                    MinStockLevel = 15,
                    Quantity = 60,
                    IngredientTypeId = 5,
                },
                new Ingredient
                {
                    IngredientId = 14,
                    Name = "Đậu Phụ Chiên",
                    Description = "Đậu phụ chiên giòn hấp thụ hương vị nước lẩu.",
                    ImageURL = "https://example.com/images/tofu-puffs.jpg",
                    MinStockLevel = 15,
                    Quantity = 65,
                    IngredientTypeId = 5,
                },

                new Ingredient
                {
                    IngredientId = 15,
                    Name = "Nấm Hương",
                    Description = "Nấm hương thơm ngon, tươi hoặc khô.",
                    ImageURL = "https://example.com/images/shiitake.jpg",
                    MinStockLevel = 15,
                    Quantity = 70,
                    IngredientTypeId = 6,
                },
                new Ingredient
                {
                    IngredientId = 16,
                    Name = "Nấm Kim Châm",
                    Description = "Nấm kim châm mỏng, thân dài.",
                    ImageURL = "https://example.com/images/enoki.jpg",
                    MinStockLevel = 15,
                    Quantity = 65,
                    IngredientTypeId = 6,
                },


                new Ingredient
                {
                    IngredientId = 17,
                    Name = "Nước Lẩu Tứ Xuyên Cay",
                    Description = "Nước lẩu cay truyền thống với hạt tiêu Tứ Xuyên và dầu ớt.",
                    ImageURL = "https://example.com/images/sichuan-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 50,
                    IngredientTypeId = 1,
                },
                new Ingredient
                {
                    IngredientId = 18,
                    Name = "Nước Lẩu Cà Chua",
                    Description = "Nước lẩu cà chua chua ngọt.",
                    ImageURL = "https://example.com/images/tomato-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 45,
                    IngredientTypeId = 1,
                },
                new Ingredient
                {
                    IngredientId = 19,
                    Name = "Nước Lẩu Nấm",
                    Description = "Nước lẩu đậm đà làm từ nhiều loại nấm.",
                    ImageURL = "https://example.com/images/mushroom-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 40,
                    IngredientTypeId = 1,
                },
                new Ingredient
                {
                    IngredientId = 20,
                    Name = "Nước Lẩu Xương Trong",
                    Description = "Nước lẩu nhẹ, trong làm từ xương hầm nhiều giờ.",
                    ImageURL = "https://example.com/images/bone-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 55,
                    IngredientTypeId = 1,
                },


                new Ingredient
                {
                    IngredientId = 21,
                    Name = "Sốt Mè",
                    Description = "Sốt kem làm từ hạt mè xay.",
                    ImageURL = "https://example.com/images/sesame-sauce.jpg",
                    MinStockLevel = 10,
                    Quantity = 40,
                    IngredientTypeId = 8,
                },
                new Ingredient
                {
                    IngredientId = 22,
                    Name = "Nước Tương Tỏi",
                    Description = "Nước tương pha với tỏi băm.",
                    ImageURL = "https://example.com/images/garlic-soy.jpg",
                    MinStockLevel = 10,
                    Quantity = 45,
                    IngredientTypeId = 8,
                },
                new Ingredient
                {
                    IngredientId = 23,
                    Name = "Dầu Ớt",
                    Description = "Dầu cay làm từ ớt ngâm dầu.",
                    ImageURL = "https://example.com/images/chili-oil.jpg",
                    MinStockLevel = 10,
                    Quantity = 50,
                    IngredientTypeId = 8,
                },
                new Ingredient
                {
                    IngredientId = 24,
                    Name = "Tương Sa Tế",
                    Description = "Sốt đậm đà làm từ dầu đậu nành, tỏi, hành và hải sản khô.",
                    ImageURL = "https://example.com/images/shacha-sauce.jpg",
                    MinStockLevel = 10,
                    Quantity = 35,
                    IngredientTypeId = 8,
                }
            );
        }
        private static void SeedIngredientPrices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientPrice>().HasData(
                // Meat prices (per pack)
                new IngredientPrice
                {
                    IngredientPriceId = 1,
                    Price = 120000m, // 120,000 VND for 250g pack of sliced beef
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-30),
                    IngredientId = 1,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 2,
                    Price = 135000m, // 135,000 VND for 250g pack of sliced beef (price increase)
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 1,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 3,
                    Price = 150000m, // 150,000 VND for 250g pack of lamb slices
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-30),
                    IngredientId = 2,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 4,
                    Price = 165000m, // 165,000 VND for 250g pack of lamb slices (price increase)
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 2,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 5,
                    Price = 95000m, // 95,000 VND for 250g pack of pork belly
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 3,
                },

                // Seafood prices (per pack)
                new IngredientPrice
                {
                    IngredientPriceId = 6,
                    Price = 110000m, // 110,000 VND for 200g pack of shrimp
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 4,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 7,
                    Price = 75000m, // 75,000 VND for 300g pack of fish balls
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 5,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 8,
                    Price = 90000m, // 90,000 VND for 200g pack of squid
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 6,
                },
                // Vegetable prices (per pack) 
                new IngredientPrice
                {
                    IngredientPriceId = 9,
                    Price = 25000m, // 25,000 VND for 400g pack of napa cabbage
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 7,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 10,
                    Price = 20000m, // 20,000 VND for 300g pack of spinach
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 8,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 11,
                    Price = 18000m, // 18,000 VND for 250g pack of corn
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 9,
                },

                // Noodle prices (per pack)
                new IngredientPrice
                {
                    IngredientPriceId = 12,
                    Price = 35000m, // 35,000 VND for 300g pack of udon noodles
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 10,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 13,
                    Price = 30000m, // 30,000 VND for 200g pack of glass noodles
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 11,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 14,
                    Price = 32000m, // 32,000 VND for 250g pack of ramen noodles
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 12,
                },

                // Tofu prices (per pack)
                new IngredientPrice
                {
                    IngredientPriceId = 15,
                    Price = 22000m, // 22,000 VND for 300g pack of firm tofu
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 13,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 16,
                    Price = 25000m, // 25,000 VND for 250g pack of tofu puffs
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 14,
                },

                // Mushroom prices (per pack)
                new IngredientPrice
                {
                    IngredientPriceId = 17,
                    Price = 45000m, // 45,000 VND for 200g pack of shiitake mushrooms
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 15,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 18,
                    Price = 35000m, // 35,000 VND for 150g pack of enoki mushrooms
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 16,
                },

                // Broth prices (per container)
                new IngredientPrice
                {
                    IngredientPriceId = 19,
                    Price = 65000m, // 65,000 VND for 500ml container of Sichuan broth
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 17,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 20,
                    Price = 55000m, // 55,000 VND for 500ml container of tomato broth
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 18,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 21,
                    Price = 60000m, // 60,000 VND for 500ml container of mushroom broth
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 19,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 22,
                    Price = 50000m, // 50,000 VND for 500ml container of bone broth
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 20,
                },

                // Sauce prices (per bottle)
                new IngredientPrice
                {
                    IngredientPriceId = 23,
                    Price = 40000m, // 40,000 VND for 200ml bottle of sesame sauce
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 21,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 24,
                    Price = 35000m, // 35,000 VND for 250ml bottle of garlic soy sauce
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 22,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 25,
                    Price = 38000m, // 38,000 VND for 150ml bottle of chili oil
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 23,
                },
                new IngredientPrice
                {
                    IngredientPriceId = 26,
                    Price = 42000m, // 42,000 VND for 200ml bottle of shacha sauce
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 24,
                }
            );
        }
        private static void SeedDamageDevices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DamageDevice>().HasData(
                new DamageDevice
                {
                    DamageDeviceId = 1,
                    Name = "Tay Cầm Bị Gãy",
                    Description = "Tay cầm của nồi lẩu bị gãy và cần được thay thế.",
                    Status = MaintenanceStatus.Pending,
                    LoggedDate = DateTime.UtcNow.AddHours(7),
                    HotPotInventoryId = 15
                },
                new DamageDevice
                {
                    DamageDeviceId = 2,
                    Name = "Đế Nồi Bị Nứt",
                    Description = "Đế của nồi lẩu bị nứt và cần được thay thế.",
                    Status = MaintenanceStatus.InProgress,
                    LoggedDate = DateTime.UtcNow.AddHours(7),
                    HotPotInventoryId = 10
                },
                new DamageDevice
                {
                    DamageDeviceId = 3,
                    Name = "Nắp Nồi Hư Hỏng",
                    Description = "Nắp của nồi lẩu bị hư hỏng và cần được thay thế.",
                    Status = MaintenanceStatus.Completed,
                    LoggedDate = DateTime.UtcNow.AddHours(7),
                    HotPotInventoryId = 9
                },
                new DamageDevice
                {
                    DamageDeviceId = 4,
                    Name = "Đĩa Bị Vỡ",
                    Description = "Đĩa bị vỡ và cần được thay thế.",
                    Status = MaintenanceStatus.Cancelled,
                    LoggedDate = DateTime.UtcNow.AddHours(7),
                    UtensilId = 5
                }
            );
        }
        private static void SeedSizeDiscounts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SizeDiscount>().HasData(
                new SizeDiscount
                {
                    SizeDiscountId = 1,
                    MinSize = 2,
                    DiscountPercentage = 4.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                },
                new SizeDiscount
                {
                    SizeDiscountId = 2,
                    MinSize = 4,
                    DiscountPercentage = 8.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                },
                new SizeDiscount
                {
                    SizeDiscountId = 3,
                    MinSize = 6,
                    DiscountPercentage = 12.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                },
                new SizeDiscount
                {
                    SizeDiscountId = 4,
                    MinSize = 8,
                    DiscountPercentage = 16.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                },
                new SizeDiscount
                {
                    SizeDiscountId = 5,
                    MinSize = 10,
                    DiscountPercentage = 20.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                },
                new SizeDiscount
                {
                    SizeDiscountId = 6,
                    MinSize = 15,
                    DiscountPercentage = 24.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                },
                new SizeDiscount
                {
                    SizeDiscountId = 7,
                    MinSize = 20,
                    DiscountPercentage = 28.00m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = null, // No end date (ongoing)
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7),
                    IsDelete = false
                }
            );
        }
        private static void SeedVehicle(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    VehicleId = 1,
                    Name = "Honda Wave Alpha",
                    LicensePlate = "59P1-12345",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.Available,
                    Notes = "Xe máy giao hàng tiêu chuẩn, màu xanh dương, đã được bảo dưỡng tháng 3/2025",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 2,
                    Name = "Yamaha Sirius",
                    LicensePlate = "59P2-23456",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.Available,
                    Notes = "Xe máy giao hàng nhanh, màu đỏ, tiết kiệm nhiên liệu",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 3,
                    Name = "Honda Vision",
                    LicensePlate = "59P2-34567",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.InUse,
                    Notes = "Xe tay ga dành cho đơn hàng nhỏ, màu trắng, có thùng hàng 60L",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 4,
                    Name = "Suzuki Raider",
                    LicensePlate = "59P3-45678",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.Available,
                    Notes = "Xe máy giao hàng tốc độ cao, phù hợp cho đơn hàng khẩn cấp",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 5,
                    Name = "Toyota Vios",
                    LicensePlate = "51A-12345",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Xe ô tô 4 chỗ, phù hợp cho đơn hàng lớn hoặc khoảng cách xa",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 6,
                    Name = "Mitsubishi Xpander",
                    LicensePlate = "51A-23456",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Xe ô tô 7 chỗ, đang trong quá trình bảo dưỡng định kỳ, sẽ sẵn sàng vào 25/04/2025",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 7,
                    Name = "Honda SH Mode",
                    LicensePlate = "59P3-56789",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.Available,
                    Notes = "Xe tay ga cao cấp, phù hợp cho giao hàng trong khu vực trung tâm thành phố",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 8,
                    Name = "Ford Ranger",
                    LicensePlate = "51A-34567",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Xe bán tải, phù hợp cho vận chuyển hàng hóa lớn và đường xa",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 9,
                    Name = "Piaggio Vespa",
                    LicensePlate = "59P4-67890",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.Available,
                    Notes = "Xe tay ga phong cách Ý, phù hợp cho giao hàng cao cấp",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                },
                new Vehicle
                {
                    VehicleId = 10,
                    Name = "Hyundai Accent",
                    LicensePlate = "51A-45678",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Xe sedan 4 chỗ, tiết kiệm nhiên liệu, phù hợp cho giao hàng khoảng cách xa",
                    CreatedAt = DateTime.UtcNow.AddHours(7),
                    UpdatedAt = DateTime.UtcNow.AddHours(7)
                }
            );
        }
    }
}
