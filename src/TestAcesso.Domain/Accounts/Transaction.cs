using System;
using TestAcesso.Domain.Enums;
using TestAcesso.Domain.Validator;

namespace TestAcesso.Domain.Accounts
{
    public class Transaction : Entity
    {
        public string AccountNumber { get; private set; }
        public decimal Value { get; private set; }
        public TransactionType Type { get; private set; }
        public bool HasExecute { get; private set; }

        protected Transaction() { }

        public Transaction(Guid id, string accountNumber, decimal value, TransactionType type)
        {
            Id = id;
            AccountNumber = accountNumber;
            Value = value;
            Type = type;
            HasExecute = false;

            Validate(this, new TransactionValidator());
        }

        public void UpdateExecute() => HasExecute = true;
    }
}
