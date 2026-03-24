using System.Collections.Generic;
using System.Threading.Tasks;

namespace TruckManagementSystem.API.Services
{
    public interface IRouteService
    {
        Task<IEnumerable<TruckManagementSystem.API.Models.Route>> GetAllRoutesAsync();
        Task<TruckManagementSystem.API.Models.Route> GetRouteByIdAsync(int id);
        Task<TruckManagementSystem.API.Models.Route> CreateRouteAsync(TruckManagementSystem.API.Models.Route route);
        Task<TruckManagementSystem.API.Models.Route> UpdateRouteAsync(TruckManagementSystem.API.Models.Route route);
        Task<bool> DeleteRouteAsync(int id);
    }
}