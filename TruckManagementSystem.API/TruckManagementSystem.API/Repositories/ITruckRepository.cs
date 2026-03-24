using System.Collections.Generic;
using System.Threading.Tasks;
using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetAllAsync();
        Task<Truck> GetByIdAsync(int id);
        Task<Truck> AddAsync(Truck truck);
        Task<Truck> UpdateAsync(Truck truck);
        Task<bool> DeleteAsync(int id);
    }
}