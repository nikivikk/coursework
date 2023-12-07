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
        public async void Create_ValidArtGiven_ShouldReturnArtId()
        {

            //Arrange
            var artId = 1;
            var artToAdd = new ArtDto()
            {
                Author = "TestAuthor",
                Name = "TestName",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var artRepositoryMock = new Mock<IArtRepository>();
            Art art = null;

            artRepositoryMock.Setup(x => x.GetById(artToAdd.Id))
                .ReturnsAsync(art);
            artRepositoryMock.Setup(x => x.Create(It.IsAny<Art>())).ReturnsAsync(artId);

            var artService = GetService(artRepositoryMock.Object);


            //Act
            var result = await artService.Create(artToAdd);

            //Assert
            Assert.Equal(artId, result);
            artRepositoryMock.Verify(x => x.Create(It.IsAny<Art>()));
        }

        [Fact]
        public async void Create_ArtExists_ShouldThrowException()
        {
            //Arrange
            var artToAdd = new ArtDto()
            {
                Author = "TestAuthor",
                Name = "TestName",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };

            var existingArt = new Art()
            {
                Author = "TestAuthor",
                Name = "TestName",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };

            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetById(artToAdd.Id)).ReturnsAsync(existingArt);

            var artService = GetService(artRepositoryMock.Object);

            //Act + Assert
            await Assert.ThrowsAsync<Exception>(() => artService.Create(artToAdd));
        }

        [Fact]
        public async void Update_ValidArtGiven_ShouldReturnUpdatedArtId()
        {
            //Arrange
            var artId = 1;
            var artToUpdate = new ArtDto()
            {
                Author = "TestAuthor",
                Name = "TestName",
            };
            var existingArt = new Art()
            {
                Id = artId,
                Author = "Author",
                Name = "Name",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetById(artToUpdate.Id)).ReturnsAsync(existingArt);
            artRepositoryMock.Setup(x => x.Update(It.IsAny<Art>())).ReturnsAsync(artId);

            var artService = GetService(artRepositoryMock.Object);

            //Act
            var result = await artService.Update(artToUpdate);

            //Assert
            Assert.Equal(artId, result);
            artRepositoryMock.Verify(x => x.Update(It.IsAny<Art>()));
        }

        [Fact]
        public async void Update_ArtNotExist_ShouldThrowException()
        {
            //Arrange
            var artId = 1;
            var artToUpdate = new ArtDto()
            {
                Author = "TestAuthor",
                Name = "TestName",
            };
            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetById(artToUpdate.Id)).ReturnsAsync((Art)null);

            var artService = GetService(artRepositoryMock.Object);

            //Act + Assert
            await Assert.ThrowsAsync<Exception>(() => artService.Update(artToUpdate));
        }

        [Fact]
        public async void Delete_ValidArtIdGiven_ShouldReturnDeletedArtId()
        {
            //Arrange
            var artIdToDelete = 1;
            var existingArt = new Art()
            {
                Id = artIdToDelete,
                Author = "Author",
                Name = "Name",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetById(artIdToDelete)).ReturnsAsync(existingArt);
            artRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(existingArt.Id);

            var artService = GetService(artRepositoryMock.Object);

            //Act
            var result = await artService.Delete(artIdToDelete);

            //Assert
            Assert.Equal(artIdToDelete, result);
            artRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
        }

        [Fact]
        public async void Delete_ArtNotExist_ShouldThrowException()
        {
            //Arrange
            var artIdToDelete = 1;

            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetById(artIdToDelete)).ReturnsAsync((Art)null);

            var artService = GetService(artRepositoryMock.Object);

            //Assert + ACT
            await Assert.ThrowsAsync<Exception>(() => artService.Delete(artIdToDelete));
        }

        [Fact]
        public async void GetById_ValidArtIdGiven_ShouldReturnArt()
        {
            //Arrange
            var artId = 1;
            var existingArt = new Art()
            {
                Id = artId,
                Author = "Author",
                Name = "Name",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var artDto = new ArtDto()
            {
                Id = artId,
                Author = "Author",
                Name = "Name",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetById(artId)).ReturnsAsync(existingArt);

            var artService = GetService(artRepositoryMock.Object);

            //Act
            var result = await artService.GetById(artId);

            //Assert
            Assert.Equal(artDto.Id, result.Id);
            Assert.Equal(artDto.Author, result.Author);
            Assert.Equal(artDto.Name, result.Name);
            Assert.Equal(artDto.Price, result.Price);
            artRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()));
        }

        [Fact]
        public async void GetAll_Valid_ShouldReturnArtList()
        {
            //Arrange
            var artId = 1;
            var existingArt = new Art()
            {
                Id = artId,
                Author = "Author",
                Name = "Name",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var existing = new List<Art>() { existingArt };
            var artDto = new ArtDto()
            {
                Id = artId,
                Author = "Author",
                Name = "Name",
                Price = 0,
                Status = true,
                Year = new DateTime(),
            };
            var expected = new List<ArtDto>() { artDto };
            var artRepositoryMock = new Mock<IArtRepository>();

            artRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(existing);

            var artService = GetService(artRepositoryMock.Object);

            //Act
            var result = await artService.GetAll();

            //Assert
            Assert.Equal(result.First().Id, expected.First().Id);
            artRepositoryMock.Verify(x => x.GetAll());
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