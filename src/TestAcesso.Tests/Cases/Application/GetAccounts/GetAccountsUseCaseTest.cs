using FluentAssertions;
using System.Linq;
using TestAcesso.Application.UseCases.GetAccounts;
using TestAcesso.Domain.Enums;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace TestAcesso.Tests.Cases.Application.GetAccounts
{
    [UseAutofacTestFramework]
    public class GetAccountsUseCaseTest
    {
        private readonly IGetAccountsUseCase getAccountsUseCase;

        public GetAccountsUseCaseTest(IGetAccountsUseCase getAccountsUseCase)
        {
            this.getAccountsUseCase = getAccountsUseCase;
        }

        [Fact]
        public void ShouldGetAccounts()
        {
            var request = new GetAccountsUcRequest();

            getAccountsUseCase.Execute(request);

            request.Accounts.Should().NotBeNullOrEmpty();
            request.MountResponse().Should().NotBeNullOrEmpty();
            request.Logs.Should().NotBeNullOrEmpty();
            request.Logs.Select(s => s.Type).Should().NotContain(LogType.Error);
        }
    }
}
