using Obloo.Domain.Entities;
using Obloo.Domain.Interfaces;

namespace Obloo.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User>
{
    User? GetUserByEmail(string email);
}