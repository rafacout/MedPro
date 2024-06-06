using System.Collections;
using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Domain.Models;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Application.Queries.Speciality.GetAllSpecialities;

public class GetAllSpecialitiesQueryHandler : IRequestHandler<GetAllSpecialitiesQuery, PaginationResult<SpecialityViewModel>>
{
    private readonly ISpecialityRepository _specialityRepository;

    public GetAllSpecialitiesQueryHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }

    public async Task<PaginationResult<SpecialityViewModel>> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var paginationResult = await _specialityRepository.GetAllAsync(request.Query, request.Page);
    
        var viewModel = paginationResult
            .Data
            .Select(speciality => new SpecialityViewModel
        {
            Id = speciality.Id,
            Name = speciality.Name,
            Description = speciality.Description
        })
            .ToList();

        var paginationViewModel = new PaginationResult<SpecialityViewModel>(paginationResult.Page,
            paginationResult.TotalPages, paginationResult.PageSize, paginationResult.ItemsCount, viewModel);
        
        return paginationViewModel;
    }
}