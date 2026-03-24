using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Repositories
{
    public interface ITruckAssignmentRepository
    {
        Task<IEnumerable<TruckAssignment>> GetAllAsync();
        Task<TruckAssignment> GetByIdAsync(int id);
        Task<TruckAssignment> AddAsync(TruckAssignment assignment);
        Task<TruckAssignment> UpdateAsync(TruckAssignment assignment);
        Task<bool> DeleteAsync(int id);
    }
}