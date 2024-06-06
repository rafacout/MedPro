using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MedProDbContext _dbContext;

    public UserRepository(MedProDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Guid> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user.Id;
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);

        if (user is not null) { 
            _dbContext.Users.Remove(user);
        }
    }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string hashPassword)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserName == email && s.Password == hashPassword);

        return user;
    }
}