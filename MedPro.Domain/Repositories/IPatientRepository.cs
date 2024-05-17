using MedPro.Domain.Entities;
using MedPro.Domain.Models;

namespace MedPro.Domain.Repositories;

public interface IPatientRepository
{
    Task<PaginationResult<Patient>> GetAllAsync(string? query, int page = 1);
    
    Task<Patient?> GetByIdAsync(Guid id);
    
    Task<Patient?> GetByDocumentAsync(string document);
    
    Task<Patient?> GetByPhoneAsync(string phone);
    
    Task<Guid> CreateAsync(Patient patient);
    
    Task UpdateAsync(Patient patient);
    
    Task DeleteAsync(Guid id);
}
