using Autofac;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Infrastructure.Masstransit;
using TestAcesso.Infrastructure.Modules;
using TestAcesso.Tests.Mock;
using TestAcesso.Webapi.Modules;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestCollectionOrderer("TestAcesso.Tests.TestCaseOrdering", "TestAcesso.Tests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("TestAcesso.Tests.ConfigureTestFramework", "TestAcesso.Tests")]
namespace TestAcesso.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {

        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebapiModule>();
            builder.RegisterModule<QueueModule>();

            builder.RegisterInstance(new Accounts().GetAccountsMock().Object).As<IGetAccounts>();
            builder.RegisterInstance(new Accounts().SendTransferMock().Object).As<ISendTransfer>();
        }
    }
}
