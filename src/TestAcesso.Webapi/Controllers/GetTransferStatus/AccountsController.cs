using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestAcesso.Application.UseCases.GetTransferStatus;

namespace TestAcesso.Webapi.Controllers.GetTransferStatus
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IGetTransferStatusUseCase getTransferStatusUseCase;
        private readonly StatusPresenter presenter;

        public AccountsController(IGetTransferStatusUseCase getTransferStatusUseCase, StatusPresenter presenter)
        {
            this.getTransferStatusUseCase = getTransferStatusUseCase;
            this.presenter = presenter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(StatusResponse), 200)]
        [Route("/fund-transfer/{transactionId}")]
        public IActionResult GetTransferStatus(Guid transactionId)
        {
            getTransferStatusUseCase.Execute(new StatusUcRequest(transactionId));

            return presenter.Result;
        }
    }
}
