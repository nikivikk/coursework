namespace art_store.DataAccess.Repository
{
    public class BaseRepository
    {
        public readonly art_storeDbContext _art_storeContext;

        public BaseRepository(art_storeDbContext art_storeContext   )
        {
            _art_storeContext = art_storeContext;
        }
    }
}
