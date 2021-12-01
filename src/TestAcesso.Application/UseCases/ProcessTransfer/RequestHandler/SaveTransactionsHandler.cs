using System;
using System.Collections.Generic;
using System.Text;
using TestAcesso.Application.Repositories.Database;

namespace TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler
{
    public class SaveTransactionsHandler : Handler<ProcessUcRequest>
    {
        private readonly ITransactionRepository transactionRepository;

        public SaveTransactionsHandler(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public override void ProcessRequest(ProcessUcRequest request)
        {
            request.AddProcessLog("Saving transactions on database");
            transactionRepository.Add(request.Transactions);

            sucessor?.ProcessRequest(request);
        }
    }
}
