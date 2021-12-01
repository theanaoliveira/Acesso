namespace TestAcesso.Webapi.Controllers.GetAccounts
{
    public class AccountsResponse
    {
        public string AccountNumber { get; }
        public decimal Balance { get; }

        public AccountsResponse(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}