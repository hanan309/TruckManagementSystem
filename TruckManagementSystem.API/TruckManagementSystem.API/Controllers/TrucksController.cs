using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManagementSystem.API.DTOs;
using TruckManagementSystem.API.Services;
using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TrucksController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        // GET: api/trucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckDto>>> GetTrucks()
        {
            var trucks = await _truckService.GetAllTrucksAsync();
            var dtos = trucks.Select(t => new TruckDto
            {
                TruckId = t.TruckId,
                Color = t.Color,
                Number = t.Number,
                Size = t.Size
            });
            return Ok(dtos);
        }

        // GET: api/trucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckDto>> GetTruck(int id)
        {
            var truck = await _truckService.GetTruckByIdAsync(id);
            if (truck == null) return NotFound();

            var dto = new TruckDto
            {
                TruckId = truck.TruckId,
                Color = truck.Color,
                Number = truck.Number,
                Size = truck.Size
            };
            return Ok(dto);
        }

        // POST: api/trucks
        [HttpPost]
        public async Task<ActionResult<TruckDto>> CreateTruck([FromBody] CreateTruckDto createDto)
        {
            var truck = new Truck
            {
                Color = createDto.Color,
                Number = createDto.Number,
                Size = createDto.Size
            };
            var created = await _truckService.CreateTruckAsync(truck);

            var dto = new TruckDto
            {
                TruckId = created.TruckId,
                Color = created.Color,
                Number = created.Number,
                Size = created.Size
            };
            return CreatedAtAction(nameof(GetTruck), new { id = dto.TruckId }, dto);
        }

        // PUT: api/trucks/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TruckDto>> UpdateTruck(int id, [FromBody] UpdateTruckDto updateDto)
        {
            var existing = await _truckService.GetTruckByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Color = updateDto.Color;
            existing.Number = updateDto.Number;
            existing.Size = updateDto.Size;

            var updated = await _truckService.UpdateTruckAsync(existing);

            var dto = new TruckDto
            {
                TruckId = updated.TruckId,
                Color = updated.Color,
                Number = updated.Number,
                Size = updated.Size
            };
            return Ok(dto);
        }

        // DELETE: api/trucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck(int id)
        {
            var deleted = await _truckService.DeleteTruckAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}