using FluentAssertions;
using JetBrains.Annotations;
using MedPro.Application.Commands.User.CreateUser;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Auth;
using MedPro.Infrastructure.Persistence.Repositories;
using MedPro.UnitTest.FakeData;
using Moq;

namespace MedPro.UnitTest.Commands.User.CreateUser;

[TestSubject(typeof(CreateUserCommandHandler))]
public class CreateUserCommandHandlerTest
{
    [Fact]
    public async Task User_CreateUser_Success()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var authServiceMock = new Mock<IAuthService>();

        var user = new UserFaker().Generate();

        unitOfWorkMock.Setup(x =>
                x.Users.CreateAsync(It.IsAny<MedPro.Domain.Entities.User>()))
            .ReturnsAsync(Guid.NewGuid());

        authServiceMock.Setup(x => x.ComputeSha256Hash(user.Password))
            .Returns("4g5fd6sg4f5d6gsdf4g6fds54gdsf");

        var request = new CreateUserCommand
        {
            UserName = "rafacout@gmail.com",
            Password = "1234567",
            Role = "admin"
        };

        var userCommandHandler = new CreateUserCommandHandler(authServiceMock.Object, unitOfWorkMock.Object);

        //Act
        var result = await userCommandHandler.Handle(request, new CancellationToken());

        //Assert
        result.Should().NotBeEmpty();
        result.Should().NotBe(Guid.Empty);

        unitOfWorkMock.Verify(x => x.Users.CreateAsync(It.IsAny<MedPro.Domain.Entities.User>()), Times.Once);
    }
}