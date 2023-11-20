using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using art_store.Entities;

namespace art_store.DataAccess.Configuration
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Orders).WithOne(_ => _.User).HasForeignKey(_ => _.UserId);
        }
    }


}
