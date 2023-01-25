using calendar.Models;
using calendar.Services.MissionService;
using Microsoft.AspNetCore.Mvc;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;
        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMissions()
        {
            return Ok(await _missionService.GetAllMissions());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMissionById(string id)
        {
            var result = await _missionService.GeMissionById(id);
            if (result == null)
                return NotFound("Mission not Found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMission(Mission mission)
        {
            var addedMission = await _missionService.AddMission(mission);
            if (addedMission == null)
                return StatusCode(500);
            return Ok(addedMission);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMission(string id, Mission mission)
        {
            var result = await _missionService.UpdateMission(id, mission);
            if (result == null)
                return StatusCode(500);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(string id)
        {
            bool result = await _missionService.DeleteMission(id);
            if (!result)
                return NotFound("Mission not Found");
            return Ok(result);
        }
    }
}
