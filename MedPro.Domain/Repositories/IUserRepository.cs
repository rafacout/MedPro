
using MedPro.Domain.Entities;

namespace MedPro.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    
    Task<Guid> CreateAsync(User user);
    
    Task UpdateAsync(User user);
    
    Task DeleteAsync(Guid id);
}