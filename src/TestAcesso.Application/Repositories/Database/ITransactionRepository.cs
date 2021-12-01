using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.Repositories.Database
{
    public interface ITransactionRepository
    {
        void Add(List<Transaction> transactions);
        void Update(Transaction transaction);
        Transaction Get(Expression<Func<Transaction, bool>> expression);
    }
}
