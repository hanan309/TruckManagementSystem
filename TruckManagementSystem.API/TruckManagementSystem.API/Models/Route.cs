using System.ComponentModel.DataAnnotations;

namespace TruckManagementSystem.API.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FromCity { get; set; }

        [Required]
        [MaxLength(100)]
        public string ToCity { get; set; }

        [Required]
        public double DistanceKm { get; set; }

        // Navigation property
        public ICollection<TruckAssignment> TruckAssignments { get; set; }
    }
}