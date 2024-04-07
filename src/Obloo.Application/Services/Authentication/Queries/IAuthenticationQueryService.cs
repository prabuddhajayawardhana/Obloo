using Obloo.Application.Services.Authentication.Common;

namespace Obloo.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string email, string password);
}
