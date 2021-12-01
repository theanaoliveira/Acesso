using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Application.UseCases.GetAccounts
{

    public class GetAccountsUcRequest : LogRequest
    {
        public List<Account> Accounts { get; set; }

        public GetAccountsUcRequest()
        {
            Accounts = new List<Account>();
            Logs = new List<Log>();
        }

        public List<GetAccountsUcResponse> MountResponse()
        {
            var response = new List<GetAccountsUcResponse>();

            Accounts.ForEach(f => response.Add(new GetAccountsUcResponse(f.AccountNumber, f.Balance)));

            return response;
        }
    }
}