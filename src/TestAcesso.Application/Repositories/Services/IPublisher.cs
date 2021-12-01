using System.Threading.Tasks;

namespace TestAcesso.Application.Repositories.Services
{
    public interface IPublisher<T>
    {
        Task PublishAsync(T objectFile);
    }
}
