using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using art_store.Entities;

namespace art_store.DataAccess.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Orders).WithOne(_ => _.Driver).HasForeignKey(_ => _.DriverId);
        }
    }
}
