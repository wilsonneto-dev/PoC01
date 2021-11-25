using Bogus;
using DomainUser = Classfy.Users.Domain.User;
using Xunit;

namespace Classfy.Users.UnitTests.Domain.Aggregates.User
{
    [CollectionDefinition(nameof(UserTestsFixture))]
    public class UserTestsFixtureCollection : ICollectionFixture<UserTestsFixture> { }

    public class UserTestsFixture
    {
        private Faker _faker;

        public UserTestsFixture()
        {
            _faker = new Faker("pt_BR");
        }

        public DomainUser.User GetValidUser()
        {
            return new DomainUser.User(
                _faker.Name.FullName(),
                new DomainUser.Email(_faker.Internet.Email()),
                _faker.Internet.Password()
            );
        }
    }
}
