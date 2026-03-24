namespace TruckManagementSystem.API.DTOs
{
    // For returning route info
    public class RouteDto
    {
        public int RouteId { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public double DistanceKm { get; set; }
    }

    // For creating a new route
    public class CreateRouteDto
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public double DistanceKm { get; set; }
    }

    // For updating an existing route
    public class UpdateRouteDto
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public double DistanceKm { get; set; }
    }
}