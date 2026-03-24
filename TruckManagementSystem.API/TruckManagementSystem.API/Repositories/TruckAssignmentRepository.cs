using Microsoft.EntityFrameworkCore;
using TruckManagementSystem.API.Data;
using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Repositories;

namespace TruckManagementSystem.API.Repositories
{
    public class TruckAssignmentRepository : ITruckAssignmentRepository
    {
        private readonly AppDbContext _context;

        public TruckAssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TruckAssignment>> GetAllAsync()
        {
            return await _context.TruckAssignments
                .Include(ta => ta.Truck)
                .Include(ta => ta.Route)
                .ToListAsync();
        }

        public async Task<TruckAssignment> GetByIdAsync(int id)
        {
            return await _context.TruckAssignments
                .Include(ta => ta.Truck)
                .Include(ta => ta.Route)
                .FirstOrDefaultAsync(ta => ta.AssignmentId == id);
        }

        public async Task<TruckAssignment> AddAsync(TruckAssignment assignment)
        {
            _context.TruckAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<TruckAssignment> UpdateAsync(TruckAssignment assignment)
        {
            _context.TruckAssignments.Update(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var assignment = await _context.TruckAssignments.FindAsync(id);
            if (assignment == null) return false;

            _context.TruckAssignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}