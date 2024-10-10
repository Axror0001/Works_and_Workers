using Jobs.Dtos;
using Jobs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly LevelService _levelService;
        public LevelController(LevelService levelService)
        {
            _levelService = levelService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLevel(CancellationToken cancellationToken = default)
        {
            var result = await _levelService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdLevel([FromRoute]int Id, CancellationToken cancellationToken = default)
        {
            var result = await _levelService.GetByIdAsync(Id, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{levelId}")]
        public async Task<IActionResult> GetAllEmployeeByLevelId([FromRoute]int Id, CancellationToken cancellationToken = default)
        {
            var result = await _levelService.GetAllEmployeeByLevelId(Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLevel([FromBody]LevelsDtos levelsDtos, CancellationToken cancellationToken = default)
        {
            var result = await _levelService.CreateAsync(levelsDtos, cancellationToken);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLevel([FromBody]LevelsDtos levelsDtos, CancellationToken cancellationToken = default)
        {
            var result = await _levelService.UpdateAsync(levelsDtos, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteLevel([FromRoute] int Id, CancellationToken cancellationToken = default)
        {
            var result = await _levelService.DeleteAsync(Id, cancellationToken);
            return Ok(result);
        }
    }
}
