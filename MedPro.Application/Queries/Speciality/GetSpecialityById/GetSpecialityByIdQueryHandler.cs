using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Queries.Speciality.GetSpecialityById;

public class GetSpecialityByIdQueryHandler : IRequestHandler<GetSpecialityByIdQuery, SpecialityViewModel>
{
    private readonly ISpecialityRepository _specialityRepository;
    public GetSpecialityByIdQueryHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }
    
    public async Task<SpecialityViewModel> Handle(GetSpecialityByIdQuery request, CancellationToken cancellationToken)
    {
        var speciality = await _specialityRepository.GetByIdAsync(request.Id);

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