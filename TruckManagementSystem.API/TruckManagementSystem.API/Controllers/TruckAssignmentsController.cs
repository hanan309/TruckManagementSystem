using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManagementSystem.API.DTOs;
using TruckManagementSystem.API.Models;
using TruckManagementSystem.API.Services;

namespace TruckManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TruckAssignmentsController : ControllerBase
    {
        private readonly ITruckAssignmentService _assignmentService;

        public TruckAssignmentsController(ITruckAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        // GET: api/truckassignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckAssignmentDto>>> GetAssignments()
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();
            var dtos = assignments.Select(a => new TruckAssignmentDto
            {
                AssignmentId = a.AssignmentId,
                TruckId = a.TruckId,
                TruckNumber = a.Truck.Number,
                RouteId = a.RouteId,
                RouteName = $"{a.Route.FromCity} to {a.Route.ToCity}",
                RoutePrice = a.RoutePrice,
                PetrolConsumption = a.PetrolConsumption
            });
            return Ok(dtos);
        }

        // GET: api/truckassignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckAssignmentDto>> GetAssignment(int id)
        {
            var a = await _assignmentService.GetAssignmentByIdAsync(id);
            if (a == null) return NotFound();

            var dto = new TruckAssignmentDto
            {
                AssignmentId = a.AssignmentId,
                TruckId = a.TruckId,
                TruckNumber = a.Truck.Number,
                RouteId = a.RouteId,
                RouteName = $"{a.Route.FromCity} to {a.Route.ToCity}",
                RoutePrice = a.RoutePrice,
                PetrolConsumption = a.PetrolConsumption
            };
            return Ok(dto);
        }

        // POST: api/truckassignments
        [HttpPost]
        public async Task<ActionResult<TruckAssignmentDto>> CreateAssignment([FromBody] CreateTruckAssignmentDto createDto)
        {
            var assignment = new TruckAssignment
            {
                TruckId = createDto.TruckId,
                RouteId = createDto.RouteId,
                RoutePrice = createDto.RoutePrice,
                PetrolConsumption = createDto.PetrolConsumption
            };
            var created = await _assignmentService.CreateAssignmentAsync(assignment);

            var dto = new TruckAssignmentDto
            {
                AssignmentId = created.AssignmentId,
                TruckId = created.TruckId,
                TruckNumber = created.Truck?.Number,
                RouteId = created.RouteId,
                RouteName = $"{created.Route?.FromCity} to {created.Route?.ToCity}",
                RoutePrice = created.RoutePrice,
                PetrolConsumption = created.PetrolConsumption
            };
            return CreatedAtAction(nameof(GetAssignment), new { id = dto.AssignmentId }, dto);
        }

        // PUT: api/truckassignments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TruckAssignmentDto>> UpdateAssignment(int id, [FromBody] UpdateTruckAssignmentDto updateDto)
        {
            var existing = await _assignmentService.GetAssignmentByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TruckId = updateDto.TruckId;
            existing.RouteId = updateDto.RouteId;
            existing.RoutePrice = updateDto.RoutePrice;
            existing.PetrolConsumption = updateDto.PetrolConsumption;

            var updated = await _assignmentService.UpdateAssignmentAsync(existing);

            var dto = new TruckAssignmentDto
            {
                AssignmentId = updated.AssignmentId,
                TruckId = updated.TruckId,
                TruckNumber = updated.Truck?.Number,
                RouteId = updated.RouteId,
                RouteName = $"{updated.Route?.FromCity} to {updated.Route?.ToCity}",
                RoutePrice = updated.RoutePrice,
                PetrolConsumption = updated.PetrolConsumption
            };
            return Ok(dto);
        }

        // DELETE: api/truckassignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var deleted = await _assignmentService.DeleteAssignmentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}