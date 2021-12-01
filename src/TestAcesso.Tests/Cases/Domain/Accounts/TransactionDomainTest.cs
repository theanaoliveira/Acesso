using FluentAssertions;
using System;
using TestAcesso.Tests.Builders.Accounts;
using Xunit;

namespace TestAcesso.Tests.Cases.Domain.Accounts
{
    public class TransactionDomainTest
    {
        [Fact]
        public void CreateTransactionDomainWithSucess()
        {
            var model = TransactionBuilder.New().Build();
            model.ValidationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public void DontCreateWithEmptyId()
        {
            var model = TransactionBuilder.New().WithId(new Guid()).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DontCreateWithNullOrEmptyAccountNumber(string value)
        {
            var model = TransactionBuilder.New().WithAccountNumber(value).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DontCreateWithZeroOrLess(decimal value)
        {
            var model = TransactionBuilder.New().WithValue(value).Build();
            model.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
