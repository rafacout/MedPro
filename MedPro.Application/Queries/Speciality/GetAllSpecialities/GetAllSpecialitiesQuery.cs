using MediatR;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Queries.Speciality.GetAllSpecialities;

public class GetAllSpecialitiesQuery : IRequest<IEnumerable<SpecialityViewModel>>
{
    public GetAllSpecialitiesQuery(string? query)
    {
        Query = query;
    }
    
    public string? Query { get; set; }
}