using MedPro.Application.InputModels;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Services.Interfaces;

public interface IDoctorService
{
    List<DoctorViewModel> GetAll();
    DoctorViewModel? GetById(Guid id);
    Guid Create(DoctorInputModel model);
    void Update(Guid id, DoctorInputModel model);
    void Delete(Guid id);
}