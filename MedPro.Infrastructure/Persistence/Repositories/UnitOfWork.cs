using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;

namespace MedPro.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MedProDbContext _dbContext;

    public UnitOfWork(MedProDbContext dbContext, ISpecialityRepository specialities, IUserRepository users)
    {
        _dbContext = dbContext;
        Specialities = specialities;
        Users = users;
    }
    
    public ISpecialityRepository Specialities { get; }
    public IUserRepository Users { get; }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}