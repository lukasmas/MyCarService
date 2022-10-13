namespace MyCarService.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string? ServicType { get; set; }
        public string? Description { get; set; }
        public float ServiceCost { get; set; }

    }
}
