using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Services
{
    public interface ITruckAssignmentService
    {
        Task<IEnumerable<TruckAssignment>> GetAllAssignmentsAsync();
        Task<TruckAssignment> GetAssignmentByIdAsync(int id);
        Task<TruckAssignment> CreateAssignmentAsync(TruckAssignment assignment);
        Task<TruckAssignment> UpdateAssignmentAsync(TruckAssignment assignment);
        Task<bool> DeleteAssignmentAsync(int id);
    }
}