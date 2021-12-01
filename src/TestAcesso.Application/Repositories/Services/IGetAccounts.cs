using System.Collections.Generic;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.Repositories.Services
{
    public interface IGetAccounts
    {
        List<Account> GetAccounts();
        Account GetAccount(string accountNumber);
    }
}
