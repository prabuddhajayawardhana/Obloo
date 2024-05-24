using Microsoft.AspNetCore.Identity;
using Obloo.Application.Common.Interfaces.Authentication;
using Obloo.Application.Common.Interfaces.Persistence;
using Obloo.Application.Services.Authentication.Common;
using Obloo.Domain.Entities;

namespace Obloo.Application.Services.Authentication.Command;

internal class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository useRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository useRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.useRepository = useRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Valid email 
        if (useRepository.GetUserByEmail(email) is not null)
            throw new Exception("User with given email already exists.");

        var user = new User { FirstName = firstName, LastName = lastName, Email = email, PasswordHash = password };

        useRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
