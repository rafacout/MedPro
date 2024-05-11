using MediatR;
using MedPro.Application.ViewModels;
using MedPro.Domain.Models;

namespace MedPro.Application.Queries.Speciality.GetAllSpecialities;

public class GetAllSpecialitiesQuery : IRequest<PaginationResult<SpecialityViewModel>>
{
    public string? Query { get; set; }
    public int Page { get; set; } = 1;
}