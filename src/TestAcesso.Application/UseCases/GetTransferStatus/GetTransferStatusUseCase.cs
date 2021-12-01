using System;
using System.Collections.Generic;
using System.Text;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Application.UseCases.GetTransferStatus
{
    public class GetTransferStatusUseCase : IGetTransferStatusUseCase
    {
        private readonly IAccountTransferRepository accountTransferRepository;
        private readonly ILogRepository logRepository;
        private readonly IOutputPort<StatusUcResponse> outputPort;

        public GetTransferStatusUseCase(IAccountTransferRepository accountTransferRepository, ILogRepository logRepository, IOutputPort<StatusUcResponse> outputPort)
        {
            this.accountTransferRepository = accountTransferRepository;
            this.logRepository = logRepository;
            this.outputPort = outputPort;
        }

        public void Execute(StatusUcRequest request)
        {
            try
            {
                request.AddProcessLog($"Getting transfer: {request.TransferId} status");
                request.AccountTransfer = accountTransferRepository.Get(w => w.Id.Equals(request.TransferId));

                if (request.AccountTransfer is null)
                    outputPort.NotFound($"Dont found any transactions with this id: {request.TransferId}");
                else
                {
                    var response = request.AccountTransfer.Status switch
                    {
                        TransactionStatus.Error => new StatusUcResponse(request.AccountTransfer.Status, request.AccountTransfer.Message),
                        _ => new StatusUcResponse(request.AccountTransfer.Status)
                    };

                    outputPort.Standard(response);
                }
            }
            catch (Exception ex)
            {
                var message = $"Occurring an erro to get transfer status. Error: {ex.InnerException?.Message ?? ex.Message}, stacktrace: {ex.StackTrace}";

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
