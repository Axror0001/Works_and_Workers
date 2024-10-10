using Jobs.Dtos;
using Jobs.Mapping;
using Jobs.Models;
using Jobs.Repository;

namespace Jobs.Service
{
    public class LevelService
    {
        private readonly ILevelRepository _levelRepository;
        public LevelService(ILevelRepository levelRepository)
        {
            this._levelRepository = levelRepository;
        }
        public async Task<IEnumerable<LevelsDtos>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _levelRepository.GetAllLevels(cancellationToken);
                return result.Select(x => new LevelsDtos()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Levels = x.Levels,
                    IsDeleted = x.IsDeleted,
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<LevelsDtos> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _levelRepository.GetByIdLevels(Id, cancellationToken);
                if (result is null)
                {
                    throw new Exception("Not Found This is Id database");
                }
                else
                {
                    var employeeDto = new LevelsDtos()
                    {
                        Id = result.Id,
                        Code = result.Code,
                        Levels = result.Levels,
                        IsDeleted = result.IsDeleted,
                    };
                    return employeeDto;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<LevelsDtos> CreateAsync(LevelsDtos LevelsDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                if (LevelsDtos is not null)
                {
                    var levelModel = LevelsDtos.ModelToDtos();
                    levelModel.Code = LevelsDtos.Code.Trim();
                    levelModel.Levels = LevelsDtos.Levels.Trim();
                    levelModel.IsDeleted = false;
                    await _levelRepository.CreateLevels(levelModel, cancellationToken);
                    return LevelsDtos;
                }
                else
                {
                    throw new Exception("LevelsDtos is null Exception");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<LevelsDtos> UpdateAsync(LevelsDtos LevelsDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _levelRepository.GetByIdLevels(LevelsDtos.Id, cancellationToken);
                if (result != null && LevelsDtos != null)
                {
                    var level = LevelsDtos.ModelToDtos();
                    level.Levels = LevelsDtos.Levels.Trim();
                    level.IsDeleted = LevelsDtos.IsDeleted;
                    level.Code = LevelsDtos.Code.Trim();
                    level.IsDeleted = LevelsDtos.IsDeleted = default;
                    await _levelRepository.UpdateLevels(level, cancellationToken);
                    return LevelsDtos;
                }
                else
                {
                    throw new Exception("Not found this Employee");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _levelRepository.GetByIdLevels(Id, cancellationToken);
                if (Id != null && result != null)
                {
                    await _levelRepository.DeleteLevels(Id, cancellationToken);
                    return true;
                }
                else
                {
                    throw new Exception($"Not Found {Id} Database ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeeByLevelId(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _levelRepository.GetByIdLevels(Id, cancellationToken);
                if (Id != null && result != null)
                {
                    var employee = await _levelRepository.GetAllEmployees(Id, cancellationToken);
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        throw new Exception("Not Found Employee this Company");
                    }
                }
                else
                {
                    throw new Exception("Not Found Job Database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
