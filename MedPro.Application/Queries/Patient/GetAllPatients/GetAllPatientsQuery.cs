using MediatR;
using MedPro.Application.Services.Interfaces;
using MedPro.Domain.Models;

namespace MedPro.Application.Queries.Patient.GetAllPatients;

public class GetAllPatientsQuery : IRequest<PaginationResult<PatientViewModel>>
{
    public string? Query { get; set; }
    public int Page { get; set; } = 1;
}