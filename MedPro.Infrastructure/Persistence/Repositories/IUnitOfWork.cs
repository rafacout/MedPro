using MedPro.Domain.Repositories;

namespace MedPro.Infrastructure.Persistence.Repositories;

public interface IUnitOfWork
{
    ISpecialityRepository Specialities { get; }
    IUserRepository Users { get;  }
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task<int> CompleteAsync();
}