using MassTransit;
using System;
using System.Threading.Tasks;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Masstransit.Consumers
{
    public class AccountConsumerFault : IConsumer<Fault<AccountTransfer>>
    {
        public Task Consume(ConsumeContext<Fault<AccountTransfer>> context)
        {
            return Task.CompletedTask;
        }
    }
}
