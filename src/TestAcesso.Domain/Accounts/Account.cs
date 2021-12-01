namespace TestAcesso.Domain.Accounts
{
    public class Account
    {
        public int Id { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public Account(int id, string accountNumber, decimal balance)
        {
            Id = id;
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
