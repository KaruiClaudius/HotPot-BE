using Capstone.HPTY.ModelLayer;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
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
        public virtual DbSet<DamageDevice> DamageDevices { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientType> IngredientTypes { get; set; }
        public virtual DbSet<IngredientPrice> IngredientPrices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatSession> ChatSessions { get; set; }
        public virtual DbSet<ReplacementRequest> ReplacementRequests { get; set; }
        public virtual DbSet<ComboAllowedIngredientType> ComboAllowedIngredientTypes { get; set; }
        public virtual DbSet<SizeDiscount> SizeDiscounts { get; set; }
        public virtual DbSet<StaffPickupAssignment> StaffPickupAssignments { get; set; }
        public virtual DbSet<PaymentReceipt> PaymentReceipts { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

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

            //return configuration.GetConnectionString("Local");
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

            modelBuilder.Entity<User>()
                .HasMany(u => u.StaffWorkShifts)
                .WithMany(w => w.Staff)
                .UsingEntity(j => j.ToTable("UserStaffWorkShifts"));

            // Configure Manager-WorkShift relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.MangerWorkShifts)
                .WithMany(w => w.Managers)
                .UsingEntity(j => j.ToTable("UserManagerWorkShifts"));

            modelBuilder.Entity<PaymentReceipt>()
               .HasOne(r => r.Payment)
               .WithOne(p => p.Receipt)
               .HasForeignKey<PaymentReceipt>(r => r.PaymentId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PaymentReceipt>()
                .HasOne(r => r.Order)
                .WithMany(o => o.Receipts)
                .HasForeignKey(r => r.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StaffPickupAssignment>()

                .HasOne(a => a.RentOrder)
                .WithMany()
                .HasForeignKey(a => a.OrderId)
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
                    .WithMany(o => o.Payments)  
                    .HasForeignKey(p => p.OrderId)
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

                entity.HasOne(c => c.Combo)
                    .WithMany(c => c.Customizations)
                    .HasForeignKey(c => c.ComboId)
                    .OnDelete(DeleteBehavior.SetNull);
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
                entity.HasKey(e => e.DamageDeviceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);


                entity.Property(e => e.Status)
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
            DataSeeder.SeedData(modelBuilder);
        }
    }
}
