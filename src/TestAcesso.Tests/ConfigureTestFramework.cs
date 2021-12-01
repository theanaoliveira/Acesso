using Autofac;
using TestAcesso.Infrastructure.Modules;
using TestAcesso.Webapi.Modules;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

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
        }
    }
}
