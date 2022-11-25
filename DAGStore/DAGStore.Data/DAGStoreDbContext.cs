using DAGStore.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace DAGStore.Data
{
    public class DAGStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Using packet manager console
        /// enable-migrations: create config migrations
        /// add-migrations: add changes database
        /// update-database: render code to sql and run
        /// </summary>

        public DAGStoreDbContext() : base("Data Source=LAPTOP-3KE0ADA0;Initial Catalog=DAGStore;Integrated Security=True;MultipleActiveResultSets=true")
        {
        }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<ProductDiscount> ProductDiscount { get; set; }
        public DbSet<ImportBill> ImportBill { get; set; }
        public DbSet<ImportBillDetail> ImportBillDetail { get; set; }
        public DbSet<MenuRecord> MenuRecord { get; set; }
        public DbSet<MenuItemRecord> MenuItemRecord { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<SliderItem> SliderItem { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Suggest> Suggest { get; set; }
        public DbSet<SuggestProduct> SuggestProduct  { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Page> Page { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public static DAGStoreDbContext Create()
        {
            return new DAGStoreDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
    }
}