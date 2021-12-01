using FluentAssertions;
using System;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Enums;
using TestAcesso.Tests.Builders.Accounts;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Infrastructure.Database
{
    [UseAutofacTestFramework]
    public class AccountTransferRepositoryTest
    {
        private readonly IAccountTransferRepository accountTransferRepository;

        public AccountTransferRepositoryTest(IAccountTransferRepository accountTransferRepository)
        {
            this.accountTransferRepository = accountTransferRepository;
        }

        [Fact]
        public void ShouldAddTransfer()
        {
            var accountTransfer = AccountTransferBuilder.New().Build();

            Action act = () => accountTransferRepository.Add(accountTransfer);

            act.Should().NotThrow();

            var savedAccount = accountTransferRepository.Get(w => w.AccountOrigin.Equals(accountTransfer.AccountOrigin));

            savedAccount.AccountOrigin.Should().Be(accountTransfer.AccountOrigin);
        }

        [Fact]
        public void ShouldUpdateTransfer()
        {
            var accountTransfer = AccountTransferBuilder.New().Build();

            accountTransferRepository.Add(accountTransfer);

            accountTransfer.SetStatus(TransactionStatus.Confirmed);

            Action act = () => accountTransferRepository.Update(accountTransfer);

            act.Should().NotThrow();

            var savedAccount = accountTransferRepository.Get(w => w.Id.Equals(accountTransfer.Id));

            savedAccount.Status.Should().Be(TransactionStatus.Confirmed);
        }

        [Fact]
        public void ShouldGetByExpression()
        {
            var accountTransfer = AccountTransferBuilder.New().Build();

            accountTransferRepository.Add(accountTransfer);

            var getById = accountTransferRepository.Get(w => w.Id.Equals(accountTransfer.Id));
            var getByOrigin = accountTransferRepository.Get(w => w.AccountOrigin.Equals(accountTransfer.AccountOrigin));
            var getByDest = accountTransferRepository.Get(w => w.AccountDestination.Equals(accountTransfer.AccountDestination));

            getById.Should().NotBeNull();
            getByOrigin.Should().NotBeNull();
            getByDest.Should().NotBeNull();
        }
    }
}
