using FootballManager.Entities;
using FootballManager.Models;
using FootballManager.Repositories;
using FootballManager.Services;
using Moq;
namespace FootballManagerTests
{
    public class TrophyServiceTests
    {
        [Fact]
        public async void CreateTrophyAsync_ShouldReturnTrue()
        {
            // Arrange
            var trophyRepositoryMock = new Mock<ITrophyRepository>();
            trophyRepositoryMock
                .Setup(repo => repo.CreateAsync(It.IsAny<TrophyEntity>()))
                .ReturnsAsync((TrophyEntity trophy) => trophy);

            var trophyService = new TrophyService(trophyRepositoryMock.Object);

            // Act
            var result = await trophyService.CreateTrophyAsync(new TrophyRegistrationForm());

            // Assert
            Assert.True(result);
        }
    }
}
