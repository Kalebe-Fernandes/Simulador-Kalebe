namespace SimuladorCredito.Infraestrututra.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
