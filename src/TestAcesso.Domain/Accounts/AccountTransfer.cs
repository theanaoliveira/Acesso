using System;
using TestAcesso.Domain.Enums;
using TestAcesso.Domain.Validator;

namespace TestAcesso.Domain.Accounts
{
    public class AccountTransfer : Entity
    {
        public string AccountOrigin { get; private set; }
        public string AccountDestination { get; private set; }
        public decimal Value { get; private set; }
        public TransactionStatus Status { get; private set; }
        public string Message { get; private set; }
        public int QtyAttempts { get; private set; }

        protected AccountTransfer() { }

        public AccountTransfer(Guid id, string accountOrigin, string accountDestination, decimal value)
        {
            Id = id;
            AccountOrigin = accountOrigin;
            AccountDestination = accountDestination;
            Value = value;
            Status = TransactionStatus.InQueue;
            QtyAttempts = 0;

            Validate(this, new AccountTransferValidator());
        }

        public void SetStatus(TransactionStatus status) => Status = status;
        public void SetQty(int qtyAttempts) => QtyAttempts = qtyAttempts;
        public void SetMessage(string message) => Message = message;
    }
}
