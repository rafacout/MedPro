using MediatR;
using MedPro.Application.Services.Interfaces;

namespace MedPro.Application.Queries.Patient.GetPatientById;

public class GetPatientByIdQuery : IRequest<PatientViewModel?>
{
    public GetPatientByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; private set; }
}