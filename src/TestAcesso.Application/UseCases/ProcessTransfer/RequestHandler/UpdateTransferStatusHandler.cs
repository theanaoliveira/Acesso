using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler
{
    public class UpdateTransferStatusHandler : Handler<ProcessUcRequest>
    {
        private readonly IAccountTransferRepository accountTransferRepository;

        public UpdateTransferStatusHandler(IAccountTransferRepository accountTransferRepository)
        {
            this.accountTransferRepository = accountTransferRepository;
        }

        public override void ProcessRequest(ProcessUcRequest request)
        {
            var qtyAttempts = request.AccountTransfer.QtyAttempts + 1;

            request.AddProcessLog($"Update transfer: {request.AccountTransfer.Id} status");
            request.AccountTransfer.SetStatus(TransactionStatus.Processing);
            request.AccountTransfer.SetQty(qtyAttempts);

            accountTransferRepository.Update(request.AccountTransfer);

            sucessor?.ProcessRequest(request);
        }
    }
}
