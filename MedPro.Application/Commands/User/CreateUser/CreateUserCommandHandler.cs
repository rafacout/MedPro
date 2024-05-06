using MediatR;
using MedPro.Domain.Repositories;

namespace MedPro.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User(request.UserName, request.Password, request.Role);
        await _userRepository.CreateAsync(user);
        return user.Id;        
    }
}