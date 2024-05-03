using MedPro.Application.InputModels;
using MedPro.Application.Services.Interfaces;
using MedPro.Application.ViewModels;
using MedPro.Domain.Entities;
using MedPro.Infrastructure.Persistence.Context;

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
        var models = _dbContext.Specialities.Select(x => new SpecialityViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        }).ToList();

        return models;
    }

    public SpecialityViewModel? GetById(Guid id)
    {
        var speciality = _dbContext.Specialities.SingleOrDefault(x => x.Id == id);

        if (speciality == null)
            return null;
        
        return new SpecialityViewModel()
        {
            Id = speciality.Id,
            Name = speciality.Name,
            Description = speciality.Description
        };
    }

    public Guid Create(SpecialityInputModel model)
    {
        var speciality = new Speciality(model.Name, model.Description);
        
        _dbContext.Specialities.Add(speciality);

        _dbContext.SaveChanges();

        return speciality.Id;
    }

    public void Update(Guid id, SpecialityInputModel model)
    {
        var speciality = _dbContext.Specialities.SingleOrDefault(x => x.Id == id);
        
        if (speciality != null)
        {
            speciality.Update(model.Name, model.Description);
            _dbContext.SaveChanges();
        }
    }

    public void Delete(Guid id)
    {
        var speciality = _dbContext.Specialities.SingleOrDefault(x => x.Id == id);

        if (speciality != null) {
            _dbContext.Specialities.Remove(speciality);
            _dbContext.SaveChanges();
        }
    }
}