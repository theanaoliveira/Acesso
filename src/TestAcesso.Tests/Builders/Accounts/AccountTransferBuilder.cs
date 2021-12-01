using System;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Tests.Builders.Accounts
{
    public class AccountTransferBuilder
    {
        public Guid Id;
        public string AccountOrigin;
        public string AccountDestination;
        public decimal Value;

        public static AccountTransferBuilder New()
        {
            return new AccountTransferBuilder()
            {
                Id = Guid.NewGuid(),
                AccountOrigin = "123",
                AccountDestination = "456",
                Value = 20,
            };
        }

        public AccountTransferBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public AccountTransferBuilder WithAccountOrigin(string accountOrigin)
        {
            AccountOrigin = accountOrigin;
            return this;
        }

        public AccountTransferBuilder WithAccountDestination(string accountDestination)
        {
            AccountDestination = accountDestination;
            return this;
        }

        public AccountTransferBuilder WithValue(decimal value)
        {
            Value = value;
            return this;
        }

        public AccountTransfer Build() => new AccountTransfer(Id, AccountOrigin, AccountDestination, Value);
    }
}
