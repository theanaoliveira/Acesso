using System;
using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.Repositories.Services;

namespace TestAcesso.Application.UseCases.GetAccounts
{
    public class GetAccountsUseCase : IGetAccountsUseCase
    {
        private readonly IGetAccounts getAccounts;
        private readonly IOutputPort<List<GetAccountsUcResponse>> outputPort;
        private readonly ILogRepository logRepository;

        public GetAccountsUseCase(IGetAccounts getAccounts, IOutputPort<List<GetAccountsUcResponse>> outputPort, ILogRepository logRepository)
        {
            this.getAccounts = getAccounts;
            this.outputPort = outputPort;
            this.logRepository = logRepository;
        }

        public void Execute(GetAccountsUcRequest request)
        {
            try
            {
                request.AddProcessLog($"Getting all users accounts");
                request.Accounts = getAccounts.GetAccounts();
                request.AddProcessLog($"Found: {request.Accounts.Count} number of counts");

                outputPort.Standard(request.MountResponse());
            }
            catch (Exception ex)
            {
                var message = $"Occurring an erro to list users accounts. Error: {ex.InnerException?.Message ?? ex.Message}, stacktrace: {ex.StackTrace}";

                request.AddErrorLog(message);
                outputPort.Error(message);
            }
            finally
            {
                logRepository.Add(request.Logs);
            }
        }
    }
}
