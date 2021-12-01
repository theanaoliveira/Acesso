using System;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.UseCases.ProcessTransfer.RequestHandler;

namespace TestAcesso.Application.UseCases.ProcessTransfer
{
    public class ProcessTransferUseCase : IProcessTransferUseCase
    {
        private readonly UpdateTransferStatusHandler updateTransferStatusHandler;
        private readonly ILogRepository logRepository;

        public ProcessTransferUseCase(UpdateTransferStatusHandler updateTransferStatusHandler,
            GetAccountsHandler getAccountsHandler,
            ValidateBalanceHandler validateBalanceHandler,
            CreateTransactionHandler createTransactionHandler,
            SaveTransactionsHandler saveTransactionsHandler,
            SendTransferHandler sendTransferHandler,
            ILogRepository logRepository)
        {
            updateTransferStatusHandler.SetSucessor(getAccountsHandler);
            getAccountsHandler.SetSucessor(validateBalanceHandler);
            validateBalanceHandler.SetSucessor(createTransactionHandler);
            createTransactionHandler.SetSucessor(saveTransactionsHandler);
            saveTransactionsHandler.SetSucessor(sendTransferHandler);

            this.updateTransferStatusHandler = updateTransferStatusHandler;
            this.logRepository = logRepository;
        }

        public void Execute(ProcessUcRequest request)
        {
            try
            {
                updateTransferStatusHandler.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                request.AddErrorLog($"Occurring an error to send transfer. Error: {ex.InnerException?.Message ?? ex.Message}, stacktrace: {ex.StackTrace}");
            }
            finally
            {
                logRepository.Add(request.Logs);
            }

        }
    }
}
