
using MedPro.Domain.Entities;
using MedPro.Domain.Models;

namespace MedPro.Domain.Repositories;

public interface ISpecialityRepository
{
    Task<PaginationResult<Speciality>> GetAllAsync(string? query, int page = 1);
    
    Task<Speciality?> GetByIdAsync(Guid id);
    
    Task<Guid> CreateAsync(Speciality speciality);
    
    Task UpdateAsync(Speciality speciality);
    
    Task DeleteAsync(Guid id);
}