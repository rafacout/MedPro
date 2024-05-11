using MediatR;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Auth;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _authService.ComputeSha256Hash(request.Password);
        var user = new Domain.Entities.User(request.UserName, hashedPassword, request.Role);
        var id = await _unitOfWork.Users.CreateAsync(user);
        await _unitOfWork.CompleteAsync();
        return id;
    }
}