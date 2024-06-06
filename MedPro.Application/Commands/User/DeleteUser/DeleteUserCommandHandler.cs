using MediatR;
using MedPro.Application.Commands.User.CreateUser;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        await _unitOfWork.Users.DeleteAsync(request.Id);
        await _unitOfWork.CompleteAsync();
        return Unit.Value;
    }
}