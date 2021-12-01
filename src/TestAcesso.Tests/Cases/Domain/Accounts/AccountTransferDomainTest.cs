using FluentAssertions;
using System;
using TestAcesso.Tests.Builders.Accounts;
using Xunit;

namespace TestAcesso.Tests.Cases.Domain.Accounts
{
    public class AccountTransferDomainTest
    {
        [Fact]
        public void CreateAccountTransferDomainWithSucess()
        {
            var model = AccountTransferBuilder.New().Build();
            model.ValidationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public void DontCreateWithEmptyId()
        {
            var model = AccountTransferBuilder.New().WithId(new Guid()).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DontCreateWithNullOrEmptyAccountOrigin(string value)
        {
            var model = AccountTransferBuilder.New().WithAccountOrigin(value).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DontCreateWithNullOrEmptyAccountDestination(string value)
        {
            var model = AccountTransferBuilder.New().WithAccountDestination(value).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DontCreateWithZeroOrLess(decimal value)
        {
            var model = AccountTransferBuilder.New().WithValue(value).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
