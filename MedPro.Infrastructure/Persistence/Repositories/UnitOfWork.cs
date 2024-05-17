using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedPro.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MedProDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(MedProDbContext dbContext, ISpecialityRepository specialities, IUserRepository users, IPatientRepository patients)
    {
        _dbContext = dbContext;
        Specialities = specialities;
        Users = users;
        Patients = patients;
    }
    
    public ISpecialityRepository Specialities { get; }
    public IUserRepository Users { get; }
    public IPatientRepository Patients { get; }

    // To use the transaction you need to first call the BeginTransactionAsync() method, then
    // Do the operation with objects (add/update/delete) and call CompleteAsync(), and finally
    // Call the CommitAsync() to commit all changes
    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}