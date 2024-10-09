using Jobs.Models;

namespace Jobs.Repository
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllJobs(CancellationToken cancellationToken = default);
        Task<Job> GetByIdJobs(int Id, CancellationToken cancellationToken = default);
        Task<Job> CreateJobs(Job jobs, CancellationToken cancellationToken = default);
        Task<Job> UpdateJobs(Job jobs, CancellationToken cancellationToken = default);
        Task<bool> DeleteJobs(int Id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetByEmployeeCompanyId(int CompanyId,  CancellationToken cancellationToken = default);
    }
}
