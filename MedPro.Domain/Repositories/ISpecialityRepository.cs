
using MedPro.Domain.Entities;

namespace MedPro.Domain.Repositories;

public interface ISpecialityRepository
{
    Task<IEnumerable<Speciality>> GetAllAsync(string query);
    
    Task<Speciality?> GetByIdAsync(Guid id);
    
    Task<Guid> CreateAsync(Speciality speciality);
    
    Task UpdateAsync(Speciality speciality);
    
    Task DeleteAsync(Guid id);
}