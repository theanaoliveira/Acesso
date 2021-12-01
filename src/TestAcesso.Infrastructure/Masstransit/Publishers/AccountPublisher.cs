using MassTransit;
using System.Threading.Tasks;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Masstransit.Publishers
{
    public class AccountPublisher : IPublisher<AccountTransfer>
    {
        private readonly IBusControl bus;

        public AccountPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(AccountTransfer objectFile) => await bus.Publish(objectFile);
    }
}
