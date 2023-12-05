using art_store.art_storeDto;
using art_store.Services.Contract;
using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using AutoMapper;
using art_store.DataAccess.Repository;

namespace art_store.Services
{
    public class DriverService : IDriverService
    {
        public readonly IDriverRepository _driverRepository;
        public readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }
        public async Task<int> Create(DriverDto driver)
        {
            var driverExisted = await _driverRepository.GetById(driver.Id);

            if (driverExisted != null)
            {
                throw new Exception("Driver exist");
            }

            var driverToAdd = _mapper.Map<Driver>(driver);
            return await _driverRepository.Create(driverToAdd);
        }

        public async Task<int> Update(DriverDto driver)
        {
            var driverToUpdate = await _driverRepository.GetById(driver.Id)
                ?? throw new Exception("Driver not exist");

            driverToUpdate = _mapper.Map(driver, driverToUpdate);
            return await _driverRepository.Update(driverToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var ToDelete = await _driverRepository.GetById(id)
            ?? throw new Exception("Driver not exist");
            return await _driverRepository.Delete(id);
        }

        public async Task<DriverDto> GetById(int id)
        {
            var driver = await _driverRepository.GetById(id);

            return _mapper.Map<DriverDto>(driver);
        }

        public async Task<List<DriverDto>> GetAll()
        {
            var drivers = await _driverRepository.GetAll();
            return _mapper.Map<List<DriverDto>>(drivers);
        }

    }
}