using TestAcesso.Domain.Accounts;

namespace TestAcesso.Tests.Builders.Accounts
{
    public class AccountBuilder
    {
        public int Id;
        public string AccountNumber;
        public decimal Balance;

        public static AccountBuilder New()
        {
            return new AccountBuilder()
            {
                Id = 1,
                AccountNumber = "123",
                Balance = 50.00m
            };
        }

        public AccountBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public AccountBuilder WithAccountNumber(string accountNumber)
        {
            AccountNumber = accountNumber;
            return this;
        }

        public AccountBuilder WithBalance(decimal balance)
        {
            Balance = balance;
            return this;
        }

        public Account Build() => new Account(Id, AccountNumber, Balance);
    }
}
