using FluentAssertions;
using System;
using System.Linq;
using TestAcesso.Application.Repositories.Database;
using TestAcesso.Application.UseCases.GetTransferStatus;
using TestAcesso.Domain.Enums;
using TestAcesso.Tests.Builders.Accounts;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Application.GetTransferStatus
{
    [UseAutofacTestFramework]
    public class GetTransferStatusUseCaseTest
    {
        private readonly IGetTransferStatusUseCase getTransferStatusUseCase;
        private readonly IAccountTransferRepository accountTransferRepository;

        public GetTransferStatusUseCaseTest(IGetTransferStatusUseCase getTransferStatusUseCase, IAccountTransferRepository accountTransferRepository)
        {
            this.getTransferStatusUseCase = getTransferStatusUseCase;
            this.accountTransferRepository = accountTransferRepository;
        }

        [Fact]
        public void ShouldNotFoundTransfer()
        {
            var request = new StatusUcRequest(Guid.NewGuid());

            getTransferStatusUseCase.Execute(request);

            request.AccountTransfer.Should().BeNull();
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().NotContain(LogType.Error);
        }

        [Fact]
        public void ShouldGetTransferStatus()
        {
            var accountTransfer = AccountTransferBuilder.New().Build();

            accountTransferRepository.Add(accountTransfer);

            var request = new StatusUcRequest(accountTransfer.Id);

            getTransferStatusUseCase.Execute(request);

            request.AccountTransfer.Should().NotBeNull();
            request.AccountTransfer.Status.Should().Be(accountTransfer.Status);
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().NotContain(LogType.Error);
        }
    }
}
