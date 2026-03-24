namespace TruckManagementSystem.API.DTOs
{
    public class TruckDto
    {
        public int TruckId { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public int Size { get; set; }
    }

    public class CreateTruckDto
    {
        public string Color { get; set; }
        public string Number { get; set; }
        public int Size { get; set; }
    }

    public class UpdateTruckDto
    {
        public string Color { get; set; }
        public string Number { get; set; }
        public int Size { get; set; }
    }
}