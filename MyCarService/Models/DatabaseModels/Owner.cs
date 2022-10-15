using System.ComponentModel.DataAnnotations;

namespace MyCarService.Models.DatabaseModels
{
    public class Owner
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
    }
}
