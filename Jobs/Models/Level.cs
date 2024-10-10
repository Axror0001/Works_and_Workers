using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    [Table("levels")]
    public class Level
    {
        [Required]
        [Key]
        public int Id {  get; set; }
        public string Code {  get; set; }
        public string? Levels {  get; set; }
        public bool IsDeleted { get; set; }
    }
}
