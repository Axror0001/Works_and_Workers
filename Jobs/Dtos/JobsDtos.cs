using Jobs.Models;

namespace Jobs.Dtos
{
    public class JobsDtos
    {
        public int Id { get; set; } 
        public bool IsDeleted { get; set; }
        public string JobName { get; set; }
        public string Direction { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBrand { get; set; }
    }
}
