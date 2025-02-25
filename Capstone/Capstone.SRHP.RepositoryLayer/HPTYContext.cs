using Capstone.HPTY.ModelLayer.Entities;
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
                .Property(c => c.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Combo>()
                .Property(c => c.TotalPrice)
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
            });

            modelBuilder.Entity<TurtorialVideo>()
                .HasMany(tv => tv.Hotpot)
                .WithOne(h => h.TurtorialVideo)
                .HasForeignKey(h => h.TurtorialVideoID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<HotPotInventory>()
                .HasIndex(hi => hi.SeriesNumber)
                .IsUnique();


            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Admin" },
                new Role { RoleId = 2, Name = "Manager" },
                new Role { RoleId = 3, Name = "Staff" },
                new Role { RoleId = 4, Name = "Customer" }
            );
        }


    }
}
