using AliAssistApp.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AliAssistApp.Controllers;

public class AuthController : BaseApiController
{
    private readonly IJWTProvider _jwtProvider;

    public AuthController(IJWTProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    [HttpPost("login")]
    public async Task<ActionResult<JWTProvider>> Get(UserDTO user)
    {
        if (user is null || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Email))
        {
            return BadRequest("Email and/or name are required");
        }

        var result =  new JWTResponse() 
        {
            AccessToken = _jwtProvider.GenerateAccessToken(user),
            RefreshToken = _jwtProvider.GenerateRefreshToken(),
        };
        
        return Ok(result);
    }
}

public class JWTResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}