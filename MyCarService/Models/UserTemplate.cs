using System.ComponentModel.DataAnnotations;

namespace MyCarService.Models
{
    public class UserTemplate
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
