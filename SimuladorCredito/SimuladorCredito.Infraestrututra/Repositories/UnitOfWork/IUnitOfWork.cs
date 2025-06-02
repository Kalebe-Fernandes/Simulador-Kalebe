using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPersonTypeRepository PersonTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        IRateRepository RateRepository { get; }
        IModalityRepository ModalityRepository { get; }
        ISegmentRepository SegmentRepository { get; }

        Task<int> Commit();
        void Dispose();
    }
}
