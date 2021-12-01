using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Application.UseCases.GetAccounts;

namespace TestAcesso.Webapi.Controllers.GetAccounts
{
    public class AccountsPresenter : IOutputPort<List<GetAccountsUcResponse>>
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

        public void Standard(List<GetAccountsUcResponse> result)
        {
            var response = new List<AccountsResponse>();

            result.ForEach(f => response.Add(new AccountsResponse(f.AccountNumber, f.Balance)));

            Result = new OkObjectResult(response);
        }
    }
}
