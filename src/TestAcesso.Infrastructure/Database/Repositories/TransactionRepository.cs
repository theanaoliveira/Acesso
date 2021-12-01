using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMapper mapper;

        public TransactionRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Add(List<Transaction> transactions)
        {
            using var context = new Context();

            context.Transactions.AddRange(mapper.Map<List<Entities.Transaction>>(transactions));
            context.SaveChanges();
        }

        public Transaction Get(Expression<Func<Transaction, bool>> expression)
        {
            using var context = new Context();
            var expr = mapper.Map<Expression<Func<Entities.Transaction, bool>>>(expression);
            var transaction = context.Transactions.Where(expr).FirstOrDefault();

            return mapper.Map<Transaction>(transaction);
        }

        public void Update(Transaction transaction)
        {
            using var context = new Context();

            context.Update(mapper.Map<Entities.Transaction>(transaction));
            context.SaveChanges();
        }
    }
}
