using Bogus;
using MedPro.Domain.Entities;

namespace MedPro.UnitTest.FakeData;

public sealed class UserFaker : Faker<User>
{
    public UserFaker()
    {
        CustomInstantiator(faker =>
            new User(faker.Internet.Email(), faker.Internet.Password(), faker.PickRandomParam("admin", "user")));

        // RuleFor(u => u.UserName, f => f.Internet.UserName())
        //     .RuleFor(u => u.Password, f => f.Internet.Password())
        //     .RuleFor(u => u.Role, f => f.PickRandomParam("admin", "user"));
    }
    
}