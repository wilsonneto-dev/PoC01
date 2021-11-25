﻿namespace Classfy.Users.Domain.Exceptions
{
    public class ConflictException : DomainException
    {
        public ConflictException()
        { }

        public ConflictException(string message) : base(message)
        { }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
