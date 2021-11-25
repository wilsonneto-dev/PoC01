namespace Classfy.Users.Domain.Exceptions
{
    public class EntityValidationException : DomainException
    {
        public EntityValidationException()
        { }

        public EntityValidationException(string message) : base(message)
        { }

        public EntityValidationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
