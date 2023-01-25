using calendar.Models;
using calendar.Services.ClientMissionService;
using calendar.Services.ClientService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionsController : ControllerBase
    {
        private readonly IClientMissionService _clientMissionService;
        public ClientMissionsController(IClientMissionService clientMissionService)
        {
            _clientMissionService = clientMissionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRelations()
        {
            return Ok(await _clientMissionService.GetAllRelations());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMissionsByClientId(string id)
        {
            var result = await _clientMissionService.GetMissionsByClientId(id);
            if (result == null)
                return NotFound("Relation not Found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelation(ClientMission relation)
        {
            var addedClient = await _clientMissionService.AddRelation(relation);
            if (addedClient == null)
                return StatusCode(500);
            return Ok(addedClient);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(ClientMission relation)
        {
            bool result = await _clientMissionService.DeleteRelation(relation);
            if (!result)
                return NotFound("Relation not Found");
            return Ok(result);
        }
    }
}
