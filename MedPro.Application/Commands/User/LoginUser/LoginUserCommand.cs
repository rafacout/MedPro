using MediatR;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Commands.User.LoginUser;

public class LoginUserCommand : IRequest<LoginUserViewModel?>
{
    public string Email { get; set; }
    public string Password { get; set; }
}