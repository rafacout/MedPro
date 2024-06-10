using FluentAssertions;
using MedPro.Application.Queries.User.GetUserById;
using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.UnitTest.FakeData;
using Moq;

namespace MedPro.UnitTest.Application.Queries;

public class GetUserByIdQueryHandlerTest
{
    [Fact]
    public async Task User_GetUserById_Success()
    {
        //Arrange
        var userId = Guid.NewGuid();
        var user = new UserFaker().Generate();
        
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.GetByIdAsync(userId).Result).Returns(user);

        var request = new GetUserByIdQuery(userId);
        var handler = new GetUserByIdQueryHandler(userRepositoryMock.Object);
        
        //Act
        var result = await handler.Handle(request, new CancellationToken());
        
        //Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(user.Id);
        result!.UserName.Should().Be(user.UserName);
        result!.Password.Should().Be(user.Password);
        result!.Role.Should().Be(user.Role);
        userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once);
    }
}