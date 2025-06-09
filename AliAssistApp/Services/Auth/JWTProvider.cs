using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AliAssistApp.Auth.Middleware;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AliAssistApp.Services.Auth;

public class JWTProvider : IJWTProvider
{
    private readonly JWTSettings _jwtSettings;
    
    public JWTProvider(IOptions<JWTSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    
    public string GenerateAccessToken(UserDTO user)
    {
        var claims = new[]
        {
            new Claim("name", user.Name),
            new Claim("email", user.Email),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireTime)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}