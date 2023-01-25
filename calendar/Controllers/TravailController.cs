using calendar.ModelDTO;
using calendar.Services.TravailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravailController : ControllerBase
    {
        private readonly ITravailService _travailService;
        public TravailController(ITravailService travailService)
        {
            _travailService = travailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTravails()
        {
            return Ok(await _travailService.GetAllTravails());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravailById(string id)
        {
            var result = await _travailService.GetTravailById(id);
            if (result == null)
                return NotFound("Travail not Found");
            return Ok(TravailDTO.ToTravailDTO(result));
        }

        [HttpPost]
        public async Task<IActionResult> AddTravail(TravailDTO travail)
        {
            var addedTravail = await _travailService.AddTravail(travail);
            if (addedTravail == null)
                return StatusCode(500);
            return Ok(TravailDTO.ToTravailDTO(addedTravail));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, TravailDTO travail)
        {
            var result = await _travailService.UpdateTravail(id, travail);
            if (result == null)
                return StatusCode(500);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravail(string id)
        {
            bool result = await _travailService.DeleteTravail(id);
            if (!result)
                return NotFound("travail not Found");
            return Ok(result);
        }
    }
}
