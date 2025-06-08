namespace AliAssistApp.Exceptions;

public class InvalidTokenException : Exception
{
    public InvalidTokenException() : base("Invalid token")
    {
    }

    public InvalidTokenException(string message) : base(message)
    {
    }
}