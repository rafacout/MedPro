using MediatR;
using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Commands.DeleteSpeciality;

public class DeleteSpecialityCommandHandler : IRequestHandler<DeleteSpecialityCommand, Unit>
{
    private readonly ISpecialityRepository _specialityRepository;

    public DeleteSpecialityCommandHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }

    public async Task<Unit> Handle(DeleteSpecialityCommand command, CancellationToken cancellationToken)
    {
        await _specialityRepository.DeleteAsync(command.Id);
        
        return Unit.Value;
    }
}