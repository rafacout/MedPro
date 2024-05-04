using MediatR;
using MedPro.Domain.Entities;
using MedPro.Infrastructure.Persistence.Context;

namespace MedPro.Application.Commands.CreateSpeciality;

public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, Guid>
{
    private readonly MedProDbContext _dbContext;

    public CreateSpecialityCommandHandler(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = new Speciality(request.Name, request.Description);
        
        await _dbContext.Specialities.AddAsync(speciality);

        await _dbContext.SaveChangesAsync();

        return speciality.Id;
    }
}