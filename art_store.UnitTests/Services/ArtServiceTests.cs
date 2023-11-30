using art_store.art_storeDto;
using art_store.DataAccess.Repository.Contracts;
using art_store.Mappings;
using art_store.Services;
using art_store.Entities;
using art_store.Services.Contract;
using AutoMapper;
using Moq;

namespace art_store.UnitTests.Services
{
    public class ArtServiceTests
    {
        [Fact]

        
        public async void Create_ValidArt_Ok()
        {

            //Arrange


            var artId = 1;
            var ArtToAdd = new ArtDto()
            {
                Author = "TestAuthor",
                Name = "TestName",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };

            var ArtRepositoryMock = new Mock<IArtRepository>();

            ArtRepositoryMock.Setup(x => x.GetById(ArtToAdd.Id)).Returns(Task.FromResult((Art)null));
            ArtRepositoryMock.Setup(x => x.Create(It.IsAny<Art>())).ReturnsAsync(artId);

            var artService = GetService(ArtRepositoryMock.Object);


            //Act

            var result = await artService.Create(ArtToAdd);

            //Assert

            Assert.Equal(artId, result);
            ArtRepositoryMock.Verify(x => x.Create(It.IsAny<Art>()));
        }

        public async void Create_ArtExists_ThrowException()
        {

            //Arrange

            var ArtToAdd = new ArtDto()
            {
                Author = "TestAuthor",
                Name = "TestName",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };

            var existedArt = new Art()
            {
                Author = "TestAuthor",
                Name = "TestName",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };

            var ArtRepositoryMock = new Mock<IArtRepository>();

            ArtRepositoryMock.Setup(x => x.GetById(ArtToAdd.Id)).ReturnsAsync(existedArt );
           

            var artService = GetService(ArtRepositoryMock.Object);


            //Act + Assert

            await Assert.ThrowsAsync<Exception>(() => artService.Create(ArtToAdd));
        }
        private IArtService GetService(IArtRepository artRepository)
        {
            var assemblies = new[]
           {
                typeof(ArtProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();

            return new ArtService(artRepository, mapper);
        }
    }
}