using MedPro.Domain.Entities;
using MedPro.Domain.Models;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Infrastructure.Persistence.Repositories;

public class SpecialityRepository : ISpecialityRepository
{
    private readonly MedProDbContext _dbContext;
    private const int PAGE_SIZE = 10;

    public SpecialityRepository(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<PaginationResult<Speciality>> GetAllAsync(string? query, int page = 1)
    {
        IQueryable<Speciality> specialities = _dbContext.Specialities;

        if (!string.IsNullOrEmpty(query))
        {
            specialities = specialities.Where(x => x.Name.Contains(query) || x.Description.Contains(query));
        }
        
        return await specialities.GetPaged(page, PAGE_SIZE);
    }

    public async Task<Speciality?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(Speciality speciality)
    {
        await _dbContext.Specialities.AddAsync(speciality);
        return speciality.Id;
    }

    public async Task UpdateAsync(Speciality speciality)
    {
        _dbContext.Specialities.Update(speciality);
    }

    public async Task DeleteAsync(Guid id)
    {
        var speciality = await _dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);

        if (speciality != null) { 
            _dbContext.Specialities.Remove(speciality);
        }
    }
}