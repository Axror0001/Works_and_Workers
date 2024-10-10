using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    [Table("jobs")]
    public class Job
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? JobName {  get; set; }
        public string? Direction {  get; set; }
        public string? CompanyName {  get; set; }
        public string? CompanyBrand {  get; set; }
    }
}
