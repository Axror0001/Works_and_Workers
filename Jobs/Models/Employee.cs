using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    [Table("employees")]
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public int? LevelId {  get; set; }
        public int? CompanyId {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Address {  get; set; }
        public string Level {  get; set; }
        [MaxLength(9)]
        public int PhoneNumber {  get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateTime { get; set; }
        public Job? Jobs { get; set; }
        public Level? Levels { get; set; }
    }
}
