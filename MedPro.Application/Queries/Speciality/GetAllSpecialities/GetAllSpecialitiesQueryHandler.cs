using System.Collections;
using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Queries.Speciality.GetAllSpecialities;

public class GetAllSpecialitiesQueryHandler : IRequestHandler<GetAllSpecialitiesQuery, IEnumerable<SpecialityViewModel>>
{
    private readonly MedProDbContext _dbContext;

    public GetAllSpecialitiesQueryHandler(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SpecialityViewModel>> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
    {
        var specialities = await _dbContext.Specialities
            .Select(x => new SpecialityViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .ToListAsync(cancellationToken: cancellationToken);
    
        return specialities;
    }
}