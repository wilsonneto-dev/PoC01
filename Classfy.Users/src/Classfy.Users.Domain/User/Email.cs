using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classfy.Users.Domain.BuildingBlocks;

namespace Classfy.Users.Domain.User
{
    public class Email: ValueObject
    {
        public Email(string address)
        {
            Address = address;
            Validate();
        }

        public string Address { get; }

        public override string ToString() => Address;

        private void Validate()
            => DomainValidation.ValidWithRegex(
                Address, 
                @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
                $"{nameof(Email)}.{nameof(Address)} is invalid: {Address}"
            );
    }
}
