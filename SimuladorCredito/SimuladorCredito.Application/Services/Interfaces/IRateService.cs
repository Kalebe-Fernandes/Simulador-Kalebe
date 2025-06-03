using SimuladorCredito.Application.DTOs;

namespace SimuladorCredito.Application.Services.Interfaces
{
    public interface IRateService : IService<RateDTO>
    {
        Task<RateDTO> GetRateByAsync(string personTypeName, string modalityName, string productName, string segmentName);
    }
}
