using Obloo.Application.Common.Interfaces.Persistence;

namespace Obloo.Domain.Interfaces;

public interface IOblooServiceProvider
{
    IUserRepository User { get; }
}
