using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Repositories;

namespace TruckManagementSystem.API.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<IEnumerable<Truck>> GetAllTrucksAsync()
        {
            return await _truckRepository.GetAllAsync();
        }

        public async Task<Truck> GetTruckByIdAsync(int id)
        {
            return await _truckRepository.GetByIdAsync(id);
        }

        public async Task<Truck> CreateTruckAsync(Truck truck)
        {
            return await _truckRepository.AddAsync(truck);
        }

        public async Task<Truck> UpdateTruckAsync(Truck truck)
        {
            return await _truckRepository.UpdateAsync(truck);
        }

        public async Task<bool> DeleteTruckAsync(int id)
        {
            return await _truckRepository.DeleteAsync(id);
        }
    }
}