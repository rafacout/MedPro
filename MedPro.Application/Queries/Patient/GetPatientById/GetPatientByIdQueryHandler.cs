using MediatR;
using MedPro.Application.Services.Interfaces;
using MedPro.Domain.Repositories;

namespace MedPro.Application.Queries.Patient.GetPatientById;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientViewModel?>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientByIdQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public async Task<PatientViewModel?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var patient = await _patientRepository.GetByIdAsync(request.Id);

        if (patient == null)
            return null;

        return new PatientViewModel
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email,
            DocumentNumber = patient.DocumentNumber,
            BloodType = patient.BloodTypeEnum.ToString(),
            Address = patient.Address,
            Height = patient.Heigth,
            Weight = patient.Weigth
        };
    }
}