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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Jobs)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.CompanyId);


            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Levels)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.LevelId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
