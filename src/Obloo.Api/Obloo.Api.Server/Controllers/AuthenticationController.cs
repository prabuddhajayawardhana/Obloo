
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Obloo.Application.Authentication.Commands.Register;
using Obloo.Application.Authentication.Common;
using Obloo.Application.Authentication.Queries.Login;
using Obloo.Domain.Contracts.Authentication;
using Obloo.Presentation.Abstractions;

namespace Obloo.Api.Server.Controllers;

[Route("auth")]
public sealed class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender) : base(sender)
    {
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        AuthenticationResult authResult = await sender.Send(command, cancellationToken);

        var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await sender.Send(query, cancellationToken);

        var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        return Ok(response);

    }
}
