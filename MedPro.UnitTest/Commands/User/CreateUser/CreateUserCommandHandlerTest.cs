using JetBrains.Annotations;
using MedPro.Application.Commands.User.CreateUser;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Auth;
using Moq;

namespace MedPro.UnitTest.Commands.User.CreateUser;

[TestSubject(typeof(CreateUserCommandHandler))]
public class CreateUserCommandHandlerTest
{

    [Fact]
    public async Task User_CreateUser_Success()
    {
        //Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var authServiceMock = new Mock<IAuthService>();

        var user = new MedPro.Domain.Entities.User("rafacout@gmail.com", "123456", "admin");
        
        userRepositoryMock.Setup(x =>
            x.CreateAsync(user).Result)
            .Returns(Guid.NewGuid());

        authServiceMock.Setup(x => x.ComputeSha256Hash(user.Password))
            .Returns("4g5fd6sg4f5d6gsdf4g6fds54gdsf");

        var request = new CreateUserCommand
        {
            UserName = "rafacout@gmail.com",
            Password = "1234567",
            Role = "admin"
        };

        var userCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

        //Act
        var result = await userCommandHandler.Handle(request, new CancellationToken());

        //Assert
        Assert.IsType<Guid>(result);
        Assert.NotEqual(Guid.Empty, result);
        
        userRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<MedPro.Domain.Entities.User>()), Times.Once);
    }
}