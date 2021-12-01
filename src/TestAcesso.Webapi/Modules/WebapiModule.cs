using Autofac;
using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.UseCases.GetAccounts;
using TestAcesso.Application.UseCases.GetTransferStatus;
using TestAcesso.Application.UseCases.SendTransfer;
using TestAcesso.Webapi.Controllers.GetAccounts;
using TestAcesso.Webapi.Controllers.GetTransferStatus;
using TestAcesso.Webapi.Controllers.SendTransfer;

namespace TestAcesso.Webapi.Modules
{
    public class WebapiModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(w => w.Namespace.Contains("Controllers"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();

            builder.RegisterType<AccountsPresenter>().As<IOutputPort<List<GetAccountsUcResponse>>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();

            builder.RegisterType<SendTransferPresenter>().As<IOutputPort<TransferUcResponse>>()
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope()
               .AsSelf();

            builder.RegisterType<StatusPresenter>().As<IOutputPort<StatusUcResponse>>()
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope()
              .AsSelf();
        }
    }
}
