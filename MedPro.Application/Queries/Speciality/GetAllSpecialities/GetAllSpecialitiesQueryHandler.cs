using System.Collections;
using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Queries.Speciality.GetAllSpecialities;

public class GetAllSpecialitiesQueryHandler : IRequestHandler<GetAllSpecialitiesQuery, IEnumerable<SpecialityViewModel>>
{
    private readonly ISpecialityRepository _specialityRepository;

    public GetAllSpecialitiesQueryHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }

    public async Task<IEnumerable<SpecialityViewModel>> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
    {
        var specialities = await _specialityRepository.GetAllAsync();
    
        var viewModel = specialities.Select(speciality => new SpecialityViewModel
        {
            Id = speciality.Id,
            Name = speciality.Name
        });
        
        return viewModel;
    }
}