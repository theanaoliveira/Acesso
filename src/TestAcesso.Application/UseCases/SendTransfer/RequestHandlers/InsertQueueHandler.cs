using TestAcesso.Application.Repositories.Services;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.UseCases.SendTransfer.RequestHandlers
{
    public class InsertQueueHandler : Handler<TransferUcRequest>
    {
        private readonly IPublisher<AccountTransfer> publisher;

        public InsertQueueHandler(IPublisher<AccountTransfer> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(TransferUcRequest request)
        {
            request.AddProcessLog($"Insert transfer: {request.AccountTransfer.Id} in queue");
            publisher.PublishAsync(request.AccountTransfer);

            sucessor?.ProcessRequest(request);
        }
    }
}
