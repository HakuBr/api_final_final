using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await _accountService.GetAllAsync();

            return Ok(accounts);
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _accountService.GetByIdAsync(id);

            if (account == null)
            {
                return NotFound(new
                {
                    message = "Conta não encontrada"
                });
            }

            return Ok(account);
        }

        // POST: api/Account
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            try
            {
                var createdAccount = await _accountService.CreateAsync(account);

                return CreatedAtAction(
                    nameof(GetAccount),
                    new { id = createdAccount.account_id },
                    createdAccount
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            var updated = await _accountService.UpdateAsync(id, account);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Conta não encontrada"
                });
            }

            return Ok(new
            {
                message = "Conta atualizada com sucesso"
            });
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var deleted = await _accountService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Conta não encontrada"
                });
            }

            return Ok(new
            {
                message = "Conta removida com sucesso"
            });
        }
    }
}