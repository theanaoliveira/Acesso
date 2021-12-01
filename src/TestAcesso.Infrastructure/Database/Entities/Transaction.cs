using System;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Infrastructure.Database.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public bool HasExecute { get; set; }
    }
}
