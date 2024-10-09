using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    [Table("levels")]
    public class Level
    {
        [Required]
        public int Id {  get; set; }
        public int EmployeeId {  get; set; }
        public List<Employee> Employees { get; set; }
        public string Code {  get; set; }
        public string Levels {  get; set; }
    }
}
