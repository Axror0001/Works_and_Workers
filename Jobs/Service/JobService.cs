using Jobs.Dtos;
using Jobs.Mapping;
using Jobs.Models;
using Jobs.Repository;

namespace Jobs.Service
{
    public class JobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            this._jobRepository = jobRepository;
        }
        public async Task<IEnumerable<JobsDtos>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _jobRepository.GetAllJobs(cancellationToken);
                return result.Select(x => new JobsDtos()
                {
                    EmployeeId = x.EmployeeId,
                    CompanyBrand = x.CompanyBrand,
                    CompanyName = x.CompanyName,
                    Direction = x.Direction,
                    JobName = x.JobName,
                    IsDeleted = x.IsDeleted,
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<JobsDtos> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _jobRepository.GetByIdJobs(Id, cancellationToken);
                if (result is null)
                {
                    throw new Exception("Not Found This is Id database");
                }
                else
                {
                    var employeeDto = new JobsDtos()
                    {
                        EmployeeId = result.EmployeeId,
                        CompanyName = result.CompanyName,
                        CompanyBrand = result.CompanyBrand,
                        Direction = result.Direction,
                        JobName = result.JobName,
                        IsDeleted = result.IsDeleted
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
        public async Task<JobsDtos> CreateAsync(JobsDtos JobsDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _jobRepository.GetByIdJobs(JobsDtos.Id, cancellationToken);
                if (JobsDtos is not null && result is not null)
                {
                    var jobModel = JobsDtos.ModelToDtos();
                    jobModel.JobName = JobsDtos.JobName.Trim();
                    jobModel.CompanyBrand = JobsDtos.CompanyBrand.Trim();
                    jobModel.Direction = JobsDtos.Direction.Trim();
                    jobModel.CompanyName = JobsDtos.CompanyName.Trim();
                    jobModel.IsDeleted = JobsDtos.IsDeleted;
                    jobModel.EmployeeId = JobsDtos.EmployeeId;
                    await _jobRepository.CreateJobs(jobModel, cancellationToken);
                    return JobsDtos;
                }
                else
                {
                    throw new Exception("JobsDtos is null Exception");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<JobsDtos> UpdateAsync(JobsDtos JobsDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _jobRepository.GetByIdJobs(JobsDtos.Id, cancellationToken);
                if (result != null && JobsDtos != null)
                {
                    result.JobName = JobsDtos.JobName.Trim();
                    result.CompanyBrand = JobsDtos.CompanyBrand.Trim();
                    result.Direction = JobsDtos.Direction.Trim();
                    result.CompanyName = JobsDtos.CompanyName.Trim();
                    result.IsDeleted = JobsDtos.IsDeleted;
                    result.EmployeeId = JobsDtos.EmployeeId;
                    return JobsDtos;
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
        public async Task<bool> DeleteAsync(JobsDtos JobsDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _jobRepository.GetByIdJobs(JobsDtos.Id, cancellationToken);
                if (JobsDtos != null && result != null)
                {
                    await _jobRepository.DeleteJobs(result.Id, cancellationToken);
                    return true;
                }
                else
                {
                    throw new Exception($"Not Found {JobsDtos.Id} Database ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeeByConpanyId(JobsDtos jobsDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _jobRepository.GetByIdJobs(jobsDtos.Id, cancellationToken);
                if(jobsDtos != null && result != null)
                {
                   var employee = await _jobRepository.GetByEmployeeCompanyId(jobsDtos.Id, cancellationToken);
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
