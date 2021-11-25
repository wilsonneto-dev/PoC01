namespace Classfy.Users.Application.Exceptions;

public abstract class ApplicationException: Exception
{
    public ApplicationException()
    { }

    public ApplicationException(string message) : base(message)
    { }

    public ApplicationException(string message, Exception innerException) : base(message, innerException)
    { }
}