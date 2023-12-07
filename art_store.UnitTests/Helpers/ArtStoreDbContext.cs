using art_store.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace art_store.UnitTests.Helpers
{
    public static class ArtStoreDbContext
    {
        public static art_storeDbContext BuildArtStoreDbContext()
        {
            var dbContext = new art_storeDbContext(
                new DbContextOptionsBuilder<art_storeDbContext>()
                    .UseInMemoryDatabase($"ArtStoreDbContext-{Guid.NewGuid():N}").Options);

            return dbContext;
        }
    }
}
