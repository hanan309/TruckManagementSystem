namespace TruckManagementSystem.API.DTOs
{
    public class TruckAssignmentDto
    {
        public int AssignmentId { get; set; }
        public int TruckId { get; set; }
        public string TruckNumber { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; } // e.g., "Islamabad to Karachi"
        public decimal RoutePrice { get; set; }
        public double PetrolConsumption { get; set; }
    }

    public class CreateTruckAssignmentDto
    {
        public int TruckId { get; set; }
        public int RouteId { get; set; }
        public decimal RoutePrice { get; set; }
        public double PetrolConsumption { get; set; }
    }

    public class UpdateTruckAssignmentDto
    {
        public int TruckId { get; set; }
        public int RouteId { get; set; }
        public decimal RoutePrice { get; set; }
        public double PetrolConsumption { get; set; }
    }
}