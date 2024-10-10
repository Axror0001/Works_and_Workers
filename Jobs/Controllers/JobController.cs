using Jobs.Dtos;
using Jobs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;
        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJob(CancellationToken cancellationToken = default)
        {
            var result = await _jobService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdJob([FromRoute] int Id, CancellationToken cancellationToken = default)
        {
            var result = await _jobService.GetByIdAsync(Id, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{jobId}")]
        public async Task<IActionResult> GetAllEmployeeByCompanyId([FromRoute] int Id, CancellationToken cancellationToken = default)
        {
            var result = await _jobService.GetAllEmployeeByConpanyId(Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody]JobsDtos jobsDtos, CancellationToken cancelToken = default)
        {
            var result = await _jobService.CreateAsync(jobsDtos, cancelToken);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateJob([FromBody]JobsDtos jobsDtos, CancellationToken cancellationToken = default)
        {
            var result = await _jobService.UpdateAsync(jobsDtos, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int Id, CancellationToken cancellationToken = default)
        {
            var result = await _jobService.DeleteAsync(Id, cancellationToken);
            return Ok(result);
        }
    }
}
