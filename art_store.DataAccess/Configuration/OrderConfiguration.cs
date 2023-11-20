using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using art_store.Entities;

namespace art_store.DataAccess.Configuration
{

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Arts).WithOne(_ => _.Order).HasForeignKey(_ => _.OrderId);
            builder.HasOne(_ => _.Driver).WithMany(_ => _.Orders).HasForeignKey(_ => _.DriverId);
            builder.HasOne(_ => _.User).WithMany(_ => _.Orders).HasForeignKey(_ => _.UserId);
        }
    }


}
