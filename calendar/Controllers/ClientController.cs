using calendar.ModelDTO;
using calendar.Models;
using calendar.Services.ClientService;
using calendar.Services.TravailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _clientService.GetAllClients());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(string id)
        {
            var result = await _clientService.GetClientById(id);
            if (result == null)
                return NotFound("Client not Found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            var addedClient = await _clientService.AddClient(client);
            if (addedClient == null)
                return StatusCode(500);
            return Ok(addedClient);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, Client client)
        {
            var result = await _clientService.UpdateClient(id, client);
            if (result == null)
                return StatusCode(500);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            bool result = await _clientService.DeleteClient(id);
            if (!result)
                return NotFound("Client not Found");
            return Ok(result);
        }
    }
}
