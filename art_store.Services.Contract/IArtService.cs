using art_store.art_storeDto;

namespace art_store.Services.Contract
{
    public interface IArtService
    {
        Task<ArtDto> GetById(int id);

        Task<int> Delete(int id);

        Task<List<ArtDto>> GetAll();

        Task<int> Create(ArtDto art);

        Task<int> Update(ArtDto art);

    }
}