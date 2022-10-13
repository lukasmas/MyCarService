using System;

namespace MyCarService.Models.DatabaseModels
{
    public class Service
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int Millage { get; set; }
        public string? ServiceType { get; set; }
        public string? Description { get; set; }
        public string? InvoiceScan { get; set; }
        public DateTime? ServiceDate { get; set; }


    }
}
