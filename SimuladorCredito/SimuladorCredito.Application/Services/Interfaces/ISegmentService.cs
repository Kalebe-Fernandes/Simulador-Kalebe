using SimuladorCredito.Application.DTOs;

namespace SimuladorCredito.Application.Services.Interfaces
{
    public interface ISegmentService : IService<SegmentDTO>
    {
        Task<SegmentDTO> GetSegmentByPersonTypeAsync(int personTypeId, decimal minimumIncome);
    }
}
