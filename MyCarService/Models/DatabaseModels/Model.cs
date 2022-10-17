using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.DatabaseModels
{
    [Table("Model")]
    public class Model
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [ForeignKey("MakeId")]
        public int MakeId { get; set; }
    }
}
