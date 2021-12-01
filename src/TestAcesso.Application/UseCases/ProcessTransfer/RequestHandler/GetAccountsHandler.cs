using TestAcesso.Application.Repositories.Services;

namespace TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler
{
    public class GetAccountsHandler : Handler<ProcessUcRequest>
    {
        private readonly IGetAccounts getAccounts;

        public GetAccountsHandler(IGetAccounts getAccounts)
        {
            this.getAccounts = getAccounts;
        }

        public override void ProcessRequest(ProcessUcRequest request)
        {
            request.AddProcessLog("Getting accounts details");
            request.AcOrigin = getAccounts.GetAccount(request.AccountTransfer.AccountOrigin);
            request.AcDest = getAccounts.GetAccount(request.AccountTransfer.AccountDestination);

            sucessor?.ProcessRequest(request);
        }
    }
}
