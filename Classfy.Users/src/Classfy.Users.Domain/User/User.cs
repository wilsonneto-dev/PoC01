using Classfy.Users.Domain.BuildingBlocks;

namespace Classfy.Users.Domain.User
{
    public class User : AggregateRoot<Guid>
    {
        public User(string name, Email email, string hashedPassword)
        {
            Name = name;
            Email = email;
            HashedPassword = hashedPassword;

            Validate();
        }

        public string Name { get; private init; }
        public Email Email { get; private init; }
        public string HashedPassword { get; private init; }

        private void Validate()
        {
            DomainValidation.ValidWithRegex(Name, @"^([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+)$", $"{nameof(Name)} is invalid: {Name}");
            DomainValidation.NotNullOrWhiteSpace(HashedPassword, $"{nameof(HashedPassword)} is invalid: {HashedPassword}");
        }
    }
}
