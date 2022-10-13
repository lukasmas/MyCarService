using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.DatabaseModels
{
    [Table("Make")]

    public class Make
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
    }
}
