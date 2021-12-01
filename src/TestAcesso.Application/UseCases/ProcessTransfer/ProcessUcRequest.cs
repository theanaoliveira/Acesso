using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Application.UseCases.ProcessTransfer
{
    public class ProcessUcRequest : LogRequest
    {
        public AccountTransfer AccountTransfer { get; private set; }
        public Account AcOrigin { get; set; }
        public Account AcDest { get; set; }
        public List<Transaction> Transactions { get; set; }

        public ProcessUcRequest(AccountTransfer accountTransfer)
        {
            AccountTransfer = accountTransfer;
            Transactions = new List<Transaction>();
            Logs = new List<Log>();
        }
    }
}