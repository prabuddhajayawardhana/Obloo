using Microsoft.EntityFrameworkCore;
using Obloo.Application.Common.Interfaces.Persistence;
using Obloo.Domain.Interfaces;
using Obloo.Infrastructure.Persistence.Data;
using Obloo.Infrastructure.Persistence.Repositories;

namespace Obloo.Infrastructure.Persistence
{
    public sealed class OblooServiceProvider(SqlDbContext context) : IOblooServiceProvider
    {
        public IUserRepository User => new UserRepository(context);
    }
}
