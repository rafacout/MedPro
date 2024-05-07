using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Auth;

namespace MedPro.Application.Commands.User.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel?>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<LoginUserViewModel?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hashPassword = _authService.ComputeSha256Hash(request.Password);
        var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, hashPassword);
        
        if (user == null)
        {
            return null;
        }
        
        var token = _authService.GenerateJwtToken(user.UserName, user.Role);

        var userViewModel = new LoginUserViewModel(user.UserName, user.Role, token);
        
        return userViewModel;
    }
}