using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Obloo.Application.Common.Interfaces.Authentication;
using Obloo.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obloo.Infrastructure.Services.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    //public string GenerateToken(Guid userId, string firstName, string lastName)
    //{
    //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b9y6DckksvZt8rVGBuPn8w=="));
    //    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //    var claims = new[]
    //    {
    //        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
    //        new Claim(JwtRegisteredClaimNames.GivenName, firstName),
    //        new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
    //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //    };
    //    var securityToke = new JwtSecurityToken(issuer: "Obloo", expires: DateTime.Now.AddDays(1), claims: claims, signingCredentials: signingCredentials);

    //    return new JwtSecurityTokenHandler().WriteToken(securityToke);
    //}

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwtSettings.ExpireMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    
}
