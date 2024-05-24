using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Obloo.Domain.Entities;
using System.Security.Claims;

namespace Obloo.Application.Services.Authentication;

public class IdentityUserManager : UserManager<User>
{
    public IdentityUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }

    public override Task<bool> CheckPasswordAsync(User user, string password)
    {
        return base.CheckPasswordAsync(user, password);
    }

    public override Task<IdentityResult> CreateAsync(User user)
    {
        return base.CreateAsync(user);
    }

    public override Task<IdentityResult> CreateAsync(User user, string password)
    {
        return base.CreateAsync(user, password);
    }

    public override string? GetUserName(ClaimsPrincipal principal)
    {
        return base.GetUserName(principal);
    }

    public override Task<bool> HasPasswordAsync(User user)
    {
        return base.HasPasswordAsync(user);
    }
}
