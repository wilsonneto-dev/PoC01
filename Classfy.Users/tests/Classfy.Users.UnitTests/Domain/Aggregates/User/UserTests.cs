using DomainUser = Classfy.Users.Domain.User;
using FluentAssertions;
using Xunit;
using System.Threading.Tasks;
using Classfy.Users.Domain.Exceptions;

namespace Classfy.Users.UnitTests.Domain.Aggregates.User;

[Collection(nameof(UserTestsFixture))]
public class UserTests
{
    public UserTests(UserTestsFixture fixture)
    {
        _fixture = fixture;
    }

    private readonly UserTestsFixture _fixture;

    [Theory(DisplayName = "DoesntAcceptInvalidNames")]
    [Trait("Domain", "UserTests - Domain")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("123")]
    [InlineData("User 2 Tres")]
    [InlineData("Usér Tre3s")]
    [InlineData(null)]
    public async Task DoesntAcceptInvalidNames(string name)
    {
        var validUser = _fixture.GetValidUser();
        var exception = await Assert.ThrowsAsync<EntityValidationException>(() => Task.FromResult(new DomainUser.User(name, validUser.Email, validUser.HashedPassword)));
        Assert.Equal($"Name is invalid: {name}", exception.Message);
    }

    [Theory(DisplayName = "DoesntAcceptInvalidEmails")]
    [Trait("Domain", "UserTests - Domain")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("teste")]
    [InlineData("teste@...")]
    [InlineData("...@te...")]
    [InlineData("teste@teste.a")]
    public void DoesntAcceptInvalidEmails(string email)
    {
        var validUser = _fixture.GetValidUser();
        var action = () => new DomainUser.User(validUser.Name, new DomainUser.Email(email), validUser.HashedPassword);

        action.Should()
            .Throw<EntityValidationException>()
            .WithMessage($"Email.Address is invalid: {email}");
    }

    [Theory(DisplayName = "DoesntAcceptInvalidPassword")]
    [Trait("Domain", "UserTests - Domain")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void DoesntAcceptInvalidPassword(string password)
    {
        var validUser = _fixture.GetValidUser();
        var action = () => new DomainUser.User(validUser.Name, validUser.Email, password);
        action.Should()
            .Throw<EntityValidationException>()
            .WithMessage($"HashedPassword is invalid: {password}");
    }
}
