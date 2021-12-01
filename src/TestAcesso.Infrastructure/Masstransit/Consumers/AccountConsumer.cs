using MassTransit;
using System.Threading.Tasks;
using TestAcesso.Application.UseCases.ProcessTransfer;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Masstransit.Consumers
{
    public class AccountConsumer : IConsumer<AccountTransfer>
    {
        private IProcessTransferUseCase processTransferUseCase;

        public AccountConsumer(IProcessTransferUseCase processTransferUseCase)
        {
            this.processTransferUseCase = processTransferUseCase;
        }

        public async Task Consume(ConsumeContext<AccountTransfer> context)
        {
            await Task.Run(() => processTransferUseCase.Execute(new ProcessUcRequest(context.Message)));
        }
    }
}
