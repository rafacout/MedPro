using MediatR;
using MedPro.Infrastructure.Persistence.Context;

namespace MedPro.Application.Commands.UpdateSpeciality;

public class UpdateSpecialityCommandHandler : IRequestHandler<UpdateSpecialityCommand, Unit>
{
    private readonly MedProDbContext _dbContext;

    public UpdateSpecialityCommandHandler(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = await _dbContext.Specialities.FindAsync(request.Id);

        if (speciality != null)
        {
            speciality.Update(request.Name, request.Description);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return Unit.Value;
    }
}