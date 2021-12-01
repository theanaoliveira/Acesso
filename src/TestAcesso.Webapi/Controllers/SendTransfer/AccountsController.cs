using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAcesso.Application.UseCases.SendTransfer;

namespace TestAcesso.Webapi.Controllers.SendTransfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITransferUseCase transferUseCase;
        private readonly SendTransferPresenter presenter;

        public AccountsController(ITransferUseCase transferUseCase, SendTransferPresenter presenter)
        {
            this.transferUseCase = transferUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(SendTranferResponse), 202)]
        [Route("/fund-transfer")]
        public IActionResult SendTransfer([FromBody] SendTranferRequest input)
        {
            transferUseCase.Execute(new TransferUcRequest(input.AccountOrigin, input.AccountDestination, input.Balance));

            return presenter.Result;
        }
    }
}
