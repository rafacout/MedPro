using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Domain.Repositories;

namespace MedPro.Application.Queries.User.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserViewModel?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
            return null;
        
        return new UserViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Password = user.Password,
            Role = user.Role
        };
    }
}