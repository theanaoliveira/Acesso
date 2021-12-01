using System;

namespace TestAcesso.Webapi.Controllers.SendTransfer
{
    public class SendTranferResponse
    {
        public Guid TransactionId { get; private set; }

        public SendTranferResponse(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
