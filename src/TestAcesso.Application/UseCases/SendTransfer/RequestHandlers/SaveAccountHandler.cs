using TestAcesso.Application.Repositories.Database;

namespace TestAcesso.Application.UseCases.SendTransfer.RequestHandlers
{
    public class SaveAccountHandler : Handler<TransferUcRequest>
    {
        private readonly IAccountTransferRepository accountTransferRepository;

        public SaveAccountHandler(IAccountTransferRepository accountTransferRepository)
        {
            this.accountTransferRepository = accountTransferRepository;
        }

        public override void ProcessRequest(TransferUcRequest request)
        {
            request.AddProcessLog($"Save transfer: {request.AccountTransfer.Id} in database");
            accountTransferRepository.Add(request.AccountTransfer);

            sucessor?.ProcessRequest(request);
        }
    }
}
