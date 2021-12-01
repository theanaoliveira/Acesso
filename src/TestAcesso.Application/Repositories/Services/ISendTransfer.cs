using TestAcesso.Domain.Accounts;

namespace TestAcesso.Application.Repositories.Services
{
    public interface ISendTransfer
    {
        public bool SendTransfer(Transaction transaction);
    }
}
