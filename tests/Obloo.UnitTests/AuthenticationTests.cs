using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Obloo.Api.Server.Controllers;
using Obloo.Application.Authentication.Commands.Register;
using Obloo.Application.Authentication.Common;
using Obloo.Application.Authentication.Queries.Login;
using Obloo.Domain.Contracts.Authentication;
using Obloo.Domain.Entities;

namespace Obloo.UnitTests
{
    public class AuthenticationTests
    {
        private readonly Mock<ISender> _senderMock;
        private readonly AuthenticationController _controller;

        public AuthenticationTests()
        {
            _senderMock = new Mock<ISender>();
            _controller = new AuthenticationController(_senderMock.Object);
        }

        [Fact]
        public async Task Register_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new RegisterRequest( "John", "Doe","john.doe@example.com","Admin@123");
            var authResult = new AuthenticationResult(new User { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" }, "token");
            _senderMock.Setup(x => x.Send(It.IsAny<RegisterCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(authResult);

            // Act
            var result = await _controller.Register(request, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AuthenticationResponse>(okResult.Value);
            Assert.Equal("John", response.FirstName);
            Assert.Equal("Doe", response.LastName);
            Assert.Equal("john.doe@example.com", response.Email);
        }

        [Fact]
        public async Task Login_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new LoginRequest("john.doe@example.com", "Admin@123");
            var authResult = new AuthenticationResult(new User { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" }, "token");
            _senderMock.Setup(x => x.Send(It.IsAny<LoginQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(authResult);

            // Act
            var result = await _controller.Login(request, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AuthenticationResponse>(okResult.Value);
            Assert.Equal("John", response.FirstName);
            Assert.Equal("Doe", response.LastName);
            Assert.Equal("john.doe@example.com", response.Email);
            Assert.Equal("token", response.Token);
        }
    }
}