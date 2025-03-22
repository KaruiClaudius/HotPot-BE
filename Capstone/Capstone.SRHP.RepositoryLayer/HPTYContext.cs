using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.RepositoryLayer
{
    public class HPTYContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<ShippingOrder> ShippingOrders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<WorkShift> WorkShifts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<SellOrder> SellOrders { get; set; }
        public virtual DbSet<RentOrder> RentOrders { get; set; }
        public virtual DbSet<SellOrderDetail> SellOrderDetails { get; set; }
        public virtual DbSet<RentOrderDetail> RentOrderDetails { get; set; }
        public virtual DbSet<Customization> Customizations { get; set; }
        public virtual DbSet<CustomizationIngredient> CustomizationIngredients { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<ComboIngredient> ComboIngredients { get; set; }
        public virtual DbSet<Utensil> Utensils { get; set; }
        public virtual DbSet<UtensilType> UtensilTypes { get; set; }
        public virtual DbSet<Hotpot> Hotpots { get; set; }
        public virtual DbSet<HotPotInventory> HotPotInventorys { get; set; }
        public virtual DbSet<TurtorialVideo> TurtorialVideos { get; set; }
        public virtual DbSet<DamageDevice> ConditionLogs { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientType> IngredientTypes { get; set; }
        public virtual DbSet<IngredientPrice> IngredientPrices { get; set; }
        //public virtual DbSet<Staff> Staffs { get; set; }
        //public virtual DbSet<Manager> Managers { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatSession> ChatSessions { get; set; }
        public virtual DbSet<ReplacementRequest> ReplacementRequests { get; set; }
        public virtual DbSet<ComboAllowedIngredientType> ComboAllowedIngredientTypes { get; set; }
        public virtual DbSet<SizeDiscount> SizeDiscounts { get; set; }
        public DbSet<StaffPickupAssignment> StaffPickupAssignments { get; set; }


        public HPTYContext(DbContextOptions<HPTYContext> options) : base(options)
        {
        }

        public HPTYContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(GetConnectionString());

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //return configuration.GetConnectionString("Server");
            return configuration.GetConnectionString("Server");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                //modelBuilder.Entity(entityType.ClrType)
                //    .Property(nameof(BaseEntity.Id))
                //    .ValueGeneratedOnAdd();


                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var propertyAccess = Expression.Property(parameter, "IsDelete");
                var notExpression = Expression.Not(propertyAccess);
                var lambda = Expression.Lambda(notExpression, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

            modelBuilder.Entity<User>(entity =>
            {

                entity.HasIndex(e => e.PhoneNumber).IsUnique();

                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(u => u.Customer)
                //    .WithOne(c => c.User)
                //    .HasForeignKey<Customer>(c => c.UserId)
                //    .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(u => u.Staff)
                //    .WithOne(s => s.User)
                //    .HasForeignKey<Staff>(s => s.UserId)
                //    .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(u => u.Manager)
                //    .WithOne(m => m.User)
                //    .HasForeignKey<Manager>(m => m.UserId)
                //    .OnDelete(DeleteBehavior.Restrict);
            });

            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.Property(c => c.LoyatyPoint)
            //        .HasDefaultValue(0);
            //});

            modelBuilder.Entity<StaffPickupAssignment>()
                .HasOne(a => a.RentOrderDetail)
                .WithMany()
                .HasForeignKey(a => a.RentOrderDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffPickupAssignment>()
                .HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(d => d.DiscountPercentage)
                    .HasDefaultValue(0);

                entity.Property(d => d.PointCost)
                    .HasDefaultValue(0);

                entity.HasOne(d => d.Order)
                    .WithOne(o => o.Discount)
                    .HasForeignKey<Order>(o => o.DiscountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(p => p.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(p => p.Order)
                    .WithOne(o => o.Payment)
                    .HasForeignKey<Payment>(p => p.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ShippingOrder>(entity =>
            {
                entity.HasOne(so => so.Order)
                    .WithOne(o => o.ShippingOrder)
                    .HasForeignKey<ShippingOrder>(so => so.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(so => so.Staff)
                    .WithMany(s => s.ShippingOrders)
                    .HasForeignKey(so => so.StaffId)
                    .OnDelete(DeleteBehavior.Restrict);
            });



            modelBuilder.Entity<WorkShift>()
                .Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>();



            modelBuilder.Entity<Order>(entity =>
            {
                modelBuilder.Entity<Order>()
                    .Property(o => o.TotalPrice)
                    .HasColumnType("decimal(18,2)");

                // Add new flags
                entity.Property(o => o.HasSellItems)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.Property(o => o.HasRentItems)
                    .IsRequired()
                    .HasDefaultValue(false);
            });

            // Configure SellOrder relationships
            modelBuilder.Entity<SellOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasOne(e => e.Order)
                    .WithOne(o => o.SellOrder)
                    .HasForeignKey<SellOrder>(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            // Configure RentOrder relationships
            modelBuilder.Entity<RentOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasOne(e => e.Order)
                    .WithOne(o => o.RentOrder)
                    .HasForeignKey<RentOrder>(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.HotpotDeposit)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                // Configure rental properties
                entity.Property(e => e.RentalStartDate)
                    .IsRequired();

                entity.Property(e => e.ExpectedReturnDate)
                    .IsRequired();
            });

            // Update SellOrderDetail relationships
            modelBuilder.Entity<SellOrderDetail>(entity =>
            {
                entity.HasOne(e => e.SellOrder)
                    .WithMany(o => o.SellOrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            // Update RentOrderDetail relationships
            modelBuilder.Entity<RentOrderDetail>(entity =>
            {
                entity.HasOne(e => e.RentOrder)
                    .WithMany(o => o.RentOrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.RentalPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            modelBuilder.Entity<ComboAllowedIngredientType>()
                .HasKey(c => c.ComboAllowedIngredientTypeId);

            modelBuilder.Entity<ComboAllowedIngredientType>()
                .HasOne(c => c.Combo)
                .WithMany(c => c.AllowedIngredientTypes)
                .HasForeignKey(c => c.ComboId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ComboAllowedIngredientType>()
                .HasOne(c => c.IngredientType)
                .WithMany()
                .HasForeignKey(c => c.IngredientTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Order)
                .WithOne(o => o.Feedback)
                .HasForeignKey<Feedback>(f => f.OrderId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Customization>()
                .Property(c => c.BasePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Combo>()
                .Property(c => c.BasePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ComboIngredient>(entity =>
            {
                entity.HasKey(e => e.ComboIngredientId);

                // Many-to-Many: Combo <-> Ingredient
                entity.HasOne(ci => ci.Combo)
                    .WithMany(c => c.ComboIngredients)
                    .HasForeignKey(ci => ci.ComboId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.Ingredient)
                    .WithMany(i => i.ComboIngredients)
                    .HasForeignKey(ci => ci.IngredientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(ci => new { ci.ComboId, ci.IngredientId });
            });

            modelBuilder.Entity<CustomizationIngredient>(entity =>
            {
                entity.HasKey(e => e.CustomizationIngredientId);

                // Many-to-Many: Customization <-> Ingredient
                entity.HasOne(ci => ci.Customization)
                    .WithMany(c => c.CustomizationIngredients)
                    .HasForeignKey(ci => ci.CustomizationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.Ingredient)
                    .WithMany(i => i.CustomizationIngredients)
                    .HasForeignKey(ci => ci.IngredientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(ci => new { ci.CustomizationId, ci.IngredientId });
            });

            // Combo Configuration
            modelBuilder.Entity<Combo>(entity =>
            {
                entity.ToTable("Combos");

                entity.Property(e => e.HotpotBrothId)
                    .HasColumnName("HotpotBrothId");

                entity.HasOne(e => e.HotpotBroth)
                    .WithMany()
                    .HasForeignKey(e => e.HotpotBrothId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Customization Configuration
            modelBuilder.Entity<Customization>(entity =>
            {
                entity.ToTable("Customizations");

                entity.Property(e => e.HotpotBrothId)
                    .HasColumnName("HotpotBrothId");

                entity.HasOne(e => e.HotpotBroth)
                    .WithMany()
                    .HasForeignKey(e => e.HotpotBrothId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Utensil>()
                .Property(u => u.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Hotpot>()
                .Property(h => h.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Utensil>()
                .HasOne(u => u.UtensilType)
                .WithMany(ut => ut.Utensils)
                .HasForeignKey(u => u.UtensilTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IngredientPrice>()
                .Property(ip => ip.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.IngredientType)
                .WithMany(it => it.Ingredients)
                .HasForeignKey(i => i.IngredientTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<DamageDevice>(entity =>
            {
                entity.HasKey(e => e.ConditionLogId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);


                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasConversion<int>();

                entity.Property(e => e.ScheduleType)
                    .IsRequired()
                    .HasConversion<int>();

                modelBuilder.Entity<DamageDevice>()
                     .HasOne(c => c.Utensil)
                     .WithMany(u => u.ConditionLogs)
                     .HasForeignKey(c => c.UtensilId);
            });

            modelBuilder.Entity<TurtorialVideo>()
                .HasMany(tv => tv.Combo)
                .WithOne(h => h.TurtorialVideo)
                .HasForeignKey(h => h.TurtorialVideoId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<HotPotInventory>()
                .HasIndex(hi => hi.SeriesNumber)
                .IsUnique();

            modelBuilder.Entity<ChatSession>(entity =>
            {
                // Primary key
                entity.HasKey(e => e.ChatSessionId);

                // Relationship with Customer (required)
                entity.HasOne(e => e.Customer)
                    .WithMany() // Assuming Customer doesn't have a navigation property back to ChatSession
                    .HasForeignKey(e => e.CustomerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                // Relationship with Manager (optional)
                entity.HasOne(e => e.Manager)
                    .WithMany() // Assuming Manager doesn't have a navigation property back to ChatSession
                    .HasForeignKey(e => e.ManagerId)
                    .IsRequired(false) // Optional relationship
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                // Configure properties
                entity.Property(e => e.Topic)
                    .HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired();
            });

            // Configure ChatMessage entity
            modelBuilder.Entity<ChatMessage>(entity =>
            {
                // Primary key
                entity.HasKey(e => e.ChatMessageId);

                // Relationship with User as Sender
                entity.HasOne(e => e.SenderUser)
                    .WithMany() // Assuming User doesn't have a navigation property back to sent messages
                    .HasForeignKey(e => e.SenderUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                // Relationship with User as Receiver
                entity.HasOne(e => e.ReceiverUser)
                    .WithMany() // Assuming User doesn't have a navigation property back to received messages
                    .HasForeignKey(e => e.ReceiverUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                // Configure properties
                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.IsRead)
                    .IsRequired();
            });

            if (modelBuilder.Model.FindEntityType(typeof(ChatMessage))
                .FindProperty("SessionId") != null)
            {
                modelBuilder.Entity<ChatSession>()
                    .HasMany(e => e.Messages)
                    .WithOne() // Assuming ChatMessage doesn't have a navigation property back to ChatSession
                    .HasForeignKey("SessionId")
                    .IsRequired(false) // Optional relationship
                    .OnDelete(DeleteBehavior.Cascade); // Messages are deleted when session is deleted
            }

            // Seed Data
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Admin" },
                new Role { RoleId = 2, Name = "Manager" },
                new Role { RoleId = 3, Name = "Staff" },
                new Role { RoleId = 4, Name = "Customer" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, PhoneNumber = "987654321", Name = "Admin", Email = "Admin@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 1 },
                new User { UserId = 2, PhoneNumber = "999999999", Name = "Manager1", Email = "Manager1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 2 },
                new User { UserId = 3, PhoneNumber = "888888888", Name = "Manager2", Email = "Manager2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 2 },
                new User { UserId = 4, PhoneNumber = "777777777", Name = "Staff1", Email = "Staff1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                new User { UserId = 5, PhoneNumber = "666666666", Name = "Staff2", Email = "Staff2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                new User { UserId = 6, PhoneNumber = "555555555", Name = "Staff3", Email = "Staff3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                new User { UserId = 7, PhoneNumber = "444444444", Name = "Staff4", Email = "Staff4@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                new User { UserId = 8, PhoneNumber = "333333333", Name = "Customer1", Email = "Customer1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                new User { UserId = 9, PhoneNumber = "222222222", Name = "Customer2", Email = "Customer2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                new User { UserId = 10, PhoneNumber = "111111111", Name = "Customer3", Email = "Customer3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4, LoyatyPoint = 200 }
            );

            //modelBuilder.Entity<Staff>().HasData(
            //    new Staff { StaffId = 1, UserId = 4 },
            //    new Staff { StaffId = 2, UserId = 5 },
            //    new Staff { StaffId = 3, UserId = 6 },
            //    new Staff { StaffId = 4, UserId = 7 }
            //);

            //modelBuilder.Entity<Manager>().HasData(
            //    new Manager { ManagerId = 1, UserId = 2 },
            //    new Manager { ManagerId = 2, UserId = 3 }
            //);

            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer { CustomerId = 1, UserId = 8 },
            //    new Customer { CustomerId = 2, UserId = 9 },
            //    new Customer { CustomerId = 3, UserId = 10, LoyatyPoint = 200 }
            //);


            modelBuilder.Entity<UtensilType>().HasData(
                new UtensilType { UtensilTypeId = 1, Name = "Chopsticks", CreatedAt = DateTime.Now, IsDelete = false },
                new UtensilType { UtensilTypeId = 2, Name = "Ladles", CreatedAt = DateTime.Now, IsDelete = false },
                new UtensilType { UtensilTypeId = 3, Name = "Strainers", CreatedAt = DateTime.Now, IsDelete = false },
                new UtensilType { UtensilTypeId = 4, Name = "Bowls", CreatedAt = DateTime.Now, IsDelete = false },
                new UtensilType { UtensilTypeId = 5, Name = "Plates", CreatedAt = DateTime.Now, IsDelete = false }
            );

            // Seed TurtorialVideos
            modelBuilder.Entity<TurtorialVideo>().HasData(
                new TurtorialVideo
                {
                    TurtorialVideoId = 1,
                    Name = "How to Use Traditional Hotpot",
                    Description = "A comprehensive guide to setting up and using a traditional hotpot.",
                    VideoURL = "https://www.youtube.com/watch?v=traditional-hotpot-guide",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new TurtorialVideo
                {
                    TurtorialVideoId = 2,
                    Name = "Electric Hotpot Setup Guide",
                    Description = "Learn how to safely set up and use your electric hotpot.",
                    VideoURL = "https://www.youtube.com/watch?v=electric-hotpot-setup",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new TurtorialVideo
                {
                    TurtorialVideoId = 3,
                    Name = "Portable Hotpot on the Go",
                    Description = "Tips and tricks for using your portable hotpot anywhere.",
                    VideoURL = "https://www.youtube.com/watch?v=portable-hotpot-guide",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new TurtorialVideo
                {
                    TurtorialVideoId = 4,
                    Name = "Multi-compartment Hotpot Mastery",
                    Description = "How to effectively use all compartments in your multi-section hotpot.",
                    VideoURL = "https://www.youtube.com/watch?v=multi-compartment-guide",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new TurtorialVideo
                {
                    TurtorialVideoId = 5,
                    Name = "Ceramic Hotpot Care Guide",
                    Description = "Learn how to properly care for and maintain your ceramic hotpot.",
                    VideoURL = "https://www.youtube.com/watch?v=ceramic-hotpot-care",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            // Seed Hotpots
            modelBuilder.Entity<Hotpot>().HasData(
                new Hotpot
                {
                    HotpotId = 1,
                    Name = "Classic Copper Hotpot",
                    Material = "Copper",
                    Size = "m",
                    Description = "Traditional copper hotpot with charcoal heating.",
                    ImageURL = "https://example.com/images/classic-copper-hotpot.jpg",
                    Price = 29.99m,
                    BasePrice = 89.99m,
                    Status = true,
                    Quantity = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 2,
                    Name = "Modern Electric Hotpot",
                    Material = "Stainless Steel",
                    Size = "L",
                    Description = "Electric hotpot with temperature control and non-stick coating.",
                    ImageURL = "https://example.com/images/modern-electric-hotpot.jpg",
                    Price = 59.99m,
                    BasePrice = 129.99m,
                    Status = true,
                    Quantity = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 3,
                    Name = "Mini Portable Hotpot",
                    Material = "Aluminum",
                    Size = "S",
                    Description = "Compact portable hotpot perfect for travel or small gatherings.",
                    ImageURL = "https://example.com/images/mini-portable-hotpot.jpg",
                    Price = 19.99m,
                    BasePrice = 69.99m,
                    Status = true,
                    Quantity = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 4,
                    Name = "Dual Section Hotpot",
                    Material = "Stainless Steel",
                    Size = "L",
                    Description = "Multi-compartment hotpot for different broths in one pot.",
                    ImageURL = "https://example.com/images/dual-section-hotpot.jpg",
                    Price = 69.99m,
                    BasePrice = 149.99m,
                    Status = true,
                    Quantity = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 5,
                    Name = "Traditional Ceramic Hotpot",
                    Material = "Ceramic",
                    Size = "M",
                    Description = "Authentic ceramic hotpot that retains heat exceptionally well.",
                    ImageURL = "https://example.com/images/traditional-ceramic-hotpot.jpg",
                    Price = 39.99m,
                    BasePrice = 79.99m,
                    Status = true,
                    Quantity = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            // Seed HotPotInventory
            modelBuilder.Entity<HotPotInventory>().HasData(
                new HotPotInventory
                {
                    HotPotInventoryId = 1,
                    SeriesNumber = "CP-2023-0001",
                    HotpotId = 1,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 2,
                    SeriesNumber = "CP-2023-0002",
                    Status = true,
                    HotpotId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 3,
                    SeriesNumber = "EL-2023-0001",
                    HotpotId = 2,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 4,
                    SeriesNumber = "EL-2023-0002",
                    HotpotId = 2,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 5,
                    SeriesNumber = "PT-2023-0001",
                    HotpotId = 3,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 6,
                    SeriesNumber = "MC-2023-0001",
                    HotpotId = 4,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 7,
                    SeriesNumber = "CR-2023-0001",
                    HotpotId = 5,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                new HotPotInventory
                {
                    HotPotInventoryId = 8,
                    SeriesNumber = "CP-2023-0003",
                    HotpotId = 1,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 9,
                    SeriesNumber = "CP-2023-0004",
                    HotpotId = 1,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 10,
                    SeriesNumber = "CP-2023-0005",
                    HotpotId = 1,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 11,
                    SeriesNumber = "PT-2023-0002",
                    HotpotId = 3,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 12,
                    SeriesNumber = "MC-2023-0002",
                    HotpotId = 4,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 13,
                    SeriesNumber = "CR-2023-0002",
                    HotpotId = 5,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 14,
                    SeriesNumber = "CR-2023-0003",
                    HotpotId = 5,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 15,
                    SeriesNumber = "CR-2023-0004",
                    HotpotId = 5,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }



            );

            // Seed Utensils
            modelBuilder.Entity<Utensil>().HasData(
                new Utensil
                {
                    UtensilId = 1,
                    Name = "Bamboo Chopsticks Set",
                    Material = "Bamboo",
                    Description = "Set of 5 pairs of traditional bamboo chopsticks.",
                    ImageURL = "https://example.com/images/bamboo-chopsticks.jpg",
                    Price = 12.99m,
                    Status = true,
                    Quantity = 100,
                    UtensilTypeId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Utensil
                {
                    UtensilId = 2,
                    Name = "Stainless Steel Hotpot Ladle",
                    Material = "Stainless Steel",
                    Description = "Durable stainless steel ladle for serving hotpot broth.",
                    ImageURL = "https://example.com/images/steel-ladle.jpg",
                    Price = 9.99m,
                    Status = true,
                    Quantity = 75,
                    UtensilTypeId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Utensil
                {
                    UtensilId = 3,
                    Name = "Wire Mesh Strainer",
                    Material = "Stainless Steel",
                    Description = "Fine mesh strainer for retrieving food from the hotpot.",
                    ImageURL = "https://example.com/images/mesh-strainer.jpg",
                    Price = 7.99m,
                    Status = true,
                    Quantity = 80,
                    UtensilTypeId = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Utensil
                {
                    UtensilId = 4,
                    Name = "Ceramic Serving Bowl Set",
                    Material = "Ceramic",
                    Description = "Set of 4 ceramic bowls for individual servings.",
                    ImageURL = "https://example.com/images/ceramic-bowls.jpg",
                    Price = 19.99m,
                    Status = true,
                    Quantity = 50,
                    UtensilTypeId = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Utensil
                {
                    UtensilId = 5,
                    Name = "Melamine Plates",
                    Material = "Melamine",
                    Description = "Set of 6 durable melamine plates for hotpot dining.",
                    ImageURL = "https://example.com/images/melamine-plates.jpg",
                    Price = 24.99m,
                    Status = true,
                    Quantity = 60,
                    UtensilTypeId = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            modelBuilder.Entity<IngredientType>().HasData(
                new IngredientType
                {
                    IngredientTypeId = 1,
                    Name = "Broth",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 2,
                    Name = "Seafood",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 3,
                    Name = "Vegetables",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 4,
                    Name = "Noodles",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 5,
                    Name = "Tofu",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 6,
                    Name = "Mushrooms",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 7,
                    Name = "Meats",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientType
                {
                    IngredientTypeId = 8,
                    Name = "Sauces",
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            // Seed Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                // Meats - using grams (g)
                new Ingredient
                {
                    IngredientId = 1,
                    Name = "Sliced Beef",
                    Description = "Thinly sliced premium beef perfect for hotpot.",
                    ImageURL = "https://example.com/images/sliced-beef.jpg",
                    MinStockLevel = 20,
                    Quantity = 100,
                    IngredientTypeId = 7,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 2,
                    Name = "Lamb Slices",
                    Description = "Tender sliced lamb meat, perfect for quick cooking.",
                    ImageURL = "https://example.com/images/lamb-slices.jpg",
                    MinStockLevel = 15,
                    Quantity = 80,
                    IngredientTypeId = 7,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 3,
                    Name = "Pork Belly",
                    Description = "Thinly sliced pork belly with perfect fat-to-meat ratio.",
                    ImageURL = "https://example.com/images/pork-belly.jpg",
                    MinStockLevel = 15,
                    Quantity = 75,
                    IngredientTypeId = 7,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Seafood - using grams (g)
                new Ingredient
                {
                    IngredientId = 4,
                    Name = "Shrimp",
                    Description = "Fresh, peeled and deveined shrimp.",
                    ImageURL = "https://example.com/images/shrimp.jpg",
                    MinStockLevel = 20,
                    Quantity = 90,
                    IngredientTypeId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 5,
                    Name = "Fish Balls",
                    Description = "Bouncy fish balls made from fresh fish paste.",
                    ImageURL = "https://example.com/images/fish-balls.jpg",
                    MinStockLevel = 30,
                    Quantity = 120,
                    IngredientTypeId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 6,
                    Name = "Squid",
                    Description = "Fresh squid sliced into rings.",
                    ImageURL = "https://example.com/images/squid.jpg",
                    MinStockLevel = 15,
                    Quantity = 60,
                    IngredientTypeId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Vegetables - using grams (g)
                new Ingredient
                {
                    IngredientId = 7,
                    Name = "Napa Cabbage",
                    Description = "Crisp, leafy vegetable perfect for hotpot.",
                    ImageURL = "https://example.com/images/napa-cabbage.jpg",
                    MinStockLevel = 25,
                    Quantity = 100,
                    IngredientTypeId = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 8,
                    Name = "Spinach",
                    Description = "Fresh spinach leaves, washed and ready to cook.",
                    ImageURL = "https://example.com/images/spinach.jpg",
                    MinStockLevel = 20,
                    Quantity = 80,
                    IngredientTypeId = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 9,
                    Name = "Corn",
                    Description = "Sweet corn cut into bite-sized pieces.",
                    ImageURL = "https://example.com/images/corn.jpg",
                    MinStockLevel = 15,
                    Quantity = 70,
                    IngredientTypeId = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Noodles - using grams (g)
                new Ingredient
                {
                    IngredientId = 10,
                    Name = "Udon Noodles",
                    Description = "Thick, chewy Japanese wheat noodles.",
                    ImageURL = "https://example.com/images/udon-noodles.jpg",
                    MinStockLevel = 20,
                    Quantity = 80,
                    IngredientTypeId = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 11,
                    Name = "Glass Noodles",
                    Description = "Transparent noodles made from mung bean starch.",
                    ImageURL = "https://example.com/images/glass-noodles.jpg",
                    MinStockLevel = 20,
                    Quantity = 85,
                    IngredientTypeId = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 12,
                    Name = "Ramen Noodles",
                    Description = "Curly wheat noodles perfect for hotpot.",
                    ImageURL = "https://example.com/images/ramen-noodles.jpg",
                    MinStockLevel = 25,
                    Quantity = 90,
                    IngredientTypeId = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Tofu - using grams (g)
                new Ingredient
                {
                    IngredientId = 13,
                    Name = "Firm Tofu",
                    Description = "Firm tofu cubes that hold their shape in hotpot.",
                    ImageURL = "https://example.com/images/firm-tofu.jpg",
                    MinStockLevel = 15,
                    Quantity = 60,
                    IngredientTypeId = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 14,
                    Name = "Tofu Puffs",
                    Description = "Deep-fried tofu puffs that absorb broth flavors.",
                    ImageURL = "https://example.com/images/tofu-puffs.jpg",
                    MinStockLevel = 15,
                    Quantity = 65,
                    IngredientTypeId = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Mushrooms - using grams (g)
                new Ingredient
                {
                    IngredientId = 15,
                    Name = "Shiitake Mushrooms",
                    Description = "Flavorful shiitake mushrooms, fresh or dried.",
                    ImageURL = "https://example.com/images/shiitake.jpg",
                    MinStockLevel = 15,
                    Quantity = 70,
                    IngredientTypeId = 6,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 16,
                    Name = "Enoki Mushrooms",
                    Description = "Delicate, long-stemmed enoki mushrooms.",
                    ImageURL = "https://example.com/images/enoki.jpg",
                    MinStockLevel = 15,
                    Quantity = 65,
                    IngredientTypeId = 6,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Broths - using milliliters (ml)
                new Ingredient
                {
                    IngredientId = 17,
                    Name = "Spicy Sichuan Broth",
                    Description = "Traditional spicy broth with Sichuan peppercorns and chili oil.",
                    ImageURL = "https://example.com/images/sichuan-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 50,
                    IngredientTypeId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 18,
                    Name = "Tomato Broth",
                    Description = "Tangy tomato-based broth, slightly sweet and sour.",
                    ImageURL = "https://example.com/images/tomato-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 45,
                    IngredientTypeId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 19,
                    Name = "Mushroom Broth",
                    Description = "Rich umami broth made from various mushrooms.",
                    ImageURL = "https://example.com/images/mushroom-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 40,
                    IngredientTypeId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 20,
                    Name = "Clear Bone Broth",
                    Description = "Light, clear broth made from simmering bones for hours.",
                    ImageURL = "https://example.com/images/bone-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 55,
                    IngredientTypeId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Sauces - using milliliters (ml)
                new Ingredient
                {
                    IngredientId = 21,
                    Name = "Sesame Sauce",
                    Description = "Creamy sauce made from ground sesame seeds.",
                    ImageURL = "https://example.com/images/sesame-sauce.jpg",
                    MinStockLevel = 10,
                    Quantity = 40,
                    IngredientTypeId = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 22,
                    Name = "Garlic Soy Sauce",
                    Description = "Soy sauce infused with fresh minced garlic.",
                    ImageURL = "https://example.com/images/garlic-soy.jpg",
                    MinStockLevel = 10,
                    Quantity = 45,
                    IngredientTypeId = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 23,
                    Name = "Chili Oil",
                    Description = "Spicy oil made from infusing oil with chili peppers.",
                    ImageURL = "https://example.com/images/chili-oil.jpg",
                    MinStockLevel = 10,
                    Quantity = 50,
                    IngredientTypeId = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Ingredient
                {
                    IngredientId = 24,
                    Name = "Shacha Sauce",
                    Description = "Umami-rich sauce made from soybean oil, garlic, shallots, and dried seafood.",
                    ImageURL = "https://example.com/images/shacha-sauce.jpg",
                    MinStockLevel = 10,
                    Quantity = 35,
                    IngredientTypeId = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            modelBuilder.Entity<IngredientPrice>().HasData(
                new IngredientPrice
                {
                    IngredientPriceId = 1,
                    Price = 0.13m, // $13 per kg = $0.13 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-30),
                    IngredientId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 2,
                    Price = 0.14m, // $14 per kg = $0.14 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 3,
                    Price = 0.15m, // $15 per kg = $0.15 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-30),
                    IngredientId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 4,
                    Price = 0.16m, // $16 per kg = $0.16 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 5,
                    Price = 0.12m, // $12 per kg = $0.12 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Seafood prices (per gram)
                new IngredientPrice
                {
                    IngredientPriceId = 6,
                    Price = 0.17m, // $17 per kg = $0.17 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 7,
                    Price = 0.10m, // $10 per kg = $0.10 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 8,
                    Price = 0.15m, // $15 per kg = $0.15 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 6,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Vegetable prices (per gram)
                new IngredientPrice
                {
                    IngredientPriceId = 9,
                    Price = 0.06m, // $6 per kg = $0.06 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 7,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 10,
                    Price = 0.05m, // $5 per kg = $0.05 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 11,
                    Price = 0.04m, // $4 per kg = $0.04 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 9,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Noodle prices (per gram)
                new IngredientPrice
                {
                    IngredientPriceId = 12,
                    Price = 0.07m, // $7 per kg = $0.07 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 10,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 13,
                    Price = 0.06m, // $6 per kg = $0.06 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 11,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 14,
                    Price = 0.065m, // $6.50 per kg = $0.065 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 12,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Tofu prices (per gram)
                new IngredientPrice
                {
                    IngredientPriceId = 15,
                    Price = 0.05m, // $5 per kg = $0.05 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 13,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 16,
                    Price = 0.055m, // $5.50 per kg = $0.055 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 14,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Mushroom prices (per gram)
                new IngredientPrice
                {
                    IngredientPriceId = 17,
                    Price = 0.08m, // $8 per kg = $0.08 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 15,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 18,
                    Price = 0.07m, // $7 per kg = $0.07 per g
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 16,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Broth prices (per milliliter)
                new IngredientPrice
                {
                    IngredientPriceId = 19,
                    Price = 0.009m, // $9 per liter = $0.009 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 17,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 20,
                    Price = 0.008m, // $8 per liter = $0.008 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 18,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 21,
                    Price = 0.0085m, // $8.50 per liter = $0.0085 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 19,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 22,
                    Price = 0.0075m, // $7.50 per liter = $0.0075 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 20,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Sauce prices (per milliliter)
                new IngredientPrice
                {
                    IngredientPriceId = 23,
                    Price = 0.005m, // $5 per liter = $0.005 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 21,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 24,
                    Price = 0.004m, // $4 per liter = $0.004 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 22,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 25,
                    Price = 0.0045m, // $4.50 per liter = $0.0045 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 23,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 26,
                    Price = 0.006m, // $6 per liter = $0.006 per ml
                    EffectiveDate = DateTime.UtcNow.AddHours(7).AddDays(-3),
                    IngredientId = 24,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );
        }
    }
}
