using BookMasterDataManagement.Model;
using BookMasterDataManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookMasterDataManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientRepository.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            await _clientRepository.AddAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client client)
        {
            if (id != client.Id) return BadRequest();
            await _clientRepository.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
