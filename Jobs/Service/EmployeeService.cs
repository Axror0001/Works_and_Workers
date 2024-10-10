using Jobs.Dtos;
using Jobs.Mapping;
using Jobs.Models;
using Jobs.Repository;

namespace Jobs.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILevelRepository _levelRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, ILevelRepository levelRepository)
        {
            this._employeeRepository = employeeRepository;
            this._levelRepository = levelRepository;
        }
        public async Task<List<EmployeeDtos>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _employeeRepository.GetAllEmployee(cancellationToken);
                return result.Select(x => new EmployeeDtos()
                {
                    Id = x.Id,
                    Address = x.Address,
                    CompanyId = x.CompanyId,
                    LastName = x.LastName,
                    Level = x.Level,
                    LevelId = x.LevelId,
                    FirstName = x.FirstName,
                    Age = x.Age,
                    PhoneNumber = x.PhoneNumber,
                    IsDelete = x.IsDelete,
                    DateTime = x.DateTime,
                }).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<EmployeeDtos> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _employeeRepository.GetByIdEmployee(Id, cancellationToken);
                if (result is null)
                {
                    throw new Exception("Not Found This is Id database");
                }
                else
                {
                    var employeeDto = new EmployeeDtos()
                    {
                        Id = result.Id,
                        CompanyId = result.CompanyId,
                        LastName = result.LastName,
                        Level = result.Level,
                        LevelId = result.LevelId,
                        FirstName = result.FirstName,
                        Age = result.Age,
                        PhoneNumber = result.PhoneNumber,
                        IsDelete = result.IsDelete,
                        DateTime = result.DateTime,
                    };
                    return employeeDto;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<EmployeeDtos> CreateAsync(EmployeeDtos employeeDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _levelRepository.GetByIdLevels(employeeDtos.LevelId, cancellationToken);
                employeeDtos.Level = result.Levels;
                if(employeeDtos is not null)
                {
                    var employeeModel = employeeDtos.ModelToDto();
                    employeeModel.Id = employeeDtos.Id;
                    employeeModel.FirstName = employeeDtos.FirstName.Trim();
                    employeeModel.Address = employeeDtos.Address.Trim();
                    employeeModel.LastName = employeeDtos.LastName.Trim();
                    employeeModel.CompanyId = employeeDtos.CompanyId;
                    employeeModel.Level = employeeDtos.Level.Trim();
                    employeeModel.LevelId = employeeDtos.LevelId;
                    employeeModel.Age = employeeDtos.Age.Trim();
                    employeeModel.PhoneNumber = employeeDtos.PhoneNumber;
                    employeeModel.IsDelete = employeeDtos.IsDelete = default;
                    await _employeeRepository.CreateEmployee(employeeModel, cancellationToken);
                    return employeeDtos;
                }
                else
                {
                    throw new Exception("EmployeeDtos is null Exception");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<EmployeeDtos> UpdateAsync(EmployeeDtos employeeDtos, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _employeeRepository.GetByIdEmployee(employeeDtos.Id, cancellationToken);
                if(employeeDtos != null && result is not null)
                {
                    var employee = employeeDtos.ModelToDto();
                    employee.Id = employeeDtos.Id;
                    employee.FirstName = employeeDtos.FirstName.Trim();
                    employee.Address = employeeDtos.Address.Trim();
                    employee.LastName = employeeDtos.LastName.Trim();
                    employee.CompanyId = employeeDtos.CompanyId;
                    employee.Level = employeeDtos.Level.Trim();
                    employee.LevelId = employeeDtos.LevelId;
                    employee.Age = employeeDtos.Age.Trim();
                    employee.PhoneNumber = employeeDtos.PhoneNumber;
                    employee.IsDelete = employeeDtos.IsDelete = default;
                    await _employeeRepository.UpdateEmployee(employee, cancellationToken);
                    return employeeDtos;
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
                if(Id != null)
                {
                    await _employeeRepository.DeleteEmployee(Id, cancellationToken);
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
    }
}
