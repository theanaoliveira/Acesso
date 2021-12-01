using TestAcesso.Application.Repositories.Services;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler
{
    public class SendTransferHandler : Handler<ProcessUcRequest>
    {
        private readonly IPublisher<TransferRequest> publisher;

        public SendTransferHandler(IPublisher<TransferRequest> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(ProcessUcRequest request)
        {
            request.AddProcessLog("Send transfer to queue");
            
            var transfer = new TransferRequest(request.AccountTransfer, request.Transactions);

            publisher.PublishAsync(transfer);

            sucessor?.ProcessRequest(request);
        }
    }
}
