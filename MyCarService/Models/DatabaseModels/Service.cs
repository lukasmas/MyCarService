namespace MyCarService.Models.DatabaseModels
{
    public class Service
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public int Mileage { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? InvoiceScan { get; set; }
        public DateTime ServiceDate { get; set; } = DateTime.Now;
    }
}
