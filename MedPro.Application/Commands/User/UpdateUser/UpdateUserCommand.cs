using MediatR;

namespace MedPro.Application.Commands.User.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}