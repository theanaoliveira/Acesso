using MassTransit;
using System.Threading.Tasks;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Application.UseCases.ProcessTransfer;

namespace TestAcesso.Infrastructure.Masstransit.Publishers
{
    public class TransactionPublisher : IPublisher<TransferRequest>
    {
        private readonly IBusControl busControl;

        public TransactionPublisher(IBusControl busControl)
        {
            this.busControl = busControl;
        }

        public async Task PublishAsync(TransferRequest objectFile) => await busControl.Publish(objectFile);
    }
}
