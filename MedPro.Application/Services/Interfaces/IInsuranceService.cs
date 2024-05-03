using MedPro.Application.InputModels;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Services.Interfaces;

public interface IInsuranceService
{
    List<InsuranceViewModel> GetAll();
    InsuranceViewModel? GetById(Guid id);
    Guid Create(InsuranceInputModel model);
    void Update(Guid id, InsuranceInputModel model);
    void Delete(Guid id);
}