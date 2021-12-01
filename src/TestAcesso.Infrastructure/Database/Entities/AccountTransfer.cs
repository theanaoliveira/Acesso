using System;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Infrastructure.Database.Entities
{
    public class AccountTransfer
    {
        public Guid Id { get; set; }
        public string AccountOrigin { get; set; }
        public string AccountDestination { get; set; }
        public decimal Value { get; set; }
        public TransactionStatus Status { get; set; }
        public string Message { get; set; }
        public int QtyAttempts { get; set; }
    }
}
