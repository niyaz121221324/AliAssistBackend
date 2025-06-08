namespace AliAssistApp.Middleware;

public class JWTSettings
{
    public string Key { get; init; } 
    public string Issuer { get; init; } 
    public string Audience { get; init; } 

    /// <summary>
    /// Время жизни токена в минутах
    /// </summary>
    public int ExpireTime { get; init; }
}