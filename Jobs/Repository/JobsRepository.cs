using Jobs.Data;
using Jobs.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Repository
{
    public class JobsRepository : IJobRepository
    {
        private readonly AppDbContext _dbContext;
        public JobsRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Job> CreateJobs(Job jobs, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Jobs.FirstOrDefaultAsync(x => !x.IsDeleted && x.JobName.Equals(jobs.JobName)
                && x.CompanyName.Equals(jobs.CompanyName) && x.CompanyBrand.Equals(jobs.CompanyBrand) && x.Direction.Equals(jobs.Direction), cancellationToken);
                if(result is not null)
                {
                    throw new Exception("This Jobs Already Exists");
                }
                else
                {
                    jobs.IsDeleted = false;
                    await _dbContext.Jobs.AddAsync(jobs, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return jobs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> DeleteJobs(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Jobs.FirstOrDefaultAsync(x => x.Id.Equals(Id) && !x.IsDeleted, cancellationToken);    
                if(result is not null)
                {
                    result.IsDeleted = true;
                    _dbContext.Jobs.Update(result);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                else
                {
                    throw new Exception("Not Found this Jobs");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Job>> GetAllJobs(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Jobs.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
                if (result is null)
                {
                    throw new Exception($"{nameof(GetAllJobs)} Not Found");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetByEmployeeCompanyId(int CompanyId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.Where(x => !x.IsDelete && x.CompanyId.Equals(CompanyId)).ToListAsync(cancellationToken);
                if(result is null)
                {
                    throw new Exception("Not Found Employee");
                }
                else
                {
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<Job> GetByIdJobs(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Jobs.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id.Equals(Id), cancellationToken);
                if( result is null)
                {
                    throw new Exception("Not Found this Jobs");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<Job> UpdateJobs(Job jobs, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Jobs.FirstOrDefaultAsync(x => x.Id.Equals(jobs.Id) && x.IsDeleted.Equals(false), cancellationToken);
                if ( result is null)
                {
                    throw new Exception("Not Found This Job");
                }
                else
                {
                    result.JobName = jobs.JobName;
                    result.CompanyName = jobs.CompanyName;
                    result.Direction = jobs.Direction;
                    result.CompanyBrand = jobs.CompanyBrand;
                    result.IsDeleted = false;
                     _dbContext.Jobs.Update(jobs);
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
    }
}
