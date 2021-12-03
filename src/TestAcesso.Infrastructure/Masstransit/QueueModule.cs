using Autofac;
using MassTransit;
using System;
using System.Collections.Generic;
using TestAcesso.Infrastructure.Masstransit.Consumers;
using GreenPipes;

namespace TestAcesso.Infrastructure.Masstransit
{
    public class QueueModule : Module
    {
        private List<Type> Consumers { get; set; }

        public QueueModule()
        {
            Consumers = new List<Type>();
        }

        public QueueModule(Action<List<Type>> config)
        {
            Consumers = new List<Type>();
            config(Consumers);
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace != null && type.Namespace.Contains("Masstransit"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.AddMassTransit(cfg =>
            {
                Consumers.ForEach(consumer => cfg.AddConsumer(consumer));
                cfg.AddBus(BusFactory);
            });
        }

        private IBusControl BusFactory(IComponentContext context)
        {
            var rabbitHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
            var rabbitPath = Environment.GetEnvironmentVariable("RABBITMQ_PATH");
            var rabbitUser = Environment.GetEnvironmentVariable("RABBITMQ_USER");
            var rabbitPass = Environment.GetEnvironmentVariable("RABBITMQ_PASS");
            var limitRetry = int.Parse(Environment.GetEnvironmentVariable("RETRY") ?? "1");

            if (Environment.GetEnvironmentVariable("CONN") != null)
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(rabbitHost, rabbitPath, h =>
                    {
                        h.Username(rabbitUser);
                        h.Password(rabbitPass);
                    });

                    cfg.UseMessageRetry(r =>
                    {
                        r.Handle<ApplicationException>();
                        r.Interval(limitRetry, TimeSpan.FromSeconds(30));
                    });

                    cfg.AutoDelete = false;
                    cfg.Durable = true;
                    cfg.Exclusive = false;

                    cfg.ConfigureEndpoints(context);
                });
            }
            else
                return Bus.Factory.CreateUsingInMemory(cfg => cfg.ConfigureEndpoints(context));
        }
    }
}
