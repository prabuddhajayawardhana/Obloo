using MediatR;
using Obloo.Application.Authentication.Common;

namespace Obloo.Application.Authentication.Commands.Register;

public sealed record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<AuthenticationResult>;
