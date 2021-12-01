using TestAcesso.Domain.Enums;

namespace TestAcesso.Webapi.Controllers.GetTransferStatus
{
    public class StatusResponse
    {
        public TransactionStatus Status { get; private set; }
        public string Message { get; private set; }

        public StatusResponse(TransactionStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
