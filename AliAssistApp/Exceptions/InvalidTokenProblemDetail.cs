namespace AliAssistApp.Exceptions;

public class InvalidTokenProblemDetail : HttpValidationProblemDetails
{
    public InvalidTokenProblemDetail(InvalidTokenException exception)
    {
        Title = "Unauthorized";
        Status = StatusCodes.Status401Unauthorized;
        Detail = exception.Message;
    }
}