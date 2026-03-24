using System.ComponentModel.DataAnnotations;

namespace TruckManagementSystem.API.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        public int Size { get; set; } // e.g., number of tires

        // Navigation property
        public ICollection<TruckAssignment> TruckAssignments { get; set; }
    }
}