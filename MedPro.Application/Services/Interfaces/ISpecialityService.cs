using MedPro.Application.InputModels;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Services.Interfaces;

public interface ISpecialityService
{
    List<SpecialityViewModel> GetAll();
    SpecialityViewModel GetById(Guid id);
    Guid Create(SpecialityInputModel model);
    void Update(SpecialityInputModel model);
    void Delete(Guid id);
}