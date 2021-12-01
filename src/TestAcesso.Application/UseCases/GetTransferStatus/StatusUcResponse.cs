using System;
using System.Collections.Generic;
using System.Text;
using TestAcesso.Domain.Enums;

namespace TestAcesso.Application.UseCases.GetTransferStatus
{
    public class StatusUcResponse
    {
        public TransactionStatus Status { get; private set; }
        public string Message { get; private set; }

        public StatusUcResponse(TransactionStatus status)
        {
            Status = status;
        }

        public StatusUcResponse(TransactionStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
