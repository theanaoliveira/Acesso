using System;
using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Application.UseCases.GetTransferStatus
{
    public class StatusUcRequest : LogRequest
    {
        public Guid TransferId { get; private set; }
        public AccountTransfer AccountTransfer { get; set; }

        public StatusUcRequest(Guid transferId)
        {
            TransferId = transferId;
            Logs = new List<Log>();
        }
    }
}