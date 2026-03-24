using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Repositories
{
    public interface IRouteRepository
    {
        Task<IEnumerable<TruckManagementSystem.API.Models.Route>> GetAllAsync();
        Task<TruckManagementSystem.API.Models.Route> GetByIdAsync(int id);
        Task<TruckManagementSystem.API.Models.Route> AddAsync(TruckManagementSystem.API.Models.Route route);
        Task<TruckManagementSystem.API.Models.Route> UpdateAsync(TruckManagementSystem.API.Models.Route route);
        Task<bool> DeleteAsync(int id);
    }
}