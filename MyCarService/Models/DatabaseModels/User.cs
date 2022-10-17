using System.ComponentModel.DataAnnotations;

namespace MyCarService.Models.DatabaseModels
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Salt { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public long? OwnerId { get; set; }

    }
}
