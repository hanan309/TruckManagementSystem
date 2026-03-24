using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Repositories;

namespace TruckManagementSystem.API.Services
{
    public class TruckAssignmentService : ITruckAssignmentService
    {
        private readonly ITruckAssignmentRepository _assignmentRepository;

        public TruckAssignmentService(ITruckAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<TruckAssignment>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<TruckAssignment> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<TruckAssignment> CreateAssignmentAsync(TruckAssignment assignment)
        {
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<TruckAssignment> UpdateAssignmentAsync(TruckAssignment assignment)
        {
            return await _assignmentRepository.UpdateAsync(assignment);
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            return await _assignmentRepository.DeleteAsync(id);
        }
    }
}