using MediatR;
using Obloo.Application.Authentication.Common;

namespace Obloo.Application.Authentication.Queries.Login;
public sealed record LoginQuery(
        string Email,
        string Password
    ) : IRequest<AuthenticationResult>;