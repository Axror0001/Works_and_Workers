using Jobs.Models;
using Microsoft.EntityFrameworkCore;


namespace Jobs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Job> Jobs { get; set; }
        
    }
}
