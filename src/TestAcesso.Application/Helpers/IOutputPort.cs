namespace TestAcesso.Application.Helpers
{
    public interface IOutputPort<T>
    {
        void Standard(T result);
        void Error(string message);
        void NotFound(string message);
    }
}
