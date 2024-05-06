using MediatR;
using MedPro.Domain.Repositories;

namespace MedPro.Application.Commands.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user != null)
        {
            user.Update(request.UserName, request.Password, request.Role);
            await _userRepository.UpdateAsync(user);    
        }
        
        return Unit.Value;
    }
}