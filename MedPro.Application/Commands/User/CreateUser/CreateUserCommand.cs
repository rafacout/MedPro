using MediatR;

namespace MedPro.Application.Commands.User.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}