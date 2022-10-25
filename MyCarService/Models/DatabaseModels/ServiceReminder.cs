namespace MyCarService.Models.DatabaseModels
{
    public class ServiceReminder
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public int InKilometers { get; set; }
        public DateTime InTime { get; set; } = DateTime.Now;
        public string Message { get; set; } = string.Empty;
    }
}
