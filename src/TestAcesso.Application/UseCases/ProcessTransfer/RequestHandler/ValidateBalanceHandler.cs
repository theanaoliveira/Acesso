using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler
{
    public class ValidateBalanceHandler : Handler<ProcessUcRequest>
    {
        private readonly IAccountTransferRepository accountTransferRepository;

        public ValidateBalanceHandler(IAccountTransferRepository accountTransferRepository)
        {
            this.accountTransferRepository = accountTransferRepository;
        }

        public override void ProcessRequest(ProcessUcRequest request)
        {
            request.AddProcessLog("Validate balance value");

            if (request.AccountTransfer.Value > request.AcOrigin.Balance)
            {
                var message = $"Not enough balance";

                request.AccountTransfer.SetStatus(TransactionStatus.Error);
                request.AccountTransfer.SetMessage(message);

                request.AddErrorLog(message);

                accountTransferRepository.Update(request.AccountTransfer);

                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
