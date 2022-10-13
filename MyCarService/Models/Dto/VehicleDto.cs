namespace MyCarService.Models.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string? Vin { get; set; }

        public int OwnerId { get; set; }
        public string? Plates { get; set; }

        public uint ProductionYear { get; set; }

        public string? Make { get; set; }
        public string? Model { get; set; }
    }
}
