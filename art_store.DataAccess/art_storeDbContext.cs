using art_store.DataAccess.Configuration;
using art_store.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace art_store.DataAccess
{
    public class art_storeDbContext : IdentityDbContext<User, IdentityRole<int>, int>
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

            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserToken");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Role");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRole");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtConfiguration).Assembly);
        }
    }


}