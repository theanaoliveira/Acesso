using System;
using System.Linq.Expressions;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.Repositories.Database
{
    public interface IAccountTransferRepository
    {
        void Add(AccountTransfer accountTransfer);
        void Update(AccountTransfer accountTransfer);
        AccountTransfer Get(Expression<Func<AccountTransfer, bool>> expression);
    }
}
