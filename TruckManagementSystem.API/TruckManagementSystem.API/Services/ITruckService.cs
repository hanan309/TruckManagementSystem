using System.Collections.Generic;
using System.Threading.Tasks;
using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Services
{
    public interface ITruckService
    {
        Task<IEnumerable<Truck>> GetAllTrucksAsync();
        Task<Truck> GetTruckByIdAsync(int id);
        Task<Truck> CreateTruckAsync(Truck truck);
        Task<Truck> UpdateTruckAsync(Truck truck);
        Task<bool> DeleteTruckAsync(int id);
    }
}