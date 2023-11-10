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
    }
}