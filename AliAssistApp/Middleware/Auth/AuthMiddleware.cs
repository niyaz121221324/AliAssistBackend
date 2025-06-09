using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AliAssistApp.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace AliAssistApp.Auth.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public AuthMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/auth"))
        {
            await _next(context);
            return;
        }
        
        var token = context.Request.Headers["X-Access-Token"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidTokenException(); 
        }
        
        if (!string.IsNullOrWhiteSpace(token))
        {
            try
            {
                var jwtSettings = _configuration.GetSection(nameof(JWTSettings)).Get<JWTSettings>();
                var key = Encoding.UTF8.GetBytes(jwtSettings.Key);
        
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch (SecurityTokenExpiredException)
            {
                throw new TokenExpiredException();
            }
            catch (Exception)
            {
                throw new InvalidTokenException();
            }
            
            await _next(context);
        }
    }
}