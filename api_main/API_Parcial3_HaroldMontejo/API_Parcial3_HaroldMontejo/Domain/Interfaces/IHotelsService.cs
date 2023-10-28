using API_Parcial3_HaroldMontejo.DAL.Entities;

namespace API_Parcial3_HaroldMontejo.Domain.Interfaces
{
    public interface IHotelsService
    {

        Task<IEnumerable<Hotels>> GetHotelsAsync();
        Task<Hotels> CreateHotelsAsync(Hotels hotels);
    }
}
