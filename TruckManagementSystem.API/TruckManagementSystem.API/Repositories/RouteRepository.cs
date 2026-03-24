using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckManagementSystem.API.Data;
using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext _context;

        public RouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TruckManagementSystem.API.Models.Route>> GetAllAsync()
        {
            return await _context.Routes.ToListAsync();
        }

        public async Task<TruckManagementSystem.API.Models.Route> GetByIdAsync(int id)
        {
            return await _context.Routes.FindAsync(id);
        }

        public async Task<TruckManagementSystem.API.Models.Route> AddAsync(TruckManagementSystem.API.Models.Route route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<TruckManagementSystem.API.Models.Route> UpdateAsync(TruckManagementSystem.API.Models.Route route)
        {
            _context.Routes.Update(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) return false;

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}