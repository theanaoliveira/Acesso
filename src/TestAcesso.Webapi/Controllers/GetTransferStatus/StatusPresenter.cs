using Microsoft.AspNetCore.Mvc;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.UseCases.GetTransferStatus;

namespace TestAcesso.Webapi.Controllers.GetTransferStatus
{
    public class StatusPresenter : IOutputPort<StatusUcResponse>
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

        public void Standard(StatusUcResponse result)
            => Result = new OkObjectResult(new StatusResponse(result.Status, result.Message));
    }
}
