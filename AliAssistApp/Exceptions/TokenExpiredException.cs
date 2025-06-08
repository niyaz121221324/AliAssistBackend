using Microsoft.IdentityModel.Tokens;

namespace AliAssistApp.Exceptions;

public class TokenExpiredException : SecurityTokenExpiredException
{
    public TokenExpiredException() : base("Token expired")
    {
    }

    public TokenExpiredException(string message) : base(message)
    {
    }
}