using art_store.art_storeDto;
using art_store.Services.Contract;
using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using AutoMapper;

namespace art_store.Services
{
    public class ArtService : IArtService 
    {
        public readonly IArtRepository _artRepository;
        public readonly IMapper _mapper;

        public ArtService(IArtRepository artRepository, IMapper mapper)
        {
            _artRepository = artRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(ArtDto art)
        {
            var artExisted = await _artRepository.GetById(art.Id);

            if (artExisted != null)
            {
                throw new Exception("Art exist");
            }

            var artToAdd = _mapper.Map<Art>(art);
            return await _artRepository.Create(artToAdd);
        }

        public async Task<int> Update(ArtDto art)
        {
            var artToUpdate = await _artRepository.GetById(art.Id)
                ?? throw new Exception("Art not exist");

            artToUpdate = _mapper.Map(art, artToUpdate);
            return await _artRepository.Update(artToUpdate);
        }

        public async Task<int> Delete(int id) {
            var artToDelete = await _artRepository.GetById(id)
            ?? throw new Exception("Art not exist");
            return await _artRepository.Delete(id);
        }

        public async Task<ArtDto> GetById(int id)
        {
            var art = await _artRepository.GetById(id);

            return _mapper.Map<ArtDto>(art);
        }

        public async Task<List<ArtDto>> GetAll()
        {
            var arts = await _artRepository.GetAll();
            return _mapper.Map<List<ArtDto>>( arts);
        }

    }
}