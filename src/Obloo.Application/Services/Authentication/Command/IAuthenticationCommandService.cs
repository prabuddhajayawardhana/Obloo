using Obloo.Application.Services.Authentication.Common;

namespace Obloo.Application.Services.Authentication.Command;

public interface IAuthenticationCommandService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
}
