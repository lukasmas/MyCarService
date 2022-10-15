using System.ComponentModel.DataAnnotations;

namespace MyCarService.Models.DatabaseModels
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Salt { get; set; }
        [Required]
        public string? Email { get; set; }
        public int? OwnerId { get; set; }

    }
}
