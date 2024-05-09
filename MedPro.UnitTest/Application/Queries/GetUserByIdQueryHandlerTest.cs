using MedPro.Application.Queries.User.GetUserById;
using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using Moq;

namespace MedPro.UnitTest.Application.Queries;

public class GetUserByIdQueryHandlerTest
{
    [Fact]
    public async Task User_GetUserById_Success()
    {
        //Arrange
        var userId = Guid.NewGuid();
        var user = new User("rafacout@gmail.com", "123456", "admin");
        
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.GetByIdAsync(userId).Result).Returns(user);

        var request = new GetUserByIdQuery(userId);
        var handler = new GetUserByIdQueryHandler(userRepositoryMock.Object);
        
        //Act
        var result = await handler.Handle(request, new CancellationToken());
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(user.UserName, result.UserName);
        Assert.Equal(user.Password, result.Password);
        Assert.Equal(user.Role, result.Role);
        
        userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once);
    }
}