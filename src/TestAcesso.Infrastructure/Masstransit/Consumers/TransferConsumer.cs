using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Application.UseCases.ProcessTransfer;
using TestAcesso.Domain.Enums;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Infrastructure.Masstransit.Consumers
{
    public class TransferConsumer : IConsumer<TransferRequest>
    {
        private readonly ISendTransfer sendTransfer;
        private readonly IAccountTransferRepository accountTransferRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly ILogRepository logRepository;

        public TransferConsumer(ISendTransfer sendTransfer, IAccountTransferRepository accountTransferRepository, ITransactionRepository transactionRepository, ILogRepository logRepository)
        {
            this.sendTransfer = sendTransfer;
            this.accountTransferRepository = accountTransferRepository;
            this.transactionRepository = transactionRepository;
            this.logRepository = logRepository;
        }

        public async Task Consume(ConsumeContext<TransferRequest> context)
        {
            await Task.Run(() =>
            {
                var logs = new List<Log>();
                var transfer = context.Message;

                logs.Add(Log.AddLog($"Starting transfer process", LogType.Process, DateTime.UtcNow));

                transfer.Transactions.ForEach(f =>
                {
                    var transaction = transactionRepository.Get(w => w.Id.Equals(f.Id));

                    if (!transaction.HasExecute)
                    {
                        logs.Add(Log.AddLog($"Send transfer: Account {f.AccountNumber}, type: {f.Type}, value: {f.Value}", LogType.Process, DateTime.UtcNow));

                        sendTransfer.SendTransfer(f);
                        f.UpdateExecute();

                        transactionRepository.Update(f);
                    }
                });

                transfer.AccountTransfer.SetStatus(TransactionStatus.Confirmed);

                logs.Add(Log.AddLog($"Update transfer status to confirm transaction", LogType.Process, DateTime.UtcNow));

                accountTransferRepository.Update(transfer.AccountTransfer);
                logRepository.Add(logs);
            });
        }
    }
}
