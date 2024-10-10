using Jobs.Data;
using Jobs.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.FirstOrDefaultAsync(x => x.FirstName.Equals(employee.FirstName)
                && x.LastName.Equals(employee.LastName) && !x.IsDelete && x.Age.Equals(employee.Age) && x.Address.Equals(employee.Address), cancellationToken);
                if(result is not null)
                {
                    throw new Exception("This Employee already Exist Database");
                }
                else
                {
                    await _dbContext.Employees.AddAsync(employee, cancellationToken);
                    await _dbContext.SaveChangesAsync();
                    return employee;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"EmployeeRepository : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEmployee(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.FirstOrDefaultAsync(x => !x.IsDelete && x.Id.Equals(Id), cancellationToken);
                if(result is not null)
                {
                    result.IsDelete = true;
                     _dbContext.Update(result);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                else
                {
                    throw new ArgumentNullException(nameof(result) + "Not Found Employee");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.Where(x => x.IsDelete.Equals(false)).ToListAsync(cancellationToken);
                if (result is not null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Employee List null Empty Employee Database");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /*public async Task<Job> GetByEmployeeIdCompany(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Jobs.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.IsDeleted, cancellationToken);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public Task<Level> GetByEmployeeIdLevel(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }*/

        public async Task<Employee> GetByIdEmployee(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsDelete.Equals(false), cancellationToken);
                if (result is not null)
                {
                    return result;
                }
                else
                {
                    return result ?? throw new ArgumentNullException(nameof(result) + "Not Found Employee");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.Employees.FirstOrDefaultAsync(x => x.IsDelete.Equals(false) && x.Id.Equals(employee.Id), cancellationToken);
                if(result is not null)
                {

                    result.Address = employee.Address;
                    result.FirstName = employee.FirstName;
                    result.LastName = employee.LastName;
                    result.Age = employee.Age;
                    result.Level = employee.Level;
                    result.CompanyId = employee.CompanyId;
                    result.LevelId = employee.LevelId;
                    result.PhoneNumber = employee.PhoneNumber;
                    result.DateTime = employee.DateTime;
                    result.IsDelete = employee.IsDelete = false;
                    _dbContext.Update(result);
                    await _dbContext.SaveChangesAsync();
                    return result;
                    
                }
                else
                {
                    throw new ArgumentNullException(nameof(result) + "Not Found Employee");
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
