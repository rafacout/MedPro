using MediatR;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Queries.Speciality.GetSpecialityById;

public class GetSpecialityByIdQuery : IRequest<SpecialityViewModel>
{
    public GetSpecialityByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}