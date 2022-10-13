using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.DatabaseModels
{
    [Table("Model")]
    public class Model
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("MakeId")]
        public int MakeId { get; set; }
    }
}
