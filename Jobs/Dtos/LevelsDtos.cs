using Jobs.Models;

namespace Jobs.Dtos
{
    public class LevelsDtos
    {
        public int Id {  get; set; }
        public int? EmployeeId { get; set; }
        public List<Employee>? Employees { get; set; }
        public string Code { get; set; }
        public string Levels { get; set; }
        public bool IsDeleted { get; set; }
    }
}
