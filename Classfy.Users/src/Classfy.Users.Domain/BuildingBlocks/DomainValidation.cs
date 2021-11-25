using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Classfy.Users.Domain.Exceptions;

namespace Classfy.Users.Domain.BuildingBlocks
{
    public static class DomainValidation
    {
        public static void NotNull(object? target, string exceptionMessage)
        {
            if (target == null)
                throw new EntityValidationException(exceptionMessage);
        }

        public static void NotNullOrWhiteSpace(string target, string exceptionMessage)
        {
            if (String.IsNullOrWhiteSpace(target))
                throw new EntityValidationException(exceptionMessage);
        }

        public static void ValidWithRegex(string target, string pattern, string exceptionMessage)
        {
            DomainValidation.NotNullOrWhiteSpace(target, exceptionMessage);
            if (!Regex.IsMatch(target, pattern))
                throw new EntityValidationException(exceptionMessage);
        }
    }
}
