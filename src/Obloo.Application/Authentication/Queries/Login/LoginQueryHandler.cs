using MediatR;
using Microsoft.AspNetCore.Identity;
using Obloo.Application.Authentication.Common;
using Obloo.Application.Common.Interfaces.Authentication;
using Obloo.Application.Common.Interfaces.Persistence;
using Obloo.Domain.Entities;

namespace Obloo.Application.Authentication.Queries.Login;

public sealed class LoginQueryHandler(IPasswordHasher<User> _passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IUserRepository useRepository) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (useRepository.GetUserByEmail(query.Email) is not User user)
            throw new Exception("User with given email does not exist.");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, query.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Invalid password");

        var token = jwtTokenGenerator.GenerateToken(user);

        return await Task.FromResult(new AuthenticationResult(user, token));
    }
}
