using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Accounts;

namespace TestAcesso.Infrastructure.Database.Repositories
{
    public class AccountTransferRepository : IAccountTransferRepository
    {
        private readonly IMapper mapper;

        public AccountTransferRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Add(AccountTransfer accountTransfer)
        {
            using var context = new Context();

            context.AccountTransfers.Add(mapper.Map<Entities.AccountTransfer>(accountTransfer));
            context.SaveChanges();
        }

        public AccountTransfer Get(Expression<Func<AccountTransfer, bool>> expression)
        {
            using var context = new Context();
            var expr = mapper.Map<Expression<Func<Entities.AccountTransfer, bool>>>(expression);
            var accountTransfer = context.AccountTransfers.Where(expr).FirstOrDefault();

            return mapper.Map<AccountTransfer>(accountTransfer);
        }

        public void Update(AccountTransfer accountTransfer)
        {
            using var context = new Context();

            context.AccountTransfers.Update(mapper.Map<Entities.AccountTransfer>(accountTransfer));
            context.SaveChanges();
        }
    }
}
