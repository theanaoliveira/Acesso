using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Domain.Accounts;
using TestAcesso.Tests.Builders.Accounts;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Infrastructure.Database
{
    [UseAutofacTestFramework]
    public class TransactionRepositoryTest
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionRepositoryTest(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        [Fact]
        public void ShouldAddTransaction()
        {
            var transaction = TransactionBuilder.New().Build();

            Action act = () => transactionRepository.Add(new List<Transaction> { transaction });

            act.Should().NotThrow();

            var savedTransaction = transactionRepository.Get(w => w.AccountNumber.Equals(transaction.AccountNumber));

            savedTransaction.AccountNumber.Should().Be(transaction.AccountNumber);
        }

        [Fact]
        public void ShouldUpdateTransfer()
        {
            var transaction = TransactionBuilder.New().Build();

            transactionRepository.Add(new List<Transaction> { transaction });

            transaction.UpdateExecute();

            Action act = () => transactionRepository.Update(transaction);

            act.Should().NotThrow();

            var savedTransaction = transactionRepository.Get(w => w.Id.Equals(transaction.Id));

            savedTransaction.HasExecute.Should().BeTrue();
        }

        [Fact]
        public void ShouldGetByExpression()
        {
            var transaction = TransactionBuilder.New().Build();

            transactionRepository.Add(new List<Transaction> { transaction });

            var getById = transactionRepository.Get(w => w.Id.Equals(transaction.Id));
            var getByAccount = transactionRepository.Get(w => w.AccountNumber.Equals(transaction.AccountNumber));

            getById.Should().NotBeNull();
            getByAccount.Should().NotBeNull();
        }
    }
}
