using Jobs.Models;

namespace Jobs.Repository
{
    public interface ILevelRepository
    {
        Task<IEnumerable<Level>> GetAllLevels(CancellationToken cancellationToken = default);
        Task<Level> GetByIdLevels(int Id, CancellationToken cancellationToken = default);
        Task<Level> CreateLevels(Level level, CancellationToken cancellationToken = default);
        Task<Level> UpdateLevels(Level level, CancellationToken cancellationToken = default);
        Task<bool> DeleteLevels(int Id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetAllEmployees(long Id, CancellationToken cancellationToken = default);
    }
}
