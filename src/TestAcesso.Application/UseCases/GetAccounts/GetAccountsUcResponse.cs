using System;
using System.Collections.Generic;
using System.Text;

namespace TestAcesso.Application.UseCases.GetAccounts
{
    public class GetAccountsUcResponse
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public GetAccountsUcResponse(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
