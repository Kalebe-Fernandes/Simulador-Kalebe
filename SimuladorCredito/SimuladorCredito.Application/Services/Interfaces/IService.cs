namespace SimuladorCredito.Application.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        string Ping();

    }
}
