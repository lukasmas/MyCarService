using System.ComponentModel.DataAnnotations;

namespace MyCarService.Models.Auth
{
    public class UserAuth
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
