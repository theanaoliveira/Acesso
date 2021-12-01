using Moq;
using System.Collections.Generic;
using TestAcesso.Application.Repositories.Services;
using TestAcesso.Domain.Accounts;
using TestAcesso.Tests.Builders.Accounts;

namespace TestAcesso.Tests.Mock
{
    public class Accounts
    {
        public Mock<IGetAccounts> GetAccountsMock()
        {
            var moq = new Mock<IGetAccounts>();

            moq.Setup(s => s.GetAccounts())
                .Returns(new List<Account>
                {
                    AccountBuilder.New().Build(),
                    AccountBuilder.New().Build(),
                    AccountBuilder.New().Build(),
                    AccountBuilder.New().Build(),
                });

            moq.Setup(s => s.GetAccount(It.IsAny<string>()))
                .Returns<string>(account => AccountBuilder.New().WithAccountNumber(account).Build());

            return moq;
        }

        public Mock<ISendTransfer> SendTransferMock()
        {
            var moq = new Mock<ISendTransfer>();

            moq.Setup(s => s.SendTransfer(It.IsAny<Transaction>())).Returns(true);

            return moq;
        }
    }
}
