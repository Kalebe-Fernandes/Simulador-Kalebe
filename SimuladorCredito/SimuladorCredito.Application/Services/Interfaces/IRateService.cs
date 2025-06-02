using SimuladorCredito.Application.DTOs;

namespace SimuladorCredito.Application.Services.Interfaces
{
    public interface IRateService : IService<RateDTO>
    {
        Task<RateDTO> GetRateByAsync(int personTypeId, int modalityId, int productId, int segmentId);
    }
}
