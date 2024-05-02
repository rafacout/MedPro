using MedPro.Application.InputModels;
using MedPro.Application.Services.Interfaces;
using MedPro.Application.ViewModels;
using MedPro.Domain.Entities;
using MedPro.Infrastructure.Persistence;

namespace MedPro.Application.Services.Implementations;

public class SpecialityService : ISpecialityService
{
    private readonly MedProDbContext _dbContext;

    public SpecialityService(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SpecialityViewModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public SpecialityViewModel GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Guid Create(SpecialityInputModel model)
    {
        var speciality = new Speciality(model.Name, model.Description);
        
        _dbContext.Specialities.Add(speciality);

        _dbContext.SaveChanges();

        return speciality.Id;
    }

    public void Update(SpecialityInputModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}