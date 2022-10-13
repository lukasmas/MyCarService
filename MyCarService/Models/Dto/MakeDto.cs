using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.Dto
{
    [Table("Make")]

    public class MakeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
    }
}
