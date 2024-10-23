using BookMasterDataManagement.Model;
using BookMasterDataManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookMasterDataManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
            await _accountRepository.AddAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Account account)
        {
            if (id != account.Id) return BadRequest();
            await _accountRepository.UpdateAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
