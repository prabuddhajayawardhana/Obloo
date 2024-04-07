namespace Obloo.Domain.Contracts.Authentication;

public record LoginRequest(
        string Email,
        string Password
    );
