using System.Collections.Generic;
using TestAcesso.Application.Helpers;
using TestAcesso.Domain.Accounts;
using TestAcesso.Domain.Logs;

namespace TestAcesso.Application.UseCases.SendTransfer
{
    public class TransferUcRequest : LogRequest
    {
        public string AccountOrigin { get; }
        public string AccountDest { get; }
        public decimal Value { get; }
        public AccountTransfer AccountTransfer { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }

        public TransferUcRequest(string accountOrigin, string accountDest, decimal value)
        {
            AccountOrigin = accountOrigin;
            AccountDest = accountDest;
            Value = value;
            Logs = new List<Log>();
        }
    }
}