using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.DatabaseModels
{
    [Table("Vehicle")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ModelId { get; set; }
        public int ProductionYear { get; set; }
        public string? VIN { get; set; }
        public string? Plate { get; set; }
        public uint CurrentMillage { get; set; }
    }
}
