using Obloo.Application.Common.Interfaces.Authentication;
using Obloo.Application.Common.Interfaces.Persistence;
using Obloo.Application.Services.Authentication.Common;
using Obloo.Domain.Entities;

namespace Obloo.Application.Services.Authentication.Queries;

internal class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _useRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository useRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _useRepository = useRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_useRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User with given email does not exist.");

        if (user.PasswordHash != password) 
            throw new Exception("Invalid password");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}
