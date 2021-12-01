using System;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Tests.Builders.Accounts
{
    public class TransactionBuilder
    {
        public Guid Id;
        public string AccountNumber;
        public decimal Value;
        public TransactionType Type;

        public static TransactionBuilder New()
        {
            return new TransactionBuilder()
            {
                Id = Guid.NewGuid(),
                AccountNumber = "123",
                Value = 20,
                Type = TransactionType.Debit
            };
        }

        public TransactionBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public TransactionBuilder WithAccountNumber(string accountNumber)
        {
            AccountNumber = accountNumber;
            return this;
        }

        public TransactionBuilder WithValue(decimal value)
        {
            Value = value;
            return this;
        }

        public TransactionBuilder WithType(TransactionType type)
        {
            Type = type;
            return this;
        }

        public Transaction Build() => new Transaction(Id, AccountNumber, Value, Type);
    }
}
