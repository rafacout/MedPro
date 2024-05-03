using MedPro.Application.InputModels;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Services.Interfaces;

public interface IAppointmentService
{
    List<AppointmentViewModel> GetAll();
    AppointmentViewModel? GetById(Guid id);
    Guid Create(AppointmentInputModel model);
    void Update(Guid id, AppointmentInputModel model);
    void Delete(Guid id);
}