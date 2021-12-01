using System;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.UseCases.SendTransfer.RequestHandlers;

namespace TestAcesso.Application.UseCases.SendTransfer
{
    public class TransferUseCase : ITransferUseCase
    {
        private readonly CreateDomainsHandler createDomainsHandler;
        private readonly IOutputPort<TransferUcResponse> outputPort;
        private readonly ILogRepository logRepository;

        public TransferUseCase(CreateDomainsHandler createDomainsHandler, 
            SaveAccountHandler saveAccountHandler, 
            InsertQueueHandler insertQueueHandler, 
            IOutputPort<TransferUcResponse> outputPort, 
            ILogRepository logRepository)
        {
            createDomainsHandler.SetSucessor(saveAccountHandler);
            saveAccountHandler.SetSucessor(insertQueueHandler);

            this.createDomainsHandler = createDomainsHandler;
            this.outputPort = outputPort;
            this.logRepository = logRepository;
        }

        public void Execute(TransferUcRequest request)
        {
            try
            {
                createDomainsHandler.ProcessRequest(request);

                if (request.HasError)
                    outputPort.Error(request.ErrorMessage);
                else
                    outputPort.Standard(new TransferUcResponse(request.AccountTransfer.Id));
            }
            catch (Exception ex)
            {
                var message = $"Occurring an erro to send transfer. Error: {ex.InnerException?.Message ?? ex.Message}, stacktrace: {ex.StackTrace}";

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
