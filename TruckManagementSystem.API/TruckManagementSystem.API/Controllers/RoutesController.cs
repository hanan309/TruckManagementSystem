using Microsoft.AspNetCore.Mvc;
using TruckManagementSystem.API.DTOs;
using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        // GET: api/routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteDto>>> GetRoutes()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            var routeDtos = routes.Select(r => new RouteDto
            {
                RouteId = r.RouteId,
                FromCity = r.FromCity,
                ToCity = r.ToCity,
                DistanceKm = r.DistanceKm
            });
            return Ok(routeDtos);
        }

        // GET: api/routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDto>> GetRoute(int id)
        {
            var route = await _routeService.GetRouteByIdAsync(id);
            if (route == null) return NotFound();

            var dto = new RouteDto
            {
                RouteId = route.RouteId,
                FromCity = route.FromCity,
                ToCity = route.ToCity,
                DistanceKm = route.DistanceKm
            };
            return Ok(dto);
        }

        // POST: api/routes
        [HttpPost]
        public async Task<ActionResult<RouteDto>> CreateRoute([FromBody] CreateRouteDto createDto)
        {
            var route = new TruckManagementSystem.API.Models.Route
            {
                FromCity = createDto.FromCity,
                ToCity = createDto.ToCity,
                DistanceKm = createDto.DistanceKm
            };
            var created = await _routeService.CreateRouteAsync(route);

            var dto = new RouteDto
            {
                RouteId = created.RouteId,
                FromCity = created.FromCity,
                ToCity = created.ToCity,
                DistanceKm = created.DistanceKm
            };
            return CreatedAtAction(nameof(GetRoute), new { id = dto.RouteId }, dto);
        }

        // PUT: api/routes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RouteDto>> UpdateRoute(int id, [FromBody] UpdateRouteDto updateDto)
        {
            var existing = await _routeService.GetRouteByIdAsync(id);
            if (existing == null) return NotFound();

            existing.FromCity = updateDto.FromCity;
            existing.ToCity = updateDto.ToCity;
            existing.DistanceKm = updateDto.DistanceKm;

            var updated = await _routeService.UpdateRouteAsync(existing);

            var dto = new RouteDto
            {
                RouteId = updated.RouteId,
                FromCity = updated.FromCity,
                ToCity = updated.ToCity,
                DistanceKm = updated.DistanceKm
            };
            return Ok(dto);
        }

        // DELETE: api/routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var deleted = await _routeService.DeleteRouteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}