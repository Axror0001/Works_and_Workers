using Jobs.Data;
using Jobs.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Repository
{
    public class LevelRepository : ILevelRepository
    {
        private readonly AppDbContext _dbContext;
        public LevelRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Level> CreateLevels(Level level, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Levels.FirstOrDefaultAsync(x => !x.IsDeleted && x.Code.Equals(level.Code) && x.Levels.Equals(level.Levels));
                if(result is not null)
                {
                    throw new Exception("This Levels Already Database");
                }
                else
                {
                    level.IsDeleted = false;
                    await _dbContext.Levels.AddAsync(level, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> DeleteLevels(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Levels.FirstOrDefaultAsync(x => x.Id.Equals(Id) && !x.IsDeleted, cancellationToken);
                if(result is null)
                {
                    result.IsDeleted = true;
                     _dbContext.Levels.Update(result);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                else
                {
                    throw new Exception("Not Found This Level");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(long Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.Where(x => !x.IsDelete && x.LevelId.Equals(Id)).ToListAsync(cancellationToken);
                if (result is not null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Not Found");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Level>> GetAllLevels(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Levels.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
                if (result is not null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Not Found");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<Level> GetByIdLevels(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Levels.FirstOrDefaultAsync(x => x.Id.Equals(Id) && !x.IsDeleted, cancellationToken);
                if(result is not null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Not Found This Level Database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<Level> UpdateLevels(Level level, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Levels.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(level.Id), cancellationToken);
                if( result is not null)
                {
                    result.Code = level.Code;
                    result.Levels = level.Levels;
                    _dbContext.Levels.Update(result);
                    await _dbContext.SaveChangesAsync();
                    return result;
                }
                else
                {
                    throw new Exception("Not Found This Levels");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
