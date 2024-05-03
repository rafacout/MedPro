using MedPro.Application.InputModels;
using MedPro.Application.ViewModels;

namespace MedPro.Application.Services.Interfaces;

public interface IServiceService
{
    List<ServiceViewModel> GetAll();
    ServiceViewModel? GetById(Guid id);
    Guid Create(ServiceInputModel model);
    void Update(Guid id, ServiceInputModel model);
    void Delete(Guid id);
}