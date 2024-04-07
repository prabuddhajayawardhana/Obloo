using Obloo.Domain.Entities;

namespace Obloo.Application.Authentication.Common;
public sealed record AuthenticationResult(
        User User,
        string Token
    );

