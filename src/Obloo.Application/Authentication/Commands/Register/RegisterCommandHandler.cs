using MediatR;
using Microsoft.AspNetCore.Identity;
using Obloo.Application.Authentication.Common;
using Obloo.Application.Common.Interfaces.Authentication;
using Obloo.Domain.Entities;
using Obloo.Domain.Interfaces;

namespace Obloo.Application.Authentication.Commands.Register
{
    public sealed class RegisterCommandHandler(IPasswordHasher<User> passwordHasher, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IOblooServiceProvider oblooService) : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        public Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (oblooService.User.GetUserByEmail(command.Email) is not null)
                throw new Exception("User with given email already exists.");

            var user = new User { FirstName = command.FirstName, LastName = command.LastName, Email = command.Email };

            user.PasswordHash = passwordHasher.HashPassword(user, command.Password);

            oblooService.User.Add(user);

            unitOfWork.SaveChangesAsync(cancellationToken);

            var token = jwtTokenGenerator.GenerateToken(user);

            return Task.FromResult(new AuthenticationResult(user, token));
        }
    }
}
