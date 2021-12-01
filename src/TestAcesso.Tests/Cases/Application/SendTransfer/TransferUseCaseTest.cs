using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.UseCases.SendTransfer;
using TestAcesso.Domain.Enums;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Application.SendTransfer
{
    [UseAutofacTestFramework]
    public class TransferUseCaseTest
    {
        private readonly ITransferUseCase transferUseCase;
        private readonly IAccountTransferRepository accountTransferRepository;

        public TransferUseCaseTest(ITransferUseCase transferUseCase, IAccountTransferRepository accountTransferRepository)
        {
            this.transferUseCase = transferUseCase;
            this.accountTransferRepository = accountTransferRepository;
        }

        [Fact]
        public void ShouldSendTransfer()
        {
            var request = new TransferUcRequest("123", "456", 100);

            transferUseCase.Execute(request);

            var savedAccount = accountTransferRepository.Get(w => w.Id.Equals(request.AccountTransfer.Id));

            savedAccount.Should().NotBeNull();
            request.AccountOrigin.Should().Be("123");
            request.AccountDest.Should().Be("456");
            request.Value.Should().Be(100);
            request.AccountTransfer.Should().NotBeNull();
            request.AccountTransfer.Valid.Should().BeTrue();
            request.HasError.Should().BeFalse();
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().NotContain(LogType.Error);
        }

        [Fact]
        public void ShouldDontSendTransfer()
        {
            var request = new TransferUcRequest("", "456", 100);

            transferUseCase.Execute(request);

            request.AccountOrigin.Should().Be("");
            request.AccountDest.Should().Be("456");
            request.Value.Should().Be(100);
            request.AccountTransfer.Should().NotBeNull();
            request.AccountTransfer.Valid.Should().BeFalse();
            request.HasError.Should().BeTrue();
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().Contain(LogType.Error);
        }
    }
}
