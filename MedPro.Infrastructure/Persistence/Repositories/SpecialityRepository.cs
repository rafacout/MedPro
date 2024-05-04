using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Infrastructure.Persistence.Repositories;

public class SpecialityRepository : ISpecialityRepository
{
    private readonly MedProDbContext _dbContext;

    public SpecialityRepository(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Speciality>> GetAllAsync()
    {
        return await _dbContext.Specialities.ToListAsync();
    }

    public async Task<Speciality?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Speciality speciality)
    {
        await _dbContext.Specialities.AddAsync(speciality);
        await _dbContext.SaveChangesAsync();
        return speciality.Id;
    }

    public async Task UpdateAsync(Speciality speciality)
    {
        _dbContext.Specialities.Update(speciality);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var speciality = await _dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);

        if (speciality != null) { 
            _dbContext.Specialities.Remove(speciality);
            await _dbContext.SaveChangesAsync();
        }
    }
}