using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAcesso.Application.UseCases.GetAccounts;

namespace TestAcesso.Webapi.Controllers.GetAccounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IGetAccountsUseCase getAccountsUseCase;
        private readonly AccountsPresenter presenter;

        public AccountsController(IGetAccountsUseCase getAccountsUseCase, AccountsPresenter presenter)
        {
            this.getAccountsUseCase = getAccountsUseCase;
            this.presenter = presenter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(AccountsResponse), 200)]
        [Route("/list-accounts")]
        public IActionResult GetAccounts()
        {
            getAccountsUseCase.Execute(new GetAccountsUcRequest());

            return presenter.Result;
        }
    }
}
