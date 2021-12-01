using AutoMapper;
using RestSharp;
using System;
using System.Collections.Generic;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Services.Calls
{
    public class GetAccounts : ExecuteServices, IGetAccounts
    {
        private readonly IMapper mapper;

        public GetAccounts(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Account GetAccount(string accountNumber)
        {
            var url = Environment.GetEnvironmentVariable("ACCOUNT_URL_BASE");
            var request = new RestRequest($"/api/Account/{accountNumber}", Method.GET);

            request.AddParameter("accountNumber", accountNumber, ParameterType.QueryString);

            var response = Execute<Entities.Account>(url, request);

            return mapper.Map<Account>(response);
        }

        List<Account> IGetAccounts.GetAccounts()
        {
            var url = Environment.GetEnvironmentVariable("ACCOUNT_URL_BASE");
            var request = new RestRequest("/api/Account", Method.GET);
            var response = Execute<List<Entities.Account>>(url, request);

            return mapper.Map<List<Account>>(response);
        }
    }
}
