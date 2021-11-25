using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Classfy.Users.Application.Exceptions
{
    internal class InputValidationException: ApplicationException
    {
        public InputValidationException(Type type, IEnumerable<ValidationFailure> failures) :
            base($"Input Validation Errors: {type.Name}", new ValidationException(failures))
        {
        }

        public InputValidationException(string message) : base(message)
        { }

        public InputValidationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
