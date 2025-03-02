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
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Customization> Customizations { get; set; }
        public virtual DbSet<CustomizationIngredient> CustomizationIngredients { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<ComboIngredient> ComboIngredients { get; set; }
        public virtual DbSet<Utensil> Utensils { get; set; }
        public virtual DbSet<UtensilType> UtensilTypes { get; set; }
        public virtual DbSet<Hotpot> Hotpots { get; set; }
        public virtual DbSet<HotPotInventory> HotPotInventorys { get; set; }
        public virtual DbSet<HotpotType> HotpotTypes { get; set; }
        public virtual DbSet<TurtorialVideo> TurtorialVideos { get; set; }
        public virtual DbSet<ConditionLog> ConditionLogs { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientType> IngredientTypes { get; set; }
        public virtual DbSet<IngredientPrice> IngredientPrices { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatSession> ChatSessions { get; set; }
        public virtual DbSet<ReplacementRequest> ReplacementRequests { get; set; }
        public virtual DbSet<ComboAllowedIngredientType> ComboAllowedIngredientTypes { get; set; }
        public virtual DbSet<SizeDiscount> SizeDiscounts { get; set; }

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

            return configuration.GetConnectionString("DefaultConnection");
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
                    .HasForeignKey(u => u.RoleID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Customer)
                    .WithOne(c => c.User)
                    .HasForeignKey<Customer>(c => c.UserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Staff)
                    .WithOne(s => s.User)
                    .HasForeignKey<Staff>(s => s.UserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Manager)
                    .WithOne(m => m.User)
                    .HasForeignKey<Manager>(m => m.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.LoyatyPoint)
                    .HasDefaultValue(0);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(d => d.Percent)
                    .HasDefaultValue(0);

                entity.Property(d => d.PointCost)
                    .HasDefaultValue(0);

                entity.HasOne(d => d.Order)
                    .WithOne(o => o.Discount)
                    .HasForeignKey<Order>(o => o.DiscountID)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(p => p.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(p => p.Order)
                    .WithOne(o => o.Payment)
                    .HasForeignKey<Order>(o => o.PaymentID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ShippingOrder>(entity =>
            {
                entity.HasOne(so => so.Order)
                    .WithOne(o => o.ShippingOrder)
                    .HasForeignKey<ShippingOrder>(so => so.OrderID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(so => so.Staff)
                    .WithMany(s => s.ShippingOrders)
                    .HasForeignKey(so => so.StaffID)
                    .OnDelete(DeleteBehavior.Restrict);
            });



            modelBuilder.Entity<WorkShift>()
                .Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>();

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<OrderDetail>(entity =>
            //{
            //    entity.HasKey(e => e.OrderDetailId);

            //    // Order relationship
            //    entity.HasOne(od => od.Order)
            //        .WithMany(o => o.OrderDetails)
            //        .HasForeignKey(od => od.OrderID)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    // Create indexes
            //    entity.HasIndex(e => e.OrderID);
            //    entity.HasIndex(e => new { e.ItemType, e.ItemID });
            //});


            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Order)
                .WithOne(o => o.Feedback)
                .HasForeignKey<Feedback>(f => f.OrderID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Customization>()
                .Property(c => c.BasePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Combo>()
                .Property(c => c.BasePrice )
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ComboIngredient>(entity =>
            {
                entity.HasKey(e => e.ComboIngredientId);

                // Many-to-Many: Combo <-> Ingredient
                entity.HasOne(ci => ci.Combo)
                    .WithMany(c => c.ComboIngredients)
                    .HasForeignKey(ci => ci.ComboID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.Ingredient)
                    .WithMany(i => i.ComboIngredients)
                    .HasForeignKey(ci => ci.IngredientID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(ci => new { ci.ComboID, ci.IngredientID });
            });

            modelBuilder.Entity<CustomizationIngredient>(entity =>
            {
                entity.HasKey(e => e.CustomizationIngredientId);

                // Many-to-Many: Customization <-> Ingredient
                entity.HasOne(ci => ci.Customization)
                    .WithMany(c => c.CustomizationIngredients)
                    .HasForeignKey(ci => ci.CustomizationID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.Ingredient)
                    .WithMany(i => i.CustomizationIngredients)
                    .HasForeignKey(ci => ci.IngredientID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(ci => new { ci.CustomizationID, ci.IngredientID });
            });

            // Combo Configuration
            modelBuilder.Entity<Combo>(entity =>
            {
                entity.ToTable("Combos");

                entity.Property(e => e.HotpotBrothID)
                    .HasColumnName("HotpotBrothID");

                entity.HasOne(e => e.HotpotBroth)
                    .WithMany()
                    .HasForeignKey(e => e.HotpotBrothID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Customization Configuration
            modelBuilder.Entity<Customization>(entity =>
            {
                entity.ToTable("Customizations");

                entity.Property(e => e.HotpotBrothID)
                    .HasColumnName("HotpotBrothID");

                entity.HasOne(e => e.HotpotBroth)
                    .WithMany()
                    .HasForeignKey(e => e.HotpotBrothID)
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
                .HasForeignKey(u => u.UtensilTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hotpot>()
                .HasOne(h => h.HotpotType)
                .WithMany(ht => ht.Hotpot)
                .HasForeignKey(h => h.HotpotTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IngredientPrice>()
                .Property(ip => ip.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.IngredientType)
                .WithMany(it => it.Ingredients)
                .HasForeignKey(i => i.IngredientTypeID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ConditionLog>(entity =>
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

                modelBuilder.Entity<ConditionLog>()
                     .HasOne(c => c.Utensil)
                     .WithMany(u => u.ConditionLogs)
                     .HasForeignKey(c => c.UtensilID);
            });

            modelBuilder.Entity<TurtorialVideo>()
                .HasMany(tv => tv.Hotpot)
                .WithOne(h => h.TurtorialVideo)
                .HasForeignKey(h => h.TurtorialVideoID)
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
                new User { UserId = -1, Name = "Admin", Email = "Admin@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 1 },
                new User { UserId = -2, Name = "Manager1", Email = "Manager1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 2 },
                new User { UserId = -3, Name = "Manager2", Email = "Manager2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 2 },
                new User { UserId = -4, Name = "Staff1", Email = "Staff1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 3 },
                new User { UserId = -5, Name = "Staff2", Email = "Staff2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 3 },
                new User { UserId = -6, Name = "Staff3", Email = "Staff3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 3 },
                new User { UserId = -7, Name = "Staff4", Email = "Staff4@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 3 },
                new User { UserId = -8, Name = "Customer1", Email = "Customer1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 4 },
                new User { UserId = -9, Name = "Customer2", Email = "Customer2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 4 },
                new User { UserId = -10, Name = "Customer3", Email = "Customer3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleID = 4 }
            );

            modelBuilder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, UserID = -4 },
                new Staff { StaffId = 2, UserID = -5 },
                new Staff { StaffId = 3, UserID = -6 },
                new Staff { StaffId = 4, UserID = -7 }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager { ManagerId = 1, UserID = -2 },
                new Manager { ManagerId = 2, UserID = -3 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, UserID = -8 },
                new Customer { CustomerId = 2, UserID = -9 },
                new Customer { CustomerId = 3, UserID = -10, LoyatyPoint = 200 }
            );

            modelBuilder.Entity<HotpotType>().HasData(
                new HotpotType { HotpotTypeId = 1, Name = "Traditional" },
                new HotpotType { HotpotTypeId = 2, Name = "Electric" },
                new HotpotType { HotpotTypeId = 3, Name = "Portable" },
                new HotpotType { HotpotTypeId = 4, Name = "Multi-compartment" },
                new HotpotType { HotpotTypeId = 5, Name = "Ceramic" }
            );
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
                    Size = 4,
                    Description = "Traditional copper hotpot with charcoal heating.",
                    ImageURL = "https://example.com/images/classic-copper-hotpot.jpg",
                    Price = 89.99m,
                    Status = true,
                    Quantity = 25,
                    HotpotTypeID = 1,
                    TurtorialVideoID = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 2,
                    Name = "Modern Electric Hotpot",
                    Material = "Stainless Steel",
                    Size = 6,
                    Description = "Electric hotpot with temperature control and non-stick coating.",
                    ImageURL = "https://example.com/images/modern-electric-hotpot.jpg",
                    Price = 129.99m,
                    Status = true,
                    Quantity = 30,
                    HotpotTypeID = 2,
                    TurtorialVideoID = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 3,
                    Name = "Mini Portable Hotpot",
                    Material = "Aluminum",
                    Size = 2,
                    Description = "Compact portable hotpot perfect for travel or small gatherings.",
                    ImageURL = "https://example.com/images/mini-portable-hotpot.jpg",
                    Price = 59.99m,
                    Status = true,
                    Quantity = 40,
                    HotpotTypeID = 3,
                    TurtorialVideoID = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 4,
                    Name = "Dual Section Hotpot",
                    Material = "Stainless Steel",
                    Size = 6,
                    Description = "Multi-compartment hotpot for different broths in one pot.",
                    ImageURL = "https://example.com/images/dual-section-hotpot.jpg",
                    Price = 149.99m,
                    Status = true,
                    Quantity = 20,
                    HotpotTypeID = 4,
                    TurtorialVideoID = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new Hotpot
                {
                    HotpotId = 5,
                    Name = "Traditional Ceramic Hotpot",
                    Material = "Ceramic",
                    Size = 4,
                    Description = "Authentic ceramic hotpot that retains heat exceptionally well.",
                    ImageURL = "https://example.com/images/traditional-ceramic-hotpot.jpg",
                    Price = 79.99m,
                    Status = true,
                    Quantity = 15,
                    HotpotTypeID = 5,
                    TurtorialVideoID = 5,
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
                    UtensilTypeID = 1,
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
                    UtensilTypeID = 2,
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
                    UtensilTypeID = 3,
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
                    UtensilTypeID = 4,
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
                    UtensilTypeID = 5,
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
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 2,
                    SeriesNumber = "CP-2023-0002",
                    HotpotId = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 3,
                    SeriesNumber = "EL-2023-0001",
                    HotpotId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 4,
                    SeriesNumber = "EL-2023-0002",
                    HotpotId = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 5,
                    SeriesNumber = "PT-2023-0001",
                    HotpotId = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 6,
                    SeriesNumber = "MC-2023-0001",
                    HotpotId = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new HotPotInventory
                {
                    HotPotInventoryId = 7,
                    SeriesNumber = "CR-2023-0001",
                    HotpotId = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            // Seed IngredientTypes
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
                // Meats
                new Ingredient
                {
                    IngredientId = 1,
                    Name = "Sliced Beef",
                    Description = "Thinly sliced premium beef perfect for hotpot.",
                    ImageURL = "https://example.com/images/sliced-beef.jpg",
                    MinStockLevel = 20,
                    Quantity = 100,
                    IngredientTypeID = 1,
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
                    IngredientTypeID = 1,
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
                    IngredientTypeID = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Seafood
                new Ingredient
                {
                    IngredientId = 4,
                    Name = "Shrimp",
                    Description = "Fresh, peeled and deveined shrimp.",
                    ImageURL = "https://example.com/images/shrimp.jpg",
                    MinStockLevel = 20,
                    Quantity = 90,
                    IngredientTypeID = 2,
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
                    IngredientTypeID = 2,
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
                    IngredientTypeID = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Vegetables
                new Ingredient
                {
                    IngredientId = 7,
                    Name = "Napa Cabbage",
                    Description = "Crisp, leafy vegetable perfect for hotpot.",
                    ImageURL = "https://example.com/images/napa-cabbage.jpg",
                    MinStockLevel = 25,
                    Quantity = 100,
                    IngredientTypeID = 3,
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
                    IngredientTypeID = 3,
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
                    IngredientTypeID = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Noodles
                new Ingredient
                {
                    IngredientId = 10,
                    Name = "Udon Noodles",
                    Description = "Thick, chewy Japanese wheat noodles.",
                    ImageURL = "https://example.com/images/udon-noodles.jpg",
                    MinStockLevel = 20,
                    Quantity = 80,
                    IngredientTypeID = 4,
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
                    IngredientTypeID = 4,
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
                    IngredientTypeID = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Tofu
                new Ingredient
                {
                    IngredientId = 13,
                    Name = "Firm Tofu",
                    Description = "Firm tofu cubes that hold their shape in hotpot.",
                    ImageURL = "https://example.com/images/firm-tofu.jpg",
                    MinStockLevel = 15,
                    Quantity = 60,
                    IngredientTypeID = 5,
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
                    IngredientTypeID = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Mushrooms
                new Ingredient
                {
                    IngredientId = 15,
                    Name = "Shiitake Mushrooms",
                    Description = "Flavorful shiitake mushrooms, fresh or dried.",
                    ImageURL = "https://example.com/images/shiitake.jpg",
                    MinStockLevel = 15,
                    Quantity = 70,
                    IngredientTypeID = 6,
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
                    IngredientTypeID = 6,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Broths
                new Ingredient
                {
                    IngredientId = 17,
                    Name = "Spicy Sichuan Broth",
                    Description = "Traditional spicy broth with Sichuan peppercorns and chili oil.",
                    ImageURL = "https://example.com/images/sichuan-broth.jpg",
                    MinStockLevel = 10,
                    Quantity = 50,
                    IngredientTypeID = 7,
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
                    IngredientTypeID = 7,
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
                    IngredientTypeID = 7,
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
                    IngredientTypeID = 7,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Sauces
                new Ingredient
                {
                    IngredientId = 21,
                    Name = "Sesame Sauce",
                    Description = "Creamy sauce made from ground sesame seeds.",
                    ImageURL = "https://example.com/images/sesame-sauce.jpg",
                    MinStockLevel = 10,
                    Quantity = 40,
                    IngredientTypeID = 8,
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
                    IngredientTypeID = 8,
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
                    IngredientTypeID = 8,
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
                    IngredientTypeID = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

            // Seed IngredientPrices
            modelBuilder.Entity<IngredientPrice>().HasData(
                // Meat prices
                new IngredientPrice
                {
                    IngredientPriceId = 1,
                    Price = 12.99m,
                    EffectiveDate = DateTime.Now.AddDays(-30),
                    IngredientID = 1,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 2,
                    Price = 13.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 1,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 3,
                    Price = 14.99m,
                    EffectiveDate = DateTime.Now.AddDays(-30),
                    IngredientID = 2,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 4,
                    Price = 15.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 2,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 5,
                    Price = 11.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 3,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Seafood prices
                new IngredientPrice
                {
                    IngredientPriceId = 6,
                    Price = 16.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 4,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 7,
                    Price = 9.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 5,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 8,
                    Price = 14.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 6,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Vegetable prices
                new IngredientPrice
                {
                    IngredientPriceId = 9,
                    Price = 5.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 7,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 10,
                    Price = 4.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 8,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 11,
                    Price = 3.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 9,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Noodle prices
                new IngredientPrice
                {
                    IngredientPriceId = 12,
                    Price = 6.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 10,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 13,
                    Price = 5.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 11,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 14,
                    Price = 6.49m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 12,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Tofu prices
                new IngredientPrice
                {
                    IngredientPriceId = 15,
                    Price = 4.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 13,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 16,
                    Price = 5.49m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 14,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Mushroom prices
                new IngredientPrice
                {
                    IngredientPriceId = 17,
                    Price = 7.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 15,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 18,
                    Price = 6.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 16,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Broth prices
                new IngredientPrice
                {
                    IngredientPriceId = 19,
                    Price = 8.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 17,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 20,
                    Price = 7.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 18,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 21,
                    Price = 8.49m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 19,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 22,
                    Price = 7.49m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 20,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },

                // Sauce prices
                new IngredientPrice
                {
                    IngredientPriceId = 23,
                    Price = 4.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 21,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 24,
                    Price = 3.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 22,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 25,
                    Price = 4.49m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 23,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                },
                new IngredientPrice
                {
                    IngredientPriceId = 26,
                    Price = 5.99m,
                    EffectiveDate = DateTime.Now,
                    IngredientID = 24,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                }
            );

        }
    }
}
