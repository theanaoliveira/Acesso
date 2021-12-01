using Autofac;
using MassTransit;
using TestAcesso.Infrastructure.Masstransit;
using TestAcesso.Infrastructure.Masstransit.Consumers;
using TestAcesso.Infrastructure.Modules;
using TestAcesso.Webapi.Modules;

namespace TestAcesso.Webapi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebapiModule>();

            builder.RegisterModule(new QueueModule(cfg =>
            {
                cfg.Add(typeof(AccountConsumer));
                cfg.Add(typeof(AccountConsumerFault));
                cfg.Add(typeof(TransferConsumer));
            }));

            return builder;
        }
    }
}
