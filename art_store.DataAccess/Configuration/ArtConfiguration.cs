using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using art_store.Entities;

namespace art_store.DataAccess.Configuration
{

    public class ArtConfiguration : IEntityTypeConfiguration<Art>
    {
        public void Configure(EntityTypeBuilder<Art> builder)
        {
            builder.ToTable("Arts", "dbo").HasKey(x => x.Id);
            builder.HasOne( _ => _.Order).WithMany(_ => _.Arts).HasForeignKey(_ => _.OrderId);
        }
    }


}
