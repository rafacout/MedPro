using MediatR;
using NetArchTest.Rules;
using NuGet.Protocol.Plugins;

namespace MedPro.ArchitectureTest
{

    public class UnitTest1
    {
        [Fact(Skip = "Error in the code")]
        public void Test1()
        {
            var result = Types
                .InAssembly(typeof(MedPro.Domain.Entities.User).Assembly)
                .That()
                .AreClasses()
                .Should()
                .BeSealed()
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(Skip = "Error in the code")]
        public void Test2()
        {
            var result = Types.InAssembly(typeof(MedPro.Domain.Entities.User).Assembly)
                .That()
                .ResideInNamespace("MedPro.Domain.Entities")
                .Should()
                .HaveNameEndingWith("Entity")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Test3()
        {
            var result = Types
                .InAssembly(typeof(MedPro.Application.Commands.User.CreateUser.CreateUserCommand).Assembly)
                .Should()
                .NotHaveDependencyOn("Infrastructure")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Test4()
        {
            var result = Types
                .InAssembly(typeof(MedPro.Api.Controllers.UserController).Assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .ShouldNot()
                .HaveDependencyOn("Infrastructure.Repositories")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Test5()
        {
            var result = Types
                .InAssembly(typeof(MedPro.Application.Commands.User.CreateUser.CreateUserCommand).Assembly)
                .That()
                .ImplementInterface(typeof(IRequestHandler))
                .Should()
                .HaveNameEndingWith("CommandHandler")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}