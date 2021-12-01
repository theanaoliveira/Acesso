using System;

namespace TestAcesso.Application.UseCases.SendTransfer
{
    public class TransferUcResponse
    {
        public Guid TransferId { get; private set; }

        public TransferUcResponse(Guid transferId)
        {
            TransferId = transferId;
        }
    }
}
