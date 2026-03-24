using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Repositories;

namespace TruckManagementSystem.API.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<TruckManagementSystem.API.Models.Route>> GetAllRoutesAsync()
        {
            return await _routeRepository.GetAllAsync();
        }

        public async Task<TruckManagementSystem.API.Models.Route> GetRouteByIdAsync(int id)
        {
            return await _routeRepository.GetByIdAsync(id);
        }

        public async Task<TruckManagementSystem.API.Models.Route> CreateRouteAsync(TruckManagementSystem.API.Models.Route route)
        {
            return await _routeRepository.AddAsync(route);
        }

        public async Task<TruckManagementSystem.API.Models.Route> UpdateRouteAsync(TruckManagementSystem.API.Models.Route route)
        {
            return await _routeRepository.UpdateAsync(route);
        }

        public async Task<bool> DeleteRouteAsync(int id)
        {
            return await _routeRepository.DeleteAsync(id);
        }
    }
}