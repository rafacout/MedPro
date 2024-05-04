using MediatR;
using MedPro.Domain.Entities;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Commands.DeleteSpeciality;

public class DeleteSpecialityCommandHandler : IRequestHandler<DeleteSpecialityCommand, Unit>
{
    private readonly MedProDbContext _dbContext;

    public DeleteSpecialityCommandHandler(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteSpecialityCommand command, CancellationToken cancellationToken)
    {
        var speciality = await _dbContext.Specialities.SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

        if (speciality == null)
            throw new ApplicationException($"Speciality with ID {command.Id} not found.");

        _dbContext.Specialities.Remove(speciality);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}