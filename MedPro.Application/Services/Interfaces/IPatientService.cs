using MedPro.Application.InputModels;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Services.Interfaces;

public interface IPatientService
{
    List<PatientViewModel> GetAll();
    PatientViewModel? GetById(Guid id);
    Guid Create(PatientInputModel model);
    void Update(Guid id, PatientInputModel model);
    void Delete(Guid id);
}