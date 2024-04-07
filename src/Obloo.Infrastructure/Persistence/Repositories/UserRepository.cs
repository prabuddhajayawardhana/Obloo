using Microsoft.EntityFrameworkCore;
using Obloo.Application.Common.Interfaces.Persistence;
using Obloo.Domain.Entities;
using Obloo.Infrastructure.Persistence.Data;
using System;

namespace Obloo.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(SqlDbContext context) : base(context)
    {
    }

    public User? GetUserByEmail(string email)
    {
        return _dbSet.FirstOrDefault(c => c.Email == email);
    }
}
