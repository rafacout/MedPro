using MediatR;
using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using MedPro.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Commands.DeleteSpeciality;

public class DeleteSpecialityCommandHandler : IRequestHandler<DeleteSpecialityCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSpecialityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSpecialityCommand command, CancellationToken cancellationToken)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));
        
        await _unitOfWork.Users.DeleteAsync(command.Id);
        await _unitOfWork.CompleteAsync();
        return Unit.Value;
    }
}