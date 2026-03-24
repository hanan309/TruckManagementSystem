using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckManagementSystem.API.Models
{
    public class TruckAssignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        [ForeignKey("Truck")]
        public int TruckId { get; set; }

        public Truck Truck { get; set; }

        [Required]
        [ForeignKey("Route")]
        public int RouteId { get; set; }

        public Route Route { get; set; }

        [Required]
        public decimal RoutePrice { get; set; }

        [Required]
        public double PetrolConsumption { get; set; } // in liters/km or total for route
    }
}