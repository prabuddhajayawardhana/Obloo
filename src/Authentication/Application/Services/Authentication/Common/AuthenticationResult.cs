using Obloo.Domain.Entities;

namespace Obloo.Application.Services.Authentication.Common;

public record AuthenticationResult(
        User user,
        string Token
    );
