namespace AliAssistApp.Exceptions;

public class TokenExpiredProblemDetail : HttpValidationProblemDetails
{
    public TokenExpiredProblemDetail(TokenExpiredException exception) 
    {
        Title = "Unauthorized";
        Status = StatusCodes.Status401Unauthorized;
        Detail = exception.Message;
    }
}