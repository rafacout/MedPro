using MediatR;
using MedPro.Application.Services.Interfaces;
using MedPro.Domain.Models;
using MedPro.Domain.Repositories;

namespace MedPro.Application.Queries.Patient.GetAllPatients;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, PaginationResult<PatientViewModel>>
{
    private readonly IPatientRepository _patientRepository;

    public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public async Task<PaginationResult<PatientViewModel>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var paginationResult = await _patientRepository.GetAllAsync(request.Query, request.Page);
    
        var viewModel = paginationResult
            .Data
            .Select(patient => new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                Address = patient.Address,
                Height = patient.Heigth,
                Weight = patient.Weigth,
                BirthDate = patient.BirthDate,
                DocumentNumber = patient.DocumentNumber,
                PhoneNumber = patient.PhoneNumber,
                BloodType = patient.BloodTypeEnum.ToString()
            })
            .ToList();

        var paginationViewModel = new PaginationResult<PatientViewModel>(paginationResult.Page,
            paginationResult.TotalPages, paginationResult.PageSize, paginationResult.ItemsCount, viewModel);
        
        return paginationViewModel;
    }
}