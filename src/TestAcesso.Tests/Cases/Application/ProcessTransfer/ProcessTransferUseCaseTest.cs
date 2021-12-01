using FluentAssertions;
using System.Linq;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.UseCases.ProcessTransfer;
using TestAcesso.Domain.Enums;
using TestAcesso.Tests.Builders.Accounts;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Application.ProcessTransfer
{
    [UseAutofacTestFramework]
    public class ProcessTransferUseCaseTest
    {
        private readonly IProcessTransferUseCase processTransferUseCase;
        private readonly IAccountTransferRepository accountTransferRepository;

        public ProcessTransferUseCaseTest(IProcessTransferUseCase processTransferUseCase, IAccountTransferRepository accountTransferRepository)
        {
            this.processTransferUseCase = processTransferUseCase;
            this.accountTransferRepository = accountTransferRepository;
        }

        [Fact]
        public void ShouldProcessTransfer()
        {
            var accountTransfer = AccountTransferBuilder.New().WithAccountOrigin("123").WithAccountDestination("456").Build();
            var request = new ProcessUcRequest(accountTransfer);

            accountTransferRepository.Add(accountTransfer);
            processTransferUseCase.Execute(request);

            request.AccountTransfer.Should().NotBeNull();
            request.AccountTransfer.Status.Should().Be(TransactionStatus.Processing);
            request.AcOrigin.Should().NotBeNull();
            request.AcOrigin.AccountNumber.Should().Be("123");
            request.AcDest.Should().NotBeNull();
            request.AcDest.AccountNumber.Should().Be("456");
            request.Transactions.Should().NotBeNullOrEmpty().And.HaveCount(2);
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().NotContain(LogType.Error);
        }

        [Fact]
        public void DontSendTransferBecauseDontHaveBalance()
        {
            var accountTransfer = AccountTransferBuilder.New().WithAccountOrigin("123").WithAccountDestination("456").WithValue(100).Build();
            var request = new ProcessUcRequest(accountTransfer);

            accountTransferRepository.Add(accountTransfer);
            processTransferUseCase.Execute(request);

            request.AccountTransfer.Should().NotBeNull();
            request.AccountTransfer.Status.Should().Be(TransactionStatus.Error);
            request.AcOrigin.Should().NotBeNull();
            request.AcOrigin.AccountNumber.Should().Be("123");
            request.AcDest.Should().NotBeNull();
            request.AcDest.AccountNumber.Should().Be("456");
            request.Transactions.Should().BeEmpty();
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().Contain(LogType.Error);
        }
    }
}
