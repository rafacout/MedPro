using MediatR;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Auth;

namespace MedPro.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _authService.ComputeSha256Hash(request.Password);
        var user = new Domain.Entities.User(request.UserName, hashedPassword, request.Role);
        return await _userRepository.CreateAsync(user);
    }
}