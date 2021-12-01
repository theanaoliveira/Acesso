using System.Collections.Generic;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.UseCases.ProcessTransfer
{
    public class TransferRequest
    {
        public AccountTransfer AccountTransfer { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public TransferRequest(AccountTransfer accountTransfer, List<Transaction> transactions)
        {
            AccountTransfer = accountTransfer;
            Transactions = transactions;
        }
    }
}
