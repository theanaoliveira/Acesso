using RestSharp;
using System;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Services.Calls
{
    public class SendTransfer : ExecuteServices, ISendTransfer
    {
        bool ISendTransfer.SendTransfer(Transaction transaction)
        {
            var url = Environment.GetEnvironmentVariable("ACCOUNT_URL_BASE");
            var request = new RestRequest("/api/Account", Method.POST);

            request.AddParameter("", "{\n \"accountNumber\": \"" + transaction.AccountNumber + "\", \n\"value\": \"" + transaction.Value + "\", \n\"type\":\"" + transaction.Type + "\"\n}", ParameterType.RequestBody);

            Execute(url, request);

            return true;
        }
    }
}
