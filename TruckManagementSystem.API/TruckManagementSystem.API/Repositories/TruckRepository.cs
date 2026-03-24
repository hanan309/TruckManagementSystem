using Microsoft.EntityFrameworkCore;
using TruckManagementSystem.API.Data;
using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Repositories;

namespace TruckManagementSystem.API.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly AppDbContext _context;

        public TruckRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Truck>> GetAllAsync()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<Truck> GetByIdAsync(int id)
        {
            return await _context.Trucks.FindAsync(id);
        }

        public async Task<Truck> AddAsync(Truck truck)
        {
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();
            return truck;
        }

        public async Task<Truck> UpdateAsync(Truck truck)
        {
            _context.Trucks.Update(truck);
            await _context.SaveChangesAsync();
            return truck;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null) return false;

            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}