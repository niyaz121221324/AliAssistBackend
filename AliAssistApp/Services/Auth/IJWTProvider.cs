namespace AliAssistApp.Services.Auth;

public interface IJWTProvider
{
    string GenerateAccessToken(UserDTO user);
    string GenerateRefreshToken();
}

public class UserDTO
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string PasswordHash { get; init; }
}