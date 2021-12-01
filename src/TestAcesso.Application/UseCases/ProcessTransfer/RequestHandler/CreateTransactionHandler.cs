using System;
using System.Collections.Generic;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler
{
    public class CreateTransactionHandler : Handler<ProcessUcRequest>
    {
        public override void ProcessRequest(ProcessUcRequest request)
        {
            request.AddProcessLog($"Create transactions objects");

            request.Transactions = new List<Transaction>
            {
                new Transaction(Guid.NewGuid(), request.AcOrigin.AccountNumber, request.AccountTransfer.Value, TransactionType.Debit),
                new Transaction(Guid.NewGuid(), request.AcDest.AccountNumber, request.AccountTransfer.Value, TransactionType.Credit),
            };

            sucessor?.ProcessRequest(request);
        }
    }
}
