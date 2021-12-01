using Microsoft.AspNetCore.Mvc;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.UseCases.SendTransfer;

namespace TestAcesso.Webapi.Controllers.SendTransfer
{
    public class SendTransferPresenter : IOutputPort<TransferUcResponse>
    {
        public IActionResult Result { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = message
            };

            Result = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "NotFound",
                Detail = message
            };

            Result = new NotFoundObjectResult(problemDetails);
        }

        public void Standard(TransferUcResponse result)
            => Result = new OkObjectResult(new SendTranferResponse(result.TransferId));
    }
}
