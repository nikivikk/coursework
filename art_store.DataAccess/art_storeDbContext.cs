using art_store.DataAccess.Configuration;
using art_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace art_store.DataAccess
{
    public class art_storeDbContext : DbContext
    {
        public art_storeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Art>  Arts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArtConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
        }
    }


}