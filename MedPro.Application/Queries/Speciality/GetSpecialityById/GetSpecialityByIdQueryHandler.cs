using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Queries.Speciality.GetSpecialityById;

public class GetSpecialityByIdQueryHandler : IRequestHandler<GetSpecialityByIdQuery, SpecialityViewModel>
{
    private readonly MedProDbContext _dbContext;

    public GetSpecialityByIdQueryHandler(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<SpecialityViewModel> Handle(GetSpecialityByIdQuery request, CancellationToken cancellationToken)
    {
        var speciality = await _dbContext.Specialities.SingleOrDefaultAsync(x => x.Id == request.Id);

        if (speciality == null)
            return null;
        
        return new SpecialityViewModel()
        {
            Id = speciality.Id,
            Name = speciality.Name,
            Description = speciality.Description
        };    
    }
}