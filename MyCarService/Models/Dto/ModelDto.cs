using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.Dto
{
    [Table("Model")]
    public class ModelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("MakeId")]
        public int MakeId { get; set; }
    }
}
