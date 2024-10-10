using Jobs.Dtos;
using Jobs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee(CancellationToken cancellationToken = default)
        {
            var result = await _employeeService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdEmployee([FromRoute]int Id, CancellationToken cancellationToken = default)
        {
            var result = await _employeeService.GetByIdAsync(Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeDtos employeeDtos, CancellationToken cancellationToken = default)
        {
            var result = await _employeeService.CreateAsync(employeeDtos, cancellationToken);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody]EmployeeDtos employeeDtos, CancellationToken cancellationToken = default)
        {
            var result = await _employeeService.UpdateAsync(employeeDtos, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int Id, CancellationToken cancellationToken = default)
        {
            var result = await _employeeService.DeleteAsync(Id, cancellationToken);
            return Ok(result);
        }
    }
}
