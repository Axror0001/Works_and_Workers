using Jobs.Models;

namespace Jobs.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployee(CancellationToken cancellationToken = default);
        Task<Employee> GetByIdEmployee(int id, CancellationToken cancellationToken = default);
        Task<Employee> CreateEmployee(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> UpdateEmployee(Employee employee, CancellationToken cancellationToken = default);
        Task<bool> DeleteEmployee(int Id, CancellationToken cancellationToken = default);
    }
}
