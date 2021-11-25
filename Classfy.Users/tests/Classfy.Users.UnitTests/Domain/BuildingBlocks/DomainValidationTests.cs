using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Classfy.Users.Domain.BuildingBlocks;
using Classfy.Users.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace Classfy.Users.UnitTests.Domain.BuildingBlocks;

public class DomainValidationTests
{
    [Fact(DisplayName = "NotNullThrowWithNullInput")]
    [Trait("Domain", "DomainValidation - Domain")]
    public void NotNullThrowWithNullInput()
    {
        var exceptionMessage = "mensagem-para-teste";
        var action = () => DomainValidation
            .NotNull(null, exceptionMessage);

        action.Should()
            .Throw<EntityValidationException>()
            .WithMessage(exceptionMessage);

    }

    [Theory(DisplayName = "NotNullNotThrowWithValidInputs")]
    [Trait("Domain", "DomainValidation - Domain")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(12364)]
    [InlineData(465489)]
    [InlineData(5545)]
    [InlineData(true)]
    [ClassData(typeof(NotNullObjectsTestData))]
    public void NotNullNotThrowWithValidInputs(object obj)
    {
        var action = () => DomainValidation.NotNull(obj, "");
        action.Should().NotThrow();
    }

    [Theory(DisplayName = "NotNullOrEmptyThrowWithInvalidInputs")]
    [Trait("Domain", "DomainValidation - Domain")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("       ")]
    public void NotNullOrEmptyThrowWithInvalidInputs(string str)
    {
        var exceptionMessage = "exception-message";
        var action = () => DomainValidation.NotNullOrWhiteSpace(str, exceptionMessage);

        action.Should().Throw<EntityValidationException>()
            .WithMessage(exceptionMessage);
    }

    [Theory(DisplayName = "NotNullOrEmptyThrowWithInvalidInputs")]
    [Trait("Domain", "DomainValidation - Domain")]
    [InlineData("test")]
    [InlineData(" - ")]
    [InlineData("sdfds54fsd4fdsf546s")]
    [InlineData("test other test")]
    [InlineData("test other")]
    public void NotNullOrEmptyNotThrowWithValidInputs(string str)
    {
        var action = () => DomainValidation.NotNullOrWhiteSpace(str, "");
        action.Should().NotThrow();
    }

    [Theory(DisplayName = "ValidWithRegexThrowWithEmptyOrNullOrSpaces")]
    [Trait("Domain", "DomainValidation - Domain")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("       ")]
    public void ValidWithRegexThrowWithEmptyOrNullOrSpaces(string str)
    {
        var exceptionMessage = "exception-message";
        var action = () => DomainValidation.NotNullOrWhiteSpace(str, exceptionMessage);

        action.Should().Throw<EntityValidationException>()
            .WithMessage(exceptionMessage);
    }

    [Theory(DisplayName = "ValidWithRegexNotThrowWithValidInputs")]
    [Trait("Domain", "DomainValidation - Domain")]
    [InlineData("tes", @"^[\w]{0,3}$")]
    [InlineData("teste", @"^[\w]+$")]
    [InlineData("18", @"^[\d]+$")]
    [InlineData("zzyzxyyx", @"^[xyz]+$")]
    [InlineData("contact@company.com", RegexValidations.Email)]
    [InlineData("test@test.com", RegexValidations.Email)]
    [InlineData("test@test.com.br", RegexValidations.Email)]
    [InlineData("test@test.br", RegexValidations.Email)]
    [InlineData("test@test.gov.br", RegexValidations.Email)]
    [InlineData("me@test.dev", RegexValidations.Email)]
    [InlineData("User Other LastName", RegexValidations.Name)]
    [InlineData("User", RegexValidations.Name)]
    [InlineData("josé", RegexValidations.Name)]
    [InlineData("Mônica", RegexValidations.Name)]
    [InlineData("Gonçalves", RegexValidations.Name)]
    [InlineData("User Surname", RegexValidations.Name)]
    public void ValidWithRegexNotThrowWithValidInputs(string str, string pattern)
    {
        var action = () => DomainValidation
            .ValidWithRegex(str, pattern, "");

        action.Should().NotThrow();
    }


    [Theory(DisplayName = "ValidWithRegexThrowWithInvalidInputs")]
    [Trait("Domain", "DomainValidation - Domain")]
    [InlineData("teste", @"^[\w]{0,3}$")]
    [InlineData("teste@test.com.br", @"^[\w]+$")]
    [InlineData("Kdfgdgfdg8", @"^[\d]+$")]
    [InlineData("zzyzaxyyx", @"^[xyz]+$")]
    [InlineData("contact@.com", RegexValidations.Email)]
    [InlineData("www.test.com", RegexValidations.Email)]
    [InlineData("User name", RegexValidations.Email)]
    [InlineData("te*st@test", RegexValidations.Email)]
    [InlineData("test@test.gov.b", RegexValidations.Email)]
    [InlineData("te@st@test.gov.br", RegexValidations.Email)]
    [InlineData("tes//t@test.gov.br", RegexValidations.Email)]
    [InlineData("te,st@test.gov.br", RegexValidations.Email)]
    [InlineData("me", RegexValidations.Email)]
    [InlineData("User Other2 LastName", RegexValidations.Name)]
    [InlineData("User 326", RegexValidations.Name)]
    [InlineData("User Surname 1236", RegexValidations.Name)]
    public void ValidWithRegexThrowWithInvalidInputs(string str, string pattern)
    {
        var exceptionMessage = "exception-message";
        var action = () => DomainValidation
            .ValidWithRegex(str, pattern, exceptionMessage);

        action.Should().Throw<EntityValidationException>()
            .WithMessage(exceptionMessage);
    }
}

public static class RegexValidations
{
    public const string Name = @"^([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+)$";
    public const string Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
}

[ExcludeFromCodeCoverage]
public class NotNullObjectsTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new { Active = true } };
        yield return new object[] { new { Name = "User", LastName = "Last" } };
        yield return new object[] { new { UserId = 135, Text = "text x" } };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
