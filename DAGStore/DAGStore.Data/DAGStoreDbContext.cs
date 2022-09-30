using DAGStore.Model.Models;
using System.Data.Entity;

namespace DAGStore.Data
{
    public class DAGStoreDbContext : DbContext
    {
        /// <summary>
        /// Using packet manager console
        /// enable-migrations: create config migrations
        /// add-migrations: add changes database
        /// update-database: render code to sql and run
        /// </summary>

        public DAGStoreDbContext() : base("Data Source=LAPTOP-3KE0ADA0;Initial Catalog=DAGStore;Integrated Security=True")
        {
        }

        public DbSet<MenuRecord> MenuRecord { get; set; }
        public DbSet<MenuItemRecord> MenuItemRecord { get; set; }
      

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
        
        }
    }
}